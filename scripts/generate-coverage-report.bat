@echo off
REM Batch script to generate HTML coverage report
REM Usage: scripts\generate-coverage-report.bat

echo Generating HTML coverage report...

REM Check if coverage data exists
if not exist "test-results\coverage" (
    echo Coverage data not found. Please run tests with coverage first.
    echo Run: scripts\run-tests-with-coverage.bat
    exit /b 1
)

REM Find the latest coverage file
for /f "delims=" %%i in ('dir /b /s "test-results\coverage\coverage.cobertura.xml" 2^>nul ^| sort /r') do (
    set "LATEST_COVERAGE_FILE=%%i"
    goto :found
)
:found

if not defined LATEST_COVERAGE_FILE (
    echo No Cobertura coverage files found in test-results\coverage
    exit /b 1
)

echo Using coverage file: %LATEST_COVERAGE_FILE%

REM Create report directory
if exist "test-results\coverage-report" rmdir /s /q "test-results\coverage-report"
mkdir "test-results\coverage-report" 2>nul

REM Generate HTML report
echo Generating HTML report...
reportgenerator ^
    -reports:"%LATEST_COVERAGE_FILE%" ^
    -targetdir:"test-results\coverage-report" ^
    -reporttypes:"Html" ^
    -title:"BackendWebService Domain Code Coverage Report" ^
    -verbosity:"Info"

if %ERRORLEVEL% equ 0 (
    echo HTML coverage report generated successfully!
    echo Report location: test-results\coverage-report\index.html
    echo Opening report in default browser...
    start "" "test-results\coverage-report\index.html"
) else (
    echo Failed to generate coverage report!
    exit /b %ERRORLEVEL%
)
