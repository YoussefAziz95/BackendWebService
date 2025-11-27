# US-028 Issue Solving Guidelines

**Document Version**: 1.0  
**Created**: October 2, 2025  
**Purpose**: Troubleshooting guide for resolving compilation errors in external service integration tests

---

## 📋 Table of Contents

1. [Overview](#overview)
2. [Error Categories](#error-categories)
3. [WireMock Configuration Issues](#wiremock-configuration-issues)
4. [SignalR Integration Issues](#signalr-integration-issues)
5. [FluentAssertions Method Issues](#fluentassertions-method-issues)
6. [AddNotificationRequest Property Access Issues](#addnotificationrequest-property-access-issues)
7. [Configuration Type Issues](#configuration-type-issues)
8. [General Troubleshooting Strategy](#general-troubleshooting-strategy)
9. [Prevention Best Practices](#prevention-best-practices)

---

## Overview

### Current Status
- **Starting Errors**: 71 compilation errors
- **After Interface Fixes**: 48 compilation errors
- **Reduction**: 32% (23 errors fixed)
- **Remaining Categories**: 4 main categories

### Successfully Fixed Issues ✅
1. **EmailDto Constructor Parameters** - Changed from object initializer to constructor syntax
2. **AddNotificationRequest Constructor Parameters** - Updated to use correct constructor with proper parameter names
3. **JsonSerializer Ambiguity** - Added using alias to specify `System.Text.Json.JsonSerializer`
4. **IJwtService Method Names** - Updated from `GenerateToken()` to `GenerateAsync()` with `access_token` property

---

## Error Categories

### 1. WireMock Configuration Issues (30 errors)
**Error Pattern**:
```
CS0103: The name 'Request' does not exist in the current context
CS1501: No overload for method 'Create' takes 0 arguments
CS0266: Cannot implicitly convert type 'IResponseBuilder' to 'ResponseMessage'
CS1662: Cannot convert lambda expression to intended delegate type
```

**Affected Files**:
- `ExternalServiceTestConfiguration.cs` (majority of errors)
- `ExternalServiceFailureTests.cs` (3 errors)

### 2. SignalR Integration Issues (5 errors)
**Error Pattern**:
```
CS0246: The type or namespace name 'HubConnectionBuilder' could not be found
CS0246: The type or namespace name 'INotificationProxy<>' could not be found
CS1061: 'AddNotificationRequest' does not contain a definition for 'Title'
CS1061: 'AddNotificationRequest' does not contain a definition for 'Message'
```

**Affected Files**:
- `SignalRIntegrationTests.cs`

### 3. FluentAssertions Method Issues (5 errors)
**Error Pattern**:
```
CS1061: 'NumericAssertions<int>' does not contain a definition for 'NotBeNull'
CS1061: 'DateTimeAssertions' does not contain a definition for 'BeBeforeOrEqualTo'
CS1061: 'GenericAsyncFunctionAssertions<AccessToken>' does not contain a definition for 'Throw'
```

**Affected Files**:
- `EmailServiceIntegrationTests.cs` (2 errors)
- `JwtAuthenticationIntegrationTests.cs` (2 errors)

### 4. Configuration Type Issues (2 errors)
**Error Pattern**:
```
CS0718: 'EmailConfiguration': static types cannot be used as type arguments
CS0246: The type or namespace name 'NotificationConfiguration' could not be found
```

**Affected Files**:
- `ExternalServiceTestConfiguration.cs`

---

## WireMock Configuration Issues

### Problem Analysis

#### Issue 1: Missing `Request` Class Reference
**Error**: `CS0103: The name 'Request' does not exist in the current context`

**Root Cause**: The `Request` class from WireMock is not properly imported or aliased.

**Solution Approach**:
1. **Check Using Directives**:
   ```csharp
   using WireMock.RequestBuilders;
   using Request = WireMock.RequestBuilders.Request;  // Alias if needed
   ```

2. **Verify WireMock Package**: Ensure correct version is installed
   ```xml
   <PackageReference Include="WireMock.Net" Version="..." />
   ```

3. **Common Patterns**:
   ```csharp
   // Correct usage
   _wireMockServer
       .Given(Request.Create()
           .WithPath("/api/email/send")
           .UsingPost())
       .RespondWith(Response.Create()
           .WithStatusCode(200));
   ```

#### Issue 2: Response Builder Conversion Error
**Error**: `CS0266: Cannot implicitly convert type 'IResponseBuilder' to 'ResponseMessage'`

**Root Cause**: WireMock's fluent API requires proper method chaining or lambda expression structure.

**Solution Approach**:
1. **Check Response Builder Pattern**:
   ```csharp
   // Option 1: Direct fluent chain
   .RespondWith(Response.Create()
       .WithStatusCode(200)
       .WithHeader("Content-Type", "application/json")
       .WithBody("{\"success\": true}"))
   
   // Option 2: Callback pattern (if using lambda)
   .RespondWith(req => Response.Create()
       .WithStatusCode(200)
       .WithBody("..."))
   ```

2. **Verify Lambda Signature**:
   - If using callback: `Func<IRequestMessage, ResponseMessage>`
   - Ensure all paths in lambda return proper type

#### Issue 3: Response Ambiguity
**Error**: `CS0104: 'Response' is an ambiguous reference`

**Root Cause**: Multiple types named `Response` exist (e.g., `Application.Features.Response` and `WireMock.ResponseBuilders.Response`)

**Solution**:
```csharp
// Add using alias at top of file
using Response = WireMock.ResponseBuilders.Response;
```

### Diagnostic Steps

1. **Identify the Pattern**:
   ```bash
   # Search for WireMock usage patterns
   grep -n "Request.Create" ExternalServiceTestConfiguration.cs
   grep -n "Response.Create" ExternalServiceTestConfiguration.cs
   ```

2. **Check Existing Working Examples**:
   - Look at `ExternalServiceFailureTests.cs` where Response alias is correctly used
   - Compare patterns in `SimplifiedExternalServiceTests.cs`

3. **Verify Package References**:
   ```bash
   dotnet list BackendWebService.IntegrationTests package | grep WireMock
   ```

### Recommended Fixes

#### Fix 1: Add Missing Using Directives
```csharp
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using Request = WireMock.RequestBuilders.Request;
using Response = WireMock.ResponseBuilders.Response;
```

#### Fix 2: Correct Response Builder Usage
```csharp
// Before (if causing conversion issues)
.RespondWith(req => {
    var response = Response.Create().WithStatusCode(200);
    return response;  // Might need explicit build/create call
})

// After (simplified direct chain)
.RespondWith(Response.Create()
    .WithStatusCode(200)
    .WithHeader("Content-Type", "application/json")
    .WithBody("{\"success\": true}"))
```

#### Fix 3: Simplify Complex Configurations
If `ExternalServiceTestConfiguration.cs` has too many errors, consider:
1. **Simplification**: Remove overly complex mock setups
2. **Refactoring**: Break into smaller, focused configuration methods
3. **Alternative**: Use real services with test containers (if feasible)

---

## SignalR Integration Issues

### Problem Analysis

#### Issue 1: HubConnectionBuilder Not Found
**Error**: `CS0246: The type or namespace name 'HubConnectionBuilder' could not be found`

**Root Cause**: Missing NuGet package or using directive for SignalR client.

**Solution Approach**:
1. **Add NuGet Package**:
   ```xml
   <PackageReference Include="Microsoft.AspNetCore.SignalR.Client" Version="8.0.0" />
   ```

2. **Add Using Directive**:
   ```csharp
   using Microsoft.AspNetCore.SignalR.Client;
   ```

3. **Verify Usage Pattern**:
   ```csharp
   var connection = new HubConnectionBuilder()
       .WithUrl($"{_factory.Server.BaseAddress}notificationHub")
       .Build();
   ```

#### Issue 2: INotificationProxy Not Found
**Error**: `CS0246: The type or namespace name 'INotificationProxy<>' could not be found`

**Root Cause**: Custom interface not properly referenced or namespace issue.

**Solution Approach**:
1. **Find Interface Definition**:
   ```bash
   grep -r "interface INotificationProxy" BackendWebService.Application/
   ```

2. **Add Using Directive**:
   ```csharp
   using Application.Contracts.HubServices;
   ```

3. **Alternative Approach**: If interface is complex or causing issues, test SignalR hub methods directly without proxy pattern

#### Issue 3: AddNotificationRequest Property Access
**Error**: `CS1061: 'AddNotificationRequest' does not contain a definition for 'Title'`

**Root Cause**: Record properties are accessed incorrectly or test is comparing wrong properties.

**Solution Approach**:
1. **Use Correct Property Names**:
   ```csharp
   // Wrong
   notificationRequest.Title
   notificationRequest.Message
   
   // Correct
   notificationRequest.KeyMessageTitle
   notificationRequest.KeyMessageBody
   ```

2. **Update Assertions**:
   ```csharp
   // Before
   deserializedRequest.Title.Should().Be(notificationRequest.Title);
   
   // After
   deserializedRequest.KeyMessageTitle.Should().Be(notificationRequest.KeyMessageTitle);
   ```

### Diagnostic Steps

1. **Check Package References**:
   ```bash
   dotnet list BackendWebService.IntegrationTests package | grep SignalR
   ```

2. **Verify Interface Location**:
   ```bash
   grep -r "INotificationProxy" BackendWebService.Application/
   ```

3. **Examine AddNotificationRequest Definition**:
   ```bash
   grep -A 20 "record AddNotificationRequest" BackendWebService.Application/
   ```

### Recommended Fixes

#### Fix 1: Add SignalR Client Package
```bash
dotnet add BackendWebService.IntegrationTests package Microsoft.AspNetCore.SignalR.Client --version 8.0.0
```

#### Fix 2: Update Property References in Assertions
Search and replace in `SignalRIntegrationTests.cs`:
- `.Title` → `.KeyMessageTitle`
- `.Message` → `.KeyMessageBody`
- `.UserId` → `.NotifierId` or `.NotifiedId` (context-dependent)

#### Fix 3: Simplify SignalR Tests
If integration is too complex:
1. **Focus on basic connectivity**: Test hub connection establishment
2. **Test core methods**: SendMessage, ReceiveMessage
3. **Skip advanced scenarios**: Complex proxy patterns, detailed serialization tests

---

## FluentAssertions Method Issues

### Problem Analysis

#### Issue 1: NotBeNull on NumericAssertions
**Error**: `CS1061: 'NumericAssertions<int>' does not contain a definition for 'NotBeNull'`

**Root Cause**: Numeric types (int, double, etc.) are value types and cannot be null in C#. FluentAssertions doesn't provide `NotBeNull()` for value types.

**Solution Approach**:
1. **For Value Types**: Use appropriate numeric assertions
   ```csharp
   // Wrong (int cannot be null)
   emailCount.Should().NotBeNull();
   
   // Correct - check for positive value or specific range
   emailCount.Should().BeGreaterThan(0);
   emailCount.Should().BePositive();
   emailCount.Should().BeGreaterOrEqualTo(0);
   ```

2. **For Nullable Value Types**:
   ```csharp
   int? nullableCount = GetCount();
   nullableCount.Should().NotBeNull();  // This is valid
   nullableCount.Value.Should().BeGreaterThan(0);
   ```

#### Issue 2: BeBeforeOrEqualTo Not Found
**Error**: `CS1061: 'DateTimeAssertions' does not contain a definition for 'BeBeforeOrEqualTo'`

**Root Cause**: Method name doesn't match FluentAssertions API (version-dependent or incorrect name).

**Solution Approach**:
1. **Check Correct Method Name**:
   ```csharp
   // Wrong
   expiryDate.Should().BeBeforeOrEqualTo(expectedDate);
   
   // Correct (FluentAssertions API)
   expiryDate.Should().BeOnOrBefore(expectedDate);
   // OR
   expiryDate.Should().BeBefore(expectedDate.AddSeconds(1));
   ```

2. **Alternative DateTime Assertions**:
   ```csharp
   // Available methods in FluentAssertions
   .BeBefore(DateTime)
   .BeAfter(DateTime)
   .BeOnOrBefore(DateTime)
   .BeOnOrAfter(DateTime)
   .BeCloseTo(DateTime, TimeSpan precision)
   .BeSameDateAs(DateTime)
   ```

#### Issue 3: Throw on Async Assertions
**Error**: `CS1061: 'GenericAsyncFunctionAssertions<AccessToken>' does not contain a definition for 'Throw'`

**Root Cause**: Incorrect async/await pattern with FluentAssertions.

**Solution Approach**:
1. **Correct Async Exception Assertion**:
   ```csharp
   // Wrong (for async methods)
   var action = () => _jwtService.GenerateAsync(null!);
   action.Should().Throw<ArgumentNullException>();
   
   // Correct (async version)
   Func<Task> action = async () => await _jwtService.GenerateAsync(null!);
   await action.Should().ThrowAsync<ArgumentNullException>();
   
   // Alternative (more concise)
   await _jwtService
       .Invoking(async s => await s.GenerateAsync(null!))
       .Should().ThrowAsync<ArgumentNullException>();
   ```

2. **For Synchronous Methods**:
   ```csharp
   Action action = () => _service.SyncMethod(null!);
   action.Should().Throw<ArgumentNullException>();
   ```

### Diagnostic Steps

1. **Check FluentAssertions Version**:
   ```bash
   dotnet list BackendWebService.IntegrationTests package | grep FluentAssertions
   ```

2. **Review FluentAssertions Documentation**:
   - Numeric assertions: https://fluentassertions.com/numeric
   - DateTime assertions: https://fluentassertions.com/datetimespans
   - Exception assertions: https://fluentassertions.com/exceptions

3. **Search for Problematic Assertions**:
   ```bash
   grep -n "\.NotBeNull()" BackendWebService.IntegrationTests/ExternalServices/EmailServiceIntegrationTests.cs
   grep -n "BeBeforeOrEqualTo" BackendWebService.IntegrationTests/ExternalServices/JwtAuthenticationIntegrationTests.cs
   ```

### Recommended Fixes

#### Fix 1: Replace NotBeNull on Numeric Types
```csharp
// In EmailServiceIntegrationTests.cs
// Line ~188 and ~218

// Before
emailCount.Should().NotBeNull();

// After
emailCount.Should().BeGreaterOrEqualTo(0, "email count should be a valid number");
// OR if expecting emails were sent
emailCount.Should().BeGreaterThan(0, "emails should have been sent");
```

#### Fix 2: Update DateTime Assertions
```csharp
// In JwtAuthenticationIntegrationTests.cs
// Line ~91

// Before
tokenResult.expires_in.Should().BeBeforeOrEqualTo(expectedExpiry);

// After
var expiryTime = DateTime.UtcNow.AddSeconds(tokenResult.expires_in);
expiryTime.Should().BeOnOrBefore(DateTime.UtcNow.AddHours(1));
// OR simply check the value
tokenResult.expires_in.Should().BeGreaterThan(0).And.BeLessOrEqualTo(3600);
```

#### Fix 3: Fix Async Exception Assertions
```csharp
// In JwtAuthenticationIntegrationTests.cs
// Line ~136-139

// Before
var action = () => _jwtService.GenerateAsync(null!);
action.Should().Throw<ArgumentNullException>();

// After
Func<Task> action = async () => await _jwtService.GenerateAsync(null!);
await action.Should().ThrowAsync<ArgumentNullException>("JWT service should throw exception for null user");
```

---

## AddNotificationRequest Property Access Issues

### Problem Analysis

**Error Pattern**:
```
CS1061: 'AddNotificationRequest' does not contain a definition for 'Title'
CS1061: 'AddNotificationRequest' does not contain a definition for 'Message'
```

**Root Cause**: Tests are still trying to access properties using old names after the record was updated to use constructor parameters.

**Affected Locations**:
- `SignalRIntegrationTests.cs` - Lines ~327-328 (assertion comparisons)

### Solution Approach

#### Step 1: Understand the Record Structure
```csharp
// AddNotificationRequest is a record with these properties:
public record AddNotificationRequest(
    string KeyMessageTitle,        // NOT "Title"
    string KeyMessageBody,         // NOT "Message"
    NotificationPriorityEnum Priority,
    DateTime ExpiryDate,
    int NotifierId,                // NOT "UserId"
    int NotifiedId,
    string NotifiedType,
    int? NotificationTypeId,
    string? NotificationType,
    int? NotificationObjectId,
    string? NotificationObjectType,
    List<AddNotificationDetailRequest> Details
);
```

#### Step 2: Update Property Access in Assertions
```csharp
// Before (wrong property names)
deserializedRequest.Title.Should().Be(notificationRequest.Title);
deserializedRequest.Message.Should().Be(notificationRequest.Message);

// After (correct property names)
deserializedRequest.KeyMessageTitle.Should().Be(notificationRequest.KeyMessageTitle);
deserializedRequest.KeyMessageBody.Should().Be(notificationRequest.KeyMessageBody);
```

### Diagnostic Steps

1. **Find All Property Access Locations**:
   ```bash
   grep -n "\.Title" BackendWebService.IntegrationTests/ExternalServices/SignalRIntegrationTests.cs
   grep -n "\.Message" BackendWebService.IntegrationTests/ExternalServices/SignalRIntegrationTests.cs
   ```

2. **Verify Record Definition**:
   ```bash
   grep -A 15 "record AddNotificationRequest" BackendWebService.Application/
   ```

3. **Check for Pattern**:
   - Look for assertions comparing deserialized objects
   - Look for property access in string interpolation
   - Look for logging statements using these properties

### Recommended Fixes

#### Fix: Update All Property References
```csharp
// In SignalRIntegrationTests.cs
// Around lines 327-328 in the SignalR_ShouldHandleJsonSerialization test

// Before
deserializedRequest.Title.Should().Be(notificationRequest.Title, "Title should match after deserialization");
deserializedRequest.Message.Should().Be(notificationRequest.Message, "Message should match after deserialization");

// After
deserializedRequest.KeyMessageTitle.Should().Be(notificationRequest.KeyMessageTitle, "Title should match after deserialization");
deserializedRequest.KeyMessageBody.Should().Be(notificationRequest.KeyMessageBody, "Message should match after deserialization");
```

---

## Configuration Type Issues

### Problem Analysis

#### Issue 1: Static Type as Type Argument
**Error**: `CS0718: 'EmailConfiguration': static types cannot be used as type arguments`

**Root Cause**: Trying to use a static class as a generic type parameter (e.g., `IOptions<EmailConfiguration>` where `EmailConfiguration` is static).

**Solution Approach**:
1. **Check Class Definition**:
   ```bash
   grep -n "class EmailConfiguration" BackendWebService.Application/
   ```

2. **Possible Scenarios**:
   - If it's meant to be a configuration class: Remove `static` keyword
   - If it's a static utility class: Create a non-static configuration POCO class
   - If using `IOptions<T>`: `T` must be a non-static class

3. **Correct Pattern**:
   ```csharp
   // Wrong (static class)
   public static class EmailConfiguration
   {
       public static string SmtpServer { get; set; }
   }
   
   // Correct (configuration class)
   public class EmailConfiguration
   {
       public string SmtpServer { get; set; }
       public int Port { get; set; }
       public string Username { get; set; }
   }
   ```

#### Issue 2: NotificationConfiguration Not Found
**Error**: `CS0246: The type or namespace name 'NotificationConfiguration' could not be found`

**Root Cause**: Class doesn't exist or is in a different namespace.

**Solution Approach**:
1. **Search for the Class**:
   ```bash
   grep -r "class NotificationConfiguration" BackendWebService.Application/
   grep -r "class NotificationConfiguration" BackendWebService.CrossCuttingConcerns/
   ```

2. **Possible Solutions**:
   - Class doesn't exist: Create it or use alternative configuration approach
   - Wrong namespace: Add correct using directive
   - Removed/refactored: Update test to use current configuration pattern

3. **Alternative Approach**:
   ```csharp
   // If configuration doesn't exist, use manual setup
   // Instead of:
   services.Configure<NotificationConfiguration>(config => { ... });
   
   // Use direct service configuration:
   services.AddSingleton(new NotificationSettings
   {
       HubEndpoint = "...",
       // other settings
   });
   ```

### Diagnostic Steps

1. **Locate EmailConfiguration**:
   ```bash
   find . -name "*.cs" -exec grep -l "EmailConfiguration" {} \;
   ```

2. **Check if Static**:
   ```bash
   grep -A 5 "class EmailConfiguration" BackendWebService.Application/
   ```

3. **Search for NotificationConfiguration**:
   ```bash
   find . -name "*.cs" -exec grep -l "NotificationConfiguration" {} \;
   ```

### Recommended Fixes

#### Fix 1: Handle EmailConfiguration
```csharp
// Option A: If class should not be static, change its definition
// In the actual EmailConfiguration class file
public class EmailConfiguration  // Remove 'static'
{
    public string SmtpServer { get; set; }
    public int SmtpPort { get; set; }
    // ... other properties
}

// Option B: If it must be static, don't use it with IOptions
// In test configuration
// Instead of:
services.Configure<EmailConfiguration>(config => { ... });

// Use:
services.AddSingleton<IEmailService>(sp => 
    new EmailService(
        EmailConfiguration.SmtpServer,  // Access static properties directly
        EmailConfiguration.SmtpPort
    ));
```

#### Fix 2: Handle NotificationConfiguration
```csharp
// Option A: Create the missing class
public class NotificationConfiguration
{
    public string HubEndpoint { get; set; }
    public int MaxRetries { get; set; }
    public TimeSpan Timeout { get; set; }
}

// Option B: Remove usage if not needed
// Remove or comment out the configuration in ExternalServiceTestConfiguration.cs
// services.Configure<NotificationConfiguration>(config => { ... });

// Option C: Use alternative configuration
services.AddSingleton(new { HubEndpoint = "/notificationHub" });
```

---

## General Troubleshooting Strategy

### Step 1: Categorize Errors
```bash
# Build and capture errors
dotnet build BackendWebService.IntegrationTests > build_errors.txt 2>&1

# Analyze error patterns
grep "error CS" build_errors.txt | cut -d: -f4 | sort | uniq -c | sort -nr
```

### Step 2: Prioritize Fixes
1. **Package/Reference Issues** (highest impact)
   - Missing NuGet packages
   - Missing using directives
   - Wrong package versions

2. **Type/Interface Issues** (medium impact)
   - Wrong method names
   - Wrong property names
   - Wrong parameter types

3. **API Usage Issues** (lower impact)
   - Incorrect FluentAssertions syntax
   - WireMock configuration patterns

### Step 3: Incremental Fixing
```bash
# Fix one category at a time
# After each fix, rebuild and verify progress
dotnet build BackendWebService.IntegrationTests --no-restore
```

### Step 4: Validate Fixes
```bash
# Run tests for fixed areas
dotnet test BackendWebService.IntegrationTests --filter "ClassName~Email" --verbosity normal
```

### Step 5: Document Patterns
- Keep track of what worked
- Note any API version-specific issues
- Document workarounds for future reference

---

## Prevention Best Practices

### 1. Interface Discovery Before Implementation
```bash
# Before writing tests, discover actual interfaces:

# Find interface definition
grep -r "interface IJwtService" BackendWebService.Application/

# Check method signatures
grep -A 3 "GenerateAsync" BackendWebService.Application/Contracts/Services/

# Verify DTO structure
grep -A 20 "class EmailDto" BackendWebService.Application/Model/
```

### 2. Use Actual Type Definitions
```csharp
// Don't assume property names
// Always check the actual class/record definition

// Wrong approach:
var dto = new SomeDto { Name = "test", Value = 123 };  // Guessing properties

// Correct approach:
// 1. Read the class definition
// 2. Use constructor if it's a record
// 3. Match actual property names
var dto = new SomeDto(
    propertyName: "test",  // Use actual parameter name
    propertyValue: 123
);
```

### 3. Incremental Test Development
```csharp
// Start simple, then expand

// Phase 1: Basic test (verify compilation)
[Fact]
public async Task Service_ShouldExist()
{
    _service.Should().NotBeNull();
}

// Phase 2: Add core functionality test
[Fact]
public async Task Service_ShouldProcessRequest()
{
    var result = await _service.ProcessAsync(request);
    result.Should().NotBeNull();
}

// Phase 3: Add detailed assertions
// Only after verifying basic structure works
```

### 4. Reference Working Examples
```bash
# Find working tests first
dotnet test BackendWebService.IntegrationTests --filter "ClassName~Database" --verbosity normal

# Study their patterns
# Apply same patterns to new tests
```

### 5. Package Version Consistency
```xml
<!-- Ensure consistent package versions across test projects -->
<PackageReference Include="FluentAssertions" Version="6.12.0" />
<PackageReference Include="Microsoft.AspNetCore.Mvc.Testing" Version="8.0.0" />
<PackageReference Include="WireMock.Net" Version="1.5.45" />
```

### 6. Using Aliases for Ambiguous Types
```csharp
// At top of file, add aliases for commonly conflicting types
using JsonSerializer = System.Text.Json.JsonSerializer;
using Response = WireMock.ResponseBuilders.Response;
using Request = WireMock.RequestBuilders.Request;
```

### 7. Check Documentation
```csharp
// For external libraries, check their documentation first
// - FluentAssertions: https://fluentassertions.com/
// - WireMock.Net: https://github.com/WireMock-Net/WireMock.Net/wiki
// - SignalR Testing: https://learn.microsoft.com/en-us/aspnet/core/signalr/test
```

### 8. Test Isolation
```csharp
// Keep tests focused and independent
// Avoid complex test configurations that affect multiple services

// Instead of one massive configuration file:
// ExternalServiceTestConfiguration.cs (500+ lines, many errors)

// Create focused configuration helpers:
// EmailServiceTestConfiguration.cs
// SignalRTestConfiguration.cs
// CacheTestConfiguration.cs
```

---

## Quick Reference: Error Code Lookup

| Error Code | Meaning | Common Cause | Quick Fix |
|------------|---------|--------------|-----------|
| CS0103 | Name does not exist | Missing using directive | Add `using` statement |
| CS0246 | Type not found | Missing package or namespace | Install package or add `using` |
| CS0718 | Static type as type argument | Using static class with generics | Make class non-static |
| CS1061 | Member not found | Wrong property/method name | Check actual interface definition |
| CS1501 | No matching overload | Wrong parameters | Check method signature |
| CS0266 | Cannot convert | Type mismatch | Check return types and conversions |
| CS1662 | Lambda conversion error | Wrong lambda return type | Verify delegate signature |

---

## Summary Checklist

### Before Fixing Errors:
- [ ] Run build and capture all errors
- [ ] Categorize errors by type
- [ ] Identify affected files
- [ ] Check package versions
- [ ] Review working examples

### During Fixes:
- [ ] Fix one category at a time
- [ ] Rebuild after each batch of fixes
- [ ] Verify error count decreases
- [ ] Document what worked

### After Fixes:
- [ ] Run full build
- [ ] Run affected tests
- [ ] Update documentation
- [ ] Commit changes with clear messages

---

## Recommended Action Plan

### Phase 1: Critical Fixes (High Impact)
1. **Add SignalR Client Package**
   ```bash
   dotnet add BackendWebService.IntegrationTests package Microsoft.AspNetCore.SignalR.Client --version 8.0.0
   ```

2. **Fix FluentAssertions Issues** (5 errors)
   - Update numeric assertions
   - Fix DateTime method names
   - Fix async exception assertions

3. **Fix Remaining AddNotificationRequest Properties** (4 errors)
   - Update property names in SignalRIntegrationTests.cs

### Phase 2: WireMock Configuration (Medium Impact)
1. **Option A: Fix Configuration Issues**
   - Add using aliases for Request/Response
   - Fix lambda expressions
   - Correct response builder patterns

2. **Option B: Simplify Approach** (Recommended if errors persist)
   - Create simplified mock configurations
   - Focus on core test scenarios
   - Consider marking complex tests as `[Fact(Skip = "...")]` temporarily

### Phase 3: Configuration Types (Low Impact)
1. **Investigate EmailConfiguration**
   - Determine if it should be static
   - Update accordingly

2. **Handle NotificationConfiguration**
   - Create if missing
   - Remove if not needed

---

## Notes for Future User Stories

### US-029+ Integration Test Improvements
- Consider test simplification strategies
- Evaluate real service vs. mock tradeoffs
- Plan for test maintenance and updates

### Documentation Updates
- Keep this guide updated with new patterns
- Add new error categories as discovered
- Document version-specific issues

---

**End of Guide**

For questions or issues not covered here, refer to:
- `US-028-IMPLEMENTATION-SUMMARY.md`
- `US-028-FINAL-SUMMARY.md`
- `US-026.1-Integration-Test-Best-Practices-And-Troubleshooting.md`

