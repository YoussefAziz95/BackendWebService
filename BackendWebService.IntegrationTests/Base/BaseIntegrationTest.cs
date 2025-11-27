using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;
using FluentAssertions;
using BackendWebService.IntegrationTests.Infrastructure;
using Persistence.Data;

namespace BackendWebService.IntegrationTests.Base;

/// <summary>
/// Base class for integration tests
/// </summary>
public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebApplicationFactory>, IAsyncLifetime
{
    protected readonly IntegrationTestWebApplicationFactory Factory;
    protected readonly HttpClient Client;
    protected readonly IServiceProvider ServiceProvider;
    protected readonly ITestDataSeeder TestDataSeeder;
    protected readonly IDatabaseCleaner DatabaseCleaner;

    protected BaseIntegrationTest(IntegrationTestWebApplicationFactory factory)
    {
        Factory = factory;
        Client = factory.CreateClient();
        ServiceProvider = factory.Services;
        TestDataSeeder = ServiceProvider.GetRequiredService<ITestDataSeeder>();
        DatabaseCleaner = ServiceProvider.GetRequiredService<IDatabaseCleaner>();
    }

    public virtual async Task InitializeAsync()
    {
        // Clear ChangeTracker before any operations
        using var scope = ServiceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.ChangeTracker.Clear();
        
        // Clean database before each test
        await DatabaseCleaner.ClearAllTablesAsync();
        
        // Seed test data
        await TestDataSeeder.SeedAllAsync();
        
        // Clear ChangeTracker after seeding
        context.ChangeTracker.Clear();
    }

    public virtual async Task DisposeAsync()
    {
        // Clear ChangeTracker before cleanup
        using var scope = ServiceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.ChangeTracker.Clear();
        
        // Clean up after each test
        await DatabaseCleaner.ClearAllTablesAsync();
        
        // Clear ChangeTracker after cleanup
        context.ChangeTracker.Clear();
    }

    /// <summary>
    /// Creates an authenticated HTTP client with JWT token
    /// </summary>
    protected async Task<HttpClient> CreateAuthenticatedClientAsync(string phoneNumber = "123-456-7890", string password = "TestPassword123!")
    {
        var token = await GetJwtTokenAsync(phoneNumber, password);
        
        var client = Factory.CreateClient();
        client.DefaultRequestHeaders.Authorization = 
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        
        return client;
    }

    /// <summary>
    /// Gets a JWT token for authentication
    /// </summary>
    protected async Task<string> GetJwtTokenAsync(string phoneNumber, string password)
    {
        var loginRequest = new
        {
            PhoneNumber = phoneNumber,
            Password = password
        };

        var response = await Client.PostAsJsonAsync("/api/v1/authorization/login", loginRequest);
        response.EnsureSuccessStatusCode();

        var loginResponse = await response.Content.ReadFromJsonAsync<ApiResponse<LoginResponse>>();
        return loginResponse?.Data?.Token ?? throw new InvalidOperationException("Failed to get JWT token");
    }

    /// <summary>
    /// Performs a GET request and returns the response
    /// </summary>
    protected async Task<HttpResponseMessage> GetAsync(string endpoint)
    {
        return await Client.GetAsync(endpoint);
    }

    /// <summary>
    /// Performs a POST request and returns the response
    /// </summary>
    protected async Task<HttpResponseMessage> PostAsync<T>(string endpoint, T data)
    {
        var json = JsonConvert.SerializeObject(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        return await Client.PostAsync(endpoint, content);
    }

    /// <summary>
    /// Performs a PUT request and returns the response
    /// </summary>
    protected async Task<HttpResponseMessage> PutAsync<T>(string endpoint, T data)
    {
        var json = JsonConvert.SerializeObject(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        return await Client.PutAsync(endpoint, content);
    }

    /// <summary>
    /// Performs a DELETE request and returns the response
    /// </summary>
    protected async Task<HttpResponseMessage> DeleteAsync(string endpoint)
    {
        return await Client.DeleteAsync(endpoint);
    }

    /// <summary>
    /// Asserts that the response is successful
    /// </summary>
    protected void AssertSuccessResponse(HttpResponseMessage response)
    {
        response.IsSuccessStatusCode.Should().BeTrue(
            $"Expected successful response but got {response.StatusCode}. " +
            $"Response content: {response.Content.ReadAsStringAsync().Result}");
    }

    /// <summary>
    /// Asserts that the response has the expected status code
    /// </summary>
    protected void AssertStatusCode(HttpResponseMessage response, System.Net.HttpStatusCode expectedStatusCode)
    {
        response.StatusCode.Should().Be(expectedStatusCode,
            $"Expected {expectedStatusCode} but got {response.StatusCode}. " +
            $"Response content: {response.Content.ReadAsStringAsync().Result}");
    }

    /// <summary>
    /// Asserts that the response contains the expected content
    /// </summary>
    protected async Task<T> AssertResponseContent<T>(HttpResponseMessage response)
    {
        AssertSuccessResponse(response);
        
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<T>(content);
        
        result.Should().NotBeNull("Response content should not be null");
        return result!;
    }

    /// <summary>
    /// Asserts that the response contains validation errors
    /// </summary>
    protected async Task AssertValidationErrors(HttpResponseMessage response, params string[] expectedErrors)
    {
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        
        var content = await response.Content.ReadAsStringAsync();
        var errorResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(content);
        
        errorResponse.Should().NotBeNull();
        errorResponse!.Errors.Should().ContainKeys(expectedErrors);
    }
}

/// <summary>
/// Login response model
/// </summary>
public class LoginResponse
{
    public string Token { get; set; } = string.Empty;
    public DateTime Expires { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
}

/// <summary>
/// Validation error response model
/// </summary>
public class ValidationErrorResponse
{
    public Dictionary<string, string[]> Errors { get; set; } = new();
    public string Title { get; set; } = string.Empty;
    public int Status { get; set; }
}

/// <summary>
/// API response wrapper model
/// </summary>
public class ApiResponse<T>
{
    public T? Data { get; set; }
    public int StatusCode { get; set; }
    public bool Succeeded { get; set; }
    public string Message { get; set; } = string.Empty;
    public object? Errors { get; set; }
    public object? Error { get; set; }
}
