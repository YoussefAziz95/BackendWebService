# PowerShell script to generate HTML coverage report
# Usage: .\scripts\generate-coverage-report.ps1

Write-Host "Generating HTML coverage report..." -ForegroundColor Green

# Check if coverage data exists
$coverageDir = "test-results"
if (-not (Test-Path $coverageDir)) {
    Write-Host "❌ Coverage data not found. Please run tests with coverage first." -ForegroundColor Red
    Write-Host "Run: .\scripts\run-tests-with-coverage.ps1" -ForegroundColor Yellow
    exit 1
}

# Find the latest coverage file
$coverageFiles = Get-ChildItem -Path $coverageDir -Filter "coverage.cobertura.xml" -Recurse
if ($coverageFiles.Count -eq 0) {
    Write-Host "❌ No Cobertura coverage files found in $coverageDir" -ForegroundColor Red
    exit 1
}

$latestCoverageFile = $coverageFiles | Sort-Object LastWriteTime -Descending | Select-Object -First 1
Write-Host "Using coverage file: $($latestCoverageFile.FullName)" -ForegroundColor Cyan

# Create report directory
$reportDir = "test-results/coverage-report"
if (Test-Path $reportDir) {
    Remove-Item -Recurse -Force $reportDir
}
New-Item -ItemType Directory -Path $reportDir -Force | Out-Null

# Generate HTML report
Write-Host "Generating HTML report..." -ForegroundColor Cyan
reportgenerator `
    -reports:"$($latestCoverageFile.FullName)" `
    -targetdir:"$reportDir" `
    -reporttypes:"Html" `
    -title:"BackendWebService Domain Code Coverage Report" `
    -verbosity:"Info"

if ($LASTEXITCODE -eq 0) {
    Write-Host "✅ HTML coverage report generated successfully!" -ForegroundColor Green
    Write-Host "Report location: $reportDir/index.html" -ForegroundColor Cyan
    Write-Host "Opening report in default browser..." -ForegroundColor Yellow
    
    # Open the report in default browser
    Start-Process "$reportDir/index.html"
} else {
    Write-Host "❌ Failed to generate coverage report!" -ForegroundColor Red
    exit $LASTEXITCODE
}
