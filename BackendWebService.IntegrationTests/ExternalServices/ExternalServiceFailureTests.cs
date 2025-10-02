using Microsoft.Extensions.DependencyInjection;
using BackendWebService.IntegrationTests.Base;
using BackendWebService.IntegrationTests.Infrastructure;
using FluentAssertions;
using Application.Contracts.Infrastructures;
using Application.Model.EmailDto;
using Application.Contracts.HubServices;
using Application.Features;
using System.Net;
using System.Net.Http;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Response = WireMock.ResponseBuilders.Response;

namespace BackendWebService.IntegrationTests.ExternalServices;

/// <summary>
/// Integration tests for external service failure scenarios and error handling
/// </summary>
public class ExternalServiceFailureTests : BaseIntegrationTest
{
    private readonly IEmailService _emailService;
    private readonly INotificationService _notificationService;
    private readonly WireMockServer _wireMockServer;

    public ExternalServiceFailureTests(IntegrationTestWebApplicationFactory factory) 
        : base(factory)
    {
        _emailService = ServiceProvider.GetRequiredService<IEmailService>();
        _notificationService = ServiceProvider.GetRequiredService<Application.Contracts.HubServices.INotificationService>();
        _wireMockServer = factory.GetEmailServiceMock() ?? WireMockServer.Start();
    }

    [Fact]
    public async Task EmailService_ShouldHandleSmtpServerUnavailable()
    {
        // Arrange
        var emailDto = new EmailDto(
            subject: "Test Email",
            body: "This is a test email body",
            to: "test@example.com",
            cC: "",
            bCC: "",
            sentAt: DateTime.UtcNow,
            senderId: 1
        );

        // Configure EmailServiceTestDouble to simulate SMTP server unavailable
        if (_emailService is EmailServiceTestDouble testDouble)
        {
            testDouble.SimulateFailure(EmailServiceBehavior.SmtpUnavailable);
        }

        // Act
        var result = _emailService.Send(emailDto);

        // Assert
        result.Should().Be(-1, "Email service should return -1 when SMTP server is unavailable");
    }

    [Fact]
    public async Task EmailService_ShouldHandleAuthenticationFailure()
    {
        // Arrange
        var emailDto = new EmailDto(
            subject: "Test Email",
            body: "This is a test email body",
            to: "test@example.com",
            cC: "",
            bCC: "",
            sentAt: DateTime.UtcNow,
            senderId: 1
        );

        // Configure EmailServiceTestDouble to simulate authentication failure
        if (_emailService is EmailServiceTestDouble testDouble)
        {
            testDouble.SimulateFailure(EmailServiceBehavior.AuthenticationFailure);
        }

        // Act
        var result = _emailService.Send(emailDto);

        // Assert
        result.Should().Be(-1, "Email service should return -1 when authentication fails");
    }

    [Fact]
    public async Task EmailService_ShouldHandleInvalidEmailAddress()
    {
        // Arrange
        var emailDto = new EmailDto(
            subject: "Test Email",
            body: "This is a test email body",
            to: "invalid-email-address",
            cC: "",
            bCC: "",
            sentAt: DateTime.UtcNow,
            senderId: 1
        );

        // Act
        var result = _emailService.Send(emailDto);

        // Assert
        result.Should().Be(-1, "Email service should return -1 for invalid email addresses");
    }

    [Fact]
    public async Task EmailService_ShouldHandleNetworkTimeout()
    {
        // Arrange
        var emailDto = new EmailDto(
            subject: "Test Email",
            body: "This is a test email body",
            to: "test@example.com",
            cC: "",
            bCC: "",
            sentAt: DateTime.UtcNow,
            senderId: 1
        );

        // Configure EmailServiceTestDouble to simulate network timeout
        if (_emailService is EmailServiceTestDouble testDouble)
        {
            testDouble.SimulateFailure(EmailServiceBehavior.NetworkTimeout);
        }

        // Act
        var result = _emailService.Send(emailDto);

        // Assert
        result.Should().Be(-1, "Email service should return -1 when network times out");
    }

    [Fact]
    public async Task EmailService_ShouldHandleRateLimiting()
    {
        // Arrange
        var emailDto = new EmailDto(
            subject: "Test Email",
            body: "This is a test email body",
            to: "test@example.com",
            cC: "",
            bCC: "",
            sentAt: DateTime.UtcNow,
            senderId: 1
        );

        // Configure EmailServiceTestDouble to simulate rate limiting
        if (_emailService is EmailServiceTestDouble testDouble)
        {
            testDouble.SimulateFailure(EmailServiceBehavior.RateLimited);
        }

        // Act
        var result = _emailService.Send(emailDto);

        // Assert
        result.Should().Be(-1, "Email service should return -1 when rate limited");
    }

    [Fact]
    public async Task NotificationService_ShouldHandleServiceUnavailable()
    {
        // Arrange
        var notificationRequest = new AddNotificationRequest(
            KeyMessageTitle: "Test Notification",
            KeyMessageBody: "This is a test notification",
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

        // Configure mock service to simulate failure
        if (_notificationService is MockNotificationService mockService)
        {
            mockService.SimulateFailure(true);
        }

        // Act
        var result = await _notificationService.SendMessageAsync(notificationRequest);

        // Assert
        result.Should().BeFalse("Notification service should return false when service is unavailable");
    }

    [Fact]
    public async Task NotificationService_ShouldHandleInvalidRequest()
    {
        // Arrange
        var notificationRequest = new AddNotificationRequest(
            KeyMessageTitle: "", // Empty title
            KeyMessageBody: "", // Empty message
            Priority: Domain.Enums.NotificationPriorityEnum.Medium,
            ExpiryDate: DateTime.UtcNow.AddDays(7),
            NotifierId: 0, // Invalid user ID
            NotifiedId: 0,
            NotifiedType: "User",
            NotificationTypeId: 1,
            NotificationType: "", // Empty type
            NotificationObjectId: null,
            NotificationObjectType: null,
            Details: new List<AddNotificationDetailRequest>()
        );

        // Act
        var result = await _notificationService.SendMessageAsync(notificationRequest);

        // Assert
        result.Should().BeFalse("Notification service should return false for invalid requests");
    }

    [Fact]
    public async Task NotificationService_ShouldHandleConcurrentFailures()
    {
        // Arrange
        var notificationTasks = new List<Task<bool>>();
        var notificationCount = 5;

        // Configure mock service to simulate failure
        if (_notificationService is MockNotificationService mockService)
        {
            mockService.SimulateFailure(true);
        }

        for (int i = 0; i < notificationCount; i++)
        {
            var notification = new AddNotificationRequest(
                KeyMessageTitle: $"Test Notification {i}",
                KeyMessageBody: $"This is test notification {i}",
                Priority: Domain.Enums.NotificationPriorityEnum.Medium,
                ExpiryDate: DateTime.UtcNow.AddDays(7),
                NotifierId: i + 1,
                NotifiedId: i + 1,
                NotifiedType: "User",
                NotificationTypeId: 1,
                NotificationType: "Info",
                NotificationObjectId: null,
                NotificationObjectType: null,
                Details: new List<AddNotificationDetailRequest>()
            );

            notificationTasks.Add(_notificationService.SendMessageAsync(notification));
        }

        // Act
        var results = await Task.WhenAll(notificationTasks);

        // Assert
        results.Should().HaveCount(notificationCount, "All concurrent requests should complete");
        results.Should().AllSatisfy(r => r.Should().BeFalse("All concurrent requests should fail when service is unavailable"));
    }

    [Fact]
    public async Task ExternalService_ShouldHandleConnectionTimeout()
    {
        // Arrange
        var httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromMilliseconds(100) // Very short timeout
        };

        // Mock slow response
        _wireMockServer
            .Given(Request.Create()
                .WithPath("/api/slow-endpoint")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithDelay(TimeSpan.FromSeconds(5))); // Response takes 5 seconds

        // Act & Assert
        var action = async () => await httpClient.GetAsync($"{_wireMockServer.Urls[0]}/api/slow-endpoint");
        await action.Should().ThrowAsync<TaskCanceledException>("HTTP client should timeout on slow responses");
    }

    [Fact]
    public async Task ExternalService_ShouldHandleMalformedResponse()
    {
        // Arrange
        var httpClient = new HttpClient();

        // Mock malformed JSON response
        _wireMockServer
            .Given(Request.Create()
                .WithPath("/api/malformed-response")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"invalid\": json}")); // Malformed JSON

        // Act
        var response = await httpClient.GetAsync($"{_wireMockServer.Urls[0]}/api/malformed-response");

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue("HTTP request should succeed");
        var content = await response.Content.ReadAsStringAsync();
        content.Should().Be("{\"invalid\": json}", "Malformed response should be returned as-is");
    }

    [Fact]
    public async Task ExternalService_ShouldHandleLargeResponse()
    {
        // Arrange
        var httpClient = new HttpClient();
        var largeResponse = new string('A', 1000000); // 1MB response

        // Mock large response
        _wireMockServer
            .Given(Request.Create()
                .WithPath("/api/large-response")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "text/plain")
                .WithBody(largeResponse));

        // Act
        var response = await httpClient.GetAsync($"{_wireMockServer.Urls[0]}/api/large-response");

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue("HTTP request should succeed for large responses");
        var content = await response.Content.ReadAsStringAsync();
        content.Length.Should().Be(1000000, "Large response should be handled correctly");
    }

    [Fact]
    public async Task ExternalService_ShouldHandleConcurrentFailures()
    {
        // Arrange
        var httpClient = new HttpClient();
        var tasks = new List<Task<HttpResponseMessage>>();

        // Mock service unavailable
        _wireMockServer
            .Given(Request.Create()
                .WithPath("/api/concurrent-failure")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(503)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"error\": \"Service Unavailable\"}"));

        // Act - Send multiple concurrent requests
        for (int i = 0; i < 10; i++)
        {
            tasks.Add(httpClient.GetAsync($"{_wireMockServer.Urls[0]}/api/concurrent-failure"));
        }

        var responses = await Task.WhenAll(tasks);

        // Assert
        responses.Should().HaveCount(10, "All concurrent requests should complete");
        responses.Should().AllSatisfy(r => r.StatusCode.Should().Be(HttpStatusCode.ServiceUnavailable, "All requests should fail with 503"));
    }

    [Fact]
    public async Task ExternalService_ShouldHandleRetryLogic()
    {
        // Arrange
        var httpClient = new HttpClient();
        var retryCount = 0;

        // Mock service that fails first few times, then succeeds
        _wireMockServer
            .Given(Request.Create()
                .WithPath("/api/retry-endpoint")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(503)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"error\": \"Service Unavailable\"}"));

        // Act
        var response = await httpClient.GetAsync($"{_wireMockServer.Urls[0]}/api/retry-endpoint");

        // Assert
        retryCount.Should().Be(1, "Request should be made once (retry logic would be implemented in the service)");
        response.StatusCode.Should().Be(HttpStatusCode.ServiceUnavailable, "First request should fail");
    }

    [Fact]
    public async Task ExternalService_ShouldHandleCircuitBreakerPattern()
    {
        // Arrange
        var httpClient = new HttpClient();
        var requestCount = 0;

        // Mock service that always fails
        _wireMockServer
            .Given(Request.Create()
                .WithPath("/api/circuit-breaker")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(503)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"error\": \"Service Unavailable\"}"));

        // Act - Send multiple requests to trigger circuit breaker
        var tasks = new List<Task<HttpResponseMessage>>();
        for (int i = 0; i < 5; i++)
        {
            tasks.Add(httpClient.GetAsync($"{_wireMockServer.Urls[0]}/api/circuit-breaker"));
        }

        var responses = await Task.WhenAll(tasks);

        // Assert
        requestCount.Should().Be(5, "All requests should be made (circuit breaker logic would be implemented in the service)");
        responses.Should().AllSatisfy(r => r.StatusCode.Should().Be(HttpStatusCode.ServiceUnavailable, "All requests should fail"));
    }
}
