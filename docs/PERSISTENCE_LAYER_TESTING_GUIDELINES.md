# Persistence Layer Testing Guidelines

## Overview
This document outlines the testing approach and patterns for the BackendWebService Persistence layer unit tests.

## Test Project Structure

### Project Configuration
- **Project Name**: `BackendWebService.Persistence.UnitTests`
- **Target Framework**: .NET 8.0
- **Test Framework**: xUnit
- **Mocking Framework**: Moq
- **Assertions**: FluentAssertions
- **Database Provider**: Entity Framework Core InMemory

### Dependencies
- `Microsoft.EntityFrameworkCore.InMemory` - In-memory database for testing
- `Microsoft.EntityFrameworkCore.SqlServer` - SQL Server provider for integration tests
- `xUnit` - Testing framework
- `Moq` - Mocking framework
- `FluentAssertions` - Fluent assertion library
- `coverlet.msbuild` - Code coverage collection

## Test Utilities

### DbContextMocks
Provides utilities for creating in-memory database contexts:

```csharp
// Create in-memory database context
using var context = DbContextMocks.CreateInMemoryDbContext();

// Create service collection with in-memory database
var services = DbContextMocks.CreateTestServiceCollection();

// Create service provider
var serviceProvider = DbContextMocks.CreateTestServiceProvider();

// Create mock context
var mockContext = DbContextMocks.CreateMockDbContext();
```

### TestDataBuilder
Provides utilities for creating test data:

```csharp
// Create individual entities
var user = TestDataBuilder.Entities.CreateUser();
var role = TestDataBuilder.Entities.CreateRole();
var category = TestDataBuilder.Entities.CreateCategory();

// Create collections
var users = TestDataBuilder.Collections.CreateUsers(5);
var roles = TestDataBuilder.Collections.CreateRoles(3);
```

### DatabaseTestHelper
Provides utilities for database operations in tests:

```csharp
using var helper = new DatabaseTestHelper();

// Seed test data
await helper.SeedTestDataAsync();

// Seed specific entities
await helper.SeedEntityAsync(user);
await helper.SeedEntitiesAsync(users);

// Clear database
await helper.ClearDatabaseAsync();

// Query operations
var count = helper.GetEntityCount<User>();
var users = helper.GetEntities<User>();
var exists = helper.EntityExists<User>(u => u.Email == "test@example.com");
```

## Testing Patterns

### 1. Repository Testing
Test repository implementations with in-memory database:

```csharp
[Fact]
public async Task GetByIdAsync_WithValidId_ShouldReturnEntity()
{
    // Arrange
    using var helper = new DatabaseTestHelper();
    var user = TestDataBuilder.Entities.CreateUser();
    await helper.SeedEntityAsync(user);
    
    var repository = new UserRepository(helper.Context);

    // Act
    var result = await repository.GetByIdAsync(user.Id);

    // Assert
    result.Should().NotBeNull();
    result!.Email.Should().Be(user.Email);
}
```

### 2. UnitOfWork Testing
Test UnitOfWork pattern with multiple repositories:

```csharp
[Fact]
public async Task CommitAsync_WithMultipleChanges_ShouldSaveAllChanges()
{
    // Arrange
    using var helper = new DatabaseTestHelper();
    var unitOfWork = new UnitOfWork(helper.Context);
    
    var user = TestDataBuilder.Entities.CreateUser();
    var role = TestDataBuilder.Entities.CreateRole();
    
    unitOfWork.GenericRepository<User>().Add(user);
    unitOfWork.GenericRepository<Role>().Add(role);

    // Act
    await unitOfWork.CommitAsync();

    // Assert
    helper.GetEntityCount<User>().Should().Be(1);
    helper.GetEntityCount<Role>().Should().Be(1);
}
```

### 3. Custom Repository Logic Testing
Test complex repository operations:

```csharp
[Fact]
public async Task GetUsersByOrganization_WithValidOrganizationId_ShouldReturnUsers()
{
    // Arrange
    using var helper = new DatabaseTestHelper();
    var organization = TestDataBuilder.Entities.CreateOrganization();
    await helper.SeedEntityAsync(organization);
    
    var users = TestDataBuilder.Collections.CreateUsers(3);
    users.ForEach(u => u.OrganizationId = organization.Id);
    await helper.SeedEntitiesAsync(users);
    
    var repository = new UserRepository(helper.Context);

    // Act
    var result = await repository.GetUsersByOrganizationAsync(organization.Id);

    // Assert
    result.Should().HaveCount(3);
    result.All(u => u.OrganizationId == organization.Id).Should().BeTrue();
}
```

### 4. DbContext Custom Logic Testing
Test custom DbContext behavior:

```csharp
[Fact]
public async Task AddAsync_WithBaseEntity_ShouldSetOrganizationId()
{
    // Arrange
    using var context = DbContextMocks.CreateInMemoryDbContext();
    context.userInfo = new UserInfo { OrganizationId = 123 };
    
    var category = TestDataBuilder.Entities.CreateCategory();
    category.OrganizationId = null; // Ensure it's null initially

    // Act
    await context.AddAsync(category);
    await context.SaveChangesAsync();

    // Assert
    category.OrganizationId.Should().Be(123);
}
```

## Test Data Management

### Entity Creation
Use `TestDataBuilder.Entities` for creating individual entities with sensible defaults:

```csharp
var user = TestDataBuilder.Entities.CreateUser(
    email: "test@example.com",
    userName: "testuser",
    firstName: "Test",
    lastName: "User"
);
```

### Collection Creation
Use `TestDataBuilder.Collections` for creating multiple entities:

```csharp
var users = TestDataBuilder.Collections.CreateUsers(5);
var categories = TestDataBuilder.Collections.CreateCategories(3, organizationId: 1);
```

### Database Seeding
Use `DatabaseTestHelper.SeedTestDataAsync()` for comprehensive test data:

```csharp
using var helper = new DatabaseTestHelper();
await helper.SeedTestDataAsync();
// This seeds: 3 users, 3 roles, 1 organization, 3 categories, 1 company, 1 supplier, 1 logging entry
```

## Best Practices

### 1. Test Isolation
- Each test should use a fresh database instance
- Use `using var helper = new DatabaseTestHelper();` for automatic cleanup
- Avoid sharing database state between tests

### 2. Test Data
- Use meaningful test data that reflects real-world scenarios
- Avoid hardcoded values where possible
- Use TestDataBuilder for consistent data creation

### 3. Assertions
- Use FluentAssertions for readable and expressive assertions
- Test both positive and negative scenarios
- Verify both return values and side effects

### 4. Async Testing
- Always use `async/await` for database operations
- Use `Task` return type for async test methods
- Handle `CancellationToken` where appropriate

### 5. Error Handling
- Test exception scenarios
- Verify error messages and exception types
- Test edge cases and boundary conditions

## Coverage Goals

### Target Coverage
- **Line Coverage**: 80%+
- **Branch Coverage**: 70%+
- **Method Coverage**: 90%+

### Excluded from Coverage
- Migration files
- Generated code
- Obsolete code
- Bin and obj directories

## Integration with CI/CD

### Docker Testing
The Persistence tests are included in the Docker test environment:

```dockerfile
# Run Persistence layer unit tests
RUN dotnet test BackendWebService.Persistence.UnitTests/BackendWebService.Persistence.UnitTests.csproj \
    --no-build \
    --no-restore \
    --collect:"XPlat Code Coverage" \
    --results-directory "/src/test-results" \
    --logger "trx;LogFileName=persistence-test-results.trx" \
    --verbosity normal \
    --configuration Release \
    --settings:coverlet.runsettings
```

### Coverage Reporting
Coverage reports are generated automatically and include:
- Line coverage
- Branch coverage
- Method coverage
- HTML report for detailed analysis

## Troubleshooting

### Common Issues

1. **Database Context Disposal**
   - Always use `using` statements for database contexts
   - Ensure proper disposal in test cleanup

2. **Test Data Conflicts**
   - Use unique identifiers for test data
   - Clear database between tests if needed

3. **Async Operations**
   - Ensure all database operations are awaited
   - Use proper async test method signatures

4. **Entity Framework Issues**
   - Ensure proper entity configuration
   - Check for missing navigation properties
   - Verify foreign key relationships

### Debugging Tips

1. **Enable Logging**
   ```csharp
    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase(databaseName)
        .LogTo(Console.WriteLine)
        .Options;
    ```

2. **Check Entity State**
   ```csharp
    var entry = context.Entry(entity);
    Console.WriteLine($"Entity State: {entry.State}");
    ```

3. **Verify Database Contents**
   ```csharp
    var count = context.Users.Count();
    Console.WriteLine($"Users in database: {count}");
    ```

## Conclusion

The Persistence layer testing framework provides comprehensive tools for testing data access logic with in-memory databases. Follow these guidelines to ensure consistent, maintainable, and effective tests.

For questions or issues, refer to the test utilities documentation or consult the team lead.
