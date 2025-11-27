using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BackendWebService.IntegrationTests.Infrastructure;
using Application.Contracts.Infrastructures;
using Application.Model.EmailDto;
using Application.Contracts.HubServices;
using Application.Features;
using System.Net.Http;
using WireMock.Server;
using WireMock.Settings;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using Request = WireMock.RequestBuilders.Request;
using Response = WireMock.ResponseBuilders.Response;

namespace BackendWebService.IntegrationTests.ExternalServices;

/// <summary>
/// Configuration class for external service integration tests
/// </summary>
public static class ExternalServiceTestConfiguration
{
    /// <summary>
    /// Configure services for external service testing
    /// </summary>
    public static void ConfigureExternalServiceTests(IServiceCollection services, IConfiguration configuration)
    {
        // Configure test email service - using static EmailConfiguration directly
        // Note: EmailConfiguration is static, so we can't use IOptions<T> pattern
        // The EmailService will use the static configuration directly

        // Configure test notification service - using direct configuration
        // Note: NotificationConfiguration class doesn't exist, using direct service configuration

        // Configure test HTTP client
        services.AddHttpClient("TestClient", client =>
        {
            client.Timeout = TimeSpan.FromSeconds(30);
            client.DefaultRequestHeaders.Add("User-Agent", "BackendWebService-IntegrationTests/1.0");
        });

        // Configure test logging
        services.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.SetMinimumLevel(LogLevel.Debug);
        });
    }

    /// <summary>
    /// Create WireMock server for email service testing
    /// </summary>
    public static WireMockServer CreateEmailServiceMock()
    {
        var settings = new WireMockServerSettings
        {
            Port = 0, // Random port
            StartAdminInterface = true,
            ReadStaticMappings = false,
            WatchStaticMappings = false,
            WatchStaticMappingsInSubdirectories = false,
            AllowPartialMapping = true,
            AdminUsername = "admin",
            AdminPassword = "password"
        };

        var server = WireMockServer.Start(settings);
        
        // Setup default email service endpoints
        SetupEmailServiceEndpoints(server);
        
        return server;
    }

    /// <summary>
    /// Create WireMock server for notification service testing
    /// </summary>
    public static WireMockServer CreateNotificationServiceMock()
    {
        var settings = new WireMockServerSettings
        {
            Port = 0, // Random port
            StartAdminInterface = true,
            ReadStaticMappings = false,
            WatchStaticMappings = false,
            WatchStaticMappingsInSubdirectories = false,
            AllowPartialMapping = true,
            AdminUsername = "admin",
            AdminPassword = "password"
        };

        var server = WireMockServer.Start(settings);
        
        // Setup default notification service endpoints
        SetupNotificationServiceEndpoints(server);
        
        return server;
    }

    /// <summary>
    /// Create WireMock server for general external service testing
    /// </summary>
    public static WireMockServer CreateExternalServiceMock()
    {
        var settings = new WireMockServerSettings
        {
            Port = 0, // Random port
            StartAdminInterface = true,
            ReadStaticMappings = false,
            WatchStaticMappings = false,
            WatchStaticMappingsInSubdirectories = false,
            AllowPartialMapping = true,
            AdminUsername = "admin",
            AdminPassword = "password"
        };

        var server = WireMockServer.Start(settings);
        
        // Setup default external service endpoints
        SetupExternalServiceEndpoints(server);
        
        return server;
    }

    /// <summary>
    /// Setup email service endpoints
    /// </summary>
    private static void SetupEmailServiceEndpoints(WireMockServer server)
    {
        // Successful email send
        server
            .Given(Request.Create()
                .WithPath("/api/email/send")
                .UsingPost()
                .WithBody("{\"to\":\"test@example.com\",\"subject\":\"Test\",\"body\":\"Test body\"}"))
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"success\": true, \"messageId\": \"test-message-id\"}"));

        // Email validation
        server
            .Given(Request.Create()
                .WithPath("/api/email/validate")
                .UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"valid\": true, \"message\": \"Email address is valid\"}"));

        // Email template
        server
            .Given(Request.Create()
                .WithPath("/api/email/template")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"templates\": [\"welcome\", \"password-reset\", \"notification\"]}"));
    }

    /// <summary>
    /// Setup notification service endpoints
    /// </summary>
    private static void SetupNotificationServiceEndpoints(WireMockServer server)
    {
        // Successful notification send
        server
            .Given(Request.Create()
                .WithPath("/api/notifications/send")
                .UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"success\": true, \"notificationId\": \"test-notification-id\"}"));

        // Notification status
        server
            .Given(Request.Create()
                .WithPath("/api/notifications/status")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"status\": \"healthy\", \"uptime\": 3600}"));

        // Notification history
        server
            .Given(Request.Create()
                .WithPath("/api/notifications/history")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"notifications\": [], \"total\": 0}"));
    }

    /// <summary>
    /// Setup external service endpoints
    /// </summary>
    private static void SetupExternalServiceEndpoints(WireMockServer server)
    {
        // Health check
        server
            .Given(Request.Create()
                .WithPath("/api/health")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"status\": \"healthy\", \"timestamp\": \"2024-01-01T00:00:00Z\"}"));

        // API info
        server
            .Given(Request.Create()
                .WithPath("/api/info")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"name\": \"Test API\", \"version\": \"1.0.0\", \"description\": \"Test API for integration tests\"}"));

        // Data endpoint
        server
            .Given(Request.Create()
                .WithPath("/api/data")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"data\": [{\"id\": 1, \"name\": \"Test Item 1\"}, {\"id\": 2, \"name\": \"Test Item 2\"}]}"));

        // Slow endpoint for timeout testing
        server
            .Given(Request.Create()
                .WithPath("/api/slow-endpoint")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithDelay(TimeSpan.FromSeconds(5))
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"message\": \"Slow response\"}"));

        // Large response endpoint
        server
            .Given(Request.Create()
                .WithPath("/api/large-response")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "text/plain")
                .WithBody(new string('A', 1000000))); // 1MB response

        // Malformed response endpoint
        server
            .Given(Request.Create()
                .WithPath("/api/malformed-response")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"invalid\": json}")); // Malformed JSON

        // Retry endpoint
        server
            .Given(Request.Create()
                .WithPath("/api/retry-endpoint")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(503)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"error\": \"Service Unavailable\"}"));

        // Circuit breaker endpoint
        server
            .Given(Request.Create()
                .WithPath("/api/circuit-breaker")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(503)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"error\": \"Service Unavailable\"}"));

        // Concurrent failure endpoint
        server
            .Given(Request.Create()
                .WithPath("/api/concurrent-failure")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(503)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"error\": \"Service Unavailable\"}"));
    }

    /// <summary>
    /// Create test HTTP client with custom configuration
    /// </summary>
    public static HttpClient CreateTestHttpClient(WireMockServer mockServer)
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri(mockServer.Urls[0]),
            Timeout = TimeSpan.FromSeconds(30)
        };

        httpClient.DefaultRequestHeaders.Add("User-Agent", "BackendWebService-IntegrationTests/1.0");
        httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

        return httpClient;
    }

    /// <summary>
    /// Create test HTTP client with custom timeout
    /// </summary>
    public static HttpClient CreateTestHttpClient(WireMockServer mockServer, TimeSpan timeout)
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri(mockServer.Urls[0]),
            Timeout = timeout
        };

        httpClient.DefaultRequestHeaders.Add("User-Agent", "BackendWebService-IntegrationTests/1.0");
        httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

        return httpClient;
    }

    /// <summary>
    /// Create test HTTP client with custom headers
    /// </summary>
    public static HttpClient CreateTestHttpClient(WireMockServer mockServer, Dictionary<string, string> customHeaders)
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri(mockServer.Urls[0]),
            Timeout = TimeSpan.FromSeconds(30)
        };

        httpClient.DefaultRequestHeaders.Add("User-Agent", "BackendWebService-IntegrationTests/1.0");
        httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

        foreach (var header in customHeaders)
        {
            httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
        }

        return httpClient;
    }

    /// <summary>
    /// Cleanup test resources
    /// </summary>
    public static void CleanupTestResources(WireMockServer? mockServer, HttpClient? httpClient)
    {
        try
        {
            mockServer?.Stop();
            mockServer?.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error stopping mock server: {ex.Message}");
        }

        try
        {
            httpClient?.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error disposing HTTP client: {ex.Message}");
        }
    }
}
