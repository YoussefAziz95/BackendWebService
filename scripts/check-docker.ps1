# PowerShell script to check Docker status and provide setup instructions
# Usage: .\scripts\check-docker.ps1

Write-Host "=== Docker Environment Check ===" -ForegroundColor Magenta
Write-Host ""

# Check if Docker is installed
try {
    $dockerVersion = docker --version 2>$null
    if ($dockerVersion) {
        Write-Host "✅ Docker is installed: $dockerVersion" -ForegroundColor Green
    } else {
        Write-Host "❌ Docker is not installed or not in PATH" -ForegroundColor Red
        Write-Host "Please install Docker Desktop from: https://www.docker.com/products/docker-desktop" -ForegroundColor Yellow
        exit 1
    }
} catch {
    Write-Host "❌ Docker is not installed or not in PATH" -ForegroundColor Red
    Write-Host "Please install Docker Desktop from: https://www.docker.com/products/docker-desktop" -ForegroundColor Yellow
    exit 1
}

# Check if Docker daemon is running
try {
    $dockerInfo = docker info 2>$null
    if ($LASTEXITCODE -eq 0) {
        Write-Host "✅ Docker daemon is running" -ForegroundColor Green
    } else {
        Write-Host "❌ Docker daemon is not running" -ForegroundColor Red
        Write-Host "Please start Docker Desktop" -ForegroundColor Yellow
        Write-Host "On Windows: Start Docker Desktop from Start Menu" -ForegroundColor Yellow
        Write-Host "On Mac: Start Docker Desktop from Applications" -ForegroundColor Yellow
        Write-Host "On Linux: Run 'sudo systemctl start docker'" -ForegroundColor Yellow
        exit 1
    }
} catch {
    Write-Host "❌ Docker daemon is not running" -ForegroundColor Red
    Write-Host "Please start Docker Desktop" -ForegroundColor Yellow
    exit 1
}

# Check if Docker Compose is available
try {
    $composeVersion = docker-compose --version 2>$null
    if ($composeVersion) {
        Write-Host "✅ Docker Compose is available: $composeVersion" -ForegroundColor Green
    } else {
        Write-Host "⚠️  Docker Compose not found, but Docker Compose V2 should be available" -ForegroundColor Yellow
    }
} catch {
    Write-Host "⚠️  Docker Compose not found, but Docker Compose V2 should be available" -ForegroundColor Yellow
}

Write-Host ""
Write-Host "✅ Docker environment is ready!" -ForegroundColor Green
Write-Host "You can now run unit tests in Docker using:" -ForegroundColor Cyan
Write-Host "  .\scripts\run-tests-docker.ps1" -ForegroundColor White
Write-Host "  docker-compose -f docker-compose.tests.yml up --build" -ForegroundColor White
