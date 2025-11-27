# Code Coverage Configuration and Usage

This document explains how to run code coverage analysis for the BackendWebService project.

## Overview

The project is configured with comprehensive code coverage tools to measure test coverage and generate detailed reports. This helps track which parts of the code are tested and identify areas that need additional test coverage.

## Tools Used

- **Coverlet**: Code coverage collection during test execution
- **ReportGenerator**: HTML report generation from coverage data
- **xUnit**: Testing framework
- **FluentAssertions**: Readable test assertions

## Configuration

### Coverage Settings

The test project is configured with the following coverage settings:

- **Coverage Threshold**: 80% minimum for line, branch, and method coverage
- **Output Formats**: Cobertura XML and OpenCover XML
- **Exclusions**: Migrations, bin/obj folders, and generated code
- **Output Directory**: `./test-results/coverage/`

### Coverage Thresholds

- **Line Coverage**: 80%
- **Branch Coverage**: 80%
- **Method Coverage**: 80%

## Running Coverage Analysis

### Quick Start (Recommended)

Run the complete coverage analysis with a single command:

**PowerShell:**
```powershell
.\scripts\run-full-coverage.ps1
```

**Command Prompt:**
```cmd
scripts\run-full-coverage.bat
```

This will:
1. Run all tests with coverage collection
2. Generate an HTML report
3. Open the report in your default browser

### Step-by-Step Process

#### 1. Run Tests with Coverage

**PowerShell:**
```powershell
.\scripts\run-tests-with-coverage.ps1
```

**Command Prompt:**
```cmd
scripts\run-tests-with-coverage.bat
```

**Manual Command:**
```bash
dotnet test BackendWebService.Domain.UnitTests/BackendWebService.Domain.UnitTests.csproj --collect:"XPlat Code Coverage" --results-directory "./test-results"
```

#### 2. Generate HTML Report

**PowerShell:**
```powershell
.\scripts\generate-coverage-report.ps1
```

**Command Prompt:**
```cmd
scripts\generate-coverage-report.bat
```

**Manual Command:**
```bash
reportgenerator -reports:"test-results/coverage/coverage.cobertura.xml" -targetdir:"test-results/coverage-report" -reporttypes:"Html"
```

## Output Structure

```
test-results/
├── coverage/                    # Raw coverage data
│   └── coverage.cobertura.xml   # Cobertura format
├── coverage-report/             # HTML report
│   ├── index.html              # Main report page
│   └── ...                     # Additional report files
└── test-results.trx            # Test execution results
```

## Reading the Coverage Report

The HTML report provides:

### Summary View
- Overall coverage percentages (line, branch, method)
- Coverage trend over time
- Files with lowest coverage

### Detailed View
- Per-class coverage breakdown
- Line-by-line coverage highlighting
- Branch coverage analysis
- Method coverage statistics

### Navigation
- Drill down from project → namespace → class → method
- Filter by coverage percentage
- Search for specific files or classes

## Coverage Thresholds

The build will fail if coverage falls below the configured thresholds:

- **Line Coverage**: Must be ≥ 80%
- **Branch Coverage**: Must be ≥ 80%
- **Method Coverage**: Must be ≥ 80%

## Excluded Files

The following are excluded from coverage analysis:

- Migration files (`**/Migrations/**`)
- Build artifacts (`**/bin/**`, `**/obj/**`)
- Generated code (marked with `Obsolete`, `GeneratedCodeAttribute`, `CompilerGeneratedAttribute`)

## Troubleshooting

### Common Issues

1. **No coverage data found**
   - Ensure tests are run with the `--collect:"XPlat Code Coverage"` parameter
   - Check that the test project builds successfully

2. **Report generation fails**
   - Verify ReportGenerator is installed: `dotnet tool list -g`
   - Check that coverage files exist in `test-results/coverage/`

3. **Coverage threshold not met**
   - Review the HTML report to identify uncovered code
   - Add additional tests for uncovered areas
   - Consider if exclusions are appropriate

### Installing ReportGenerator

If ReportGenerator is not installed:

```bash
dotnet tool install -g dotnet-reportgenerator-globaltool
```

## Best Practices

1. **Run coverage regularly** during development
2. **Review reports** to identify testing gaps
3. **Maintain thresholds** to ensure quality
4. **Exclude appropriate files** (generated code, migrations)
5. **Focus on critical paths** for high coverage

## Integration with CI/CD

The coverage configuration is designed to work with continuous integration:

- Coverage data is collected during test execution
- Thresholds ensure minimum coverage requirements
- Reports can be published as build artifacts
- Coverage trends can be tracked over time

## Additional Resources

- [Coverlet Documentation](https://github.com/coverlet-coverage/coverlet)
- [ReportGenerator Documentation](https://github.com/danielpalme/ReportGenerator)
- [xUnit Documentation](https://xunit.net/)
- [FluentAssertions Documentation](https://fluentassertions.com/)
