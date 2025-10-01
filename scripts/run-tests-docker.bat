@echo off
REM Batch script to run unit tests in Docker container
REM Usage: scripts\run-tests-docker.bat

echo === Running Unit Tests in Docker Container ===
echo.

REM Clean previous test results
if exist "test-results" (
    rmdir /s /q "test-results"
    echo Cleaned previous test results
)

REM Create test results directory
mkdir "test-results" 2>nul

echo Building Docker image for unit tests...
docker build -f Dockerfile.tests -t backendwebservice-tests .

if %ERRORLEVEL% neq 0 (
    echo Docker build failed!
    exit /b %ERRORLEVEL%
)

echo Docker image built successfully!
echo.

echo Running unit tests in Docker container...
docker run --rm -v "%CD%\test-results:/src/test-results" backendwebservice-tests

if %ERRORLEVEL% equ 0 (
    echo.
    echo Unit tests completed successfully in Docker!
    echo Coverage data: ./test-results/coverage/
    echo HTML report: ./test-results/coverage-report/index.html
    echo.
    
    REM Check if HTML report exists and open it
    if exist "test-results\coverage-report\index.html" (
        echo Opening coverage report in default browser...
        start "" "test-results\coverage-report\index.html"
    )
) else (
    echo Unit tests failed in Docker container!
    exit /b %ERRORLEVEL%
)
