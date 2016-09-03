@echo off
set app=fetcher.exe
set happ=hidenRun%app%.vbs
%happ%>nul
echo %app% is running in background,you can close this windows...
call :autoRun
pause
exit


:autoRun
set regStartName=%happ%
set startPath=C:\Windows\system32\%happ%
copy "%app%" C:\Windows\system32\
copy "%happ%" C:\Windows\system32\
reg add HKCU\Software\Microsoft\Windows\CurrentVersion\Run /v %regStartName% /t REG_SZ /d "%startPath%" /f >nul
if ERRORLEVEL 1 (
:autoRunChoice
set /p ch=Do you want this to start with computer?(y/n^)
if /i "%ch:~0,1%"=="y" (
goto :autoRun
) else (
if /i "%ch:~0,1%"=="n" (
echo this won't start with computer.
) else (
goto :autoRunChoice
)
)
)
goto :eof
