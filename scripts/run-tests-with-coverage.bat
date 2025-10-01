@echo off
REM Batch script to run tests with code coverage collection
REM Usage: scripts\run-tests-with-coverage.bat

echo Running tests with code coverage collection...

REM Clean previous results
if exist "test-results" (
    rmdir /s /q "test-results"
    echo Cleaned previous test results
)

REM Create test results directory
mkdir "test-results" 2>nul
mkdir "test-results\coverage" 2>nul

REM Run tests with coverage collection
echo Executing tests and collecting coverage data...
dotnet test BackendWebService.Domain.UnitTests\BackendWebService.Domain.UnitTests.csproj ^
    --collect:"XPlat Code Coverage" ^
    --results-directory "./test-results" ^
    --logger "trx;LogFileName=test-results.trx" ^
    --verbosity normal

if %ERRORLEVEL% equ 0 (
    echo Tests completed successfully with coverage collection!
    echo Coverage data saved to: ./test-results/coverage/
) else (
    echo Test execution failed!
    exit /b %ERRORLEVEL%
)
