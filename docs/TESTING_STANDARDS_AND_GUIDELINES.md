# Testing Standards and Guidelines

## Table of Contents

1. [Overview](#overview)
2. [Test Naming Conventions](#test-naming-conventions)
3. [Test Structure Patterns](#test-structure-patterns)
4. [Assertion Styles](#assertion-styles)
5. [Test Data Setup](#test-data-setup)
6. [Code Coverage Expectations](#code-coverage-expectations)
7. [What to Test and What Not to Test](#what-to-test-and-what-not-to-test)
8. [Test Organization](#test-organization)
9. [Common Anti-Patterns to Avoid](#common-anti-patterns-to-avoid)
10. [Running Tests](#running-tests)
11. [Coverage Reports](#coverage-reports)
12. [Readability and Maintainability](#readability-and-maintainability)

## Overview

This document establishes testing standards and guidelines for the BackendWebService project. These standards are based on industry best practices and lessons learned from implementing comprehensive unit tests for the PaymentMethod domain entity.

### Testing Philosophy

- **Test-Driven Development**: Write tests first when possible
- **Comprehensive Coverage**: Aim for high coverage while maintaining quality
- **Clear and Readable**: Tests should be self-documenting
- **Maintainable**: Tests should be easy to update and extend
- **Fast and Reliable**: Tests should run quickly and consistently

## Test Naming Conventions

### Test Class Naming
- **Pattern**: `[EntityName]Tests` or `[ClassName]Tests`
- **Examples**: 
  - `PaymentMethodTests`
  - `UserServiceTests`
  - `OrderRepositoryTests`

### Test Method Naming
- **Pattern**: `MethodName_Scenario_ExpectedResult`
- **Examples**:
  - `PaymentMethod_Constructor_ShouldSetDefaultValues`
  - `PaymentMethod_MethodType_ShouldValidateCorrectly`
  - `UserService_GetUserById_ShouldReturnUserWhenExists`
  - `UserService_GetUserById_ShouldThrowExceptionWhenNotFound`

### Test Categories
Use `[Fact]` for single test cases and `[Theory]` for parameterized tests:

```csharp
[Fact]
public void PaymentMethod_Constructor_ShouldSetDefaultValues()

[Theory]
[InlineData("Credit Card", true)]
[InlineData("", false)]
public void PaymentMethod_MethodType_ShouldValidateCorrectly(string methodType, bool isValid)
```

## Test Structure Patterns

### Arrange-Act-Assert (AAA) Pattern

Every test should follow the AAA pattern:

```csharp
[Fact]
public void PaymentMethod_Constructor_ShouldSetDefaultValues()
{
    // Arrange & Act
    var paymentMethod = new PaymentMethod();

    // Assert
    paymentMethod.IsDefault.Should().BeFalse();
    paymentMethod.IsVerified.Should().BeFalse();
    paymentMethod.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
}
```

### Test Structure Guidelines

1. **Arrange**: Set up test data and dependencies
2. **Act**: Execute the method under test
3. **Assert**: Verify the expected outcome

### Multiple Assertions
When testing multiple aspects of the same behavior:

```csharp
[Fact]
public void PaymentMethod_Constructor_ShouldSetDefaultValues()
{
    // Arrange & Act
    var paymentMethod = new PaymentMethod();

    // Assert - Group related assertions
    paymentMethod.IsDefault.Should().BeFalse();
    paymentMethod.IsVerified.Should().BeFalse();
    
    // Assert - Separate group for timestamp
    paymentMethod.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
    paymentMethod.UpdatedAt.Should().BeNull();
}
```

## Assertion Styles

### FluentAssertions (Preferred)

Use FluentAssertions for readable, expressive assertions:

```csharp
// Good - FluentAssertions
paymentMethod.IsDefault.Should().BeFalse();
paymentMethod.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
paymentMethod.ExpiryDate.Should().BeNull();
paymentMethod.Type.Should().Be(PaymentEnum.CreditCard);

// Collections
users.Should().HaveCount(3);
users.Should().Contain(u => u.Name == "John");

// Exceptions
action.Should().Throw<ArgumentException>()
    .WithMessage("Value cannot be null*");
```

### Traditional Assertions (When Necessary)

Use traditional assertions only when FluentAssertions doesn't provide the needed functionality:

```csharp
// Only when FluentAssertions doesn't support the assertion
Assert.True(condition);
Assert.Equal(expected, actual);
```

## Test Data Setup

### Test Data Creation

#### Simple Objects
```csharp
var paymentMethod = new PaymentMethod
{
    UserId = 1,
    MethodType = "Credit Card",
    Provider = "Visa",
    AccountNumber = "4111111111111111",
    Name = "My Visa Card",
    Type = PaymentEnum.CreditCard
};
```

#### Test Data Builders (For Complex Objects)
```csharp
public class PaymentMethodBuilder
{
    private PaymentMethod _paymentMethod = new PaymentMethod();

    public PaymentMethodBuilder WithUserId(int userId)
    {
        _paymentMethod.UserId = userId;
        return this;
    }

    public PaymentMethodBuilder WithCreditCard()
    {
        _paymentMethod.MethodType = "Credit Card";
        _paymentMethod.Provider = "Visa";
        _paymentMethod.Type = PaymentEnum.CreditCard;
        return this;
    }

    public PaymentMethod Build() => _paymentMethod;
}

// Usage
var paymentMethod = new PaymentMethodBuilder()
    .WithUserId(1)
    .WithCreditCard()
    .Build();
```

#### Parameterized Test Data
```csharp
public static class PaymentMethodTestData
{
    public static IEnumerable<object[]> ValidPaymentMethods => new[]
    {
        new object[] { "Credit Card", "Visa", "4111111111111111", "My Visa Card", PaymentEnum.CreditCard },
        new object[] { "Debit Card", "MasterCard", "5555555555554444", "My Debit Card", PaymentEnum.DebitCard },
        new object[] { "Mobile Payment", "Apple Pay", "1234567890", "Apple Pay", PaymentEnum.MobilePayment }
    };
}
```

## Code Coverage Expectations

### Coverage Targets by Layer

| Layer | Line Coverage | Branch Coverage | Method Coverage |
|-------|---------------|-----------------|-----------------|
| **Domain** | 95%+ | 90%+ | 100% |
| **Application** | 85%+ | 80%+ | 90%+ |
| **Persistence** | 75%+ | 70%+ | 80%+ |
| **Overall** | 80%+ | 75%+ | 85%+ |

### Coverage Guidelines

1. **Domain Entities**: Aim for 100% coverage - they contain core business logic
2. **Services**: Focus on business logic, not framework code
3. **Repositories**: Test custom logic, not framework CRUD operations
4. **Controllers**: Test action methods, not framework pipeline

### Exclusions

Exclude from coverage:
- Auto-generated code
- Migration files
- Configuration classes with no logic
- Framework boilerplate

```xml
<ExcludeByFile>**/Migrations/**,**/bin/**,**/obj/**</ExcludeByFile>
<ExcludeByAttribute>Obsolete,GeneratedCodeAttribute,CompilerGeneratedAttribute</ExcludeByAttribute>
```

## What to Test and What Not to Test

### ✅ What to Test

#### Domain Layer
- **Entity constructors** and default values
- **Property validation** and business rules
- **Business logic methods**
- **Edge cases** and boundary conditions
- **State transitions**

#### Application Layer
- **Service methods** and business workflows
- **Command/Query handlers**
- **Validation logic**
- **Error handling**
- **Authorization logic**

#### Persistence Layer
- **Custom repository methods**
- **Complex queries**
- **Data transformations**
- **Transaction handling**

### ❌ What Not to Test

- **Framework code** (Entity Framework, ASP.NET Core)
- **Third-party libraries** (unless customizing)
- **Auto-generated code**
- **Simple property getters/setters** (unless they contain logic)
- **Configuration classes** with no logic
- **Private methods** (test through public interface)

### 🤔 What to Consider

- **Integration points** - Test through integration tests
- **External services** - Mock in unit tests, test integration separately
- **Database operations** - Unit test logic, integration test data access

## Test Organization

### Test Class Organization

#### By Functionality
```csharp
public class PaymentMethodTests
{
    #region Constructor Tests
    [Fact]
    public void PaymentMethod_Constructor_ShouldSetDefaultValues()
    
    [Fact]
    public void PaymentMethod_Constructor_ShouldInitializeRequiredProperties()
    #endregion

    #region Property Validation Tests
    [Theory]
    [InlineData("Credit Card", true)]
    [InlineData("", false)]
    public void PaymentMethod_MethodType_ShouldValidateCorrectly(string methodType, bool isValid)
    #endregion

    #region Business Logic Tests
    [Fact]
    public void PaymentMethod_ExpiryDate_ShouldValidateCorrectly()
    #endregion

    #region Edge Cases Tests
    [Fact]
    public void PaymentMethod_BoundaryValues_ShouldBeHandledCorrectly()
    #endregion
}
```

#### Test Categories
- **Constructor Tests**: Default values, initialization
- **Property Validation Tests**: Validation rules, constraints
- **Business Logic Tests**: Core business methods
- **Edge Cases Tests**: Boundary conditions, error scenarios
- **Integration Tests**: Cross-component interactions

### Test Method Organization

1. **Group related tests** using regions
2. **Order tests logically** (simple to complex)
3. **Use descriptive names** that explain the scenario
4. **Keep tests focused** on one behavior per test

## Common Anti-Patterns to Avoid

### ❌ Test Anti-Patterns

#### 1. Testing Implementation Details
```csharp
// Bad - Testing internal implementation
[Fact]
public void PaymentMethod_ShouldHavePrivateField()
{
    var field = typeof(PaymentMethod).GetField("_internalField", BindingFlags.NonPublic);
    field.Should().NotBeNull();
}

// Good - Testing public behavior
[Fact]
public void PaymentMethod_Constructor_ShouldSetDefaultValues()
{
    var paymentMethod = new PaymentMethod();
    paymentMethod.IsDefault.Should().BeFalse();
}
```

#### 2. Overly Complex Test Setup
```csharp
// Bad - Too much setup
[Fact]
public void PaymentMethod_ShouldWork()
{
    var user = new User { Id = 1, Name = "John", Email = "john@example.com" };
    var organization = new Organization { Id = 1, Name = "Acme Corp" };
    var category = new Category { Id = 1, Name = "Payment" };
    // ... 20 more lines of setup
    var paymentMethod = new PaymentMethod();
    // Test logic
}

// Good - Minimal setup
[Fact]
public void PaymentMethod_Constructor_ShouldSetDefaultValues()
{
    var paymentMethod = new PaymentMethod();
    paymentMethod.IsDefault.Should().BeFalse();
}
```

#### 3. Testing Multiple Behaviors
```csharp
// Bad - Testing multiple behaviors
[Fact]
public void PaymentMethod_ShouldHandleEverything()
{
    var paymentMethod = new PaymentMethod();
    
    // Test constructor
    paymentMethod.IsDefault.Should().BeFalse();
    
    // Test property setting
    paymentMethod.MethodType = "Credit Card";
    paymentMethod.MethodType.Should().Be("Credit Card");
    
    // Test validation
    paymentMethod.ExpiryDate = DateTime.Now.AddDays(-1);
    // ... more tests
}

// Good - One behavior per test
[Fact]
public void PaymentMethod_Constructor_ShouldSetDefaultValues()

[Fact]
public void PaymentMethod_MethodType_ShouldBeSettable()

[Fact]
public void PaymentMethod_ExpiryDate_ShouldValidateCorrectly()
```

#### 4. Hardcoded Test Data
```csharp
// Bad - Hardcoded values
[Fact]
public void PaymentMethod_ShouldWork()
{
    var paymentMethod = new PaymentMethod
    {
        UserId = 12345,
        MethodType = "Credit Card",
        Provider = "Visa",
        AccountNumber = "4111111111111111"
    };
    // Test logic
}

// Good - Meaningful test data
[Fact]
public void PaymentMethod_WithValidData_ShouldBeCreated()
{
    var paymentMethod = new PaymentMethod
    {
        UserId = 1,
        MethodType = "Credit Card",
        Provider = "Visa",
        AccountNumber = "4111111111111111",
        Name = "Test Payment Method",
        Type = PaymentEnum.CreditCard
    };
    
    paymentMethod.Should().NotBeNull();
}
```

#### 5. Ignoring Test Failures
```csharp
// Bad - Ignoring test failures
[Fact]
public void PaymentMethod_ShouldWork()
{
    try
    {
        // Test logic that might fail
        var result = SomeMethod();
        result.Should().NotBeNull();
    }
    catch
    {
        // Ignore failures - BAD!
    }
}

// Good - Proper error handling
[Fact]
public void PaymentMethod_WithInvalidData_ShouldThrowException()
{
    var action = () => new PaymentMethod { MethodType = null };
    action.Should().Throw<ArgumentException>();
}
```

## Running Tests

### Local Test Execution

#### Run All Tests
```bash
dotnet test
```

#### Run Specific Test Project
```bash
dotnet test BackendWebService.Domain.UnitTests
```

#### Run with Coverage
```bash
.\scripts\run-full-coverage.ps1
```

#### Run Specific Test Class
```bash
dotnet test --filter "ClassName=PaymentMethodTests"
```

#### Run Specific Test Method
```bash
dotnet test --filter "MethodName=PaymentMethod_Constructor_ShouldSetDefaultValues"
```

### Docker Test Execution

#### Run Tests in Docker
```bash
.\scripts\run-tests-docker.ps1
```

#### Run with Docker Compose
```bash
docker-compose -f docker-compose.tests.yml up --build
```

### Test Execution Best Practices

1. **Run tests frequently** during development
2. **Run all tests** before committing
3. **Use parallel execution** for faster feedback
4. **Monitor test execution time** - keep tests fast
5. **Fix failing tests immediately** - don't let them accumulate

## Coverage Reports

### Generating Coverage Reports

#### Local Generation
```bash
# Run tests with coverage
.\scripts\run-tests-with-coverage.ps1

# Generate HTML report
.\scripts\generate-coverage-report.ps1

# Run both
.\scripts\run-full-coverage.ps1
```

#### Docker Generation
```bash
# Run tests in Docker with coverage
.\scripts\run-tests-docker.ps1
```

### Interpreting Coverage Reports

#### Coverage Metrics
- **Line Coverage**: Percentage of executable lines covered
- **Branch Coverage**: Percentage of conditional branches covered
- **Method Coverage**: Percentage of methods covered

#### Coverage Report Features
- **Visual Indicators**: Green (covered), Red (uncovered), Gray (non-coverable)
- **Visit Counts**: Number of times each line was executed
- **Method Breakdown**: Individual method coverage details
- **File Analysis**: Line-by-line coverage analysis

#### Coverage Report Location
- **Main Report**: `test-results/coverage-report/index.html`
- **Individual Classes**: `test-results/coverage-report/[ClassName].html`
- **Coverage Data**: `test-results/coverage/coverage.cobertura.xml`

### Coverage Report Best Practices

1. **Review coverage reports regularly**
2. **Focus on uncovered lines** that contain business logic
3. **Don't chase 100% coverage** at the expense of test quality
4. **Use coverage reports** to identify testing gaps
5. **Share coverage reports** with the team

## Readability and Maintainability

### Test Readability Guidelines

#### 1. Clear Test Names
```csharp
// Good - Clear and descriptive
[Fact]
public void PaymentMethod_WithExpiredDate_ShouldBeInvalid()

// Bad - Unclear
[Fact]
public void Test1()
```

#### 2. Descriptive Assertions
```csharp
// Good - Clear assertion
paymentMethod.IsDefault.Should().BeFalse("because new payment methods should not be default");

// Bad - Unclear assertion
Assert.False(paymentMethod.IsDefault);
```

#### 3. Meaningful Test Data
```csharp
// Good - Meaningful data
var paymentMethod = new PaymentMethod
{
    MethodType = "Credit Card",
    Provider = "Visa",
    AccountNumber = "4111111111111111"
};

// Bad - Meaningless data
var paymentMethod = new PaymentMethod
{
    MethodType = "Test",
    Provider = "Test",
    AccountNumber = "123"
};
```

### Test Maintainability Guidelines

#### 1. Keep Tests Simple
- One behavior per test
- Minimal setup
- Clear assertions

#### 2. Use Helper Methods
```csharp
private PaymentMethod CreateValidPaymentMethod()
{
    return new PaymentMethod
    {
        UserId = 1,
        MethodType = "Credit Card",
        Provider = "Visa",
        AccountNumber = "4111111111111111",
        Name = "Test Payment Method",
        Type = PaymentEnum.CreditCard
    };
}
```

#### 3. Avoid Test Dependencies
- Tests should be independent
- No shared state between tests
- Each test should be able to run in isolation

#### 4. Regular Test Maintenance
- Review tests during code reviews
- Refactor tests when code changes
- Remove obsolete tests
- Update tests when requirements change

### Test Documentation

#### 1. Test Comments
```csharp
[Fact]
public void PaymentMethod_WithFutureExpiryDate_ShouldBeValid()
{
    // Arrange - Create payment method with future expiry date
    var futureDate = DateTime.UtcNow.AddYears(1);
    var paymentMethod = CreateValidPaymentMethod();
    
    // Act - Set future expiry date
    paymentMethod.ExpiryDate = futureDate;
    
    // Assert - Should be valid
    paymentMethod.ExpiryDate.Should().Be(futureDate);
}
```

#### 2. Test Documentation
- Document complex test scenarios
- Explain business rules being tested
- Document any special test setup requirements

## Conclusion

These testing standards and guidelines provide a foundation for writing high-quality, maintainable tests across the BackendWebService project. By following these standards, we ensure:

- **Consistency** across all test code
- **Readability** for all team members
- **Maintainability** as the codebase evolves
- **Quality** through comprehensive coverage
- **Efficiency** through proper test organization

Remember: **Good tests are an investment in code quality and team productivity**. Take the time to write them well, and they will pay dividends in the long run.

---

*This document is living and should be updated as we learn more about testing best practices and project-specific requirements.*
