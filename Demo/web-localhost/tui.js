#!/usr/bin/env node
/* eslint-disable no-console */
const fs = require('fs');
const path = require('path');
const os = require('os');
const net = require('net');
const readline = require('readline');
const { spawn } = require('child_process');

const ROOT_DIR = __dirname;
const BRIDGE_OUT_DIR = path.resolve(ROOT_DIR, 'server', 'bridge-out');
const SDK_DIR = path.resolve(ROOT_DIR, '..', '..', 'SDK', 'Java-linux');
const SDK_JAR_UHF = path.join(SDK_DIR, 'CReader_Uhf.jar');
const SDK_JAR_LEGACY = path.join(SDK_DIR, 'CReader.jar');
const SDK_JAR = fs.existsSync(SDK_JAR_UHF) ? SDK_JAR_UHF : SDK_JAR_LEGACY;

const DEFAULT_TCP_PORTS = [27011, 2022];
const DEFAULT_SERIAL_INTERVAL_MS = 1000;
const DEFAULT_TCP_SCAN_INTERVAL_MS = 15000;
const DEFAULT_STATUS_INTERVAL_MS = 1500;
const DEFAULT_HEARTBEAT_MS = 10000;
const DEFAULT_READER_PING_MS = 12000;

function sleep(ms) {
  return new Promise((resolve) => setTimeout(resolve, Math.max(0, Number(ms) || 0)));
}

function nowIso() {
  return new Date().toISOString();
}

function normalizeBaseUrl(raw) {
  const s = String(raw || '').trim();
  if (!s) return '';
  return s.endsWith('/') ? s.slice(0, -1) : s;
}

function envStr(name, fallback = '') {
  const v = process.env[name];
  return v == null ? fallback : String(v);
}

function envInt(name, fallback) {
  const raw = envStr(name, '').trim();
  if (!raw) return fallback;
  const n = Number(raw);
  return Number.isFinite(n) ? Math.trunc(n) : fallback;
}

function envBool(name, fallback = false) {
  const raw = envStr(name, '').trim().toLowerCase();
  if (!raw) return Boolean(fallback);
  if (['1', 'true', 'yes', 'y', 'on', 'enable', 'enabled'].includes(raw)) return true;
  if (['0', 'false', 'no', 'n', 'off', 'disable', 'disabled'].includes(raw)) return false;
  return Boolean(fallback);
}

function normalizeHttpUrl(raw) {
  let s = String(raw ?? '').trim();
  if (!s) return '';
  if (!/^https?:\/\//i.test(s)) s = `http://${s}`;
  return normalizeBaseUrl(s);
}

function maskToken(raw) {
  const s = String(raw ?? '').trim();
  if (!s) return '';
  const token = s.toLowerCase().startsWith('token ') ? s.slice(6).trim() : s;
  const [key, secret] = token.split(':');
  if (!key) return '***';
  const k = key.length <= 6 ? key : `${key.slice(0, 3)}...${key.slice(-2)}`;
  const sec = secret ? `${'*'.repeat(Math.min(6, secret.length))}` : '';
  return secret ? `token ${k}:${sec}` : `token ${k}`;
}

function normalizeAuth(raw) {
  const s = String(raw ?? '').trim();
  if (!s) return '';
  if (s.toLowerCase().startsWith('token ')) return `token ${s.slice(6).trim()}`;
  return `token ${s}`;
}

function promptLine(question, { defaultValue = '' } = {}) {
  return new Promise((resolve) => {
    const rl = readline.createInterface({ input: process.stdin, output: process.stdout });
    rl.question(question, (answer) => {
      rl.close();
      const value = String(answer ?? '').trim();
      resolve(value || defaultValue);
    });
  });
}

function promptSecret(question) {
  return new Promise((resolve) => {
    const stdin = process.stdin;
    const stdout = process.stdout;
    if (!stdin.isTTY) {
      return resolve('');
    }

    let value = '';
    stdout.write(question);
    stdin.setRawMode(true);
    stdin.resume();

    const onData = (buf) => {
      const s = buf.toString('utf8');
      for (let i = 0; i < s.length; i += 1) {
        const ch = s[i];
        if (ch === '\u0003') {
          stdout.write('\n');
          process.exit(130);
        }
        if (ch === '\r' || ch === '\n') {
          stdout.write('\n');
          stdin.setRawMode(false);
          stdin.pause();
          stdin.removeListener('data', onData);
          return resolve(value.trim());
        }
        if (ch === '\u007f' || ch === '\b') {
          if (value.length > 0) {
            value = value.slice(0, -1);
            stdout.write('\b \b');
          }
          continue;
        }
        if (ch < ' ' || ch === '\u001b') continue;
        value += ch;
        stdout.write('*');
      }
    };

    stdin.on('data', onData);
  });
}

function assertBridgeReady() {
  const mainClass = path.join(BRIDGE_OUT_DIR, 'com', 'st8504', 'bridge', 'BridgeMain.class');
  if (!fs.existsSync(SDK_JAR)) {
    throw new Error(`Missing SDK jar: ${SDK_JAR}`);
  }
  if (!fs.existsSync(mainClass)) {
    throw new Error(`Java bridge not built. Run: ${path.join(ROOT_DIR, 'build-bridge.sh')}`);
  }
}

class Bridge {
  constructor({ rootDir }) {
    this.rootDir = rootDir;
    this.proc = null;
    this.nextId = 1;
    this.pending = new Map();
    this.listeners = new Set();
    this.buffer = '';
  }

  onEvent(handler) {
    this.listeners.add(handler);
    return () => this.listeners.delete(handler);
  }

  emit(evt) {
    for (const handler of this.listeners) handler(evt);
  }

  start() {
    if (this.proc) return;
    assertBridgeReady();

    const bridgeOutDir = path.resolve(this.rootDir, 'server', 'bridge-out');
    const classPath = [bridgeOutDir, SDK_JAR].join(path.delimiter);
    const javaArgs = ['-cp', classPath, 'com.st8504.bridge.BridgeMain'];

    this.proc = spawn('java', javaArgs, {
      stdio: ['pipe', 'pipe', 'pipe'],
      env: { ...process.env },
    });

    this.proc.stdout.setEncoding('utf8');
    this.proc.stdout.on('data', (chunk) => this.#handleStdout(chunk));

    this.proc.stderr.setEncoding('utf8');
    this.proc.stderr.on('data', (chunk) => {
      this.emit({ type: 'bridge-stderr', message: String(chunk) });
    });

    this.proc.on('exit', (code, signal) => {
      const msg = `Java bridge exited (code=${code}, signal=${signal})`;
      for (const [, p] of this.pending) p.reject(new Error(msg));
      this.pending.clear();
      this.proc = null;
      this.emit({ type: 'bridge-exit', message: msg });
    });
  }

  stop() {
    if (!this.proc) return;
    this.proc.kill();
    this.proc = null;
  }

  #handleStdout(chunk) {
    this.buffer += chunk;
    while (true) {
      const idx = this.buffer.indexOf('\n');
      if (idx === -1) return;
      const line = this.buffer.slice(0, idx).trimEnd();
      this.buffer = this.buffer.slice(idx + 1);
      if (!line) continue;
      this.#handleLine(line);
    }
  }

  #handleLine(line) {
    const parts = line.split('\t');
    const kind = parts[0];
    if (kind === 'RES') {
      const id = Number(parts[1]);
      const okOrErr = parts[2];
      const payload = parts.slice(3).join('\t');
      const pending = this.pending.get(id);
      if (!pending) return;
      this.pending.delete(id);
      if (okOrErr === 'OK') pending.resolve(payload ? JSON.parse(payload) : {});
      else pending.reject(new Error(payload || 'Unknown error'));
      return;
    }
    if (kind === 'EVT') {
      const evtType = parts[1];
      const payload = parts.slice(2).join('\t');
      let data = payload;
      try {
        data = payload ? JSON.parse(payload) : {};
      } catch {
        // keep raw
      }
      this.emit({ type: 'bridge-event', event: evtType, data });
      return;
    }
    this.emit({ type: 'bridge-unknown', line });
  }

  request(cmd, args = {}) {
    this.start();
    const id = this.nextId++;
    const line = `REQ\t${id}\t${cmd}\t${JSON.stringify(args)}\n`;

    return new Promise((resolve, reject) => {
      const timeoutMs = Number(process.env.BRIDGE_TIMEOUT_MS || 30000);
      const timeout = setTimeout(() => {
        this.pending.delete(id);
        reject(new Error(`Timeout waiting for ${cmd}`));
      }, timeoutMs);

      this.pending.set(id, {
        resolve: (v) => {
          clearTimeout(timeout);
          resolve(v);
        },
        reject: (e) => {
          clearTimeout(timeout);
          reject(e);
        },
      });

      this.proc.stdin.write(line);
    });
  }
}

class ErpPusher {
  constructor(cfg, log) {
    this.cfg = cfg;
    this.log = typeof log === 'function' ? log : () => {};
    this.queue = [];
    this.timer = null;
    this.inflight = false;
    this.failCount = 0;
    this.backoffUntil = 0;
    this.lastWarnAt = 0;
    this.lastOkAt = 0;
    this.lastErrAt = 0;
    this.lastErrMsg = '';
    this.dropped = 0;
  }

  enabled() {
    return Boolean(this.cfg?.enabled);
  }

  enqueue(tag) {
    if (!this.enabled()) return;
    if (!tag || typeof tag !== 'object') return;
    this.queue.push({ ...tag, ts: Date.now() });
    const maxQueue = this.cfg.maxQueue;
    if (Number.isFinite(maxQueue) && maxQueue > 0 && this.queue.length > maxQueue) {
      const dropCount = this.queue.length - maxQueue;
      this.queue.splice(0, dropCount);
      this.dropped += dropCount;
    }
    this.#schedule();
  }

  #schedule() {
    if (this.timer) return;
    const waitMs = Math.max(50, this.cfg.batchMs);
    this.timer = setTimeout(() => {
      this.timer = null;
      this.flush().catch(() => {});
    }, waitMs);
  }

  async flush() {
    if (!this.enabled()) return;
    if (!this.queue.length) return;
    if (this.inflight) {
      this.#schedule();
      return;
    }
    const now = Date.now();
    if (this.backoffUntil && now < this.backoffUntil) {
      this.#schedule();
      return;
    }
    const maxBatch = Math.max(1, Number(this.cfg.maxBatch) || 1);
    const maxAgeMs = Number(this.cfg.maxAgeMs) || 0;
    const batch = [];
    while (this.queue.length && batch.length < maxBatch) {
      const item = this.queue.shift();
      if (!item) continue;
      if (maxAgeMs > 0 && now - (item.ts || 0) > maxAgeMs) {
        this.dropped += 1;
        continue;
      }
      batch.push(item);
    }
    if (!batch.length) {
      if (this.queue.length) this.#schedule();
      return;
    }
    try {
      this.inflight = true;
      await this.#send(batch);
      this.failCount = 0;
      this.backoffUntil = 0;
      this.lastOkAt = Date.now();
    } catch (e) {
      this.failCount += 1;
      const base = Number(this.cfg.backoffBaseMs) || 300;
      const max = Number(this.cfg.backoffMaxMs) || 5000;
      const backoffMs = Math.min(max, base * 2 ** Math.min(8, this.failCount));
      this.backoffUntil = Date.now() + backoffMs;
      const msg = String(e && e.message ? e.message : e);
      this.lastErrAt = Date.now();
      this.lastErrMsg = msg;
      if (Date.now() - this.lastWarnAt > 5000) {
        this.lastWarnAt = Date.now();
        this.log(`ERP push error: ${msg}`);
      }
    } finally {
      this.inflight = false;
      if (this.queue.length) this.#schedule();
    }
  }

  async #send(tags) {
    const url = `${this.cfg.baseUrl}${this.cfg.endpoint}`;
    const headers = { 'content-type': 'application/json' };

    const auth = String(this.cfg.auth || '').trim();
    if (auth) headers.authorization = auth.toLowerCase().startsWith('token ') ? auth : `token ${auth}`;

    const secret = String(this.cfg.secret || '').trim();
    if (secret) headers['x-rfidenter-token'] = secret;

    const payload = { device: this.cfg.device, tags, ts: Date.now() };

    const timeoutMs = Number(this.cfg.timeoutMs) || 0;
    const controller = timeoutMs > 0 ? new AbortController() : null;
    const timer = controller ? setTimeout(() => controller.abort(), timeoutMs) : null;
    let res;
    try {
      res = await fetch(url, {
        method: 'POST',
        headers,
        body: JSON.stringify(payload),
        signal: controller ? controller.signal : undefined,
      });
    } finally {
      if (timer) clearTimeout(timer);
    }
    if (!res.ok) {
      if (res.status === 401) throw new Error('401 UNAUTHORIZED (token invalid/expired)');
      const text = await res.text().catch(() => '');
      throw new Error(`HTTP ${res.status} ${res.statusText}${text ? `: ${text.slice(0, 200)}` : ''}`);
    }
    const data = await res.json().catch(() => ({}));
    if (data && data.ok === false) throw new Error(String(data.error || 'ERP response not ok'));
  }

  stats() {
    return {
      queue: this.queue.length,
      inflight: this.inflight,
      lastOkAt: this.lastOkAt,
      lastErrAt: this.lastErrAt,
      lastErrMsg: this.lastErrMsg,
      dropped: this.dropped,
    };
  }
}

function listLocalIpv4() {
  const ifaces = os.networkInterfaces();
  const ips = [];
  for (const [, addrs] of Object.entries(ifaces)) {
    for (const addr of addrs || []) {
      if (addr.family !== 'IPv4') continue;
      if (addr.internal) continue;
      const ip = String(addr.address || '').trim();
      if (ip) ips.push(ip);
    }
  }
  return [...new Set(ips)];
}

function listSerialDevicesLinux() {
  const devices = new Set();
  try {
    for (const name of fs.readdirSync('/dev')) {
      if (/^tty(USB|ACM)\d+$/.test(name)) devices.add(path.join('/dev', name));
    }
  } catch {
    // ignore
  }
  for (const dir of ['/dev/serial/by-id', '/dev/serial/by-path']) {
    try {
      if (!fs.existsSync(dir)) continue;
      for (const name of fs.readdirSync(dir)) devices.add(path.join(dir, name));
    } catch {
      // ignore
    }
  }
  return [...devices];
}

async function tryTcpConnect({ ip, port, timeoutMs }) {
  return await new Promise((resolve) => {
    const socket = new net.Socket();
    let done = false;
    function finish(result) {
      if (done) return;
      done = true;
      try {
        socket.destroy();
      } catch {
        // ignore
      }
      resolve(result);
    }
    socket.setTimeout(timeoutMs);
    socket.once('connect', () => finish(true));
    socket.once('timeout', () => finish(false));
    socket.once('error', () => finish(false));
    socket.connect(port, ip);
  });
}

function findDefaultSubnet() {
  const ips = listLocalIpv4();
  if (!ips.length) return null;
  const parts = ips[0].split('.');
  if (parts.length !== 4) return null;
  return `${parts[0]}.${parts[1]}.${parts[2]}.0/24`;
}

async function scanTcpPorts({ ports, timeoutMs = 140, concurrency = 64 }) {
  const subnet = findDefaultSubnet();
  if (!subnet) return { subnet: null, devices: [], portsTried: ports };
  const base = subnet.split('/')[0].split('.');
  const prefix = `${base[0]}.${base[1]}.${base[2]}.`;
  const ips = [];
  for (let i = 1; i <= 254; i++) ips.push(`${prefix}${i}`);
  const devices = [];
  let idx = 0;

  async function worker() {
    while (true) {
      const ip = ips[idx++];
      if (!ip) return;
      for (const port of ports) {
        // eslint-disable-next-line no-await-in-loop
        const ok = await tryTcpConnect({ ip, port, timeoutMs });
        if (ok) {
          devices.push({ ip, port });
          break;
        }
      }
    }
  }

  const workers = [];
  for (let i = 0; i < concurrency; i++) workers.push(worker());
  await Promise.all(workers);
  return { subnet, devices, portsTried: ports };
}

function buildDefaultTcpIps() {
  const ips = new Set(['192.168.0.250']);
  for (const ip of listLocalIpv4()) {
    const parts = ip.split('.');
    if (parts.length !== 4) continue;
    const prefix = `${parts[0]}.${parts[1]}.${parts[2]}.`;
    ips.add(`${prefix}250`);
    ips.add(`${prefix}251`);
  }
  return [...ips];
}

const useColor =
  process.stdout.isTTY &&
  String(process.env.TERM || '').toLowerCase() !== 'dumb' &&
  !Object.prototype.hasOwnProperty.call(process.env, 'NO_COLOR');

const animEnabled = !Object.prototype.hasOwnProperty.call(process.env, 'RFID_TUI_NO_ANIM');

const ANSI = {
  reset: useColor ? '\x1b[0m' : '',
  bold: useColor ? '\x1b[1m' : '',
  dim: useColor ? '\x1b[2m' : '',
  red: useColor ? '\x1b[31m' : '',
  green: useColor ? '\x1b[32m' : '',
  yellow: useColor ? '\x1b[33m' : '',
  blue: useColor ? '\x1b[34m' : '',
  cyan: useColor ? '\x1b[36m' : '',
  inverse: useColor ? '\x1b[7m' : '',
};

function colorize(code, text) {
  return `${code}${text}${ANSI.reset}`;
}

function stripAnsi(text) {
  return String(text ?? '').replace(/\x1b\[[0-9;]*m/g, '');
}

function truncateAnsi(text, maxWidth) {
  const s = String(text ?? '');
  if (maxWidth <= 0) return '';
  let out = '';
  let visible = 0;
  for (let i = 0; i < s.length; i += 1) {
    const ch = s[i];
    if (ch === '\x1b') {
      const m = s.slice(i).match(/^\x1b\[[0-9;]*m/);
      if (m) {
        out += m[0];
        i += m[0].length - 1;
        continue;
      }
    }
    if (visible >= maxWidth) break;
    out += ch;
    visible += 1;
  }
  return out;
}

function padAnsi(text, width) {
  const truncated = truncateAnsi(text, width);
  const len = stripAnsi(truncated).length;
  const safe = truncated + ANSI.reset;
  if (len < width) return safe + ' '.repeat(width - len);
  return safe;
}

function shortenMiddle(text, maxWidth) {
  const s = String(text ?? '');
  if (s.length <= maxWidth) return s;
  if (maxWidth <= 7) return s.slice(0, maxWidth);
  const keep = Math.floor((maxWidth - 3) / 2);
  const tail = maxWidth - 3 - keep;
  return `${s.slice(0, keep)}...${s.slice(-tail)}`;
}

const SPIN = ['|', '/', '-', '\\'];
const PULSE = ['.', 'o', 'O', 'o'];

function tickNow(stepMs = 200) {
  return Math.floor(Date.now() / Math.max(50, stepMs));
}

function animatedTitle(text, tick) {
  if (!useColor || !animEnabled) return text;
  const s = String(text ?? '');
  const n = s.length;
  if (!n) return s;
  const pos = (tick % (n + 6)) - 3;
  let out = '';
  for (let i = 0; i < n; i += 1) {
    const ch = s[i];
    const dist = Math.abs(pos - i);
    if (dist === 0) out += `${ANSI.bold}${ANSI.green}${ch}${ANSI.reset}`;
    else if (dist === 1) out += `${ANSI.green}${ch}${ANSI.reset}`;
    else if (dist === 2) out += `${ANSI.dim}${ANSI.green}${ch}${ANSI.reset}`;
    else out += `${ANSI.dim}${ch}${ANSI.reset}`;
  }
  return out;
}

function movingBar(width, tick) {
  const inner = Math.max(3, width - 2);
  const pos = tick % inner;
  let bar = '[';
  for (let i = 0; i < inner; i += 1) {
    if (i === pos) bar += '>';
    else if (i === pos - 1 || (pos === 0 && i === inner - 1)) bar += '=';
    else bar += ' ';
  }
  bar += ']';
  return bar;
}

function rateBar(rate, width) {
  const inner = Math.max(3, width);
  const capped = Math.max(0, Math.min(20, Number(rate) || 0));
  const fill = Math.round((capped / 20) * inner);
  let bar = '';
  for (let i = 0; i < inner; i += 1) {
    bar += i < fill ? '#' : '.';
  }
  return bar;
}

const MAX_ANT_LIMIT = 31;

function clampMaxAnt(value) {
  const n = Number(value);
  if (!Number.isFinite(n)) return 16;
  return Math.max(1, Math.min(MAX_ANT_LIMIT, Math.trunc(n)));
}

function maskForRange(maxAnt) {
  let mask = 0;
  const limit = clampMaxAnt(maxAnt);
  for (let i = 1; i <= limit; i += 1) {
    mask |= 1 << (i - 1);
  }
  return mask >>> 0;
}

function maskClamp(mask, maxAnt) {
  const limit = clampMaxAnt(maxAnt);
  return (mask >>> 0) & maskForRange(limit);
}

function maskToList(mask, maxAnt) {
  const list = [];
  const limit = clampMaxAnt(maxAnt);
  const m = mask >>> 0;
  for (let i = 1; i <= limit; i += 1) {
    if (m & (1 << (i - 1))) list.push(i);
  }
  return list;
}

function maskToHex(mask, maxAnt) {
  const limit = clampMaxAnt(maxAnt);
  const width = limit > 16 ? 8 : 4;
  return `0x${(mask >>> 0).toString(16).toUpperCase().padStart(width, '0')}`;
}

function parseAntennaInput(raw, maxAnt) {
  const limit = clampMaxAnt(maxAnt);
  const s = String(raw ?? '').trim().toLowerCase();
  if (!s) return { error: 'Empty input.' };
  if (s === 'all' || s === '*') return { mask: maskForRange(limit) };
  if (s === 'none' || s === 'off' || s === '0') return { mask: 0 };

  if (s.startsWith('mask:')) {
    const value = s.slice(5).trim();
    if (!value) return { error: 'Mask value missing.' };
    const n = value.startsWith('0x') ? parseInt(value, 16) : parseInt(value, 10);
    if (!Number.isFinite(n)) return { error: 'Invalid mask number.' };
    return { mask: maskClamp(n, limit) };
  }

  if (/^0x[0-9a-f]+$/i.test(s)) {
    const n = parseInt(s, 16);
    if (!Number.isFinite(n)) return { error: 'Invalid hex mask.' };
    return { mask: maskClamp(n, limit) };
  }

  if (/^\d+$/.test(s)) {
    const n = Number(s);
    if (!Number.isFinite(n)) return { error: 'Invalid number.' };
    if (n >= 1 && n <= limit) {
      return { mask: maskClamp(1 << (n - 1), limit) };
    }
    return { mask: maskClamp(n, limit) };
  }

  const parts = s.split(/[\s,]+/).filter(Boolean);
  if (!parts.length) return { error: 'Empty antenna list.' };
  let mask = 0;
  for (const part of parts) {
    if (/^\d+\-\d+$/.test(part)) {
      const [aRaw, bRaw] = part.split('-');
      const a = Number(aRaw);
      const b = Number(bRaw);
      if (!Number.isFinite(a) || !Number.isFinite(b)) return { error: `Invalid range: ${part}` };
      const start = Math.max(1, Math.min(a, b));
      const end = Math.min(limit, Math.max(a, b));
      for (let i = start; i <= end; i += 1) mask |= 1 << (i - 1);
    } else if (/^\d+$/.test(part)) {
      const n = Number(part);
      if (!Number.isFinite(n)) return { error: `Invalid antenna: ${part}` };
      if (n < 1 || n > limit) return { error: `Antenna out of range: ${part}` };
      mask |= 1 << (n - 1);
    } else {
      return { error: `Invalid token: ${part}` };
    }
  }
  return { mask: maskClamp(mask, limit) };
}

function formatAntennaList(mask, maxAnt) {
  const list = maskToList(mask, maxAnt);
  if (!list.length) return 'none';
  if (list.length === clampMaxAnt(maxAnt)) return 'all';
  if (list.length > 8) return `${list[0]}..${list[list.length - 1]} (${list.length})`;
  return list.join(',');
}

function lcg(seed) {
  let s = seed >>> 0;
  return () => {
    s = (s * 1664525 + 1013904223) >>> 0;
    return s;
  };
}

function hexStream(width, tick) {
  const count = Math.max(4, Math.floor((width + 1) / 3));
  const rng = lcg(0x9e3779b9 ^ tick);
  const cells = [];
  for (let i = 0; i < count; i += 1) {
    const v = rng() & 0xff;
    const h = v.toString(16).toUpperCase().padStart(2, '0');
    cells.push(h);
  }
  const cursor = tick % cells.length;
  if (animEnabled) {
    cells[cursor] = `${ANSI.inverse}${cells[cursor]}${ANSI.reset}`;
  }
  return cells.join(' ').slice(0, width);
}

function pad(text, width) {
  const s = String(text ?? '');
  if (s.length >= width) return s.slice(0, width);
  return s + ' '.repeat(width - s.length);
}

async function main() {
  if (!process.stdin.isTTY || !process.stdout.isTTY) {
    console.error('TUI requires a TTY. Run in a terminal.');
    process.exit(1);
  }

  console.log('RFID TUI (Linux)');
  console.log('----------------');
  const modeRaw = await promptLine('Mode [1] Online, [2] Offline: ');
  const mode = modeRaw === '1' || /online/i.test(modeRaw) ? 'online' : 'offline';

  const apiBaseUrl = normalizeHttpUrl(envStr('RFID_TUI_API_URL', ''));
  const apiMode = Boolean(apiBaseUrl);
  const apiControl = apiMode && envBool('RFID_TUI_API_CONTROL', false);
  const apiStartStop = apiMode && (apiControl || envBool('RFID_TUI_API_STARTSTOP', false));
  const apiReadOnly = apiMode && !apiStartStop;

  let erpUrl = '';
  let erpAuth = '';
  if (mode === 'online' && (!apiMode || apiControl)) {
    erpUrl = normalizeHttpUrl(await promptLine('ERP URL: '));
    erpAuth = normalizeAuth(await promptSecret('ERP token (api_key:api_secret): '));
    if (!erpUrl) {
      console.error('ERP URL is required for online mode.');
      process.exit(1);
    }
    if (!erpAuth) {
      console.error('ERP token is required for online mode.');
      process.exit(1);
    }
  }

  const deviceName = process.env.ERP_PUSH_DEVICE || os.hostname();
  const erpBaseUrl = erpUrl;
  const erpAuthMasked = maskToken(erpAuth);
  const offlineDir = path.resolve(ROOT_DIR, 'logs');
  const offlineFile = path.join(offlineDir, `offline-tags-${nowIso().slice(0, 10)}.ndjson`);
  let offlineStream = null;
  if (mode === 'offline') {
    try {
      fs.mkdirSync(offlineDir, { recursive: true });
      offlineStream = fs.createWriteStream(offlineFile, { flags: 'a' });
    } catch (e) {
      console.error(`Failed to open offline log file: ${offlineFile}`);
      console.error(String(e && e.message ? e.message : e));
      process.exit(1);
    }
  }

  if (!apiMode) {
    try {
      assertBridgeReady();
    } catch (e) {
      console.error(String(e && e.message ? e.message : e));
      process.exit(1);
    }
  }

  const bridge = apiMode ? null : new Bridge({ rootDir: ROOT_DIR });
  const logs = [];
  const sanitizeLog = (msg) => {
    const line = String(msg ?? '').replace(/[\r\n\t]+/g, ' ').replace(/\s{2,}/g, ' ').trim();
    return line;
  };

  const addLog = (msg) => {
    const clean = sanitizeLog(msg);
    if (!clean) return;
    logs.push(`[${new Date().toISOString().replace('T', ' ').replace('Z', '')}] ${clean}`);
    if (logs.length > 12) logs.splice(0, logs.length - 12);
  };

  let apiLastErrAt = 0;

  function apiLogOnce(msg) {
    const now = Date.now();
    if (now - apiLastErrAt < 3000) return;
    apiLastErrAt = now;
    addLog(msg);
  }

  async function apiRequest(path, { method = 'GET', body } = {}) {
    if (!apiBaseUrl) throw new Error('API base URL is not set');
    const url = `${apiBaseUrl}${path}`;
    const headers = body ? { 'content-type': 'application/json' } : undefined;
    let res;
    try {
      res = await fetch(url, {
        method,
        headers,
        body: body ? JSON.stringify(body) : undefined,
      });
    } catch (e) {
      apiLogOnce(`API ${method} ${path} failed: ${String(e?.message || e)}`);
      throw e;
    }
    const data = await res.json().catch(() => ({}));
    if (!data || data.ok !== true) {
      const msg = data?.error || `${res.status} ${res.statusText || 'HTTP error'}`;
      apiLogOnce(`API ${method} ${path} error: ${msg}`);
      throw new Error(msg);
    }
    return data;
  }

  const apiGet = (path) => apiRequest(path, { method: 'GET' });
  const apiPost = (path, body) => apiRequest(path, { method: 'POST', body });

  const maxAntDefault = clampMaxAnt(process.env.RFID_MAX_ANT || 16);
  const envAntRaw = process.env.RFID_ANTENNAS || process.env.RFID_ANT_MASK || '';
  const parsedEnvAnt = envAntRaw ? parseAntennaInput(envAntRaw, maxAntDefault) : null;
  const initialAntMask = parsedEnvAnt?.mask ?? maskForRange(maxAntDefault);

  const state = {
    mode,
    apiMode,
    apiBaseUrl,
    apiControl,
    apiStartStop,
    apiReadOnly,
    connected: false,
    inventory: false,
    desiredInventory: false,
    connInfo: { mode: '-', addr: '-' },
    totalReads: 0,
    uniqueCount: 0,
    uniqueTags: new Set(),
    lastTagAt: 0,
    lastHeartbeatAt: 0,
    lastReaderPingAt: 0,
    scanPhase: 'idle',
    lastScanAt: 0,
    lastConnectAttempt: '',
    rateWindow: [],
    maxAnt: maxAntDefault,
    antennaMask: maskClamp(initialAntMask, maxAntDefault),
    lastAppliedMask: null,
    pendingInvApply: true,
    inputMode: '',
    inputBuffer: '',
    inputError: '',
    erpRemote: null,
  };

  const erpCfg = {
    baseUrl: erpBaseUrl,
    endpoint: '/api/method/rfidenter.rfidenter.api.ingest_tags',
    auth: erpAuth,
    secret: '',
    device: deviceName,
    pushEnabled: mode === 'online' && !apiMode,
    batchMs: envInt('ERP_PUSH_BATCH_MS', 250),
    maxBatch: envInt('ERP_PUSH_MAX_BATCH', 200),
    maxQueue: envInt('ERP_PUSH_MAX_QUEUE', 5000),
    timeoutMs: envInt('ERP_PUSH_TIMEOUT_MS', 0),
    maxAgeMs: envInt('ERP_PUSH_MAX_AGE_MS', 0),
    backoffBaseMs: envInt('ERP_PUSH_BACKOFF_BASE_MS', 500),
    backoffMaxMs: envInt('ERP_PUSH_BACKOFF_MAX_MS', 30000),
  };
  erpCfg.enabled = Boolean(erpCfg.baseUrl && erpCfg.pushEnabled);

  const erpPush = new ErpPusher(erpCfg, (m) => addLog(m));

  async function applyServerErpConfig() {
    if (!apiMode || !apiControl) return;
    if (mode !== 'online' && !envBool('RFID_TUI_SYNC_ERP_OFFLINE', false)) {
      addLog('ERP config sync skipped (offline)');
      return;
    }
    const patch =
      mode === 'online'
        ? {
            baseUrl: erpBaseUrl,
            auth: erpAuth,
            device: deviceName,
            agentId: deviceName,
            pushEnabled: true,
            rpcEnabled: true,
            overrideEnv: true,
            profile: 'server',
            activeProfile: 'server',
          }
        : {
            baseUrl: '',
            device: deviceName,
            pushEnabled: false,
            rpcEnabled: false,
            clearAuth: true,
            overrideEnv: true,
            profile: 'local',
            activeProfile: 'local',
          };
    try {
      const res = await apiPost('/api/erp/config', patch);
      state.erpRemote = res?.result || null;
      addLog(`ERP config synced (${mode})`);
    } catch (e) {
      addLog(`ERP config sync failed: ${String(e?.message || e)}`);
    }
  }

  if (apiMode) {
    if (apiControl) {
      await applyServerErpConfig();
    } else {
      try {
        const res = await apiGet('/api/erp/config');
        state.erpRemote = res?.result || null;
      } catch {
        // ignore
      }
    }
  }

  async function registerAgentOnce() {
    if (mode !== 'online' || apiMode) return;
    const url = `${erpCfg.baseUrl}/api/method/rfidenter.rfidenter.api.register_agent`;
    const headers = { 'content-type': 'application/json' };
    if (erpCfg.auth) headers.authorization = erpCfg.auth.toLowerCase().startsWith('token ') ? erpCfg.auth : `token ${erpCfg.auth}`;
    const payload = {
      agent_id: deviceName,
      device: deviceName,
      ui_urls: [],
      ui_host: '',
      ui_port: 0,
      platform: process.platform,
      version: 'rfid-tui',
      pid: process.pid,
      ts: Date.now(),
    };
    const controller = new AbortController();
    const timer = setTimeout(() => controller.abort(), 5000);
    try {
      const res = await fetch(url, { method: 'POST', headers, body: JSON.stringify(payload), signal: controller.signal });
      if (!res.ok) throw new Error(`HTTP ${res.status} ${res.statusText}`);
      state.lastHeartbeatAt = Date.now();
    } finally {
      clearTimeout(timer);
    }
  }

  function recordRate() {
    const now = Date.now();
    state.rateWindow.push(now);
    const cutoff = now - 5000;
    while (state.rateWindow.length && state.rateWindow[0] < cutoff) state.rateWindow.shift();
  }

  function handleTag(tag) {
    const epc = String(tag?.epcId || '').trim().toUpperCase();
    state.totalReads += 1;
    recordRate();
    state.lastTagAt = Date.now();
    if (epc && !state.uniqueTags.has(epc)) {
      state.uniqueTags.add(epc);
      state.uniqueCount += 1;
    }
    if (mode === 'offline' && offlineStream) {
      const line = JSON.stringify({ ts: Date.now(), epcId: epc, raw: tag });
      offlineStream.write(`${line}\n`);
    }
    if (mode === 'online') erpPush.enqueue(tag);
  }

  function buildInvParams(mask) {
    return {
      ivtType: 0,
      memory: 1,
      invPwd: '00000000',
      qValue: 6,
      session: 255,
      scanTime: 20,
      antennaMask: mask,
      tidPtr: 0,
      tidLen: 0,
      target: 0,
      retryCount: 0,
    };
  }

  async function applyInventoryParams({ restart = false } = {}) {
    if (apiMode && !apiControl) return false;
    if (!state.connected) {
      state.pendingInvApply = true;
      return false;
    }
    if (state.lastAppliedMask === state.antennaMask && !state.pendingInvApply) return true;
    const wasRunning = state.inventory;
    if (restart && wasRunning) {
      try {
        if (apiMode) await apiPost('/api/inventory/stop', {});
        else await bridge.request('STOP_READ', {});
      } catch {
        // ignore
      }
      state.inventory = false;
    }

    try {
      if (apiMode) {
        await apiPost('/api/inventory/params', buildInvParams(state.antennaMask));
      } else {
        await bridge.request('SET_INV_PARAM', buildInvParams(state.antennaMask));
      }
      state.pendingInvApply = false;
      state.lastAppliedMask = state.antennaMask;
      addLog(
        `Antenna mask applied: ${maskToHex(state.antennaMask, state.maxAnt)} [${formatAntennaList(
          state.antennaMask,
          state.maxAnt,
        )}]`,
      );
    } catch (e) {
      state.pendingInvApply = true;
      addLog(`Set antenna mask failed: ${String(e && e.message ? e.message : e)}`);
      return false;
    }

    if (restart && (wasRunning || state.desiredInventory)) {
      await startInventoryWithRecovery();
    }
    return true;
  }

  async function startInventoryWithRecovery() {
    if (apiMode && !apiStartStop) return;
    if (!state.connected) return;
    try {
      const res = apiMode ? await apiPost('/api/inventory/start', {}) : await bridge.request('START_READ', {});
      state.inventory = true;
      const rc = res?.result?.rc ?? res?.rc ?? 0;
      addLog(`Inventory started (rc=${rc})`);
      return;
    } catch (e) {
      addLog(`StartRead error: ${String(e && e.message ? e.message : e)}`);
    }
    if (apiMode) {
      state.inventory = false;
      return;
    }
    try {
      await bridge.request('STOP_READ', {});
      await sleep(200);
      const res = await bridge.request('START_READ', {});
      state.inventory = true;
      addLog(`Inventory restarted (rc=${res?.rc ?? 0})`);
    } catch (e) {
      state.inventory = false;
      addLog(`StartRead failed: ${String(e && e.message ? e.message : e)}`);
    }
  }

  function updateConnInfo(args) {
    if (!args || typeof args !== 'object') return;
    const mode = String(args.mode || '').trim();
    if (mode === 'serial') {
      state.connInfo = { mode: 'serial', addr: String(args.device || '') };
    } else {
      state.connInfo = { mode: 'tcp', addr: `${String(args.ip || '')}:${String(args.port || '')}` };
    }
  }

  if (!apiMode) {
    bridge.onEvent((evt) => {
      if (evt.type === 'bridge-event') {
        if (evt.event === 'STATUS') {
          if (typeof evt.data?.connected === 'boolean') state.connected = evt.data.connected;
          if (typeof evt.data?.inventoryStarted === 'boolean') state.inventory = evt.data.inventoryStarted;
          if (evt.data?.lastConnectArgs) updateConnInfo(evt.data.lastConnectArgs);
        }
        if (evt.event === 'TAG') handleTag(evt.data);
        if (evt.event === 'READ_OVER' || evt.event === 'TAG_FAIL') {
          state.inventory = false;
          if (state.desiredInventory) startInventoryWithRecovery().catch(() => {});
        }
      } else if (evt.type === 'bridge-stderr') {
        addLog(`Bridge stderr: ${String(evt.message || '').trim()}`);
      } else if (evt.type === 'bridge-exit') {
        state.connected = false;
        state.inventory = false;
        addLog(evt.message);
      }
    });
  }

  async function handleSseEvent(event, payload) {
    if (!event) return;
    if (event === 'TAG') {
      handleTag(payload);
      return;
    }
    if (event === 'STATUS') {
      if (typeof payload?.connected === 'boolean') state.connected = payload.connected;
      if (typeof payload?.inventoryStarted === 'boolean') state.inventory = payload.inventoryStarted;
      if (payload?.lastConnectArgs) updateConnInfo(payload.lastConnectArgs);
      return;
    }
    if (event === 'READ_OVER' || event === 'TAG_FAIL') {
      state.inventory = false;
      if (state.desiredInventory) startInventoryWithRecovery().catch(() => {});
      return;
    }
    if (event === 'log') {
      const msg = String(payload?.message || payload || '').trim();
      if (msg) addLog(msg);
      return;
    }
    if (event === 'hello') {
      addLog('API stream connected');
    }
  }

  async function startSseLoop() {
    if (!apiMode) return;
    const decoder = new TextDecoder();
    let delayMs = 1000;
    while (!shuttingDown) {
      try {
        const res = await fetch(`${apiBaseUrl}/api/events`, {
          method: 'GET',
          headers: { accept: 'text/event-stream' },
        });
        if (!res.ok) throw new Error(`SSE HTTP ${res.status} ${res.statusText}`);
        delayMs = 1000;
        let buffer = '';
        let evtName = '';
        let dataLines = [];
        const reader = res.body.getReader();
        while (!shuttingDown) {
          const { value, done } = await reader.read();
          if (done) break;
          buffer += decoder.decode(value, { stream: true });
          while (true) {
            const idx = buffer.indexOf('\n');
            if (idx === -1) break;
            const line = buffer.slice(0, idx).replace(/\r$/, '');
            buffer = buffer.slice(idx + 1);
            if (!line) {
              const dataStr = dataLines.join('\n').trim();
              let payload = dataStr;
              if (dataStr) {
                try {
                  payload = JSON.parse(dataStr);
                } catch {
                  payload = dataStr;
                }
              }
              await handleSseEvent(evtName || 'message', payload);
              evtName = '';
              dataLines = [];
              continue;
            }
            if (line.startsWith('event:')) {
              evtName = line.slice(6).trim();
              continue;
            }
            if (line.startsWith('data:')) {
              dataLines.push(line.slice(5).trim());
            }
          }
        }
      } catch (e) {
        apiLogOnce(`SSE error: ${String(e?.message || e)}`);
      }
      if (!shuttingDown) await sleep(delayMs);
      delayMs = Math.min(5000, Math.round(delayMs * 1.5));
    }
  }

  let shuttingDown = false;
  let connectInFlight = false;
  let lastFullScanAt = 0;
  const recentFailures = new Map();

  function markFailure(key, ms = 5000) {
    recentFailures.set(key, Date.now() + ms);
  }

  function canTry(key) {
    const until = recentFailures.get(key);
    if (!until) return true;
    if (Date.now() > until) {
      recentFailures.delete(key);
      return true;
    }
    return false;
  }

  async function tryConnectSerial(device) {
    if (!canTry(`serial:${device}`)) return false;
    try {
      state.lastConnectAttempt = `serial ${device}`;
      const res = apiMode
        ? await apiPost('/api/connect', { mode: 'serial', device, baud: 0, readerType: 16, logSwitch: 0 })
        : await bridge.request('CONNECT', { mode: 'serial', device, baud: 0, readerType: 16, logSwitch: 0 });
      state.connected = true;
      state.inventory = false;
      updateConnInfo({ mode: 'serial', device });
      const rc = res?.result?.rc ?? res?.rc ?? 0;
      addLog(`Connected (serial): ${device} rc=${rc}`);
      await applyInventoryParams({ restart: false });
      if (state.desiredInventory) await startInventoryWithRecovery();
      return true;
    } catch (e) {
      markFailure(`serial:${device}`);
      const msg = String(e?.message || e);
      if (msg) addLog(`Serial connect failed: ${msg}`);
      return false;
    }
  }

  async function tryConnectTcp(ip, port) {
    const key = `tcp:${ip}:${port}`;
    if (!canTry(key)) return false;
    try {
      state.lastConnectAttempt = `tcp ${ip}:${port}`;
      const res = apiMode
        ? await apiPost('/api/connect', { mode: 'tcp', ip, port, readerType: 16, logSwitch: 0 })
        : await bridge.request('CONNECT', { mode: 'tcp', ip, port, readerType: 16, logSwitch: 0 });
      state.connected = true;
      state.inventory = false;
      updateConnInfo({ mode: 'tcp', ip, port });
      const rc = res?.result?.rc ?? res?.rc ?? 0;
      addLog(`Connected (tcp): ${ip}:${port} rc=${rc}`);
      await applyInventoryParams({ restart: false });
      if (state.desiredInventory) await startInventoryWithRecovery();
      return true;
    } catch (e) {
      markFailure(key);
      const msg = String(e?.message || e);
      if (msg) addLog(`TCP connect failed: ${msg}`);
      return false;
    }
  }

  async function autoConnectTick() {
    if (shuttingDown) return;
    if (apiMode && !apiControl) return;
    if (state.connected) return;
    if (connectInFlight) return;
    connectInFlight = true;
    try {
      state.scanPhase = 'serial-scan';
      state.lastScanAt = Date.now();
      let serials = [];
      if (apiMode) {
        try {
          const data = await apiGet('/api/serial/list');
          serials = Array.isArray(data?.result?.devices) ? data.result.devices.map((d) => d.path).filter(Boolean) : [];
        } catch {
          serials = [];
        }
      } else {
        serials = listSerialDevicesLinux();
      }
      for (const dev of serials) {
        // eslint-disable-next-line no-await-in-loop
        const ok = await tryConnectSerial(dev);
        if (ok) return;
      }

      const ports = DEFAULT_TCP_PORTS;
      if (!apiMode) {
        state.scanPhase = 'tcp-quick';
        for (const ip of buildDefaultTcpIps()) {
          for (const port of ports) {
            // eslint-disable-next-line no-await-in-loop
            const ok = await tryConnectTcp(ip, port);
            if (ok) return;
          }
        }
      }

      const now = Date.now();
      if (now - lastFullScanAt >= DEFAULT_TCP_SCAN_INTERVAL_MS) {
        lastFullScanAt = now;
        state.scanPhase = 'tcp-scan';
        const scan = apiMode ? await apiPost('/api/scan', { ports }) : await scanTcpPorts({ ports });
        const devices = apiMode
          ? Array.isArray(scan?.result?.devices)
            ? scan.result.devices
            : []
          : scan.devices || [];
        for (const dev of devices) {
          // eslint-disable-next-line no-await-in-loop
          const ok = await tryConnectTcp(dev.ip, dev.port);
          if (ok) return;
        }
      }
    } catch (e) {
      addLog(`Auto-connect error: ${String(e && e.message ? e.message : e)}`);
    } finally {
      state.scanPhase = 'idle';
      connectInFlight = false;
    }
  }

  async function statusPoll() {
    try {
      const st = apiMode
        ? (() => {
            // /api/status -> { ok: true, status }
            return apiGet('/api/status').then((data) => data.status || data.result || {});
          })()
        : bridge.request('STATUS', {});
      const status = await st;
      if (typeof status?.connected === 'boolean') state.connected = status.connected;
      if (typeof status?.inventoryStarted === 'boolean') state.inventory = status.inventoryStarted;
      if (status?.lastConnectArgs) updateConnInfo(status.lastConnectArgs);
      if (apiReadOnly) {
        state.desiredInventory = state.inventory;
      } else {
        if (state.connected && state.pendingInvApply && !state.inventory && (!apiMode || apiControl)) {
          await applyInventoryParams({ restart: false });
        }
        if (state.connected && state.desiredInventory && !state.inventory && (!apiMode || apiStartStop)) {
          await startInventoryWithRecovery();
        }
      }
    } catch {
      // ignore
    }
  }

  async function readerPing() {
    if (!state.connected) return;
    try {
      let info;
      if (apiMode) {
        const data = await apiGet('/api/info');
        info = data.result || data;
      } else {
        info = await bridge.request('GET_INFO', {});
      }
      state.lastReaderPingAt = Date.now();
      const antRaw = Number(info?.ant ?? info?.raw?.ant ?? 0);
      if (Number.isFinite(antRaw) && antRaw > state.maxAnt && antRaw <= MAX_ANT_LIMIT) {
        state.maxAnt = clampMaxAnt(antRaw);
      }
    } catch (e) {
      addLog('Reader ping failed');
      if (!apiMode) {
        bridge.stop();
        state.connected = false;
        state.inventory = false;
      }
    }
  }

  function clearCounts() {
    state.totalReads = 0;
    state.uniqueCount = 0;
    state.uniqueTags.clear();
    state.rateWindow = [];
  }

function render() {
  const width = Math.max(68, process.stdout.columns || 80);
  const tick = tickNow(200);
  const rate = state.rateWindow.length ? (state.rateWindow.length / 5).toFixed(1) : '0.0';
  const lines = [];
  const dimGreen = ANSI.dim + ANSI.green;
  const titleText = `RFID TUI`;
  const title = `${animatedTitle(titleText, tick)} ${colorize(dimGreen, '// ST-8504 / UHFReader288')}`;
  const sep = colorize(dimGreen, '-'.repeat(width));
  const label = (text) => colorize(dimGreen, String(text).toUpperCase());
  const badge = (text, color) => colorize(ANSI.bold + color, `[${text}]`);
  const ok = (text) => badge(text, ANSI.green);
  const warn = (text) => badge(text, dimGreen);
  const err = (text) => badge(text, ANSI.red);
  const connBadge = state.connected ? ok('LINK UP') : err('LINK DOWN');
  const invBadge = state.inventory ? ok('RX ON') : warn('RX OFF');
  const desiredBadge = apiReadOnly ? warn('REMOTE') : state.desiredInventory ? ok('ARMED') : warn('IDLE');
  const modeBadge = state.mode === 'online' ? ok('ONLINE') : warn('OFFLINE');
  const autoBadge = ok('ACTIVE');
  const key = (k, text) => `${colorize(ANSI.inverse + ANSI.green, ` ${k} `)} ${colorize(dimGreen, text)}`;
  const spin = SPIN[tick % SPIN.length];
  const pulse = state.lastTagAt && Date.now() - state.lastTagAt < 2000 ? PULSE[tick % PULSE.length] : '-';
  const scanAnim = state.connected ? ' ' : `${spin} ${movingBar(10, tick)}`;
  const scanLabel = state.connected ? 'idle' : state.scanPhase;
  const antListText = formatAntennaList(state.antennaMask, state.maxAnt);
  const antMaskHex = maskToHex(state.antennaMask, state.maxAnt);
  const inputCursor = state.inputMode && animEnabled && tick % 2 === 0 ? '_' : ' ';

  const timeOrDash = (ts) => (ts ? new Date(ts).toLocaleTimeString() : '-');

  lines.push(padAnsi(title, width));
  lines.push(padAnsi(colorize(dimGreen, hexStream(width, tick)), width));
  lines.push(padAnsi(sep, width));
  const controlBadge = apiReadOnly ? warn('READ-ONLY') : apiControl ? ok('CONTROL') : warn('START/STOP');
  lines.push(padAnsi(`${label('Mode')}: ${modeBadge}  ${label('Device')}: ${deviceName}  ${label('API')}: ${controlBadge}`, width));
  if (state.mode === 'online') {
    const urlText = shortenMiddle(erpBaseUrl || '-', Math.max(12, width - 30));
    lines.push(padAnsi(`${label('Target')}: ${urlText}  ${label('Token')}: ${erpAuthMasked || '-'}`, width));
    if (apiMode) {
      const eff = state.erpRemote?.effective;
      const push = eff ? (eff.pushActive ? 'on' : 'off') : '-';
      const rpc = eff ? (eff.rpcActive ? 'on' : 'off') : '-';
      const auth = eff ? eff.authMasked || '-' : '-';
      lines.push(padAnsi(`${label('ERP')}: remote push=${push} rpc=${rpc} auth=${auth}`, width));
    } else {
      const stats = erpPush.stats();
      const erpOk = stats.lastOkAt ? timeOrDash(stats.lastOkAt) : '-';
      const erpErr = stats.lastErrAt ? timeOrDash(stats.lastErrAt) : '-';
      lines.push(
        padAnsi(
          `${label('ERP')}: queue=${stats.queue} inflight=${stats.inflight ? 'yes' : 'no'} dropped=${stats.dropped} ok=${erpOk} err=${erpErr}`,
          width,
        ),
      );
    }
  } else {
    const logText = shortenMiddle(offlineFile, Math.max(12, width - 15));
    lines.push(padAnsi(`${label('Offline log')}: ${logText}`, width));
  }
  lines.push(padAnsi(sep, width));
  lines.push(
    padAnsi(`${label('Link')}: ${connBadge}  ${label('Conn')}: ${state.connInfo.mode} ${state.connInfo.addr}`, width),
  );
  lines.push(
    padAnsi(
      `${label('Rx')}: ${invBadge}  ${label('Desired')}: ${desiredBadge}  ${label('Auto-connect')}: ${autoBadge}`,
      width,
    ),
  );
  lines.push(
    padAnsi(
      `${label('Reads')}: total=${state.totalReads} unique=${state.uniqueCount} rate=${rate}/s ${label('rate')}: ${rateBar(
        Number(rate),
        8,
      )}  ${label('Last tag')}: ${timeOrDash(state.lastTagAt)} ${pulse}`,
      width,
    ),
  );
  lines.push(
    padAnsi(
      `${label('Heartbeat')}: ${timeOrDash(state.lastHeartbeatAt)}  ${label('Reader ping')}: ${timeOrDash(
        state.lastReaderPingAt,
      )}`,
      width,
    ),
  );
  lines.push(
    padAnsi(`${label('Scan')}: ${scanLabel} ${scanAnim}  ${label('Last scan')}: ${timeOrDash(state.lastScanAt)}`, width),
  );
  const settingsLine = apiMode && !apiControl
    ? `${label('Settings')}: ANT ${antListText} ${label('mask')}: ${antMaskHex}  ${label('Edit')}: -`
    : `${label('Settings')}: ANT ${antListText} ${label('mask')}: ${antMaskHex}  ${label('Edit')}: ${key('A', 'antennas')}`;
  lines.push(padAnsi(settingsLine, width));
  lines.push(padAnsi(sep, width));
  const keysLine = apiReadOnly
    ? `${label('Keys')}: ${key('C', 'clear counts')}  ${key('Q', 'quit')}  ${label('Control')}: ${warn('READ-ONLY')}`
    : apiMode && !apiControl
      ? `${label('Keys')}: ${key('S', 'start')}  ${key('T', 'stop')}  ${key('C', 'clear counts')}  ${key('Q', 'quit')}  ${label(
          'Control',
        )}: ${warn('START/STOP')}`
      : `${label('Keys')}: ${key('S', 'start')}  ${key('T', 'stop')}  ${key('A', 'antennas')}  ${key(
          'C',
          'clear counts',
        )}  ${key('Q', 'quit')}`;
  lines.push(padAnsi(keysLine, width));
  lines.push(padAnsi(sep, width));
  if (state.inputMode) {
    lines.push(padAnsi(`${label('Input')}: ${state.inputBuffer}${inputCursor}`, width));
    if (state.inputError) lines.push(padAnsi(colorize(ANSI.red, state.inputError), width));
  }
  lines.push(padAnsi(colorize(dimGreen, 'LOG STREAM:'), width));
  for (const line of logs.slice(-8)) lines.push(padAnsi(line, width));
  while (lines.length < (process.stdout.rows || 24)) lines.push('');
  readline.cursorTo(process.stdout, 0, 0);
  readline.clearScreenDown(process.stdout);
  process.stdout.write(lines.join('\n'));
}

  function handleKey(data) {
    const s = data.toString('utf8');
    const keyLower = s.toLowerCase();

    if (state.inputMode) {
      if (s === '\u0003') {
        shutdown();
        return;
      }
      if (s === '\u001b') {
        state.inputMode = '';
        state.inputBuffer = '';
        state.inputError = '';
        addLog('Antenna edit canceled');
        return;
      }
      if (s === '\r' || s === '\n') {
        const parsed = parseAntennaInput(state.inputBuffer, state.maxAnt);
        if (parsed.error) {
          state.inputError = parsed.error;
          return;
        }
        state.antennaMask = parsed.mask;
        state.inputMode = '';
        state.inputBuffer = '';
        state.inputError = '';
        applyInventoryParams({ restart: true }).catch(() => {});
        return;
      }
      if (s === '\u007f' || s === '\b') {
        state.inputBuffer = state.inputBuffer.slice(0, -1);
        state.inputError = '';
        return;
      }
      if (s === '\u0015') {
        state.inputBuffer = '';
        state.inputError = '';
        return;
      }
      if (s.startsWith('\u001b')) return;
      const filtered = s.replace(/[^\x20-\x7E]/g, '');
      if (!filtered) return;
      state.inputBuffer += filtered;
      state.inputError = '';
      return;
    }

    if (s === '\u0003' || keyLower === 'q') {
      shutdown();
      return;
    }
    if (apiMode && !apiStartStop && (keyLower === 'a' || keyLower === 's' || keyLower === 't')) {
      addLog('Read-only: controls disabled in API mode');
      return;
    }
    if (apiMode && !apiControl && keyLower === 'a') {
      addLog('Start/stop-only: antenna edit disabled');
      return;
    }
    if (keyLower === 'a') {
      state.inputMode = 'antenna';
      state.inputBuffer = '';
      state.inputError = '';
      return;
    }
    if (keyLower === 's') {
      state.desiredInventory = true;
      if (state.connected) {
        if (!apiMode || apiControl) {
          applyInventoryParams({ restart: false })
            .then(() => startInventoryWithRecovery().catch(() => {}))
            .catch(() => {});
        } else {
          startInventoryWithRecovery().catch(() => {});
        }
      }
      addLog('Start requested');
      return;
    }
    if (keyLower === 't') {
      state.desiredInventory = false;
      if (state.connected) {
        if (apiMode) {
          if (apiStartStop) apiPost('/api/inventory/stop', {}).catch(() => {});
        } else {
          bridge.request('STOP_READ', {}).catch(() => {});
        }
      }
      state.inventory = false;
      addLog('Stop requested');
      return;
    }
    if (keyLower === 'c') {
      clearCounts();
      addLog('Counts cleared');
    }
  }

  const intervals = [];
  intervals.push(setInterval(() => autoConnectTick().catch(() => {}), DEFAULT_SERIAL_INTERVAL_MS));
  intervals.push(setInterval(() => statusPoll().catch(() => {}), DEFAULT_STATUS_INTERVAL_MS));
  intervals.push(setInterval(() => readerPing().catch(() => {}), DEFAULT_READER_PING_MS));
  if (apiMode) {
    startSseLoop().catch(() => {});
  }
  intervals.push(
    setInterval(() => {
      if (mode === 'online' && !apiMode) {
        registerAgentOnce().catch((e) => addLog(`Heartbeat error: ${String(e?.message || e)}`));
        return;
      }
      state.lastHeartbeatAt = Date.now();
    }, DEFAULT_HEARTBEAT_MS),
  );
  intervals.push(setInterval(() => render(), 250));

  process.stdout.write('\x1b[?1049h\x1b[?25l');
  process.stdin.setRawMode(true);
  process.stdin.resume();
  process.stdin.on('data', handleKey);

  function shutdown() {
    if (shuttingDown) return;
    shuttingDown = true;
    for (const t of intervals) clearInterval(t);
    process.stdin.removeListener('data', handleKey);
    try {
      process.stdin.setRawMode(false);
    } catch {
      // ignore
    }
    try {
      process.stdout.write('\x1b[?25h\x1b[?1049l');
    } catch {
      // ignore
    }
    (async () => {
      try {
        state.desiredInventory = false;
        if (state.connected) {
          if (apiMode && apiControl) await apiPost('/api/inventory/stop', {});
          else await bridge.request('STOP_READ', {});
        }
      } catch {
        // ignore
      }
      try {
        if (state.connected) {
          if (apiMode && apiControl) await apiPost('/api/disconnect', {});
          else await bridge.request('DISCONNECT', {});
        }
      } catch {
        // ignore
      }
      try {
        if (!apiMode) bridge.stop();
      } catch {
        // ignore
      }
      try {
        if (offlineStream) offlineStream.end();
      } catch {
        // ignore
      }
      process.exit(0);
    })();
  }

  process.on('SIGINT', shutdown);
  process.on('SIGTERM', shutdown);
  render();
  addLog('TUI started');
}

main().catch((e) => {
  console.error(String(e && e.message ? e.message : e));
  process.exit(1);
});
