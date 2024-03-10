@echo off
setlocal

set mypath=%cd%\Images
echo path %mypath%
rmdir /s /q %mypath%
mkdir %mypath%
rem Create 10 empty PNG files
for /l %%i in (1, 1, 10) do (
    copy /y nul "%mypath%\art-%%i.png" > nul
)

echo Empty PNG files created successfully.
set mypath=%mypath%\OtherFolder
echo path %mypath%
mkdir %mypath%
rem Create 10 empty PNG files
for /l %%i in (1, 1, 10) do (
    copy /y nul "%mypath%\art-deep-%%i.png" > nul
)
echo Empty PNG files created successfully.
endlocal