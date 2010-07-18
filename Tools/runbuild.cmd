powershell -Command "& {Import-Module .\PSake\psake.psm1; Invoke-psake .\build.ps1 %*}"
pause