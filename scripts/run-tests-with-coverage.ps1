# PowerShell script to run tests with code coverage collection
# Usage: .\scripts\run-tests-with-coverage.ps1

Write-Host "Running tests with code coverage collection..." -ForegroundColor Green

# Clean previous results
if (Test-Path "test-results") {
    Remove-Item -Recurse -Force "test-results"
    Write-Host "Cleaned previous test results" -ForegroundColor Yellow
}

# Create test results directory
New-Item -ItemType Directory -Path "test-results" -Force | Out-Null
New-Item -ItemType Directory -Path "test-results/coverage" -Force | Out-Null

# Run tests with coverage collection
Write-Host "Executing tests and collecting coverage data..." -ForegroundColor Cyan
dotnet test BackendWebService.Domain.UnitTests/BackendWebService.Domain.UnitTests.csproj `
    --collect:"XPlat Code Coverage" `
    --results-directory "./test-results" `
    --logger "trx;LogFileName=test-results.trx" `
    --verbosity normal

if ($LASTEXITCODE -eq 0) {
    Write-Host "✅ Tests completed successfully with coverage collection!" -ForegroundColor Green
    Write-Host "Coverage data saved to: ./test-results/coverage/" -ForegroundColor Cyan
} else {
    Write-Host "❌ Test execution failed!" -ForegroundColor Red
    exit $LASTEXITCODE
}
