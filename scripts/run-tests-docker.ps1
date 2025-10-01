# PowerShell script to run unit tests in Docker container
# Usage: .\scripts\run-tests-docker.ps1

Write-Host "=== Running Unit Tests in Docker Container ===" -ForegroundColor Magenta
Write-Host ""

# Clean previous test results
if (Test-Path "test-results") {
    Remove-Item -Recurse -Force "test-results"
    Write-Host "Cleaned previous test results" -ForegroundColor Yellow
}

# Create test results directory
New-Item -ItemType Directory -Path "test-results" -Force | Out-Null

Write-Host "Building Docker image for unit tests..." -ForegroundColor Cyan
docker build -f Dockerfile.tests -t backendwebservice-tests .

if ($LASTEXITCODE -ne 0) {
    Write-Host "❌ Docker build failed!" -ForegroundColor Red
    exit $LASTEXITCODE
}

Write-Host "✅ Docker image built successfully!" -ForegroundColor Green
Write-Host ""

Write-Host "Running unit tests in Docker container..." -ForegroundColor Cyan
docker run --rm -v "${PWD}/test-results:/src/test-results" backendwebservice-tests

if ($LASTEXITCODE -eq 0) {
    Write-Host ""
    Write-Host "✅ Unit tests completed successfully in Docker!" -ForegroundColor Green
    Write-Host "📊 Coverage data: ./test-results/coverage/" -ForegroundColor Cyan
    Write-Host "📋 HTML report: ./test-results/coverage-report/index.html" -ForegroundColor Cyan
    Write-Host ""
    
    # Check if HTML report exists and open it
    if (Test-Path "test-results/coverage-report/index.html") {
        Write-Host "Opening coverage report in default browser..." -ForegroundColor Yellow
        Start-Process "test-results/coverage-report/index.html"
    }
} else {
    Write-Host "❌ Unit tests failed in Docker container!" -ForegroundColor Red
    exit $LASTEXITCODE
}
