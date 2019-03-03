echo off

set config=%1
if "%config%" == "" (
   set config=Release
)

REM Restore packages
call "%nuget%" restore "UXC.Utils.sln" -NonInteractive

REM Build
"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" "UXC.Utils.sln" /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false
