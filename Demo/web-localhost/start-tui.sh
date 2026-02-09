#!/usr/bin/env bash
set -euo pipefail

ROOT_DIR="$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd)"
LOG_FILE="${TMPDIR:-/tmp}/rfid-tui-install-$$.log"
KEEP_LOG=0

if [[ -x "$ROOT_DIR/port-perms.sh" ]]; then
  "$ROOT_DIR/port-perms.sh" || true
fi

cleanup() {
  if [[ "$KEEP_LOG" != "1" ]]; then
    rm -f "$LOG_FILE"
  fi
}
trap cleanup EXIT

has_cmd() {
  command -v "$1" >/dev/null 2>&1
}

print_header() {
  echo "RFID TUI Installer"
  echo "=================="
}

print_step() {
  printf "%-24s %s\n" "$1" "$2"
}

spinner_wait() {
  local pid="$1"
  local msg="$2"
  local spin='|/-\'
  local i=0
  while kill -0 "$pid" >/dev/null 2>&1; do
    printf "\r%-24s [%c]" "$msg" "${spin:i++%4:1}"
    sleep 0.1
  done
}

run_quiet() {
  local msg="$1"
  shift
  "$@" >"$LOG_FILE" 2>&1 &
  local pid=$!
  spinner_wait "$pid" "$msg"
  if wait "$pid"; then
    printf "\r%-24s [OK]\n" "$msg"
    return 0
  fi
  printf "\r%-24s [FAIL]\n" "$msg"
  return 1
}

print_header

if [[ -n "${RFID_TUI_API_URL:-}" ]]; then
  if ! has_cmd node; then
    print_step "Node.js" "MISSING"
    echo "Please install Node.js 18+"
    exit 1
  fi
  print_step "Node.js" "OK ($(node -v))"
  echo "Starting TUI (API mode)..."
  exec node "$ROOT_DIR/tui.js"
fi

if ! has_cmd node; then
  print_step "Node.js" "MISSING"
  echo "Please install Node.js 18+"
  exit 1
fi
print_step "Node.js" "OK ($(node -v))"

if ! has_cmd java; then
  print_step "Java" "MISSING"
  echo "Please install Java (JRE)"
  exit 1
fi
print_step "Java" "OK ($(java -version 2>&1 | head -n 1))"

SDK_DIR="$ROOT_DIR/../../SDK/Java-linux"
SDK_JAR_UHF="$SDK_DIR/CReader_Uhf.jar"
SDK_JAR_LEGACY="$SDK_DIR/CReader.jar"
if [[ -f "$SDK_JAR_UHF" ]]; then
  print_step "SDK Jar" "OK ($(basename "$SDK_JAR_UHF"))"
elif [[ -f "$SDK_JAR_LEGACY" ]]; then
  print_step "SDK Jar" "OK ($(basename "$SDK_JAR_LEGACY"))"
else
  print_step "SDK Jar" "MISSING"
  echo "Missing SDK jar in: $SDK_DIR"
  exit 1
fi

BRIDGE_OUT_DIR="$ROOT_DIR/server/bridge-out"
BRIDGE_SRC_DIR="$ROOT_DIR/server/bridge-src"
BRIDGE_MAIN_CLASS="$BRIDGE_OUT_DIR/com/st8504/bridge/BridgeMain.class"

NEED_BUILD=0
REQUIRED_CLASSES=(
  "com/st8504/bridge/BridgeMain.class"
  "android/util/Log.class"
  "android/os/SystemClock.class"
  "com/rfid/serialport/SerialPort.class"
)

for c in "${REQUIRED_CLASSES[@]}"; do
  if [[ ! -f "$BRIDGE_OUT_DIR/$c" ]]; then
    NEED_BUILD=1
    break
  fi
done

if [[ $NEED_BUILD -eq 0 && -f "$BRIDGE_MAIN_CLASS" ]]; then
  if find "$BRIDGE_SRC_DIR" -type f -name '*.java' -newer "$BRIDGE_MAIN_CLASS" -print -quit | grep -q .; then
    NEED_BUILD=1
  fi
fi

if [[ $NEED_BUILD -eq 1 ]]; then
  if ! run_quiet "Building bridge" "$ROOT_DIR/build-bridge.sh"; then
    echo "Bridge build failed. See: $LOG_FILE"
    KEEP_LOG=1
    exit 1
  fi
else
  print_step "Java bridge" "OK"
fi

echo "Starting TUI..."
exec node "$ROOT_DIR/tui.js"
