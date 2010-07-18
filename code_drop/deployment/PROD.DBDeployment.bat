@echo off

SET DIR=%~d0%~p0%

SET deploy.settings="%DIR%..\settings\Production.settings"

"%DIR%NAnt\nant.exe" /f:"%DIR%scripts\database.deploy" -D:deploy.settings=%deploy.settings%

pause