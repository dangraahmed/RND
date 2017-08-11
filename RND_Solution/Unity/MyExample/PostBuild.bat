set projectdir=%1
set targetdir=%2

cd projectdir

copy ..\..\..\ApplePhone\bin\Debug\ApplePhone.dll %targetdir%
copy ..\..\..\NokiaPhone\bin\Debug\NokiaPhone.dll %targetdir%
copy ..\..\..\SamsungPhone\bin\Debug\SamsungPhone.dll %targetdir%
copy ..\..\..\LoggingTypes\bin\Debug\LoggingTypes.dll %targetdir%