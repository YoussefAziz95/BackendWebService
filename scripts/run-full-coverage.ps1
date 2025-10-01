# PowerShell script to run tests with coverage and generate HTML report
# Usage: .\scripts\run-full-coverage.ps1

Write-Host "=== BackendWebService Code Coverage Analysis ===" -ForegroundColor Magenta
Write-Host ""

# Step 1: Run tests with coverage
Write-Host "Step 1: Running tests with coverage collection..." -ForegroundColor Green
& ".\scripts\run-tests-with-coverage.ps1"

if ($LASTEXITCODE -ne 0) {
    Write-Host "❌ Test execution failed. Stopping." -ForegroundColor Red
    exit $LASTEXITCODE
}

Write-Host ""
Write-Host "Step 2: Generating HTML coverage report..." -ForegroundColor Green
& ".\scripts\generate-coverage-report.ps1"

if ($LASTEXITCODE -ne 0) {
    Write-Host "❌ Report generation failed." -ForegroundColor Red
    exit $LASTEXITCODE
}

Write-Host ""
Write-Host "=== Coverage Analysis Complete ===" -ForegroundColor Magenta
Write-Host "📊 Coverage data: ./test-results/coverage/" -ForegroundColor Cyan
Write-Host "📋 HTML report: ./test-results/coverage-report/index.html" -ForegroundColor Cyan
Write-Host ""
Write-Host "✅ All done! Check the HTML report for detailed coverage information." -ForegroundColor Green
