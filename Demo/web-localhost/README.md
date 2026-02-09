# ST-8504 / UHFReader288 — Localhost Web UI (Linux)

This is a **localhost web UI** (browser-based) to use the reader on Linux.

It runs **only on your own PC** (binds to `127.0.0.1`) and talks to the reader via the provided **Linux Java SDK**: `SDK/Java-linux/CReader.jar`.

## What works in v1

- Connect/disconnect (TCP/IP)
- Inventory (start/stop, live tag stream, antenna mask, session/Q/scan-time)
- Read/Write by EPC (Password/EPC/TID/User banks)
- Set RF power / region / antenna selection for inventory
- GPIO set/get (if supported by your firmware)

## Limitations

- **USB/RS232 direct support is not included yet** because this SDK folder only ships a TCP/IP Java API for Linux (`CReader.jar`).  
  If you must use USB/RS232 on Linux, you’ll need either:
  - a vendor **Linux serial SDK / protocol spec**, or
  - use the Windows tools via `wine`.

## Requirements

- `node` (Node.js 18+ recommended)
- `java` (JRE is enough)
- Serial port access (`/dev/ttyUSB*`, `/dev/ttyACM*`)

If you see permission errors on Linux, run with `sudo` once or add a udev rule:

```
KERNEL=="ttyUSB[0-9]*", MODE="0666"
KERNEL=="ttyACM[0-9]*", MODE="0666"
```

## RunTASK: finalize the UI/backend contract for Zebra page polling and eliminate all background timers.

Context:
- We introduced rfidenter.get_device_snapshot as a READ-ONLY polling endpoint to replace rfidenter.device_status (write-style).
- UI must NEVER call device_status on an interval.
- We must avoid timer leaks and background activity on page hide/router change/visibility change.
- Manual print queue processing (5s interval) must also stop when the page is hidden/unloaded.

Requirements (strict):
1) Backend: get_device_snapshot must be provably side-effect free:
   - No insert/save/set_value/publish_realtime
   - No RFID Edge Event writes
   - Must not mutate RFID Batch State (including modified timestamps)
   - Return schema:
     { ok: true, server_time, state: {device_id,status,pause_reason,current_batch_id,current_product,pending_product,last_event_seq,last_seen_at}, queue_depths:{print,erp,agent} }
2) Tests:
   - Add a test asserting BOTH:
     a) RFID Edge Event count unchanged
     b) RFID Batch State modified/last_seen_at unchanged by get_device_snapshot
3) UI (rfidenter_zebra.js):
   - Poll ONLY get_device_snapshot every 2s (with backoff on 429/503)
   - On auth error: stop polling + disable controls + show banner; no msgprint spam when quiet=true
   - Ensure ALL timers stop on:
     a) wrapper hide
     b) router change
     c) document.visibilitychange hidden
     d) beforeunload
   - Timers to stop include:
     - batch poll interval/backoff timeout
     - manual item queue interval (processItemQueue)
     - any agent polling loop should not continue after hide (abort via cancellation flag)
4) UI UX:
   - If queue_depths.print/erp are null, hide those fields (do not show N/A).
   - Keep agent queue depth display.

Deliverables:
- Provide diffs for api.py, __init__.py wrappers, rfidenter_zebra.js, and tests.
- Include a short manual QA checklist focusing on "only snapshot endpoint called", "no duplicate timers", and "no background queue processing".

From this folder:

1) Build the Java bridge (one-time):

`./build-bridge.sh`

2) Start the web app:

`./run.sh`

3) Open:

`http://127.0.0.1:8787`

If you need a different port:

`PORT=8787 ./run.sh`

## Combined web + TUI

`./start-web.sh` will start the web server **and** the TUI (API mode) on the same backend.

To disable TUI:

`RFID_NO_TUI=1 ./start-web.sh`

To run TUI against an existing server:

`RFID_TUI_API_URL=http://127.0.0.1:8787 ./start-tui.sh`

By default, API mode is **read-only** (no start/stop or ERP config changes).
To enable start/stop only:

`RFID_TUI_API_STARTSTOP=1 RFID_TUI_API_URL=http://127.0.0.1:8787 ./start-tui.sh`

To enable full control:

`RFID_TUI_API_CONTROL=1 RFID_TUI_API_URL=http://127.0.0.1:8787 ./start-tui.sh`

## Terminal TUI (Linux)

The TUI is a terminal-first mode with auto-connect and start/stop controls.

Run:

`./start-tui.sh`

Flow:

- Choose Online or Offline
- Online asks for ERP URL and token (use `api_key:api_secret`, it will add `token ` prefix)
- Offline writes tag events to `logs/offline-tags-YYYY-MM-DD.ndjson`
- In API mode, offline does not overwrite server ERP config (set `RFID_TUI_SYNC_ERP_OFFLINE=1` to force)

Keys:

- `S` start inventory
- `T` stop inventory
- `A` antenna settings (enter list like `1,2,3` or `1-4`, or `0x0F`)
- `C` clear counters
- `Q` quit

Auto-connect:

- Serial: `/dev/ttyUSB*` and `/dev/ttyACM*`
- TCP: ports `27011` and `2022` on the local `/24` subnet (prefers default route interface, ignores docker/VPN where possible)

WLAN/DHCP note:
- If Wi‑Fi comes up after startup or the reader’s IP changes, the backend auto-maintain loop retries connect and can fall back to TCP scan.
- Tunables: `RFID_AUTO_MAINTAIN_MS`, `RFID_AUTO_MAINTAIN_MAX_MS`, `RFID_AUTO_SCAN_MIN_MS`.

ERP push tuning (optional):

- `ERP_PUSH_BATCH_MS` (default `250`)
- `ERP_PUSH_MAX_BATCH` (default `200`)
- `ERP_PUSH_MAX_QUEUE` (default `5000`)
- `ERP_PUSH_TIMEOUT_MS` (default `0`, timeout disabled)
- `ERP_PUSH_MAX_AGE_MS` (default `0`, disables drop)
- `ERP_PUSH_BACKOFF_BASE_MS` (default `500`)
- `ERP_PUSH_BACKOFF_MAX_MS` (default `30000`)
