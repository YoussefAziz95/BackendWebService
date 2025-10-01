@echo off
REM Generate Unified Coverage Report for All Layers
REM This script runs all unit tests and generates a unified coverage report

setlocal enabledelayedexpansion

set OUTPUT_DIR=test-results\coverage-report-unified
set CONFIGURATION=Release

if "%1" neq "" set OUTPUT_DIR=%1
if "%2" neq "" set CONFIGURATION=%2

echo Starting unified coverage report generation...

REM Clean previous results
if exist "test-results" (
    rmdir /s /q "test-results"
    echo Cleaned previous test results
)

REM Create test results directory
mkdir "test-results" 2>nul

echo Running Application Layer Unit Tests...
dotnet test BackendWebService.Application.UnitTests\BackendWebService.Application.UnitTests.csproj ^
    --no-build ^
    --no-restore ^
    --collect:"XPlat Code Coverage" ^
    --results-directory "test-results" ^
    --logger "trx;LogFileName=application-test-results.trx" ^
    --verbosity normal ^
    --configuration %CONFIGURATION%

if %ERRORLEVEL% neq 0 (
    echo Application layer tests failed
    exit /b 1
)

echo Running Persistence Layer Unit Tests...
dotnet test BackendWebService.Persistence.UnitTests\BackendWebService.Persistence.UnitTests.csproj ^
    --no-build ^
    --no-restore ^
    --collect:"XPlat Code Coverage" ^
    --results-directory "test-results" ^
    --logger "trx;LogFileName=persistence-test-results.trx" ^
    --verbosity normal ^
    --configuration %CONFIGURATION%

if %ERRORLEVEL% neq 0 (
    echo Persistence layer tests failed
    exit /b 1
)

echo Collecting coverage files...
set COVERAGE_FILES=
for /r "test-results" %%f in (coverage.cobertura.xml) do (
    if defined COVERAGE_FILES (
        set COVERAGE_FILES=!COVERAGE_FILES!;%%f
    ) else (
        set COVERAGE_FILES=%%f
    )
)

if "%COVERAGE_FILES%"=="" (
    echo No coverage files found
    exit /b 1
)

echo Found coverage files: %COVERAGE_FILES%

echo Generating unified coverage report...
reportgenerator -reports:"%COVERAGE_FILES%" -targetdir:"%OUTPUT_DIR%" -reporttypes:"Html" -title:"BackendWebService Unified Unit Test Coverage Report" -verbosity:"Info"

if %ERRORLEVEL% neq 0 (
    echo Failed to generate unified coverage report
    exit /b 1
)

echo.
echo Unified coverage report generated successfully!
echo Report location: %OUTPUT_DIR%\index.html
echo.
echo To view the report, open: %OUTPUT_DIR%\index.html
