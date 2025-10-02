using Application.Model.EmailDto;
using Application.Features;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BackendWebService.IntegrationTests.ExternalServices;

/// <summary>
/// Test data builder for external service integration tests
/// </summary>
public static class ExternalServiceTestDataBuilder
{
    /// <summary>
    /// Create a valid email DTO for testing
    /// </summary>
    public static EmailDto CreateValidEmailDto()
    {
        return new EmailDto(
            subject: "Test Email Subject",
            body: "This is a test email body with some content.",
            to: "test@example.com",
            cC: "cc@example.com",
            bCC: "bcc@example.com",
            sentAt: DateTime.UtcNow,
            senderId: 1
        );
    }

    /// <summary>
    /// Create an email DTO with invalid email address
    /// </summary>
    public static EmailDto CreateInvalidEmailDto()
    {
        return new EmailDto(
            subject: "Test Email Subject",
            body: "This is a test email body with some content.",
            to: "invalid-email-address",
            cC: "",
            bCC: "",
            sentAt: DateTime.UtcNow,
            senderId: 1
        );
    }

    /// <summary>
    /// Create an email DTO with empty required fields
    /// </summary>
    public static EmailDto CreateEmptyEmailDto()
    {
        return new EmailDto(
            subject: "",
            body: "",
            to: "",
            cC: "",
            bCC: "",
            sentAt: DateTime.UtcNow,
            senderId: 1
        );
    }

    /// <summary>
    /// Create an email DTO with long content
    /// </summary>
    public static EmailDto CreateLongContentEmailDto()
    {
        var longBody = new string('A', 10000); // 10KB body
        var longSubject = new string('B', 1000); // 1KB subject

        return new EmailDto(
            subject: longSubject,
            body: longBody,
            to: "test@example.com",
            cC: "",
            bCC: "",
            sentAt: DateTime.UtcNow,
            senderId: 1
        );
    }

    /// <summary>
    /// Create an email DTO with special characters
    /// </summary>
    public static EmailDto CreateSpecialCharactersEmailDto()
    {
        return new EmailDto(
            subject: "Test Email with Special Characters: !@#$%^&*()_+-=[]{}|;':\",./<>?",
            body: "This email contains special characters:\n• Bullet point\n• Another bullet point\n• Unicode: 你好世界 🌍",
            to: "test+special@example.com",
            cC: "cc+special@example.com",
            bCC: "bcc+special@example.com",
            sentAt: DateTime.UtcNow,
            senderId: 1
        );
    }

    /// <summary>
    /// Create a valid notification request for testing
    /// </summary>
    public static AddNotificationRequest CreateValidNotificationRequest()
    {
        return new AddNotificationRequest(
            KeyMessageTitle: "Test Notification",
            KeyMessageBody: "This is a test notification message",
            Priority: Domain.Enums.NotificationPriorityEnum.Medium,
            ExpiryDate: DateTime.UtcNow.AddDays(7),
            NotifierId: 1,
            NotifiedId: 1,
            NotifiedType: "User",
            NotificationTypeId: 1,
            NotificationType: "Info",
            NotificationObjectId: null,
            NotificationObjectType: null,
            Details: new List<AddNotificationDetailRequest>()
        );
    }

    /// <summary>
    /// Create a notification request with invalid data
    /// </summary>
    public static AddNotificationRequest CreateInvalidNotificationRequest()
    {
        return new AddNotificationRequest(
            KeyMessageTitle: "", // Empty title
            KeyMessageBody: "", // Empty message
            Priority: Domain.Enums.NotificationPriorityEnum.Low,
            ExpiryDate: DateTime.UtcNow.AddDays(1),
            NotifierId: 0, // Invalid user ID
            NotifiedId: 0,
            NotifiedType: "",
            NotificationTypeId: null,
            NotificationType: "", // Empty type
            NotificationObjectId: null,
            NotificationObjectType: null,
            Details: new List<AddNotificationDetailRequest>()
        );
    }

    /// <summary>
    /// Create a notification request with long content
    /// </summary>
    public static AddNotificationRequest CreateLongContentNotificationRequest()
    {
        var longTitle = new string('A', 1000); // 1KB title
        var longMessage = new string('B', 10000); // 10KB message

        return new AddNotificationRequest(
            KeyMessageTitle: longTitle,
            KeyMessageBody: longMessage,
            Priority: Domain.Enums.NotificationPriorityEnum.Medium,
            ExpiryDate: DateTime.UtcNow.AddDays(7),
            NotifierId: 1,
            NotifiedId: 1,
            NotifiedType: "User",
            NotificationTypeId: 1,
            NotificationType: "Info",
            NotificationObjectId: null,
            NotificationObjectType: null,
            Details: new List<AddNotificationDetailRequest>()
        );
    }

    /// <summary>
    /// Create a notification request with special characters
    /// </summary>
    public static AddNotificationRequest CreateSpecialCharactersNotificationRequest()
    {
        return new AddNotificationRequest(
            KeyMessageTitle: "Test Notification with Special Characters: !@#$%^&*()_+-=[]{}|;':\",./<>?",
            KeyMessageBody: "This notification contains special characters:\n• Bullet point\n• Another bullet point\n• Unicode: 你好世界 🌍",
            Priority: Domain.Enums.NotificationPriorityEnum.Medium,
            ExpiryDate: DateTime.UtcNow.AddDays(7),
            NotifierId: 1,
            NotifiedId: 1,
            NotifiedType: "User",
            NotificationTypeId: 1,
            NotificationType: "Info",
            NotificationObjectId: null,
            NotificationObjectType: null,
            Details: new List<AddNotificationDetailRequest>()
        );
    }

    /// <summary>
    /// Create a valid HTTP request message
    /// </summary>
    public static HttpRequestMessage CreateValidHttpRequest(string endpoint = "/api/test")
    {
        var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "BackendWebService-IntegrationTests/1.0");
        return request;
    }

    /// <summary>
    /// Create a POST HTTP request message with JSON content
    /// </summary>
    public static HttpRequestMessage CreatePostHttpRequest<T>(T content, string endpoint = "/api/test")
    {
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "BackendWebService-IntegrationTests/1.0");
        
        var json = JsonSerializer.Serialize(content);
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        
        return request;
    }

    /// <summary>
    /// Create a PUT HTTP request message with JSON content
    /// </summary>
    public static HttpRequestMessage CreatePutHttpRequest<T>(T content, string endpoint = "/api/test")
    {
        var request = new HttpRequestMessage(HttpMethod.Put, endpoint);
        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "BackendWebService-IntegrationTests/1.0");
        
        var json = JsonSerializer.Serialize(content);
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        
        return request;
    }

    /// <summary>
    /// Create a DELETE HTTP request message
    /// </summary>
    public static HttpRequestMessage CreateDeleteHttpRequest(string endpoint = "/api/test")
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, endpoint);
        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "BackendWebService-IntegrationTests/1.0");
        return request;
    }

    /// <summary>
    /// Create an HTTP request with custom headers
    /// </summary>
    public static HttpRequestMessage CreateHttpRequestWithHeaders(
        HttpMethod method, 
        string endpoint, 
        Dictionary<string, string> headers)
    {
        var request = new HttpRequestMessage(method, endpoint);
        
        foreach (var header in headers)
        {
            request.Headers.Add(header.Key, header.Value);
        }
        
        return request;
    }

    /// <summary>
    /// Create a test user for authentication
    /// </summary>
    public static TestUser CreateTestUser()
    {
        return new TestUser
        {
            Id = 1,
            Username = "testuser",
            Email = "test@example.com",
            FirstName = "Test",
            LastName = "User",
            IsActive = true
        };
    }

    /// <summary>
    /// Create a test user with invalid data
    /// </summary>
    public static TestUser CreateInvalidTestUser()
    {
        return new TestUser
        {
            Id = 0,
            Username = "",
            Email = "invalid-email",
            FirstName = "",
            LastName = "",
            IsActive = false
        };
    }

    /// <summary>
    /// Create a test organization
    /// </summary>
    public static TestOrganization CreateTestOrganization()
    {
        return new TestOrganization
        {
            Id = 1,
            Name = "Test Organization",
            Country = "Test Country",
            City = "Test City",
            StreetAddress = "123 Test Street",
            Email = "org@example.com",
            Phone = "123-456-7890",
            FaxNo = "123-456-7891",
            TaxNo = "TAX123456",
            IsActive = true
        };
    }

    /// <summary>
    /// Create a test API response
    /// </summary>
    public static TestApiResponse CreateTestApiResponse()
    {
        return new TestApiResponse
        {
            Success = true,
            Message = "Operation completed successfully",
            Data = new { Id = 1, Name = "Test Item" },
            Timestamp = DateTime.UtcNow
        };
    }

    /// <summary>
    /// Create a test API error response
    /// </summary>
    public static TestApiResponse CreateTestApiErrorResponse()
    {
        return new TestApiResponse
        {
            Success = false,
            Message = "An error occurred",
            Error = "Test error message",
            Timestamp = DateTime.UtcNow
        };
    }

    /// <summary>
    /// Create a test configuration
    /// </summary>
    public static TestConfiguration CreateTestConfiguration()
    {
        return new TestConfiguration
        {
            ApiUrl = "https://api.test.com",
            Timeout = 30,
            RetryCount = 3,
            RetryDelay = 1000,
            EnableLogging = true,
            LogLevel = "Debug"
        };
    }

    /// <summary>
    /// Create a test configuration with invalid values
    /// </summary>
    public static TestConfiguration CreateInvalidTestConfiguration()
    {
        return new TestConfiguration
        {
            ApiUrl = "",
            Timeout = -1,
            RetryCount = -1,
            RetryDelay = -1,
            EnableLogging = false,
            LogLevel = ""
        };
    }
}

/// <summary>
/// Test user model
/// </summary>
public class TestUser
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}

/// <summary>
/// Test organization model
/// </summary>
public class TestOrganization
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string StreetAddress { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string FaxNo { get; set; } = string.Empty;
    public string TaxNo { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}

/// <summary>
/// Test API response model
/// </summary>
public class TestApiResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public object? Data { get; set; }
    public string? Error { get; set; }
    public DateTime Timestamp { get; set; }
}

/// <summary>
/// Test configuration model
/// </summary>
public class TestConfiguration
{
    public string ApiUrl { get; set; } = string.Empty;
    public int Timeout { get; set; }
    public int RetryCount { get; set; }
    public int RetryDelay { get; set; }
    public bool EnableLogging { get; set; }
    public string LogLevel { get; set; } = string.Empty;
}
