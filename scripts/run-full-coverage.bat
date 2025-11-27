@echo off
REM Batch script to run tests with coverage and generate HTML report
REM Usage: scripts\run-full-coverage.bat

echo === BackendWebService Code Coverage Analysis ===
echo.

REM Step 1: Run tests with coverage
echo Step 1: Running tests with coverage collection...
call scripts\run-tests-with-coverage.bat

if %ERRORLEVEL% neq 0 (
    echo Test execution failed. Stopping.
    exit /b %ERRORLEVEL%
)

echo.
echo Step 2: Generating HTML coverage report...
call scripts\generate-coverage-report.bat

if %ERRORLEVEL% neq 0 (
    echo Report generation failed.
    exit /b %ERRORLEVEL%
)

echo.
echo === Coverage Analysis Complete ===
echo Coverage data: ./test-results/coverage/
echo HTML report: ./test-results/coverage-report/index.html
echo.
echo All done! Check the HTML report for detailed coverage information.
