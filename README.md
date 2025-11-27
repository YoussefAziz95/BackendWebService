# BackendWebService

A comprehensive .NET 8.0 backend web service solution with a clean architecture approach.

## Solution Structure

- **BackendWebService.Api**: Main API project with controllers and endpoints
- **BackendWebService.Application**: Application layer with business logic and feature handlers
- **BackendWebService.Domain**: Domain layer with entities and business rules
- **BackendWebService.Persistence**: Data access layer with repositories and DbContext
- **BackendWebService.SharedKernal**: Shared utilities and extensions
- **BackendWebService.CrossCuttingConcerns**: Cross-cutting concerns and services

## Testing

The solution includes comprehensive unit testing across multiple layers:

### Test Projects

- **BackendWebService.Application.UnitTests**: Unit tests for the Application layer
- **BackendWebService.Persistence.UnitTests**: Unit tests for the Persistence layer
- **BackendWebService.Domain.UnitTests**: Unit tests for the Domain layer

### Code Coverage

The solution maintains comprehensive code coverage reporting with unified coverage reports across all layers.

#### Current Coverage Status

- **Line Coverage**: 0.6% (436 of 64,273 lines)
- **Branch Coverage**: 6.2% (74 of 1,178 branches)

#### Coverage Goals

- **Line Coverage**: ≥ 80%
- **Branch Coverage**: ≥ 80%
- **Method Coverage**: ≥ 80%

### Generating Coverage Reports

#### Quick Start

```powershell
# Generate unified coverage report
.\scripts\generate-unified-coverage-report.ps1
```

#### Manual Generation

```cmd
# Run all tests with coverage collection
dotnet test --collect:"XPlat Code Coverage" --results-directory "test-results"

# Generate unified report
reportgenerator -reports:"test-results\**\coverage.cobertura.xml" -targetdir:"test-results\coverage-report-unified" -reporttypes:"Html"
```

#### Viewing Reports

Open `test-results/coverage-report-unified/index.html` in your browser to view the detailed coverage report.

## Docker Support

The solution includes Docker support for both the main application and testing:

### Running Tests in Docker

```bash
# Build and run tests in Docker
docker-compose -f docker-compose.tests.yml up --build
```

### Main Application

```bash
# Run the main application
docker-compose up --build
```

## Development

### Prerequisites

- .NET 8.0 SDK
- Visual Studio 2022 or VS Code
- SQL Server (for local development)
- Docker (optional)

### Running the Solution

1. **Clone the repository**
2. **Restore packages**: `dotnet restore`
3. **Update database**: `dotnet ef database update` (from Persistence project)
4. **Run the application**: `dotnet run --project BackendWebService.Api`

### Running Tests

```cmd
# Run all tests
dotnet test

# Run specific test project
dotnet test BackendWebService.Application.UnitTests

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"
```

## Documentation

Comprehensive documentation is available in the `docs/` directory:

- [Testing Guidelines](docs/TESTING_STANDARDS_AND_GUIDELINES.md)
- [Unified Coverage Report Guide](docs/UNIFIED_COVERAGE_REPORT_GUIDE.md)
- [Application Layer Testing](docs/APPLICATION_LAYER_TESTING_GUIDELINES.md)
- [Persistence Layer Testing](docs/PERSISTENCE_LAYER_TESTING_GUIDELINES.md)
- [Docker Testing](docs/DOCKER_TESTING.md)

## Scripts

Useful scripts are available in the `scripts/` directory:

- `generate-unified-coverage-report.ps1`: Generate unified coverage reports
- `run-all-tests.ps1`: Run all tests across all projects
- `setup-test-environment.ps1`: Set up the test environment

## Contributing

1. Follow the established coding standards
2. Write unit tests for new features
3. Ensure all tests pass before submitting
4. Update documentation as needed
5. Maintain or improve code coverage

## License

This project is licensed under the MIT License.
