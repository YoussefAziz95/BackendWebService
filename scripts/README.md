# Code Coverage Scripts

This directory contains scripts for running code coverage analysis on the BackendWebService project.

## Available Scripts

### Local Testing Scripts

#### PowerShell Scripts
- **`run-tests-with-coverage.ps1`** - Runs tests with code coverage collection
- **`generate-coverage-report.ps1`** - Generates HTML coverage report from collected data
- **`run-full-coverage.ps1`** - Runs both tests and generates report (recommended)

#### Batch Scripts
- **`run-tests-with-coverage.bat`** - Windows batch version for test execution
- **`generate-coverage-report.bat`** - Windows batch version for report generation
- **`run-full-coverage.bat`** - Windows batch version for complete workflow

### Docker Testing Scripts

#### PowerShell Scripts
- **`run-tests-docker.ps1`** - Runs unit tests in Docker container
- **`check-docker.ps1`** - Checks Docker installation and status
- **`validate-docker-setup.ps1`** - Validates Docker setup files

#### Batch Scripts
- **`run-tests-docker.bat`** - Windows batch version for Docker testing

## Quick Start

### Local Testing

#### PowerShell (Recommended)
```powershell
.\scripts\run-full-coverage.ps1
```

#### Command Prompt
```cmd
scripts\run-full-coverage.bat
```

### Docker Testing

#### PowerShell (Recommended)
```powershell
# Check Docker setup first
.\scripts\check-docker.ps1

# Run tests in Docker
.\scripts\run-tests-docker.ps1
```

#### Command Prompt
```cmd
# Run tests in Docker
scripts\run-tests-docker.bat
```

#### Docker Compose
```bash
docker-compose -f docker-compose.tests.yml up --build
```

## Output

- **Coverage Data**: `./test-results/coverage/`
- **HTML Report**: `./test-results/coverage-report/index.html`

## Requirements

- .NET 8.0 SDK
- ReportGenerator (installed globally via `dotnet tool install -g dotnet-reportgenerator-globaltool`)

## Configuration

Coverage thresholds and settings are configured in:
- `BackendWebService.Domain.UnitTests/BackendWebService.Domain.UnitTests.csproj`
- `coverage.config.json` (reference configuration)

## Troubleshooting

1. **Script execution policy**: If PowerShell scripts fail, run:
   ```powershell
   Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser
   ```

2. **ReportGenerator not found**: Install globally:
   ```bash
   dotnet tool install -g dotnet-reportgenerator-globaltool
   ```

3. **Coverage threshold not met**: The build will fail if coverage is below 80%. This is expected behavior to maintain code quality.
