# Application Layer Testing Guidelines

## Overview

This document provides guidelines for testing the Application layer of the BackendWebService project. The Application layer contains business logic, service implementations, feature handlers, and cross-cutting concerns.

## Test Project Structure

The Application layer tests are located in `BackendWebService.Application.UnitTests` and follow this structure:

```
BackendWebService.Application.UnitTests/
├── TestUtilities/
│   ├── RepositoryMocks.cs          # Repository mocking utilities
│   ├── ServiceMocks.cs             # Service mocking utilities
│   ├── ExternalDependencyMocks.cs  # External dependency mocks
│   └── TestDataBuilder.cs          # Test data builders
├── SampleTests/
│   └── ApplicationLayerSetupValidationTests.cs  # Setup validation tests
└── [Feature Tests]/
    └── [Component Tests]/
```

## Testing Strategy

### 1. Unit Testing Approach

- **Isolation**: Each test should be isolated and not depend on external systems
- **Mocking**: Use mocks for all dependencies (repositories, services, external systems)
- **Fast Execution**: Tests should run quickly without I/O operations
- **Deterministic**: Tests should produce consistent results

### 2. Test Categories

#### Service Tests
- Test service implementations and business logic
- Mock repository dependencies
- Test success and failure scenarios
- Validate error handling

#### Feature Handler Tests
- Test command and query handlers
- Mock all dependencies
- Test validation logic
- Test authorization logic

#### Manager Tests
- Test custom managers (AppUserManager, AppRoleManager, etc.)
- Focus on custom business logic
- Mock underlying framework dependencies

#### Utility Tests
- Test utility classes and helper methods
- Mock external dependencies (file system, email, etc.)
- Test edge cases and error conditions

### 3. Mocking Guidelines

#### Repository Mocks
```csharp
// Use the provided repository mock utilities
var userRepositoryMock = RepositoryMocks.CreateRepositoryMock<IUserRepository>();
userRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
    .ReturnsAsync(testUser);
```

#### Service Mocks
```csharp
// Use the provided service mock utilities
var authServiceMock = ServiceMocks.Common.CreateAuthenticationServiceMock();
authServiceMock.Setup(x => x.IsAuthenticated())
    .Returns(true);
```

#### External Dependency Mocks
```csharp
// Use the provided external dependency mocks
var httpContextAccessorMock = ExternalDependencyMocks.ExternalServices.CreateHttpContextAccessorMock();
var userManagerMock = ExternalDependencyMocks.Managers.CreateUserManagerMock();
```

### 4. Test Data Builders

Use the provided test data builders for consistent test data:

```csharp
// Create test entities
var user = TestDataBuilder.Entities.CreateUser("test@example.com", "testuser");
var role = TestDataBuilder.Entities.CreateRole("AdminRole");

// Create test responses
var successResponse = TestDataBuilder.DTOs.CreateSuccessResponse(data);
var errorResponse = TestDataBuilder.DTOs.CreateErrorResponse<string>("Error message");
```

## Test Naming Conventions

### Method Naming
- Use descriptive names that explain what is being tested
- Follow the pattern: `MethodName_Scenario_ExpectedResult`

Examples:
```csharp
[Fact]
public void GetUserById_WhenUserExists_ReturnsUser()
{
    // Test implementation
}

[Fact]
public void GetUserById_WhenUserNotFound_ThrowsNotFoundException()
{
    // Test implementation
}
```

### Class Naming
- Use descriptive names that indicate what is being tested
- Follow the pattern: `[ComponentName]Tests`

Examples:
- `UserServiceTests`
- `AuthenticationServiceTests`
- `CreateUserCommandHandlerTests`

## Coverage Requirements

### Target Coverage
- **Line Coverage**: 80% minimum
- **Branch Coverage**: 80% minimum
- **Method Coverage**: 80% minimum

### Coverage Exclusions
The following are excluded from coverage calculations:
- Generated code
- Obsolete code
- Migration files
- Bin and obj directories

## Test Organization

### By Feature Module
Organize tests by feature modules to match the Application layer structure:

```
Tests/
├── AdministrationModule/
│   ├── CompanyFeature/
│   ├── ConsumerFeature/
│   └── Identity/
├── ClientModule/
├── CustomerModule/
├── EmployeeModule/
├── IdentityModule/
├── InventoryModule/
├── SystemModule/
└── WorkflowModule/
```

### By Component Type
Within each module, organize by component type:

```
FeatureModule/
├── Services/
├── Handlers/
├── Managers/
├── Utilities/
└── Validators/
```

## Best Practices

### 1. Test Structure (AAA Pattern)
```csharp
[Fact]
public void MethodName_Scenario_ExpectedResult()
{
    // Arrange
    var mockDependency = new Mock<IDependency>();
    var service = new Service(mockDependency.Object);
    var input = TestDataBuilder.CreateInput();

    // Act
    var result = service.Method(input);

    // Assert
    result.Should().NotBeNull();
    result.Property.Should().Be(expectedValue);
    mockDependency.Verify(x => x.Method(It.IsAny<Type>()), Times.Once);
}
```

### 2. Assertion Guidelines
- Use FluentAssertions for readable assertions
- Verify mock interactions
- Test both positive and negative scenarios
- Test edge cases and boundary conditions

### 3. Test Data Management
- Use test data builders for consistent data
- Create data that represents realistic scenarios
- Avoid hardcoded values in tests
- Use meaningful test data that enhances readability

### 4. Mock Verification
```csharp
// Verify method was called
mockDependency.Verify(x => x.Method(It.IsAny<Type>()), Times.Once);

// Verify method was called with specific parameters
mockDependency.Verify(x => x.Method(It.Is<string>(s => s == "expected")), Times.Once);

// Verify method was never called
mockDependency.Verify(x => x.Method(It.IsAny<Type>()), Times.Never);
```

## Running Tests

### Local Development
```bash
# Run all Application layer tests
dotnet test BackendWebService.Application.UnitTests

# Run tests with coverage
dotnet test BackendWebService.Application.UnitTests --collect:"XPlat Code Coverage"

# Run specific test class
dotnet test BackendWebService.Application.UnitTests --filter "ClassName=UserServiceTests"
```

### Docker
```bash
# Run tests in Docker
docker-compose -f docker-compose.tests.yml up unit-tests
```

## Troubleshooting

### Common Issues

1. **Build Errors**: Ensure all dependencies are properly referenced
2. **Mock Setup Issues**: Verify mock setup matches actual method signatures
3. **Coverage Issues**: Check that all code paths are tested
4. **Test Failures**: Review test data and assertions

### Debugging Tips

1. Use meaningful test names and descriptions
2. Add comments for complex test scenarios
3. Use debugger to step through failing tests
4. Check mock verification calls

## Maintenance

### Regular Tasks
- Review and update test coverage reports
- Refactor tests when application code changes
- Remove obsolete tests
- Update test data builders as needed

### Code Review Checklist
- [ ] Tests follow naming conventions
- [ ] All dependencies are properly mocked
- [ ] Test covers both success and failure scenarios
- [ ] Assertions are clear and meaningful
- [ ] Mock verifications are appropriate
- [ ] Test data is realistic and consistent

## Resources

- [xUnit Documentation](https://xunit.net/)
- [Moq Documentation](https://github.com/moq/moq4)
- [FluentAssertions Documentation](https://fluentassertions.com/)
- [Coverlet Documentation](https://github.com/coverlet-coverage/coverlet)
