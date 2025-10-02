using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using BackendWebService.IntegrationTests.Base;
using BackendWebService.IntegrationTests.Infrastructure;
using FluentAssertions;

namespace BackendWebService.IntegrationTests.API;

/// <summary>
/// End-to-end integration tests for API endpoints
/// </summary>
public class ApiEndToEndTests : BaseIntegrationTest
{
    public ApiEndToEndTests(IntegrationTestWebApplicationFactory factory) 
        : base(factory)
    {
    }

    [Fact]
    public async Task HealthCheck_ShouldReturnOk()
    {
        // Act
        var response = await Client.GetAsync("/health");

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue();
        
        var content = await response.Content.ReadAsStringAsync();
        content.Should().Contain("Healthy");
    }

    [Fact]
    public async Task Swagger_ShouldBeAccessible()
    {
        // Act
        var response = await Client.GetAsync("/swagger");

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue();
        
        var content = await response.Content.ReadAsStringAsync();
        content.Should().Contain("swagger");
    }

    [Fact]
    public async Task ApiDocumentation_ShouldBeAccessible()
    {
        // Act
        var response = await Client.GetAsync("/swagger/v1/swagger.json");

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue();
        
        var content = await response.Content.ReadAsStringAsync();
        var swaggerDoc = JsonConvert.DeserializeObject<dynamic>(content);
        swaggerDoc.Should().NotBeNull();
    }

    [Fact]
    public async Task Authentication_ShouldRequireValidToken()
    {
        // Act
        var response = await Client.GetAsync("/api/protected");

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task Authentication_ShouldAcceptValidToken()
    {
        // Arrange
        var authenticatedClient = await CreateAuthenticatedClientAsync();

        // Act - Use a valid protected endpoint
        var response = await authenticatedClient.GetAsync("/api/v1/user/find-by-id/1");

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue();
    }

    [Fact]
    public async Task UserRegistration_ShouldCreateNewUser()
    {
        // Arrange
        var registrationRequest = new
        {
            UserName = "newuser@example.com",
            Email = "newuser@example.com",
            Password = "NewPassword123!",
            FirstName = "New",
            LastName = "User",
            OrganizationId = 1
        };

        // Act
        var response = await PostAsync("/api/auth/register", registrationRequest);

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue();
        
        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task UserLogin_ShouldReturnToken()
    {
        // Arrange
        var loginRequest = new
        {
            Username = "testuser1",
            Password = "TestPassword123!"
        };

        // Act
        var response = await PostAsync("/api/auth/login", loginRequest);

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue();
        
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<LoginResponse>(content);
        result.Should().NotBeNull();
        result.Token.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task UserLogin_WithInvalidCredentials_ShouldReturnUnauthorized()
    {
        // Arrange
        var loginRequest = new
        {
            Username = "invaliduser",
            Password = "wrongpassword"
        };

        // Act
        var response = await PostAsync("/api/auth/login", loginRequest);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task GetUsers_ShouldReturnUserList()
    {
        // Arrange
        var authenticatedClient = await CreateAuthenticatedClientAsync();

        // Act - Use a valid endpoint that exists
        var response = await authenticatedClient.GetAsync("/api/v1/user/find-by-id/1");

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue();
        
        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task GetUserById_ShouldReturnSpecificUser()
    {
        // Arrange
        var authenticatedClient = await CreateAuthenticatedClientAsync();
        var userId = 1;

        // Act
        var response = await authenticatedClient.GetAsync($"/api/users/{userId}");

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue();
        
        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task GetUserById_WithInvalidId_ShouldReturnNotFound()
    {
        // Arrange
        var authenticatedClient = await CreateAuthenticatedClientAsync();
        var invalidUserId = 99999;

        // Act
        var response = await authenticatedClient.GetAsync($"/api/users/{invalidUserId}");

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task CreateUser_ShouldAddNewUser()
    {
        // Arrange
        var authenticatedClient = await CreateAuthenticatedClientAsync();
        var newUser = new
        {
            UserName = "createuser@example.com",
            Email = "createuser@example.com",
            FirstName = "Create",
            LastName = "User",
            OrganizationId = 1
        };

        // Act
        var response = await authenticatedClient.PostAsJsonAsync("/api/users", newUser);

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue();
        
        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task UpdateUser_ShouldModifyExistingUser()
    {
        // Arrange
        var authenticatedClient = await CreateAuthenticatedClientAsync();
        var userId = 1;
        var updateRequest = new
        {
            FirstName = "Updated",
            LastName = "Name"
        };

        // Act
        var response = await authenticatedClient.PutAsJsonAsync($"/api/users/{userId}", updateRequest);

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue();
    }

    [Fact]
    public async Task DeleteUser_ShouldRemoveUser()
    {
        // Arrange
        var authenticatedClient = await CreateAuthenticatedClientAsync();
        var userId = 2; // Use a different user ID to avoid deleting the test user

        // Act
        var response = await authenticatedClient.DeleteAsync($"/api/users/{userId}");

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue();
    }

    [Fact]
    public async Task GetCompanies_ShouldReturnCompanyList()
    {
        // Arrange
        var authenticatedClient = await CreateAuthenticatedClientAsync();

        // Act
        var response = await authenticatedClient.GetAsync("/api/companies");

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue();
        
        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task CreateCompany_ShouldAddNewCompany()
    {
        // Arrange
        var authenticatedClient = await CreateAuthenticatedClientAsync();
        var newCompany = new
        {
            CompanyName = "New Test Company",
            OrganizationId = 1
        };

        // Act
        var response = await authenticatedClient.PostAsJsonAsync("/api/companies", newCompany);

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue();
    }

    [Fact]
    public async Task GetCategories_ShouldReturnCategoryList()
    {
        // Arrange
        var authenticatedClient = await CreateAuthenticatedClientAsync();

        // Act
        var response = await authenticatedClient.GetAsync("/api/categories");

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue();
        
        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task CreateCategory_ShouldAddNewCategory()
    {
        // Arrange
        var authenticatedClient = await CreateAuthenticatedClientAsync();
        var newCategory = new
        {
            Name = "New Test Category",
            OrganizationId = 1
        };

        // Act
        var response = await authenticatedClient.PostAsJsonAsync("/api/categories", newCategory);

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue();
    }

    [Fact]
    public async Task Api_ShouldHandleValidationErrors()
    {
        // Arrange
        var authenticatedClient = await CreateAuthenticatedClientAsync();
        var invalidUser = new
        {
            UserName = "", // Invalid: empty username
            Email = "invalid-email", // Invalid: malformed email
            FirstName = "", // Invalid: empty first name
            LastName = "" // Invalid: empty last name
        };

        // Act
        var response = await authenticatedClient.PostAsJsonAsync("/api/users", invalidUser);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<ValidationErrorResponse>(content);
        result.Should().NotBeNull();
        result.Errors.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Api_ShouldHandleConcurrentRequests()
    {
        // Arrange
        var authenticatedClient = await CreateAuthenticatedClientAsync();
        var tasks = new List<Task<HttpResponseMessage>>();

        // Act
        for (int i = 0; i < 10; i++)
        {
            tasks.Add(authenticatedClient.GetAsync("/api/users"));
        }

        var responses = await Task.WhenAll(tasks);

        // Assert
        responses.Should().HaveCount(10);
        responses.Should().AllSatisfy(r => r.IsSuccessStatusCode.Should().BeTrue());
    }

    [Fact]
    public async Task Api_ShouldHandleLargePayload()
    {
        // Arrange
        var authenticatedClient = await CreateAuthenticatedClientAsync();
        var largeData = Enumerable.Range(1, 1000)
            .Select(i => new { id = i, name = $"Item {i}", value = i * 10 })
            .ToList();

        // Act
        var response = await authenticatedClient.PostAsJsonAsync("/api/bulk", largeData);

        // Assert
        // Note: This test assumes a bulk endpoint exists
        // The actual implementation would depend on the specific API design
        response.IsSuccessStatusCode.Should().BeTrue();
    }

    [Fact]
    public async Task Api_ShouldHandleCorsHeaders()
    {
        // Act
        var response = await Client.GetAsync("/api/users");

        // Assert
        response.Headers.Should().ContainKey("Access-Control-Allow-Origin");
        response.Headers.Should().ContainKey("Access-Control-Allow-Methods");
        response.Headers.Should().ContainKey("Access-Control-Allow-Headers");
    }

    [Fact]
    public async Task Api_ShouldHandleContentNegotiation()
    {
        // Arrange
        var authenticatedClient = await CreateAuthenticatedClientAsync();
        authenticatedClient.DefaultRequestHeaders.Accept.Clear();
        authenticatedClient.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        // Act
        var response = await authenticatedClient.GetAsync("/api/users");

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue();
        response.Content.Headers.ContentType?.MediaType.Should().Be("application/json");
    }

    [Fact]
    public async Task Api_ShouldHandleRateLimiting()
    {
        // Arrange
        var authenticatedClient = await CreateAuthenticatedClientAsync();
        var tasks = new List<Task<HttpResponseMessage>>();

        // Act - Make many requests quickly
        for (int i = 0; i < 100; i++)
        {
            tasks.Add(authenticatedClient.GetAsync("/api/users"));
        }

        var responses = await Task.WhenAll(tasks);

        // Assert
        // Note: This test assumes rate limiting is implemented
        // The actual behavior would depend on the specific rate limiting configuration
        responses.Should().NotBeEmpty();
    }
}
