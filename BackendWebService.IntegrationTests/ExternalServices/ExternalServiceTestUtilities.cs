using System.Net.Http;
using System.Text;
using System.Text.Json;
using WireMock.Server;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BackendWebService.IntegrationTests.ExternalServices;

/// <summary>
/// Utility methods for external service integration tests
/// </summary>
public static class ExternalServiceTestUtilities
{
    /// <summary>
    /// Setup mock server for successful responses
    /// </summary>
    public static void SetupSuccessfulResponses(WireMockServer server)
    {
        // Email service success
        server
            .Given(Request.Create()
                .WithPath("/api/email/send")
                .UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"success\": true, \"messageId\": \"test-message-id\"}"));

        // Notification service success
        server
            .Given(Request.Create()
                .WithPath("/api/notifications/send")
                .UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"success\": true, \"notificationId\": \"test-notification-id\"}"));

        // General API success
        server
            .Given(Request.Create()
                .WithPath("/api/test")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"status\": \"success\", \"message\": \"Test completed\"}"));
    }

    /// <summary>
    /// Setup mock server for error responses
    /// </summary>
    public static void SetupErrorResponses(WireMockServer server)
    {
        // Service unavailable
        server
            .Given(Request.Create()
                .WithPath("/api/service-unavailable")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(503)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"error\": \"Service Unavailable\"}"));

        // Authentication failure
        server
            .Given(Request.Create()
                .WithPath("/api/auth-failure")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(401)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"error\": \"Unauthorized\"}"));

        // Rate limiting
        server
            .Given(Request.Create()
                .WithPath("/api/rate-limited")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(429)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"error\": \"Rate Limited\"}"));
    }

    /// <summary>
    /// Setup mock server for timeout scenarios
    /// </summary>
    public static void SetupTimeoutResponses(WireMockServer server)
    {
        // Slow response
        server
            .Given(Request.Create()
                .WithPath("/api/slow")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithDelay(TimeSpan.FromSeconds(10))
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"message\": \"Slow response\"}"));

        // Timeout response
        server
            .Given(Request.Create()
                .WithPath("/api/timeout")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(408)
                .WithHeader("Content-Type", "application/json")
                .WithBody("{\"error\": \"Request Timeout\"}"));
    }

    /// <summary>
    /// Create HTTP client with custom configuration
    /// </summary>
    public static HttpClient CreateHttpClient(WireMockServer server, TimeSpan? timeout = null)
    {
        var client = new HttpClient
        {
            BaseAddress = new Uri(server.Urls[0]),
            Timeout = timeout ?? TimeSpan.FromSeconds(30)
        };

        client.DefaultRequestHeaders.Add("User-Agent", "BackendWebService-IntegrationTests/1.0");
        client.DefaultRequestHeaders.Add("Accept", "application/json");

        return client;
    }

    /// <summary>
    /// Create HTTP client with custom headers
    /// </summary>
    public static HttpClient CreateHttpClientWithHeaders(WireMockServer server, Dictionary<string, string> headers)
    {
        var client = CreateHttpClient(server);

        foreach (var header in headers)
        {
            client.DefaultRequestHeaders.Add(header.Key, header.Value);
        }

        return client;
    }

    /// <summary>
    /// Create JSON content for HTTP requests
    /// </summary>
    public static StringContent CreateJsonContent<T>(T obj)
    {
        var json = JsonSerializer.Serialize(obj);
        return new StringContent(json, Encoding.UTF8, "application/json");
    }

    /// <summary>
    /// Deserialize JSON response
    /// </summary>
    public static async Task<T?> DeserializeJsonResponse<T>(HttpResponseMessage response)
    {
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(content);
    }

    /// <summary>
    /// Wait for async operation with timeout
    /// </summary>
    public static async Task<T> WaitWithTimeout<T>(Task<T> task, TimeSpan timeout)
    {
        using var cts = new CancellationTokenSource(timeout);
        try
        {
            return await task.WaitAsync(cts.Token);
        }
        catch (OperationCanceledException)
        {
            throw new TimeoutException($"Operation timed out after {timeout.TotalSeconds} seconds");
        }
    }

    /// <summary>
    /// Retry operation with exponential backoff
    /// </summary>
    public static async Task<T> RetryWithBackoff<T>(
        Func<Task<T>> operation,
        int maxRetries = 3,
        TimeSpan initialDelay = default)
    {
        if (initialDelay == default)
            initialDelay = TimeSpan.FromMilliseconds(100);

        var delay = initialDelay;
        Exception? lastException = null;

        for (int i = 0; i < maxRetries; i++)
        {
            try
            {
                return await operation();
            }
            catch (Exception ex)
            {
                lastException = ex;
                if (i == maxRetries - 1)
                    break;

                await Task.Delay(delay);
                delay = TimeSpan.FromMilliseconds(delay.TotalMilliseconds * 2);
            }
        }

        throw lastException ?? new InvalidOperationException("Retry operation failed");
    }

    /// <summary>
    /// Cleanup test resources
    /// </summary>
    public static void CleanupResources(params IDisposable?[] resources)
    {
        foreach (var resource in resources)
        {
            try
            {
                resource?.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error disposing resource: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Validate HTTP response
    /// </summary>
    public static void ValidateHttpResponse(HttpResponseMessage response, int expectedStatusCode)
    {
        response.Should().NotBeNull("Response should not be null");
        response.StatusCode.Should().Be((System.Net.HttpStatusCode)expectedStatusCode, 
            $"Response status code should be {expectedStatusCode}");
        response.Content.Should().NotBeNull("Response content should not be null");
    }

    /// <summary>
    /// Validate JSON response content
    /// </summary>
    public static void ValidateJsonResponse<T>(T response, Func<T, bool> validator)
    {
        response.Should().NotBeNull("Response should not be null");
        validator(response).Should().BeTrue("Response should pass validation");
    }
}
