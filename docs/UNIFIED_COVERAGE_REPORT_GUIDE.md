# Unified Coverage Report Guide

This guide explains how to generate and interpret unified coverage reports for the BackendWebService solution.

## Overview

The unified coverage report combines code coverage data from all test projects in the solution to provide a comprehensive view of test coverage across all layers.

## Current Test Projects

- **BackendWebService.Application.UnitTests**: Tests for the Application layer
- **BackendWebService.Persistence.UnitTests**: Tests for the Persistence layer

## Generating the Unified Report

### Method 1: Using PowerShell Script (Recommended)

```powershell
# Run from the solution root directory
.\scripts\generate-unified-coverage-report.ps1

# Or with custom output directory
.\scripts\generate-unified-coverage-report.ps1 -OutputDir "custom-output" -Configuration "Debug"
```

### Method 2: Using Batch File

```cmd
# Run from the solution root directory
scripts\generate-unified-coverage-report.bat

# Or with custom parameters
scripts\generate-unified-coverage-report.bat "custom-output" "Debug"
```

### Method 3: Manual Generation

1. **Run Application Layer Tests:**
   ```cmd
   dotnet test BackendWebService.Application.UnitTests\BackendWebService.Application.UnitTests.csproj --collect:"XPlat Code Coverage" --results-directory "test-results"
   ```

2. **Run Persistence Layer Tests:**
   ```cmd
   dotnet test BackendWebService.Persistence.UnitTests\BackendWebService.Persistence.UnitTests.csproj --collect:"XPlat Code Coverage" --results-directory "test-results"
   ```

3. **Generate Unified Report:**
   ```cmd
   reportgenerator -reports:"test-results\**\coverage.cobertura.xml" -targetdir:"test-results\coverage-report-unified" -reporttypes:"Html" -title:"BackendWebService Unified Unit Test Coverage Report"
   ```

## Report Structure

The unified report includes:

- **Overall Coverage Statistics**: Line, branch, and method coverage percentages
- **Layer-wise Breakdown**: Coverage for each project/layer
- **File-level Coverage**: Detailed coverage for individual files
- **Class-level Coverage**: Coverage for individual classes and methods

## Current Coverage Status

As of the latest generation:

- **Line Coverage**: 0.6% (436 of 64,273 lines)
- **Branch Coverage**: 6.2% (74 of 1,178 branches)

## Coverage Goals

The target coverage thresholds are:

- **Line Coverage**: ≥ 80%
- **Branch Coverage**: ≥ 80%
- **Method Coverage**: ≥ 80%

## Interpreting the Report

### Coverage Types

1. **Line Coverage**: Percentage of executable lines covered by tests
2. **Branch Coverage**: Percentage of conditional branches covered by tests
3. **Method Coverage**: Percentage of methods covered by tests

### Color Coding

- **Green**: High coverage (≥ 80%)
- **Yellow**: Medium coverage (50-79%)
- **Red**: Low coverage (< 50%)

### Key Metrics

- **Covered**: Number of items covered by tests
- **Uncovered**: Number of items not covered by tests
- **Coverable**: Total number of items that can be covered
- **Total**: Total number of items (including non-coverable)

## Improving Coverage

To improve coverage:

1. **Identify Low Coverage Areas**: Use the report to find files/classes with low coverage
2. **Write Additional Tests**: Create unit tests for uncovered code paths
3. **Focus on Critical Paths**: Prioritize testing business-critical functionality
4. **Review Test Quality**: Ensure tests are meaningful and not just for coverage

## Troubleshooting

### Common Issues

1. **No Coverage Files Found**
   - Ensure tests are running successfully
   - Check that Coverlet is properly configured in test projects

2. **Report Generation Fails**
   - Verify ReportGenerator is installed: `dotnet tool install -g dotnet-reportgenerator-globaltool`
   - Check file paths and permissions

3. **Low Coverage Numbers**
   - This is expected for a new test suite
   - Focus on gradually improving coverage over time

### Dependencies

- **.NET 8.0 SDK**
- **ReportGenerator Global Tool**: `dotnet tool install -g dotnet-reportgenerator-globaltool`
- **Coverlet**: Included in test project packages

## Integration with CI/CD

The unified coverage report can be integrated into CI/CD pipelines:

1. **Generate Report**: Run the coverage generation script
2. **Publish Artifacts**: Upload the report as a build artifact
3. **Set Thresholds**: Configure coverage thresholds for build validation
4. **Notify on Changes**: Set up notifications for coverage changes

## Best Practices

1. **Regular Generation**: Generate reports regularly to track progress
2. **Version Control**: Don't commit coverage reports to version control
3. **Documentation**: Document coverage goals and progress
4. **Team Awareness**: Share coverage reports with the development team
5. **Quality Focus**: Prioritize test quality over quantity

## Future Enhancements

Planned improvements:

1. **Integration Test Coverage**: Include integration test coverage
2. **API Test Coverage**: Include API endpoint coverage
3. **Automated Thresholds**: Automatic build failure on low coverage
4. **Trend Analysis**: Track coverage trends over time
5. **Coverage Badges**: Generate coverage badges for README files
