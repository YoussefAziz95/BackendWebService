# Testing Quick Reference Guide

## Quick Commands

### Run Tests
```bash
# All tests
dotnet test

# Specific project
dotnet test BackendWebService.Domain.UnitTests

# With coverage
.\scripts\run-full-coverage.ps1

# Docker
.\scripts\run-tests-docker.ps1
```

### Test Naming
```csharp
// Test class
[ClassName]Tests

// Test method
MethodName_Scenario_ExpectedResult
```

### Test Structure
```csharp
[Fact]
public void MethodName_Scenario_ExpectedResult()
{
    // Arrange
    var input = CreateTestData();
    
    // Act
    var result = MethodUnderTest(input);
    
    // Assert
    result.Should().Be(expected);
}
```

### Coverage Targets
- **Domain**: 95%+ line coverage
- **Application**: 85%+ line coverage  
- **Persistence**: 75%+ line coverage
- **Overall**: 80%+ line coverage

### Common Assertions
```csharp
// Basic assertions
value.Should().Be(expected);
value.Should().NotBeNull();
value.Should().BeTrue();

// Collections
collection.Should().HaveCount(3);
collection.Should().Contain(item);

// Exceptions
action.Should().Throw<ArgumentException>();

// Dates
date.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
```

### Test Data
```csharp
// Simple objects
var entity = new Entity { Property = "value" };

// Test builders
var entity = new EntityBuilder()
    .WithProperty("value")
    .Build();

// Parameterized tests
[Theory]
[InlineData("value1", true)]
[InlineData("value2", false)]
public void Test(string input, bool expected)
```

## Coverage Report Location
- **Main Report**: `test-results/coverage-report/index.html`
- **Individual Classes**: `test-results/coverage-report/[ClassName].html`
