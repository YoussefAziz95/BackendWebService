# US-028-1: Integration Test Fix - Execution Plan

## 📋 **Executive Summary**

**Current State:** 138/203 tests passing (68%), 50 tests failing (25%), 15 tests skipped (7%)

**Root Cause:** Test isolation failure due to shared in-memory database with parallel test execution

**Goal:** Achieve 95%+ test pass rate with stable, repeatable test execution

**Estimated Time:** 4-6 hours for full implementation

---

## 🎯 **Problem Analysis**

### **Core Issues Identified:**

1. **Test Isolation Failure**
   - Shared in-memory database name: `"IntegrationTestDb_Shared"`
   - Parallel test execution causing race conditions
   - Data pollution between tests

2. **Identity & Password Hashing**
   - In-memory database not fully compatible with ASP.NET Identity
   - Password verification fails after user creation
   - Hash persistence issues

3. **Test Lifecycle Problems**
   - Cleanup happens during other tests' execution
   - Data deleted while tests are still running
   - Seeded data disappears mid-test

4. **Missing Relationship Data**
   - Organizations not loading with Users
   - Foreign key references fail
   - Navigation properties return null

---

## 🛣️ **Solution Routes**

## **Route 1: Quick Win - Isolated Databases + Sequential Execution** ⭐ **RECOMMENDED**

### **Overview:**
Implement unique database per test AND disable parallel execution for maximum stability.

### **Impact:**
- **Complexity:** Low
- **Time:** 30 minutes
- **Expected Pass Rate:** 85-90%
- **Risk:** Very Low

### **Implementation Steps:**

#### **Step 1.1: Modify IntegrationTestWebApplicationFactory**
**File:** `BackendWebService.IntegrationTests/Infrastructure/IntegrationTestWebApplicationFactory.cs`

**Location:** Line 84 (inside ConfigureWebHost method)

**Current Code:**
```csharp
services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseInMemoryDatabase("IntegrationTestDb_Shared");
    options.EnableSensitiveDataLogging();
    options.EnableDetailedErrors();
});
```

**Replace With:**
```csharp
services.AddDbContext<ApplicationDbContext>(options =>
{
    // Generate unique database name per test run to ensure complete isolation
    var uniqueDbName = $"IntegrationTestDb_{Guid.NewGuid()}";
    options.UseInMemoryDatabase(uniqueDbName);
    options.EnableSensitiveDataLogging();
    options.EnableDetailedErrors();
    
    // Log database name for debugging
    Console.WriteLine($"Using database: {uniqueDbName}");
});
```

**Why This Works:**
- Each test gets its own isolated database
- No data pollution between tests
- Cleanup is automatic when test completes

#### **Step 1.2: Disable Test Parallelization**
**File:** `BackendWebService.IntegrationTests/BackendWebService.IntegrationTests.csproj`

**Location:** Inside `<PropertyGroup>` section (around line 8)

**Current Code:**
```xml
<PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <IsPackable>false</IsPackable>
    <IsTestProject>true</IsTestProject>
    <ParallelizeTestCollections>false</ParallelizeTestCollections>
</PropertyGroup>
```

**Replace With:**
```xml
<PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <IsPackable>false</IsPackable>
    <IsTestProject>true</IsTestProject>
    <ParallelizeTestCollections>false</ParallelizeTestCollections>
    <ParallelizeAssembly>false</ParallelizeAssembly>
</PropertyGroup>
```

**Why This Works:**
- Forces all tests to run sequentially
- Eliminates race conditions
- Ensures predictable test order

#### **Step 1.3: Remove Database Cleanup Logic** (Optional but Recommended)
**File:** `BackendWebService.IntegrationTests/Base/BaseIntegrationTest.cs`

**Location:** Lines 50-60 (DisposeAsync method)

**Current Code:**
```csharp
public async Task DisposeAsync()
{
    await DatabaseCleaner.ClearAllTablesAsync();
}
```

**Replace With:**
```csharp
public async Task DisposeAsync()
{
    // No cleanup needed - each test has isolated database
    // Database will be garbage collected automatically
    await Task.CompletedTask;
}
```

**Why This Works:**
- Faster test execution
- No cleanup conflicts
- Database is automatically disposed

#### **Step 1.4: Verify Configuration**
**Command:**
```bash
dotnet test --logger "console;verbosity=normal" | Select-String "Total tests"
```

**Expected Output:**
```
Total tests: 203
     Passed: 175-185
     Failed: 15-25
```

---

## **Route 2: Medium Complexity - Fix Seed Data + Relationships**

### **Overview:**
Fix underlying data relationship issues and ensure proper seeding order.

### **Impact:**
- **Complexity:** Medium
- **Time:** 1-2 hours
- **Expected Pass Rate:** 80-85% (when combined with Route 1)
- **Risk:** Medium

### **Implementation Steps:**

#### **Step 2.1: Fix Organization Seeding Order**
**File:** `BackendWebService.IntegrationTests/Infrastructure/TestDataSeeder.cs`

**Location:** Lines 15-30 (SeedAsync method)

**Current Code:**
```csharp
public async Task SeedAsync()
{
    _context.ChangeTracker.Clear();
    
    await SeedRolesAsync();
    await SeedUsersAsync();
    await SeedCompaniesAsync();
    await SeedCategoriesAsync();
    
    _context.ChangeTracker.Clear();
}
```

**Replace With:**
```csharp
public async Task SeedAsync()
{
    _context.ChangeTracker.Clear();
    
    // CRITICAL: Seed in dependency order!
    // 1. Organizations (no dependencies)
    await SeedOrganizationsAsync();
    await _context.SaveChangesAsync(); // Save immediately
    
    // 2. Roles (no dependencies)
    await SeedRolesAsync();
    await _context.SaveChangesAsync(); // Save immediately
    
    // 3. Users (depends on Organizations and Roles)
    await SeedUsersAsync();
    await _context.SaveChangesAsync(); // Save immediately
    
    // 4. Companies and Categories (depend on Organizations)
    await SeedCompaniesAsync();
    await SeedCategoriesAsync();
    await _context.SaveChangesAsync(); // Save immediately
    
    _context.ChangeTracker.Clear();
}
```

#### **Step 2.2: Add SeedOrganizationsAsync Method**
**File:** `BackendWebService.IntegrationTests/Infrastructure/TestDataSeeder.cs`

**Location:** Add after SeedRolesAsync method (around line 35)

**Add This Code:**
```csharp
private async Task SeedOrganizationsAsync()
{
    // Check if organizations already exist
    if (await _context.Organizations.AnyAsync())
    {
        Console.WriteLine("Organizations already exist, skipping...");
        return;
    }
    
    var organizations = new List<Organization>
    {
        TestDataFactory.CreateOrganization(
            name: "Test Organization",
            country: "Test Country"
        )
    };
    
    foreach (var org in organizations)
    {
        await _context.Organizations.AddAsync(org);
    }
    
    await _context.SaveChangesAsync();
    Console.WriteLine($"Seeded {organizations.Count} organizations");
}
```

#### **Step 2.3: Update TestDataFactory to Set Organization ID**
**File:** `BackendWebService.IntegrationTests/Utilities/TestDataFactory.cs`

**Location:** CreateUser method (lines 14-45)

**Current Code:**
```csharp
OrganizationId = organizationId ?? 1,
```

**Replace With:**
```csharp
// Use the first organization's ID if not specified
OrganizationId = organizationId ?? 1, // Will be set correctly after organizations are seeded
```

**Note:** Keep this as-is, but ensure organizations are seeded BEFORE users.

#### **Step 2.4: Fix User-Organization Relationship Loading**
**File:** `BackendWebService.IntegrationTests/Database/RelationshipIntegrationTests.cs`

**Location:** Line 45-65 (Relationship_ShouldLoadRelatedEntities test)

**Add Include Statement:**
```csharp
[Fact]
public async Task Relationship_ShouldLoadRelatedEntities()
{
    // Arrange
    var userId = 1;

    // Act - Explicitly load the Organization relationship
    var userWithOrganization = await _context.Users
        .Include(u => u.Organization) // ← Add this!
        .FirstOrDefaultAsync(u => u.Id == userId);

    // Assert
    userWithOrganization.Should().NotBeNull(because: "User should exist");
    userWithOrganization!.Organization.Should().NotBeNull(because: "User should have related organization");
    userWithOrganization.OrganizationId.Should().BeGreaterThan(0);
}
```

---

## **Route 3: Advanced - TestContainers with Real SQL Server**

### **Overview:**
Use TestContainers to spin up real SQL Server instances for testing.

### **Impact:**
- **Complexity:** High
- **Time:** 3-4 hours
- **Expected Pass Rate:** 95%+
- **Risk:** Medium-High (requires Docker)

### **Implementation Steps:**

#### **Step 3.1: Add TestContainers NuGet Package**
**File:** `BackendWebService.IntegrationTests/BackendWebService.IntegrationTests.csproj`

**Add to ItemGroup:**
```xml
<PackageReference Include="Testcontainers.MsSql" Version="3.7.0" />
```

#### **Step 3.2: Create TestContainers Factory**
**File:** `BackendWebService.IntegrationTests/Infrastructure/SqlServerTestContainerFactory.cs` (NEW FILE)

**Full Code:**
```csharp
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Testcontainers.MsSql;

namespace BackendWebService.IntegrationTests.Infrastructure;

public class SqlServerTestContainerFactory : IAsyncDisposable
{
    private readonly MsSqlContainer _container;
    private bool _disposed;

    public SqlServerTestContainerFactory()
    {
        _container = new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
            .WithPassword("YourStrong@Passw0rd")
            .WithCleanUp(true)
            .Build();
    }

    public async Task<string> GetConnectionStringAsync()
    {
        if (!_disposed && _container.State != TestcontainersStates.Running)
        {
            await _container.StartAsync();
        }
        return _container.GetConnectionString();
    }

    public async ValueTask DisposeAsync()
    {
        if (!_disposed)
        {
            await _container.DisposeAsync();
            _disposed = true;
        }
    }
}
```

#### **Step 3.3: Modify Factory to Use TestContainers**
**File:** `BackendWebService.IntegrationTests/Infrastructure/IntegrationTestWebApplicationFactory.cs`

**Add Field:**
```csharp
private SqlServerTestContainerFactory? _sqlServerFactory;
```

**Modify ConfigureWebHost:**
```csharp
builder.ConfigureServices(async services =>
{
    // Remove existing DbContext
    var descriptor = services.SingleOrDefault(d => 
        d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
    if (descriptor != null) services.Remove(descriptor);

    // Initialize SQL Server container
    _sqlServerFactory = new SqlServerTestContainerFactory();
    var connectionString = await _sqlServerFactory.GetConnectionStringAsync();

    // Use real SQL Server
    services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(connectionString);
        options.EnableSensitiveDataLogging();
        options.EnableDetailedErrors();
    });
    
    // Ensure database is created
    var sp = services.BuildServiceProvider();
    using var scope = sp.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await context.Database.EnsureCreatedAsync();
});
```

**Note:** This requires Docker to be running on the test machine.

---

## **Route 4: Hybrid Approach - Quick Fixes + Data Improvements**

### **Overview:**
Combine Route 1 (quick wins) with selective fixes from Route 2 (data issues).

### **Impact:**
- **Complexity:** Low-Medium
- **Time:** 1 hour
- **Expected Pass Rate:** 88-92%
- **Risk:** Low

### **Implementation Steps:**

#### **Step 4.1: Implement All of Route 1**
Follow all steps from Route 1 (Isolated Databases + Sequential Execution)

#### **Step 4.2: Fix Only Critical Seed Issues**
From Route 2, implement:
- Step 2.1: Fix Organization Seeding Order
- Step 2.2: Add SeedOrganizationsAsync Method
- Skip Steps 2.3 and 2.4 (less critical)

#### **Step 4.3: Add Retry Logic for Flaky Tests**
**File:** `BackendWebService.IntegrationTests/Base/BaseIntegrationTest.cs`

**Add Retry Helper Method:**
```csharp
protected async Task<T> RetryAsync<T>(
    Func<Task<T>> action, 
    int maxAttempts = 3, 
    int delayMs = 100)
{
    for (int i = 0; i < maxAttempts; i++)
    {
        try
        {
            return await action();
        }
        catch when (i < maxAttempts - 1)
        {
            await Task.Delay(delayMs * (i + 1));
        }
    }
    throw new Exception("Max retry attempts reached");
}
```

**Usage in Authentication:**
```csharp
protected async Task<string> GetJwtTokenAsync(string phoneNumber, string password)
{
    return await RetryAsync(async () =>
    {
        var loginRequest = new { PhoneNumber = phoneNumber, Password = password };
        var response = await Client.PostAsJsonAsync("/api/v1/authorization/login", loginRequest);
        response.EnsureSuccessStatusCode();
        var loginResponse = await response.Content.ReadFromJsonAsync<ApiResponse<LoginResponse>>();
        return loginResponse?.Data?.Token ?? throw new InvalidOperationException("Failed to get JWT token");
    });
}
```

---

## 📊 **Comparison Matrix**

| Route | Time | Complexity | Pass Rate | Maintenance | Docker Required |
|-------|------|------------|-----------|-------------|-----------------|
| **Route 1** | 30m | Low | 85-90% | Low | No |
| **Route 2** | 2h | Medium | 80-85% | Medium | No |
| **Route 3** | 4h | High | 95%+ | Medium | **Yes** |
| **Route 4** | 1h | Medium | 88-92% | Low | No |

---

## 🎯 **Recommended Execution Plan**

### **Phase 1: Immediate (Day 1) - Route 1** ⭐
**Time:** 30 minutes

1. Implement isolated databases (Step 1.1)
2. Disable parallelization (Step 1.2)
3. Remove cleanup logic (Step 1.3)
4. Run full test suite and verify

**Success Criteria:** 85%+ tests passing

### **Phase 2: Same Day - Route 4 (If needed)**
**Time:** 1 hour (if Phase 1 doesn't reach 90%)

1. Keep Route 1 changes
2. Add organization seeding (Route 2, Steps 2.1-2.2)
3. Add retry logic (Route 4, Step 4.3)
4. Run full test suite again

**Success Criteria:** 90%+ tests passing

### **Phase 3: Future Sprint - Route 3**
**Time:** 4 hours (when Docker infrastructure is ready)

1. Add TestContainers support
2. Migrate critical tests to real SQL Server
3. Keep in-memory for fast unit tests
4. Maintain hybrid approach

**Success Criteria:** 95%+ tests passing with production-like environment

---

## 🔍 **Verification Steps**

### **After Each Phase:**

1. **Run Full Test Suite:**
   ```bash
   dotnet test --logger "console;verbosity=normal"
   ```

2. **Check for Skipped Tests:**
   ```bash
   dotnet test --logger "console;verbosity=normal" | Select-String "Skipped"
   ```

3. **Verify No Database Warnings:**
   ```bash
   dotnet test --logger "console;verbosity=normal" | Select-String "cleanup warning"
   ```

4. **Check Authentication Tests:**
   ```bash
   dotnet test --filter "FullyQualifiedName~Authentication" --logger "console;verbosity=normal"
   ```

5. **Check Relationship Tests:**
   ```bash
   dotnet test --filter "FullyQualifiedName~Relationship" --logger "console;verbosity=normal"
   ```

---

## 🚨 **Rollback Plan**

If any route causes issues:

### **Rollback Route 1:**
```bash
git checkout BackendWebService.IntegrationTests/Infrastructure/IntegrationTestWebApplicationFactory.cs
git checkout BackendWebService.IntegrationTests/BackendWebService.IntegrationTests.csproj
git checkout BackendWebService.IntegrationTests/Base/BaseIntegrationTest.cs
```

### **Rollback Route 2:**
```bash
git checkout BackendWebService.IntegrationTests/Infrastructure/TestDataSeeder.cs
git checkout BackendWebService.IntegrationTests/Utilities/TestDataFactory.cs
```

### **Rollback Route 3:**
```bash
# Remove TestContainers package
dotnet remove package Testcontainers.MsSql
# Delete new files
rm BackendWebService.IntegrationTests/Infrastructure/SqlServerTestContainerFactory.cs
```

---

## 📈 **Success Metrics**

### **Must Have:**
- [ ] 90%+ tests passing (183+ out of 203)
- [ ] No database cleanup warnings
- [ ] Authentication tests 100% passing
- [ ] All skipped tests remain intentionally skipped (15 tests)

### **Nice to Have:**
- [ ] 95%+ tests passing (193+ out of 203)
- [ ] Test execution time under 2 minutes
- [ ] Zero flaky tests
- [ ] All relationship tests passing

### **Continuous Monitoring:**
- [ ] Run tests before every commit
- [ ] CI/CD pipeline runs full test suite
- [ ] Test coverage above 80%
- [ ] No new skipped tests added without justification

---

## 📝 **Notes and Considerations**

### **In-Memory Database Limitations:**
The following tests will ALWAYS be skipped (by design):
- 6 Transaction tests (in-memory DB doesn't support transactions)
- 5 Stored Procedure tests (not supported)
- 2 Database migration tests (not applicable)
- 1 SMTP test (requires real server)
- 1 Raw SQL test (not supported)

**Total: 15 intentionally skipped tests**

### **Performance Considerations:**
- Route 1: Fastest (in-memory DB, no cleanup overhead)
- Route 2: Same speed as Route 1
- Route 3: Slower (real DB startup), but most reliable
- Route 4: Balanced (fast with better reliability)

### **CI/CD Integration:**
```yaml
# .github/workflows/tests.yml
- name: Run Integration Tests
  run: dotnet test --logger "trx" --no-build
  env:
    ASPNETCORE_ENVIRONMENT: Test
```

---

## ✅ **Sign-Off Checklist**

Before marking this US as complete:

- [ ] Route selected and approved
- [ ] All implementation steps completed
- [ ] Tests run successfully locally
- [ ] No new warnings or errors introduced
- [ ] Code reviewed and approved
- [ ] Documentation updated
- [ ] CI/CD pipeline passing
- [ ] Metrics meet success criteria

---

**Document Version:** 1.0  
**Last Updated:** 2025-10-02  
**Author:** AI Assistant  
**Status:** Ready for Implementation  

