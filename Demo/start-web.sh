#!/usr/bin/env bash
set -euo pipefail

SCRIPT_DIR="$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd)"
WEB_DIR="$(cd -- "$SCRIPT_DIR/web-localhost" && pwd)"

PORT="${PORT:-8787}"
if [[ $# -ge 1 ]]; then
  PORT="$1"
fi

HOST="${HOST:-127.0.0.1}"
if [[ $# -ge 2 ]]; then
  HOST="$2"
fi

export PORT
export HOST

if [[ "${RFID_NO_TUI:-0}" == "1" ]]; then
  exec "$WEB_DIR/run.sh"
fi

LOG_DIR="$WEB_DIR/logs"
mkdir -p "$LOG_DIR"
SERVER_LOG="$LOG_DIR/web-server.log"

"$WEB_DIR/run.sh" >"$SERVER_LOG" 2>&1 &
SERVER_PID=$!

cleanup() {
  if kill -0 "$SERVER_PID" >/dev/null 2>&1; then
    kill "$SERVER_PID" >/dev/null 2>&1 || true
  fi
}
trap cleanup EXIT INT TERM

API_HOST="$HOST"
if [[ "$API_HOST" == "0.0.0.0" || "$API_HOST" == "::" ]]; then
  API_HOST="127.0.0.1"
fi

RFID_TUI_API_URL="http://$API_HOST:$PORT" "$WEB_DIR/start-tui.sh"
