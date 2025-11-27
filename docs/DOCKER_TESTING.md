# Docker Testing Environment

This document explains how to run unit tests in a Docker container for consistent, isolated test execution.

## Overview

The Docker testing environment provides:
- Consistent test execution across different machines
- Isolated environment independent of local setup
- Automated coverage collection and report generation
- Easy CI/CD integration

## Prerequisites

- Docker Desktop installed and running
- Docker Compose (included with Docker Desktop)

## Quick Start

### PowerShell (Recommended)
```powershell
.\scripts\run-tests-docker.ps1
```

### Command Prompt
```cmd
scripts\run-tests-docker.bat
```

### Docker Compose
```bash
docker-compose -f docker-compose.tests.yml up --build
```

## Docker Configuration

### Dockerfile.tests

The `Dockerfile.tests` is a multi-stage build optimized for test execution:

**Stage 1: Test Runner**
- Uses .NET 8.0 SDK base image
- Installs ReportGenerator globally
- Restores NuGet packages (cached layer)
- Builds the solution
- Runs unit tests with coverage collection
- Generates HTML coverage report

**Stage 2: Results Extraction**
- Lightweight Alpine Linux base
- Copies test results from test runner stage
- Sets proper permissions for file access

### Docker Compose

Two compose files are available:

1. **`docker-compose.tests.yml`** - Standalone testing
2. **`docker-compose.yml`** - Includes testing service with profile

## Manual Docker Commands

### Build Test Image
```bash
docker build -f Dockerfile.tests -t backendwebservice-tests .
```

### Run Tests
```bash
docker run --rm -v "${PWD}/test-results:/src/test-results" backendwebservice-tests
```

### Run with Docker Compose
```bash
# Using standalone test compose file
docker-compose -f docker-compose.tests.yml up --build

# Using main compose file with testing profile
docker-compose --profile testing up --build unit-tests
```

## Output Structure

After running tests, the following structure will be created:

```
test-results/
├── coverage/                    # Raw coverage data
│   └── coverage.cobertura.xml   # Cobertura format
├── coverage-report/             # HTML report
│   ├── index.html              # Main report page
│   └── ...                     # Additional report files
└── test-results.trx            # Test execution results
```

## Environment Variables

The Docker container uses these environment variables:

- `DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1` - Skip first-time setup
- `DOTNET_CLI_TELEMETRY_OPTOUT=1` - Disable telemetry

## Volume Mounts

- `./test-results:/src/test-results` - Maps host test results directory to container

## CI/CD Integration

### GitHub Actions Example
```yaml
name: Unit Tests
on: [push, pull_request]

jobs:
  test:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v3
      - name: Run Unit Tests
        run: |
          docker build -f Dockerfile.tests -t backendwebservice-tests .
          docker run --rm -v "$PWD/test-results:/src/test-results" backendwebservice-tests
      - name: Upload Coverage Reports
        uses: actions/upload-artifact@v3
        with:
          name: coverage-report
          path: test-results/coverage-report/
```

### Azure DevOps Example
```yaml
trigger:
- main

pool:
  vmImage: 'ubuntu-latest'

steps:
- task: Docker@2
  displayName: 'Build test image'
  inputs:
    command: 'build'
    dockerfile: 'Dockerfile.tests'
    tags: 'backendwebservice-tests'

- task: Docker@2
  displayName: 'Run unit tests'
  inputs:
    command: 'run'
    containerRegistryEndpoint: ''
    arguments: '--rm -v $(Build.SourcesDirectory)/test-results:/src/test-results backendwebservice-tests'

- task: PublishBuildArtifacts@1
  displayName: 'Publish coverage report'
  inputs:
    pathToPublish: 'test-results/coverage-report'
    artifactName: 'coverage-report'
```

## Troubleshooting

### Common Issues

1. **Permission Denied on Windows**
   ```bash
   # Ensure Docker Desktop has file sharing enabled for the project directory
   # Check Docker Desktop Settings > Resources > File Sharing
   ```

2. **Build Fails with Package Restore**
   ```bash
   # Clear Docker build cache
   docker builder prune -a
   
   # Rebuild without cache
   docker build --no-cache -f Dockerfile.tests -t backendwebservice-tests .
   ```

3. **Volume Mount Not Working**
   ```bash
   # Use absolute path for volume mount
   docker run --rm -v "C:\full\path\to\project\test-results:/src/test-results" backendwebservice-tests
   ```

4. **Tests Fail in Container**
   ```bash
   # Run container interactively for debugging
   docker run -it --rm -v "${PWD}/test-results:/src/test-results" backendwebservice-tests /bin/bash
   ```

### Debugging

1. **Interactive Container**
   ```bash
   docker run -it --rm -v "${PWD}/test-results:/src/test-results" backendwebservice-tests /bin/bash
   ```

2. **Check Container Logs**
   ```bash
   docker logs <container-id>
   ```

3. **Inspect Test Results**
   ```bash
   # After running tests, check the mounted directory
   ls -la test-results/
   ```

## Performance Optimization

### Build Optimization
- NuGet packages are restored in a separate layer for caching
- Multi-stage build reduces final image size
- Only necessary files are copied to final stage

### Runtime Optimization
- Tests run in Release configuration
- Coverage collection is optimized for container environment
- Report generation happens in the same container

## Security Considerations

- Container runs with minimal privileges
- No sensitive data is included in the image
- Volume mounts are read-only where possible
- Environment variables are used for configuration

## Best Practices

1. **Regular Updates**: Keep base images updated
2. **Cache Management**: Use `.dockerignore` to exclude unnecessary files
3. **Resource Limits**: Set appropriate memory and CPU limits
4. **Cleanup**: Remove unused images and containers regularly
5. **Monitoring**: Monitor test execution time and resource usage

## Advanced Usage

### Custom Test Configuration
```bash
# Run specific test categories
docker run --rm -v "${PWD}/test-results:/src/test-results" \
  -e TEST_CATEGORY="Integration" \
  backendwebservice-tests
```

### Parallel Test Execution
```bash
# Run multiple test containers in parallel
docker run --rm -v "${PWD}/test-results-1:/src/test-results" backendwebservice-tests &
docker run --rm -v "${PWD}/test-results-2:/src/test-results" backendwebservice-tests &
wait
```

### Custom Coverage Thresholds
```bash
# Override coverage thresholds
docker run --rm -v "${PWD}/test-results:/src/test-results" \
  -e COVERAGE_THRESHOLD="90" \
  backendwebservice-tests
```
