#!/usr/bin/env bash

# =========================================================
# Namaz Time Calculator (Ubuntu Bash Version)
# Requires:
#   - bash
#   - curl
#   - jq
#   - bc
#
# Install dependencies:
#   sudo apt update
#   sudo apt install curl jq bc
# =========================================================

# -----------------------------
# Function: Calculate Asr Time
# -----------------------------
get_asr_time_dynamic() {

    local date="$1"
    local latitude="$2"
    local longitude="$3"
    local utc_offset="$4"
    local method="$5"   # "hanafi" or "shafi"

    # Standard Meridian
    local lambda_sm
    lambda_sm=$(echo "$utc_offset * 15.0" | bc -l)

    # Convert latitude to radians
    local pi="4*a(1)"
    local phi
    phi=$(echo "$pi * $latitude / 180.0" | bc -l)

    # Day of year
    local n
    n=$(date -d "$date" +%j)

    # gamma
    local gamma
    gamma=$(echo "(2 * $pi / 365) * ($n - 1)" | bc -l)

    # Solar declination (delta)
    local delta
    delta=$(echo "
        0.006918
        - (0.399912 * c($gamma))
        + (0.070257 * s($gamma))
        - (0.006758 * c(2 * $gamma))
        + (0.000907 * s(2 * $gamma))
        - (0.002697 * c(3 * $gamma))
        + (0.00148 * s(3 * $gamma))
    " | bc -l)

    # Equation of Time
    local eot
    eot=$(echo "
        229.18 * (
            0.000075
            + (0.001868 * c($gamma))
            - (0.032077 * s($gamma))
            - (0.014615 * c(2 * $gamma))
            - (0.040849 * s(2 * $gamma))
        )
    " | bc -l)

    # Dhuhr
    local dhuhr
    dhuhr=$(echo "
        12.0 + (($lambda_sm - $longitude) / 15.0) - ($eot / 60.0)
    " | bc -l)

    # Jurisprudential multiplier
    local a=2.0
    if [[ "$method" == "shafi" ]]; then
        a=1.0
    fi

    # g0 = tan(abs(phi - delta))
    local diff
    diff=$(echo "$phi - $delta" | bc -l)

    # absolute value
    if (( $(echo "$diff < 0" | bc -l) )); then
        diff=$(echo "-1 * $diff" | bc -l)
    fi

    local g0
    g0=$(echo "s($diff)/c($diff)" | bc -l)

    local g_asr
    g_asr=$(echo "$a + $g0" | bc -l)

    # alpha = atan(1/g_asr)
    local alpha
    alpha=$(echo "a(1 / $g_asr)" | bc -l)

    # cosH
    local cosH
    cosH=$(echo "
        (
            s($alpha)
            - (s($phi) * s($delta))
        ) / (
            c($phi) * c($delta)
        )
    " | bc -l)

    # Clamp cosH between -1 and 1
    if (( $(echo "$cosH > 1" | bc -l) )); then
        cosH=1
    fi

    if (( $(echo "$cosH < -1" | bc -l) )); then
        cosH=-1
    fi

    # acos(x) = atan2(sqrt(1-x²), x)
    local h_radians
    h_radians=$(echo "a(sqrt(1 - ($cosH * $cosH)) / $cosH)" | bc -l)

    local h_degrees
    h_degrees=$(echo "$h_radians * (180.0 / $pi)" | bc -l)

    # Asr decimal time
    local asr_decimal
    asr_decimal=$(echo "$dhuhr + ($h_degrees / 15.0)" | bc -l)

    # Hours
    local hours
    hours=$(printf "%.0f" "$(echo "$asr_decimal / 1" | bc -l)")

    # Minutes
    local minutes
    minutes=$(printf "%.0f" "$(echo "($asr_decimal - $hours) * 60" | bc -l)")

    # Fix minute overflow
    if [[ "$minutes" -ge 60 ]]; then
        minutes=0
        hours=$((hours + 1))
    fi

    printf "%02d:%02d\n" "$hours" "$minutes"
}

# =========================================================
# Configuration
# =========================================================

LAT="19.0760"
LNG="72.8777"
UTC_OFFSET="5.5"

DATE=$(date +"%Y-%m-%d")
TZID=$(timedatectl show --property=Timezone --value)

# =========================================================
# Calculate Asr Times
# =========================================================

HANAFI_ASR=$(get_asr_time_dynamic "$DATE" "$LAT" "$LNG" "$UTC_OFFSET" "hanafi")
SHAFI_ASR=$(get_asr_time_dynamic "$DATE" "$LAT" "$LNG" "$UTC_OFFSET" "shafi")

# =========================================================
# API Request
# =========================================================

URL="https://api.sunrise-sunset.org/json?lat=${LAT}&lng=${LNG}&date=${DATE}&formatted=0&tzid=${TZID}"

RESPONSE=$(curl -s "$URL")

# Extract times
FAJR=$(echo "$RESPONSE" | jq -r '.results.astronomical_twilight_begin')
SUNRISE=$(echo "$RESPONSE" | jq -r '.results.sunrise')
DHUHR=$(echo "$RESPONSE" | jq -r '.results.solar_noon')
MAGHRIB=$(echo "$RESPONSE" | jq -r '.results.sunset')
ISHA=$(echo "$RESPONSE" | jq -r '.results.astronomical_twilight_end')

# Format HH:mm
FAJR=$(date -d "$FAJR" +"%H:%M")
SUNRISE=$(date -d "$SUNRISE" +"%H:%M")
DHUHR=$(date -d "$DHUHR" +"%H:%M")
MAGHRIB=$(date -d "$MAGHRIB" +"%H:%M")
ISHA=$(date -d "$ISHA" +"%H:%M")

# =========================================================
# Output
# =========================================================

echo
echo "Mumbai (${DATE})"
echo "----------------------------------------"

printf "%-20s %-10s\n" "Namaz" "Time"
printf "%-20s %-10s\n" "-------------------" "----------"

printf "%-20s %-10s\n" "Fajr" "$FAJR"
printf "%-20s %-10s\n" "Sunrise" "$SUNRISE"
printf "%-20s %-10s\n" "Dhuhr" "$DHUHR"
printf "%-20s %-10s\n" "Shafi Asr" "$SHAFI_ASR"
printf "%-20s %-10s\n" "Hanafi Asr" "$HANAFI_ASR"
printf "%-20s %-10s\n" "Maghrib" "$MAGHRIB"
printf "%-20s %-10s\n" "Isha" "$ISHA"

echo "----------------------------------------"
