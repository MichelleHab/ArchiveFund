@echo off
for %%i in (*.html) do (
    ren %%i %%~ni.htm
)
