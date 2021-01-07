
REM NOTE: This script assumes that both nuget.exe is installed and on the %PATH%
REM       and that is is run from Visual Studo's Developer Command Prompt

SET _configuration=Debug
IF /I "%1" == "-release" SET _configuration=Release

msbuild ..\src\Sample.StudioX.Activities.sln -p:Configuration=%_configuration%
nuget pack ..\src\Sample.StudioX.Activities -OutputDir ..\Output\%_configuration% -properties tfm="net461"