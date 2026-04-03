@echo off

:: Check for admin rights
net session >nul 2>&1
if %errorlevel% neq 0 (
    echo Requesting Administrator privileges...
    powershell -Command "Start-Process '%~f0' -Verb RunAs"
    exit
)

:: Launch Windows Terminal with 3 tabs
wt ^
new-tab -p "PowerShell" --tabColor "#6A5ACD" --title "Azurite" ;^
new-tab -p "PowerShell" --tabColor "#1E90FF" --title "API" -d "C:\" ;^
new-tab -p "PowerShell" --tabColor "#32CD32" --title "UI" -d "C:\"

exit
