#!/usr/bin/env bash
set -euo pipefail

if [[ "${RFID_AUTO_PORT_PERMS:-1}" != "1" ]]; then
  exit 0
fi

RULE_PATH="/etc/udev/rules.d/99-rfid-serial.rules"
RULE_CONTENT='KERNEL=="ttyUSB[0-9]*", MODE="0666"\nKERNEL=="ttyACM[0-9]*", MODE="0666"'

needs_fix=0
for d in /dev/ttyUSB* /dev/ttyACM*; do
  if [[ -e "$d" ]]; then
    if [[ ! -r "$d" || ! -w "$d" ]]; then
      needs_fix=1
      break
    fi
  fi
done

if [[ $needs_fix -eq 0 ]]; then
  exit 0
fi

apply_root() {
  printf "%b\n" "$RULE_CONTENT" >"$RULE_PATH"
  if command -v udevadm >/dev/null 2>&1; then
    udevadm control --reload-rules || true
    udevadm trigger || true
  fi
  for d in /dev/ttyUSB* /dev/ttyACM*; do
    [[ -e "$d" ]] && chmod 666 "$d" || true
  done
}

if [[ "$(id -u)" -eq 0 ]]; then
  apply_root
  exit 0
fi

if command -v sudo >/dev/null 2>&1; then
  if sudo -n true >/dev/null 2>&1; then
    sudo bash -c "printf '%b\\n' '$RULE_CONTENT' >'$RULE_PATH'"
    if command -v udevadm >/dev/null 2>&1; then
      sudo udevadm control --reload-rules || true
      sudo udevadm trigger || true
    fi
    sudo bash -c 'for d in /dev/ttyUSB* /dev/ttyACM*; do [[ -e "$d" ]] && chmod 666 "$d" || true; done'
    exit 0
  fi
fi

echo "RFID: port permissions not updated. Run with sudo or add udev rule: $RULE_PATH" >&2
