#!/usr/bin/env bash
#
# namaz_time.sh
# Bash/Ubuntu port of NamazTime.ps1
#
# Calculates the five daily Namaz (Salah) times for a given location:
#   Fajr, Sunrise, Dhuhr, Asr (Hanafi & Shafi'i), Maghrib, Isha
#
# - Fajr / Sunrise / Dhuhr / Maghrib / Isha come from the sunrise-sunset.org API
#   (astronomical twilight, sunrise, solar noon, sunset, astronomical twilight).
# - Asr is computed locally using the same astronomical formula as the source
#   PowerShell script (solar declination + equation of time + spherical
#   trigonometry hour-angle), for both the Hanafi and Shafi'i shadow ratios.
#
# Usage:
#   ./namaz_time.sh                       # Mumbai, today, system timezone
#   ./namaz_time.sh -d 2026-12-25          # Mumbai, specific date
#   ./namaz_time.sh -a 25.2048 -g 55.2708 -u 4 -d 2026-01-01   # Dubai
#   ./namaz_time.sh -h                     # help
#
set -uo pipefail

# ---------------------------------------------------------------------------
# Defaults (Mumbai coordinates, matching the original script)
# ---------------------------------------------------------------------------
LAT="19.0760"
LNG="72.8777"
UTC_OFFSET="5.5"
TARGET_DATE="$(date +%Y-%m-%d)"
LOCATION_NAME="Mumbai"

# ---------------------------------------------------------------------------
# Argument parsing
# ---------------------------------------------------------------------------
usage() {
    cat <<EOF
Usage: $(basename "$0") [options]

Options:
  -a, --lat LAT          Latitude in decimal degrees   (default: ${LAT})
  -g, --lng LNG          Longitude in decimal degrees  (default: ${LNG})
  -u, --utc-offset HRS   UTC offset in hours, e.g. 5.5 (default: ${UTC_OFFSET})
  -d, --date YYYY-MM-DD  Date to calculate for         (default: today)
  -n, --name NAME        Label to show in the output   (default: ${LOCATION_NAME})
  -h, --help             Show this help message

Example (Dubai):
  $(basename "$0") -a 25.2048 -g 55.2708 -u 4 -n Dubai
EOF
}

while [[ $# -gt 0 ]]; do
    case "$1" in
        -a|--lat)        LAT="$2"; shift 2 ;;
        -g|--lng)        LNG="$2"; shift 2 ;;
        -u|--utc-offset) UTC_OFFSET="$2"; shift 2 ;;
        -d|--date)       TARGET_DATE="$2"; shift 2 ;;
        -n|--name)       LOCATION_NAME="$2"; shift 2 ;;
        -h|--help)       usage; exit 0 ;;
        *)
            echo "Unknown option: $1" >&2
            usage
            exit 1
            ;;
    esac
done

# ---------------------------------------------------------------------------
# Dependency checks
# ---------------------------------------------------------------------------
for cmd in curl awk date; do
    if ! command -v "$cmd" >/dev/null 2>&1; then
        echo "Error: required command '$cmd' is not installed." >&2
        exit 1
    fi
done
HAVE_JQ=0
if command -v jq >/dev/null 2>&1; then
    HAVE_JQ=1
fi

# ---------------------------------------------------------------------------
# Validate the date
# ---------------------------------------------------------------------------
if ! date -d "$TARGET_DATE" >/dev/null 2>&1; then
    echo "Error: invalid date '$TARGET_DATE'. Expected format YYYY-MM-DD." >&2
    exit 1
fi

DAY_OF_YEAR=$(date -d "$TARGET_DATE" +%j)
DAY_OF_YEAR=$((10#$DAY_OF_YEAR))   # strip any leading zero so bash doesn't read it as octal
DISPLAY_DATE=$(date -d "$TARGET_DATE" +"%d-%m-%Y")

# ---------------------------------------------------------------------------
# Asr time calculation (astronomical formula, mirrors Get-AsrTimeDynamic)
#
#   get_asr_time <day_of_year> <lat> <lng> <utc_offset> <method: hanafi|shafi>
#   prints "HH:MM" to stdout
# ---------------------------------------------------------------------------
get_asr_time() {
    local n="$1" lat="$2" lng="$3" utc_offset="$4" method="$5"

    awk -v n="$n" -v lat="$lat" -v lng="$lng" -v utc_offset="$utc_offset" -v method="$method" '
    BEGIN {
        PI = atan2(0, -1)

        # 0. Dynamically calculate Standard Meridian (lambda_sm)
        lambda_sm = utc_offset * 15.0

        # 1. Coordinates to radians
        phi       = PI * lat / 180.0
        lambdaLoc = lng

        # 2. Calendar constant gamma
        gamma = (2 * PI / 365.0) * (n - 1)

        # 3. Solar declination (delta), radians
        delta = 0.006918 \
              - (0.399912 * cos(gamma)) \
              + (0.070257 * sin(gamma)) \
              - (0.006758 * cos(2 * gamma)) \
              + (0.000907 * sin(2 * gamma)) \
              - (0.002697 * cos(3 * gamma)) \
              + (0.001480 * sin(3 * gamma))

        # 4. Equation of Time (EoT), minutes
        eot = 229.18 * (0.000075 \
              + (0.001868 * cos(gamma)) \
              - (0.032077 * sin(gamma)) \
              - (0.014615 * cos(2 * gamma)) \
              - (0.040849 * sin(2 * gamma)))

        # 5. Solar noon (Dhuhr base), decimal hours
        dhuhr = 12.0 + ((lambda_sm - lambdaLoc) / 15.0) - (eot / 60.0)

        # 6. Jurisprudential multiplier (Hanafi = 2, Shafii = 1)
        a = (method == "shafi") ? 1.0 : 2.0

        # 7. Solar altitude angle (alpha) for Asr
        diff = phi - delta
        if (diff < 0) diff = -diff
        g0    = sin(diff) / cos(diff)        # tan(|phi - delta|)
        gAsr  = a + g0
        alpha = atan2(1.0, gAsr)             # atan(1/gAsr)

        # 8. Hour angle (H) via spherical trigonometry
        cosH = (sin(alpha) - (sin(phi) * sin(delta))) / (cos(phi) * cos(delta))
        if (cosH > 1.0)  cosH = 1.0          # guard against FP domain errors
        if (cosH < -1.0) cosH = -1.0
        hRadians = atan2(sqrt(1 - cosH * cosH), cosH)   # acos(cosH)
        hDegrees = hRadians * (180.0 / PI)

        # 9. Final Asr decimal value
        asrDecimal = dhuhr + (hDegrees / 15.0)

        hours   = int(asrDecimal)
        minutes = int((asrDecimal - hours) * 60 + 0.5)
        if (minutes >= 60) { minutes -= 60; hours += 1 }
        if (hours >= 24)   { hours -= 24 }
        if (hours < 0)     { hours += 24 }

        printf "%02d:%02d", hours, minutes
    }'
}

# ---------------------------------------------------------------------------
# Determine the IANA timezone id to send to the API (so its DST/offset rules
# match this machine), with a graceful fallback chain.
# ---------------------------------------------------------------------------
get_tzid() {
    local tz=""
    if command -v timedatectl >/dev/null 2>&1; then
        tz=$(timedatectl show -p Timezone --value 2>/dev/null || true)
    fi
    if [[ -z "$tz" && -r /etc/timezone ]]; then
        tz=$(cat /etc/timezone 2>/dev/null || true)
    fi
    if [[ -z "$tz" && -L /etc/localtime ]]; then
        tz=$(readlink -f /etc/localtime 2>/dev/null | sed -n 's#.*/zoneinfo/##p')
    fi
    if [[ -z "$tz" ]]; then
        tz="UTC"
    fi
    printf '%s' "$tz"
}
TZID=$(get_tzid)

# ---------------------------------------------------------------------------
# Extract a field from the API's "results" object, with or without jq.
#   json_get <json_text> <field_name>
# ---------------------------------------------------------------------------
json_get() {
    local json="$1" field="$2"
    if [[ "$HAVE_JQ" -eq 1 ]]; then
        printf '%s' "$json" | jq -r --arg f "$field" '.results[$f] // empty'
    else
        printf '%s' "$json" | grep -oP "\"${field}\"\s*:\s*\"\K[^\"]*"
    fi
}

# ---------------------------------------------------------------------------
# Fetch sun/twilight data from sunrise-sunset.org
# ---------------------------------------------------------------------------
API_URL="https://api.sunrise-sunset.org/json?lat=${LAT}&lng=${LNG}&date=${TARGET_DATE}&formatted=0&tzid=${TZID}"

RESPONSE=$(curl -fsS --max-time 15 "$API_URL" 2>/tmp/namaz_curl_err.$$) 
CURL_STATUS=$?
if [[ $CURL_STATUS -ne 0 ]]; then
    echo "Error: failed to reach the prayer-times API ($API_URL)." >&2
    [[ -s /tmp/namaz_curl_err.$$ ]] && cat /tmp/namaz_curl_err.$$ >&2
    rm -f /tmp/namaz_curl_err.$$
    exit 1
fi
rm -f /tmp/namaz_curl_err.$$

API_STATUS=""
if [[ "$HAVE_JQ" -eq 1 ]]; then
    API_STATUS=$(printf '%s' "$RESPONSE" | jq -r '.status // empty')
else
    API_STATUS=$(printf '%s' "$RESPONSE" | grep -oP '"status"\s*:\s*"\K[^"]*')
fi

if [[ "$API_STATUS" != "OK" ]]; then
    echo "Error: API did not return OK status (got '${API_STATUS:-unknown}')." >&2
    echo "Response: $RESPONSE" >&2
    exit 1
fi

FAJR_RAW=$(json_get "$RESPONSE" "astronomical_twilight_begin")
SUNRISE_RAW=$(json_get "$RESPONSE" "sunrise")
DHUHR_RAW=$(json_get "$RESPONSE" "solar_noon")
MAGHRIB_RAW=$(json_get "$RESPONSE" "sunset")
ISHA_RAW=$(json_get "$RESPONSE" "astronomical_twilight_end")

for pair in "Fajr:$FAJR_RAW" "Sunrise:$SUNRISE_RAW" "Dhuhr:$DHUHR_RAW" "Maghrib:$MAGHRIB_RAW" "Isha:$ISHA_RAW"; do
    name="${pair%%:*}"
    val="${pair#*:}"
    if [[ -z "$val" ]]; then
        echo "Error: could not parse '$name' time from API response." >&2
        exit 1
    fi
done

# Convert ISO-8601 timestamps (with offset) to local HH:MM
to_local_hm() {
    date -d "$1" +"%H:%M" 2>/dev/null
}

FAJR=$(to_local_hm "$FAJR_RAW")
SUNRISE=$(to_local_hm "$SUNRISE_RAW")
DHUHR=$(to_local_hm "$DHUHR_RAW")
MAGHRIB=$(to_local_hm "$MAGHRIB_RAW")
ISHA=$(to_local_hm "$ISHA_RAW")

# ---------------------------------------------------------------------------
# Asr (Hanafi & Shafi'i)
# ---------------------------------------------------------------------------
HANAFI_ASR=$(get_asr_time "$DAY_OF_YEAR" "$LAT" "$LNG" "$UTC_OFFSET" "hanafi")
SHAFI_ASR=$(get_asr_time "$DAY_OF_YEAR" "$LAT" "$LNG" "$UTC_OFFSET" "shafi")

# ---------------------------------------------------------------------------
# Display
# ---------------------------------------------------------------------------
if [[ -t 1 ]]; then
    CYAN=$'\033[36m'
    BOLD=$'\033[1m'
    RESET=$'\033[0m'
else
    CYAN=""; BOLD=""; RESET=""
fi

printf "\n%s%s (%s)%s\n\n" "$CYAN" "$LOCATION_NAME" "$DISPLAY_DATE" "$RESET"
printf "%-20s %-10s\n" "Namaz" "Time"
printf "%-20s %-10s\n" "--------------------" "----------"
printf "%-20s %-10s\n" "Fajr"       "$FAJR"
printf "%-20s %-10s\n" "Sunrise"    "$SUNRISE"
printf "%-20s %-10s\n" "Dhuhr"      "$DHUHR"
printf "%-20s %-10s\n" "Shafi Asr"  "$SHAFI_ASR"
printf "%-20s %-10s\n" "Hanafi Asr" "$HANAFI_ASR"
printf "%-20s %-10s\n" "Maghrib"    "$MAGHRIB"
printf "%-20s %-10s\n" "Isha"       "$ISHA"
echo
