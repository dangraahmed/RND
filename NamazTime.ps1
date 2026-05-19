function Get-AsrTimeDynamic {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true)]
        [DateTime]$Date,

        [Parameter(Mandatory = $true)]
        [Double]$Latitude,

        [Parameter(Mandatory = $true)]
        [Double]$Longitude,

        [Parameter(Mandatory = $true)]
        [Double]$UtcOffsetHours,

        [Parameter(Mandatory = $false)]
        [Switch]$ShafiMethod
    )

    process {
        # 0. Dynamically calculate Standard Meridian (lambda_sm)
        # Earth rotates 15 degrees per hour
        $lambdaSm = $UtcOffsetHours * 15.0

        # 1. Coordinate Boundaries to Radians
        $phi = [Math]::PI * $Latitude / 180.0  
        $lambdaLoc = $Longitude             

        # 2. Extract Calendar Constants
        $n = $Date.DayOfYear
        $gamma = (2 * [Math]::PI / 365) * ($n - 1)

        # 3. Compute Solar Declination (delta) in Radians
        $delta = 0.006918 - 
        (0.399912 * [Math]::Cos($gamma)) + 
        (0.070257 * [Math]::Sin($gamma)) - 
        (0.006758 * [Math]::Cos(2 * $gamma)) + 
        (0.000907 * [Math]::Sin(2 * $gamma)) - 
        (0.002697 * [Math]::Cos(3 * $gamma)) + 
        (0.00148 * [Math]::Sin(3 * $gamma))

        # 4. Compute Equation of Time (EoT) in Minutes
        $eot = 229.18 * (0.000075 + 
            (0.001868 * [Math]::Cos($gamma)) - 
            (0.032077 * [Math]::Sin($gamma)) - 
            (0.014615 * [Math]::Cos(2 * $gamma)) - 
            (0.040849 * [Math]::Sin(2 * $gamma)))

        # 5. Calculate Solar Noon (Dhuhr base time) in Decimal Hours
        $dhuhr = 12.0 + (($lambdaSm - $lambdaLoc) / 15.0) - ($eot / 60.0)

        # 6. Set Jurisprudential Multiplier (Hanafi = 2, Shafi'i = 1)
        $a = $ShafiMethod.IsPresent ? 1.0 : 2.0

        # 7. Find Solar Altitude Angle (alpha) for Asr
        $g0 = [Math]::Tan([Math]::Abs($phi - $delta))
        $gAsr = $a + $g0
        $alpha = [Math]::Atan(1.0 / $gAsr)

        # 8. Solve Hour Angle (H) via Spherical Trigonometry
        $cosH = ([Math]::Sin($alpha) - ([Math]::Sin($phi) * [Math]::Sin($delta))) / ([Math]::Cos($phi) * [Math]::Cos($delta))
        
        # Guard against floating-point precision domain exceptions
        $cosH = [Math]::Max(-1.0, [Math]::Min(1.0, $cosH))
        $hRadians = [Math]::Acos($cosH)
        $hDegrees = $hRadians * (180.0 / [Math]::PI)

        # 9. Derive Final Asr Decimal Value & Time Object
        $asrDecimal = $dhuhr + ($hDegrees / 15.0)
        
        $hours = [Math]::Truncate($asrDecimal)
        $minutes = [Math]::Round(($asrDecimal - $hours) * 60)

        # Format output as [DateTime] type to ensure seamless pipeline compatibility
        $timeSpan = New-TimeSpan -Hours $hours -Minutes $minutes
        $asrDateTime = $Date.Date.Add($timeSpan)

        # 10. Generate Output Object
        [PSCustomObject]@{
            Date       = $Date.ToString("yyyy-MM-dd")
            Method     = $ShafiMethod.IsPresent ? "Shafi'i/Standard" : "Hanafi"
            AsrTime24H = $asrDateTime.ToString("HH:mm")
            AsrTime12H = $asrDateTime.ToString("hh:mm tt")
        }
    }
}

# Mumbai Coordinates
$lat = "19.0760"
$lng = "72.8777"
$utcOffset = 5.5
$date = (Get-Date).AddDays(0)  # Today's date
$tzid = [System.TimeZoneInfo]::Local.Id

# --- Execution Framework ---
# Example 1: Standard Execution (Hanafi)
$hanafiAsr = Get-AsrTimeDynamic -Date $date -Latitude $lat -Longitude $lng -UtcOffsetHours $utcOffset

# Example 2: Override to Shafi'i/Standard Execution
$shafiAsr = Get-AsrTimeDynamic -Date $date -Latitude $lat -Longitude $lng -UtcOffsetHours $utcOffset -ShafiMethod


# API URL
$url = "https://api.sunrise-sunset.org/json?lat=$lat&lng=$lng&date=$date&formatted=0&tzid=$tzid"

# Fetch API Data
$response = Invoke-RestMethod -Uri $url

# Approximate Namaz Times
$fajr = Get-Date $response.results.astronomical_twilight_begin
$sunrise = Get-Date $response.results.sunrise
$dhuhr = Get-Date $response.results.solar_noon
$maghrib = Get-Date $response.results.sunset
$isha = Get-Date $response.results.astronomical_twilight_end

# Display Results
Write-Host "`nMumbai ($($date.ToString('dd-MM-yyyy')))" -ForegroundColor Cyan

$data = @(
    [PSCustomObject]@{ Namaz = "Fajr";       Time = $fajr.ToString("HH:mm") }
    [PSCustomObject]@{ Namaz = "Sunrise";    Time = $sunrise.ToString("HH:mm") }
    [PSCustomObject]@{ Namaz = "Dhuhr";      Time = $dhuhr.ToString("HH:mm") }
    [PSCustomObject]@{ Namaz = "Shafi Asr";  Time = $shafiAsr.AsrTime24H }
    [PSCustomObject]@{ Namaz = "Hanafi Asr"; Time = $hanafiAsr.AsrTime24H }
    [PSCustomObject]@{ Namaz = "Maghrib";    Time = $maghrib.ToString("HH:mm") }
    [PSCustomObject]@{ Namaz = "Isha";       Time = $isha.ToString("HH:mm") }
)

$data | Format-Table `
    @{Label="Namaz"; Expression={$_.Namaz}; Width=20}, `
    @{Label="Time";  Expression={$_.Time}; Width=10}


# It will calculate lambda_sm as 60.0 (4 * 15) behind the scenes
# Get-AsrTimeDynamic -Date $date -Latitude 25.2048 -Longitude 55.2708 -UtcOffsetHours 4 -ShafiMethod
