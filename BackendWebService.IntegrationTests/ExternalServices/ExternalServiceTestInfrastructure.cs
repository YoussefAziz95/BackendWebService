using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WireMock.Server;
using WireMock.Settings;
using System.Net.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace BackendWebService.IntegrationTests.ExternalServices;

/// <summary>
/// Test infrastructure for external service integration tests
/// </summary>
public class ExternalServiceTestInfrastructure : WebApplicationFactory<Program>, IAsyncLifetime
{
    private WireMockServer? _emailServiceMock;
    private WireMockServer? _notificationServiceMock;
    private WireMockServer? _externalApiMock;

    public ExternalServiceTestInfrastructure()
    {
        // Initialize mock servers for external services
        _emailServiceMock = WireMockServer.Start(new WireMockServerSettings
        {
            Port = 0, // Use dynamic port
            UseSSL = false
        });

        _notificationServiceMock = WireMockServer.Start(new WireMockServerSettings
        {
            Port = 0, // Use dynamic port
            UseSSL = false
        });

        _externalApiMock = WireMockServer.Start(new WireMockServerSettings
        {
            Port = 0, // Use dynamic port
            UseSSL = false
        });
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration((context, config) =>
        {
            config.AddInMemoryCollection(new Dictionary<string, string?>
            {
                // Email service configuration
                ["EmailSettings:Host"] = _emailServiceMock?.Urls[0] ?? "localhost",
                ["EmailSettings:Port"] = "587",
                ["EmailSettings:Username"] = "test@example.com",
                ["EmailSettings:Password"] = "test-password",
                ["EmailSettings:From"] = "test@example.com",
                ["EmailSettings:EnableSSL"] = "false",

                // Notification service configuration
                ["NotificationSettings:BaseUrl"] = _notificationServiceMock?.Urls[0] ?? "localhost",
                ["NotificationSettings:ApiKey"] = "test-api-key",

                // External API configuration
                ["ExternalApiSettings:BaseUrl"] = _externalApiMock?.Urls[0] ?? "localhost",
                ["ExternalApiSettings:ApiKey"] = "test-external-api-key",
                ["ExternalApiSettings:Timeout"] = "30",

                // Cache configuration
                ["CacheSettings:DefaultExpiration"] = "300", // 5 minutes
                ["CacheSettings:MaxSize"] = "1000",

                // JWT configuration
                ["JwtSettings:Secret"] = "SuperSecretKeyForExternalServiceTestingThatIsLongEnough",
                ["JwtSettings:Issuer"] = "ExternalServiceTestIssuer",
                ["JwtSettings:Audience"] = "ExternalServiceTestAudience",
                ["JwtSettings:ExpiryMinutes"] = "60"
            });
        });

        builder.ConfigureServices(services =>
        {
            // Configure HTTP clients for external services
            if (_emailServiceMock != null)
            {
                services.AddHttpClient("EmailService", client =>
                {
                    client.BaseAddress = new Uri(_emailServiceMock.Urls[0]);
                    client.Timeout = TimeSpan.FromSeconds(30);
                });
            }

            if (_notificationServiceMock != null)
            {
                services.AddHttpClient("NotificationService", client =>
                {
                    client.BaseAddress = new Uri(_notificationServiceMock.Urls[0]);
                    client.Timeout = TimeSpan.FromSeconds(30);
                });
            }

            if (_externalApiMock != null)
            {
                services.AddHttpClient("ExternalApi", client =>
                {
                    client.BaseAddress = new Uri(_externalApiMock.Urls[0]);
                    client.Timeout = TimeSpan.FromSeconds(30);
                });
            }

            // Configure test-specific services
            services.AddSingleton<ITestExternalServiceProvider>(provider =>
                new TestExternalServiceProvider(
                    _emailServiceMock,
                    _notificationServiceMock,
                    _externalApiMock));
        });

        builder.UseEnvironment("Test");
    }

    public async Task InitializeAsync()
    {
        // Setup default mock responses for external services
        await SetupEmailServiceMocks();
        await SetupNotificationServiceMocks();
        await SetupExternalApiMocks();
    }

    public new async Task DisposeAsync()
    {
        _emailServiceMock?.Stop();
        _notificationServiceMock?.Stop();
        _externalApiMock?.Stop();
        await base.DisposeAsync();
    }

    private async Task SetupEmailServiceMocks()
    {
        if (_emailServiceMock == null) return;

        // Mock successful email sending
        _emailServiceMock
            .Given(WireMock.RequestBuilders.Request.Create()
                .WithPath("/api/email/send")
                .UsingPost())
            .RespondWith(WireMock.ResponseBuilders.Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"success\": true, \"messageId\": \"test-message-id\"}"));

        // Mock email sending failure
        _emailServiceMock
            .Given(WireMock.RequestBuilders.Request.Create()
                .WithPath("/api/email/send-error")
                .UsingPost())
            .RespondWith(WireMock.ResponseBuilders.Response.Create()
                .WithStatusCode(500)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"success\": false, \"error\": \"SMTP server unavailable\"}"));

        // Mock email validation
        _emailServiceMock
            .Given(WireMock.RequestBuilders.Request.Create()
                .WithPath("/api/email/validate")
                .UsingPost())
            .RespondWith(WireMock.ResponseBuilders.Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"valid\": true, \"message\": \"Email address is valid\"}"));
    }

    private async Task SetupNotificationServiceMocks()
    {
        if (_notificationServiceMock == null) return;

        // Mock successful notification sending
        _notificationServiceMock
            .Given(WireMock.RequestBuilders.Request.Create()
                .WithPath("/api/notifications/send")
                .UsingPost())
            .RespondWith(WireMock.ResponseBuilders.Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"success\": true, \"notificationId\": \"test-notification-id\"}"));

        // Mock notification sending failure
        _notificationServiceMock
            .Given(WireMock.RequestBuilders.Request.Create()
                .WithPath("/api/notifications/send-error")
                .UsingPost())
            .RespondWith(WireMock.ResponseBuilders.Response.Create()
                .WithStatusCode(500)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"success\": false, \"error\": \"Notification service unavailable\"}"));

        // Mock notification status check
        _notificationServiceMock
            .Given(WireMock.RequestBuilders.Request.Create()
                .WithPath("/api/notifications/status/*")
                .UsingGet())
            .RespondWith(WireMock.ResponseBuilders.Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"status\": \"delivered\", \"timestamp\": \"2024-01-01T00:00:00Z\"}"));
    }

    private async Task SetupExternalApiMocks()
    {
        if (_externalApiMock == null) return;

        // Mock successful API call
        _externalApiMock
            .Given(WireMock.RequestBuilders.Request.Create()
                .WithPath("/api/external/data")
                .UsingGet())
            .RespondWith(WireMock.ResponseBuilders.Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"data\": \"test-data\", \"timestamp\": \"2024-01-01T00:00:00Z\"}"));

        // Mock API authentication failure
        _externalApiMock
            .Given(WireMock.RequestBuilders.Request.Create()
                .WithPath("/api/external/unauthorized")
                .UsingGet())
            .RespondWith(WireMock.ResponseBuilders.Response.Create()
                .WithStatusCode(401)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"error\": \"Unauthorized\", \"message\": \"Invalid API key\"}"));

        // Mock API timeout
        _externalApiMock
            .Given(WireMock.RequestBuilders.Request.Create()
                .WithPath("/api/external/timeout")
                .UsingGet())
            .RespondWith(WireMock.ResponseBuilders.Response.Create()
                .WithStatusCode(408)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"error\": \"Request Timeout\", \"message\": \"The request timed out\"}"));

        // Mock API rate limiting
        _externalApiMock
            .Given(WireMock.RequestBuilders.Request.Create()
                .WithPath("/api/external/rate-limit")
                .UsingGet())
            .RespondWith(WireMock.ResponseBuilders.Response.Create()
                .WithStatusCode(429)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"error\": \"Rate Limited\", \"message\": \"Too many requests\"}"));
    }

    public WireMockServer? GetEmailServiceMock() => _emailServiceMock;
    public WireMockServer? GetNotificationServiceMock() => _notificationServiceMock;
    public WireMockServer? GetExternalApiMock() => _externalApiMock;
}

/// <summary>
/// Test external service provider for managing mock services
/// </summary>
public interface ITestExternalServiceProvider
{
    WireMockServer? EmailServiceMock { get; }
    WireMockServer? NotificationServiceMock { get; }
    WireMockServer? ExternalApiMock { get; }
}

public class TestExternalServiceProvider : ITestExternalServiceProvider
{
    public WireMockServer? EmailServiceMock { get; }
    public WireMockServer? NotificationServiceMock { get; }
    public WireMockServer? ExternalApiMock { get; }

    public TestExternalServiceProvider(
        WireMockServer? emailServiceMock,
        WireMockServer? notificationServiceMock,
        WireMockServer? externalApiMock)
    {
        EmailServiceMock = emailServiceMock;
        NotificationServiceMock = notificationServiceMock;
        ExternalApiMock = externalApiMock;
    }
}
