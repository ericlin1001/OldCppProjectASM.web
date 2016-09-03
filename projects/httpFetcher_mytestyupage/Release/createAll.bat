@echo off
set app=fetcher.exe
set happ=hidenRun%app%.vbs

copy httpRequest.exe %app%
echo createObject("wscript.shell").run "%app%",0 >%happ%