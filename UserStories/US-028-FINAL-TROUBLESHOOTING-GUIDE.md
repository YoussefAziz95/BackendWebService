# US-028: External Service Integration Tests - Final Troubleshooting Guide

## 🎯 Objective
Fix all remaining test failures to ensure 100% test success rate without skipping any tests.

---

## 📋 Current Status

### Compilation Errors (7 errors)
All errors are in `SignalRIntegrationTests.cs` related to missing `_notificationService` field.

### Test Categories Status
- ✅ **Cache Tests**: Fixed (3 tests)
- ✅ **Email Tests**: Fixed (some expectations need adjustment)
- ✅ **JWT Tests**: Fixed (claim assertions corrected)
- ❌ **SignalR Tests**: Need implementation (7 compilation errors)
- ❌ **External Service Failure Tests**: Need service registration

---

## 🔧 Phase 1: Implement Missing INotificationService

### Problem
`INotificationService` interface exists but has no implementation, causing:
- 7 compilation errors in SignalRIntegrationTests
- Constructor failures in ExternalServiceFailureTests

### Solution Strategy

#### Option A: Create Mock Implementation (Recommended for Tests)
**Location**: `BackendWebService.IntegrationTests/Infrastructure/MockNotificationService.cs`

```csharp
using Application.Contracts.HubServices;
using Application.Features;

namespace BackendWebService.IntegrationTests.Infrastructure;

/// <summary>
/// Mock implementation of INotificationService for integration tests
/// </summary>
public class MockNotificationService : INotificationService
{
    private readonly List<AddNotificationRequest> _sentNotifications = new();
    private bool _simulateFailure = false;

    public Task<bool> SendMessageAsync(AddNotificationRequest request)
    {
        if (_simulateFailure)
        {
            return Task.FromResult(false);
        }

        if (request == null || 
            string.IsNullOrEmpty(request.KeyMessageTitle) || 
            string.IsNullOrEmpty(request.KeyMessageBody))
        {
            return Task.FromResult(false);
        }

        _sentNotifications.Add(request);
        return Task.FromResult(true);
    }

    // Test helper methods
    public void SimulateFailure(bool shouldFail)
    {
        _simulateFailure = shouldFail;
    }

    public IReadOnlyList<AddNotificationRequest> GetSentNotifications()
    {
        return _sentNotifications.AsReadOnly();
    }

    public void ClearSentNotifications()
    {
        _sentNotifications.Clear();
    }
}
```

#### Option B: Create Real Implementation (For Production)
**Location**: `BackendWebService.Application/Implementations/HubServices/NotificationService.cs`

```csharp
using Application.Contracts.HubServices;
using Application.Contracts.Persistence;
using Application.Features;
using Microsoft.AspNetCore.SignalR;
using CrossCuttingConcerns.ConfigHubs;

namespace Application.Implementations.HubServices;

public class NotificationService : INotificationService
{
    private readonly IHubContext<NotificationHub> _hubContext;
    private readonly IUnitOfWork _unitOfWork;

    public NotificationService(
        IHubContext<NotificationHub> hubContext,
        IUnitOfWork unitOfWork)
    {
        _hubContext = hubContext;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> SendMessageAsync(AddNotificationRequest request)
    {
        try
        {
            // Validate request
            if (request == null || 
                string.IsNullOrEmpty(request.KeyMessageTitle) || 
                string.IsNullOrEmpty(request.KeyMessageBody))
            {
                return false;
            }

            // Save notification to database
            var notification = new Notification
            {
                KeyMessageTitle = request.KeyMessageTitle,
                KeyMessageBody = request.KeyMessageBody,
                Priority = request.Priority,
                ExpiryDate = request.ExpiryDate,
                NotifierId = request.NotifierId,
                NotifiedId = request.NotifiedId,
                NotifiedType = request.NotifiedType,
                NotificationTypeId = request.NotificationTypeId,
                NotificationType = request.NotificationType,
                NotificationObjectId = request.NotificationObjectId,
                NotificationObjectType = request.NotificationObjectType
            };

            // Use repository to add notification
            await _unitOfWork.GenericRepository<Notification>().AddAsync(notification);
            await _unitOfWork.SaveChangesAsync();

            // Send SignalR notification
            await _hubContext.Clients.User(request.NotifiedId.ToString())
                .SendAsync("ReceiveNotification", notification);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
```

---

## 🔧 Phase 2: Register Service in Test Infrastructure

### Update IntegrationTestWebApplicationFactory

**Location**: `BackendWebService.IntegrationTests/Infrastructure/IntegrationTestWebApplicationFactory.cs`

Add service registration in `ConfigureWebHost` method:

```csharp
protected override void ConfigureWebHost(IWebHostBuilder builder)
{
    builder.ConfigureServices(services =>
    {
        // ... existing service configurations ...

        // Register mock notification service for tests
        services.AddScoped<INotificationService, MockNotificationService>();
        
        // OR if using real implementation:
        // services.AddScoped<INotificationService, NotificationService>();
    });
}
```

---

## 🔧 Phase 3: Update Application Service Configuration

**Location**: `BackendWebService.Application/ServiceConfiguration/ServiceCollectionExtension.cs`

Add service registration:

```csharp
public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
{
    // ... existing registrations ...

    // Add notification service
    services.AddScoped<INotificationService, NotificationService>();

    return services;
}
```

---

## 🔧 Phase 4: Fix SignalRIntegrationTests Constructor

**Current Issue**:
```csharp
private readonly INotificationService _notificationService;
private readonly IHubContext<NotificationHub>? _hubContext;

public SignalRIntegrationTests(IntegrationTestWebApplicationFactory factory) 
    : base(factory)
{
    // INotificationService is not registered, so we skip tests that require it
    _hubContext = ServiceProvider.GetService<IHubContext<NotificationHub>>();
}
```

**Fix**:
```csharp
private readonly INotificationService _notificationService;
private readonly IHubContext<NotificationHub> _hubContext;

public SignalRIntegrationTests(IntegrationTestWebApplicationFactory factory) 
    : base(factory)
{
    _notificationService = ServiceProvider.GetRequiredService<INotificationService>();
    _hubContext = ServiceProvider.GetRequiredService<IHubContext<NotificationHub>>();
}
```

---

## 🔧 Phase 5: Fix ExternalServiceFailureTests Constructor

**Current Issue**:
```csharp
public ExternalServiceFailureTests(IntegrationTestWebApplicationFactory factory) 
    : base(factory)
{
    _emailService = ServiceProvider.GetRequiredService<IEmailService>();
    // INotificationService is not yet implemented, so we can't get it
    _notificationService = null!;
    _wireMockServer = factory.GetEmailServiceMock() ?? WireMockServer.Start();
}
```

**Fix**:
```csharp
public ExternalServiceFailureTests(IntegrationTestWebApplicationFactory factory) 
    : base(factory)
{
    _emailService = ServiceProvider.GetRequiredService<IEmailService>();
    _notificationService = ServiceProvider.GetRequiredService<INotificationService>();
    _wireMockServer = factory.GetEmailServiceMock() ?? WireMockServer.Start();
}
```

---

## 🔧 Phase 6: Remove All [Fact(Skip = "...")] Attributes

### Files to Update:
1. `SignalRIntegrationTests.cs` - Remove skip attributes from all 11 tests
2. `ExternalServiceFailureTests.cs` - Remove skip attributes from 4 tests
3. `SimplifiedExternalServiceTests.cs` - Remove skip attributes from 4 tests
4. `JwtAuthenticationIntegrationTests.cs` - Remove skip attribute from 1 test
5. `EmailServiceIntegrationTests.cs` - Keep 1 skip (legitimate - requires real SMTP)

### Replace Pattern:
```csharp
// BEFORE
[Fact(Skip = "INotificationService not yet implemented")]

// AFTER
[Fact]
```

---

## 🔧 Phase 7: Adjust Test Expectations for Email Tests

### Issue: Email Service Throws Exceptions for Invalid Inputs

**Current Implementation**: EmailService throws exceptions for invalid emails/empty content
**Test Expectations**: Tests expect graceful handling (return -1 or false)

### Solution Options:

#### Option A: Update Email Service to Handle Gracefully (Recommended)
Wrap SMTP operations in try-catch and return error codes:

```csharp
public int Send(EmailDto emailDto)
{
    try
    {
        // Validate inputs first
        if (string.IsNullOrEmpty(emailDto.To))
        {
            return -1; // Invalid recipient
        }

        // Attempt to send email
        SendEmail(emailDto);
        return 1; // Success
    }
    catch (SmtpCommandException ex)
    {
        // Log error
        return -1; // SMTP error
    }
    catch (Exception ex)
    {
        // Log error
        return -1; // General error
    }
}
```

#### Option B: Keep Current Behavior, Update Tests
Change tests to expect exceptions instead of return values:

```csharp
// For invalid email test
var action = () => _emailService.Send(emailDto);
action.Should().Throw<Exception>("Email service should throw for invalid email");
```

**Recommendation**: Use Option A for better production error handling.

---

## 🔧 Phase 8: Fix Concurrent DbContext Issue

### Issue: JWT Concurrent Token Generation Test Fails

**Problem**: DbContext is not thread-safe, causing:
```
A second operation was started on this context instance before a previous operation completed
```

### Solutions:

#### Option 1: Use Scoped Services for Each Request
```csharp
[Fact]
public async Task JwtService_ShouldHandleConcurrentTokenGeneration()
{
    // Arrange
    var user = await _appUserManager.FindByNameAsync("admin");
    user.Should().NotBeNull("Test user should exist");

    // Act - Create separate scopes for concurrent operations
    var tasks = new List<Task<string>>();
    for (int i = 0; i < 10; i++)
    {
        tasks.Add(Task.Run(async () =>
        {
            using var scope = ServiceProvider.CreateScope();
            var scopedJwtService = scope.ServiceProvider.GetRequiredService<IJwtService>();
            var scopedUserManager = scope.ServiceProvider.GetRequiredService<IAppUserManager>();
            
            // Re-fetch user in this scope
            var scopedUser = await scopedUserManager.FindByNameAsync("admin");
            var result = await scopedJwtService.GenerateAsync(scopedUser!);
            return result.access_token;
        }));
    }

    var tokens = await Task.WhenAll(tasks);

    // Assert
    tokens.Should().HaveCount(10, "All concurrent token generations should complete");
    tokens.Should().AllSatisfy(t => t.Should().NotBeNullOrEmpty("All tokens should be generated"));
}
```

#### Option 2: Remove Skip and Document Limitation
If concurrent testing is not critical, document the limitation:

```csharp
[Fact]
public async Task JwtService_ShouldHandleConcurrentTokenGeneration()
{
    // NOTE: This test validates sequential token generation
    // True concurrent testing requires separate DbContext instances
    
    var user = await _appUserManager.FindByNameAsync("admin");
    user.Should().NotBeNull("Test user should exist");

    // Generate tokens sequentially (still validates the service works correctly)
    var tokens = new List<string>();
    for (int i = 0; i < 10; i++)
    {
        var result = await _jwtService.GenerateAsync(user!);
        tokens.Add(result.access_token);
    }

    // Assert
    tokens.Should().HaveCount(10, "All token generations should complete");
    tokens.Should().AllSatisfy(t => t.Should().NotBeNullOrEmpty("All tokens should be generated"));
}
```

---

## 🔧 Phase 9: Implementation Order

### Step-by-Step Execution Plan:

1. **Create MockNotificationService** (5 minutes)
   - Create new file in Infrastructure folder
   - Implement interface with mock behavior
   - Add test helper methods

2. **Register Mock Service** (2 minutes)
   - Update IntegrationTestWebApplicationFactory
   - Add service registration

3. **Fix Test Constructors** (5 minutes)
   - Update SignalRIntegrationTests
   - Update ExternalServiceFailureTests
   - Change GetService to GetRequiredService

4. **Remove All Skip Attributes** (10 minutes)
   - Use find/replace for `[Fact(Skip = "INotificationService not yet implemented")]`
   - Replace with `[Fact]`
   - Do this across all 4 affected files

5. **Build and Test** (2 minutes)
   - Run: `dotnet build BackendWebService.IntegrationTests`
   - Verify: 0 compilation errors

6. **Fix Email Service Handling** (10 minutes)
   - Update EmailService.Send method
   - Add try-catch for graceful error handling
   - Return appropriate error codes

7. **Fix Concurrent Test** (5 minutes)
   - Update JWT concurrent test
   - Use scoped services approach

8. **Run All Tests** (5 minutes)
   - Run: `dotnet test BackendWebService.IntegrationTests --filter "FullyQualifiedName~ExternalServices"`
   - Target: 100% pass rate

9. **Commit and Push** (2 minutes)
   - Commit changes with clear message
   - Push to repository

**Total Estimated Time**: 45-50 minutes

---

## 🎯 Success Criteria

### Must Achieve:
- ✅ 0 compilation errors
- ✅ 0 skipped tests (except legitimate SMTP test)
- ✅ 100% test pass rate for all external service tests
- ✅ All SignalR tests running and passing
- ✅ All email tests passing with proper error handling
- ✅ All JWT tests passing
- ✅ All cache tests passing
- ✅ All failure scenario tests passing

### Acceptance Test Command:
```bash
dotnet test BackendWebService.IntegrationTests --filter "FullyQualifiedName~ExternalServices" --verbosity normal
```

**Expected Output**:
```
Test summary: total: ~80, failed: 0, succeeded: ~79, skipped: 1, duration: <30s
Build succeeded
```

---

## 🚨 Common Pitfalls to Avoid

1. **Don't Skip Tests** - Implement proper solutions instead
2. **Don't Use null!** - Always register required services
3. **Test with Real Behavior** - Mock services should simulate real behavior
4. **Handle Async Properly** - Use proper async/await patterns
5. **Thread Safety** - Use scoped services for concurrent operations
6. **Validate Inputs** - Services should validate and handle invalid inputs gracefully

---

## 📝 Notes

- This guide provides a complete solution without skipping any tests
- All tests should run and pass successfully
- Mock implementation is suitable for testing environment
- Real implementation should be created for production use
- Tests validate both success and failure scenarios
- Proper error handling ensures robust service behavior

---

## 🔄 Next Steps After Completion

1. Run full test suite to ensure no regressions
2. Generate coverage report
3. Document any remaining test limitations
4. Proceed with US-029 (next user story)
5. Consider implementing real NotificationService for production

---

**END OF TROUBLESHOOTING GUIDE**

