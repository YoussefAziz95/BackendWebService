# Generate Unified Coverage Report for All Layers
# This script runs all unit tests and generates a unified coverage report

param(
    [string]$OutputDir = "test-results/coverage-report-unified",
    [string]$Configuration = "Release"
)

Write-Host "Starting unified coverage report generation..." -ForegroundColor Green

# Clean previous results
if (Test-Path "test-results") {
    Remove-Item -Recurse -Force "test-results"
    Write-Host "Cleaned previous test results" -ForegroundColor Yellow
}

# Create test results directory
New-Item -ItemType Directory -Path "test-results" -Force | Out-Null

Write-Host "Running Application Layer Unit Tests..." -ForegroundColor Cyan
dotnet test BackendWebService.Application.UnitTests/BackendWebService.Application.UnitTests.csproj `
    --no-build `
    --no-restore `
    --collect:"XPlat Code Coverage" `
    --results-directory "test-results" `
    --logger "trx;LogFileName=application-test-results.trx" `
    --verbosity normal `
    --configuration $Configuration

if ($LASTEXITCODE -ne 0) {
    Write-Error "Application layer tests failed"
    exit 1
}

Write-Host "Running Persistence Layer Unit Tests..." -ForegroundColor Cyan
dotnet test BackendWebService.Persistence.UnitTests/BackendWebService.Persistence.UnitTests.csproj `
    --no-build `
    --no-restore `
    --collect:"XPlat Code Coverage" `
    --results-directory "test-results" `
    --logger "trx;LogFileName=persistence-test-results.trx" `
    --verbosity normal `
    --configuration $Configuration

if ($LASTEXITCODE -ne 0) {
    Write-Error "Persistence layer tests failed"
    exit 1
}

Write-Host "Collecting coverage files..." -ForegroundColor Cyan
$coverageFiles = Get-ChildItem test-results -Recurse -Filter "coverage.cobertura.xml" | ForEach-Object { $_.FullName }

if ($coverageFiles.Count -eq 0) {
    Write-Error "No coverage files found"
    exit 1
}

Write-Host "Found $($coverageFiles.Count) coverage files:" -ForegroundColor Green
$coverageFiles | ForEach-Object { Write-Host "  - $_" -ForegroundColor Gray }

Write-Host "Generating unified coverage report..." -ForegroundColor Cyan
$coverageFilesString = $coverageFiles -join ";"
reportgenerator -reports:"$coverageFilesString" -targetdir:"$OutputDir" -reporttypes:"Html" -title:"BackendWebService Unified Unit Test Coverage Report" -verbosity:"Info"

if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to generate unified coverage report"
    exit 1
}

Write-Host "Unified coverage report generated successfully!" -ForegroundColor Green
Write-Host "Report location: $OutputDir/index.html" -ForegroundColor Yellow

# Display coverage summary
Write-Host "`nCoverage Summary:" -ForegroundColor Cyan
Write-Host "=================" -ForegroundColor Cyan

# Extract coverage statistics from the HTML report
$indexContent = Get-Content "$OutputDir/index.html" -Raw
$lineMatch = [regex]::Match($indexContent, 'Line coverage:.*?(\d+\.?\d*)%')
$branchMatch = [regex]::Match($indexContent, 'Branch coverage:.*?(\d+\.?\d*)%')

if ($lineMatch.Success) {
    Write-Host "Line Coverage: $($lineMatch.Groups[1].Value)%" -ForegroundColor $(if ([double]$lineMatch.Groups[1].Value -ge 80) { "Green" } else { "Red" })
}

if ($branchMatch.Success) {
    Write-Host "Branch Coverage: $($branchMatch.Groups[1].Value)%" -ForegroundColor $(if ([double]$branchMatch.Groups[1].Value -ge 80) { "Green" } else { "Red" })
}

Write-Host "`nTo view the report, open: $OutputDir/index.html" -ForegroundColor Yellow
