# PowerShell script to validate Docker setup without running containers
# Usage: .\scripts\validate-docker-setup.ps1

Write-Host "=== Docker Setup Validation ===" -ForegroundColor Magenta
Write-Host ""

# Check if required files exist
$requiredFiles = @(
    "Dockerfile.tests",
    "docker-compose.tests.yml",
    "docker-compose.yml",
    ".dockerignore"
)

$allFilesExist = $true
foreach ($file in $requiredFiles) {
    if (Test-Path $file) {
        Write-Host "✅ $file exists" -ForegroundColor Green
    } else {
        Write-Host "❌ $file is missing" -ForegroundColor Red
        $allFilesExist = $false
    }
}

# Check if scripts exist
$requiredScripts = @(
    "scripts/run-tests-docker.ps1",
    "scripts/run-tests-docker.bat",
    "scripts/check-docker.ps1"
)

foreach ($script in $requiredScripts) {
    if (Test-Path $script) {
        Write-Host "✅ $script exists" -ForegroundColor Green
    } else {
        Write-Host "❌ $script is missing" -ForegroundColor Red
        $allFilesExist = $false
    }
}

# Check if documentation exists
if (Test-Path "docs/DOCKER_TESTING.md") {
    Write-Host "✅ Docker documentation exists" -ForegroundColor Green
} else {
    Write-Host "❌ Docker documentation is missing" -ForegroundColor Red
    $allFilesExist = $false
}

Write-Host ""

if ($allFilesExist) {
    Write-Host "✅ All Docker setup files are present!" -ForegroundColor Green
    Write-Host ""
    Write-Host "Next steps:" -ForegroundColor Cyan
    Write-Host "1. Ensure Docker Desktop is installed and running" -ForegroundColor White
    Write-Host "2. Run: .\scripts\check-docker.ps1" -ForegroundColor White
    Write-Host "3. Run: .\scripts\run-tests-docker.ps1" -ForegroundColor White
} else {
    Write-Host "❌ Some required files are missing!" -ForegroundColor Red
    Write-Host "Please ensure all Docker setup files are created properly." -ForegroundColor Yellow
    exit 1
}
