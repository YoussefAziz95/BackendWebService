using Microsoft.Extensions.DependencyInjection;
using BackendWebService.IntegrationTests.Base;
using BackendWebService.IntegrationTests.Infrastructure;
using FluentAssertions;
using Application.Contracts.AppManager;
using Application.Model.Jwt;
using Microsoft.AspNetCore.Identity;
using Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Contracts.Services;

namespace BackendWebService.IntegrationTests.ExternalServices;

/// <summary>
/// Integration tests for JWT authentication service interactions
/// </summary>
public class JwtAuthenticationIntegrationTests : BaseIntegrationTest
{
    private readonly IJwtService _jwtService;
    private readonly IAppUserManager _appUserManager;
    private readonly IAppSignInManager _appSignInManager;

    public JwtAuthenticationIntegrationTests(IntegrationTestWebApplicationFactory factory) 
        : base(factory)
    {
        _jwtService = ServiceProvider.GetRequiredService<IJwtService>();
        _appUserManager = ServiceProvider.GetRequiredService<IAppUserManager>();
        _appSignInManager = ServiceProvider.GetRequiredService<IAppSignInManager>();
    }

    [Fact]
    public async Task JwtService_ShouldGenerateValidToken()
    {
        // Arrange
        var user = await _appUserManager.FindByNameAsync("admin");
        user.Should().NotBeNull("Test user should exist");

        // Act
        var tokenResult = await _jwtService.GenerateAsync(user!);
        var token = tokenResult.access_token;

        // Assert
        token.Should().NotBeNullOrEmpty("JWT token should be generated");
        
        // Verify token structure
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadJwtToken(token);
        
        jsonToken.Should().NotBeNull("Token should be valid JWT");
        jsonToken.Header.Should().ContainKey("alg", "Token should have algorithm");
        jsonToken.Header.Should().ContainKey("typ", "Token should have type");
    }

    [Fact]
    public async Task JwtService_ShouldIncludeUserClaimsInToken()
    {
        // Arrange
        var user = await _appUserManager.FindByNameAsync("admin");
        user.Should().NotBeNull("Test user should exist");

        // Act
        var tokenResult = await _jwtService.GenerateAsync(user!);
        var token = tokenResult.access_token;

        // Assert
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadJwtToken(token);
        
        jsonToken.Claims.Should().Contain(c => c.Type == ClaimTypes.NameIdentifier, "Token should contain user ID claim");
        jsonToken.Claims.Should().Contain(c => c.Type == ClaimTypes.Name, "Token should contain username claim");
        jsonToken.Claims.Should().Contain(c => c.Type == ClaimTypes.Email, "Token should contain email claim");
    }

    [Fact]
    public async Task JwtService_ShouldHandleTokenExpiration()
    {
        // Arrange
        var user = await _appUserManager.FindByNameAsync("admin");
        user.Should().NotBeNull("Test user should exist");

        // Act
        var tokenResult = await _jwtService.GenerateAsync(user!);
        var token = tokenResult.access_token;

        // Assert
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadJwtToken(token);
        
        jsonToken.ValidTo.Should().BeAfter(DateTime.UtcNow, "Token should have future expiration");
        jsonToken.ValidFrom.Should().BeOnOrBefore(DateTime.UtcNow, "Token should be valid from now or earlier");
    }

    [Fact]
    public async Task JwtService_ShouldGenerateDifferentTokensForDifferentUsers()
    {
        // Arrange
        var adminUser = await _appUserManager.FindByNameAsync("admin");
        var regularUser = await _appUserManager.FindByNameAsync("user");
        
        adminUser.Should().NotBeNull("Admin user should exist");
        regularUser.Should().NotBeNull("Regular user should exist");

        // Act
        var adminTokenResult = await _jwtService.GenerateAsync(adminUser!);
        var adminToken = adminTokenResult.access_token;
        var regularTokenResult = await _jwtService.GenerateAsync(regularUser!);
        var regularToken = regularTokenResult.access_token;

        // Assert
        adminToken.Should().NotBe(regularToken, "Different users should have different tokens");
    }

    [Fact]
    public async Task JwtService_ShouldGenerateDifferentTokensForSameUser()
    {
        // Arrange
        var user = await _appUserManager.FindByNameAsync("admin");
        user.Should().NotBeNull("Test user should exist");

        // Act
        var token1Result = await _jwtService.GenerateAsync(user!);
        var token1 = token1Result.access_token;
        await Task.Delay(100); // Small delay to ensure different timestamps
        var token2Result = await _jwtService.GenerateAsync(user!);
        var token2 = token2Result.access_token;

        // Assert
        token1.Should().NotBe(token2, "Same user should get different tokens at different times");
    }

    [Fact]
    public async Task JwtService_ShouldHandleNullUser()
    {
        // Arrange & Act
        Func<Task> action = async () => await _jwtService.GenerateAsync(null!);

        // Assert
        await action.Should().ThrowAsync<ArgumentNullException>("JWT service should throw exception for null user");
    }

    [Fact]
    public async Task JwtService_ShouldIncludeRolesInToken()
    {
        // Arrange
        var user = await _appUserManager.FindByNameAsync("admin");
        user.Should().NotBeNull("Test user should exist");

        // Act
        var tokenResult = await _jwtService.GenerateAsync(user!);
        var token = tokenResult.access_token;

        // Assert
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadJwtToken(token);
        
        jsonToken.Claims.Should().Contain(c => c.Type == ClaimTypes.Role, "Token should contain role claims");
    }

    [Fact]
    public async Task JwtService_ShouldHandleTokenValidation()
    {
        // Arrange
        var user = await _appUserManager.FindByNameAsync("admin");
        user.Should().NotBeNull("Test user should exist");

        // Act
        var tokenResult = await _jwtService.GenerateAsync(user!);
        var token = tokenResult.access_token;

        // Assert
        var handler = new JwtSecurityTokenHandler();
        var action = () => handler.ReadJwtToken(token);
        
        action.Should().NotThrow("Generated token should be valid and parseable");
    }

    [Fact]
    public async Task JwtService_ShouldHandleTokenWithCustomClaims()
    {
        // Arrange
        var user = await _appUserManager.FindByNameAsync("admin");
        user.Should().NotBeNull("Test user should exist");

        // Act
        var tokenResult = await _jwtService.GenerateAsync(user!);
        var token = tokenResult.access_token;

        // Assert
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadJwtToken(token);
        
        // Verify standard claims are present
        jsonToken.Claims.Should().Contain(c => c.Type == JwtRegisteredClaimNames.Sub, "Token should contain subject claim");
        jsonToken.Claims.Should().Contain(c => c.Type == JwtRegisteredClaimNames.Jti, "Token should contain JTI claim");
        jsonToken.Claims.Should().Contain(c => c.Type == JwtRegisteredClaimNames.Iat, "Token should contain issued at claim");
    }

    [Fact]
    public async Task JwtService_ShouldHandleTokenRefresh()
    {
        // Arrange
        var user = await _appUserManager.FindByNameAsync("admin");
        user.Should().NotBeNull("Test user should exist");

        // Act
        var originalTokenResult = await _jwtService.GenerateAsync(user!);
        var originalToken = originalTokenResult.access_token;
        await Task.Delay(100); // Small delay
        var refreshedTokenResult = await _jwtService.GenerateAsync(user!);
        var refreshedToken = refreshedTokenResult.access_token;

        // Assert
        originalToken.Should().NotBe(refreshedToken, "Refreshed token should be different");
        
        // Both tokens should be valid
        var handler = new JwtSecurityTokenHandler();
        var originalJsonToken = handler.ReadJwtToken(originalToken);
        var refreshedJsonToken = handler.ReadJwtToken(refreshedToken);
        
        originalJsonToken.Should().NotBeNull("Original token should be valid");
        refreshedJsonToken.Should().NotBeNull("Refreshed token should be valid");
    }

    [Fact]
    public async Task JwtService_ShouldHandleConcurrentTokenGeneration()
    {
        // Arrange
        var user = await _appUserManager.FindByNameAsync("admin");
        user.Should().NotBeNull("Test user should exist");

        // Act
        var tasks = new List<Task<string>>();
        for (int i = 0; i < 10; i++)
        {
            tasks.Add(Task.Run(async () => {
                var result = await _jwtService.GenerateAsync(user!);
                return result.access_token;
            }));
        }

        var tokens = await Task.WhenAll(tasks);

        // Assert
        tokens.Should().HaveCount(10, "All concurrent token generations should complete");
        tokens.Should().AllSatisfy(t => t.Should().NotBeNullOrEmpty("All tokens should be generated"));
        tokens.Should().OnlyHaveUniqueItems("All tokens should be unique");
    }

    [Fact]
    public async Task JwtService_ShouldHandleTokenWithOrganizationId()
    {
        // Arrange
        var user = await _appUserManager.FindByNameAsync("admin");
        user.Should().NotBeNull("Test user should exist");

        // Act
        var tokenResult = await _jwtService.GenerateAsync(user!);
        var token = tokenResult.access_token;

        // Assert
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadJwtToken(token);
        
        jsonToken.Claims.Should().Contain(c => c.Type == "OrganizationId", "Token should contain organization ID claim");
    }

    [Fact]
    public async Task JwtService_ShouldHandleTokenSecurity()
    {
        // Arrange
        var user = await _appUserManager.FindByNameAsync("admin");
        user.Should().NotBeNull("Test user should exist");

        // Act
        var tokenResult = await _jwtService.GenerateAsync(user!);
        var token = tokenResult.access_token;

        // Assert
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadJwtToken(token);
        
        // Verify security-related claims
        jsonToken.Header.Should().ContainKey("alg", "Token should specify algorithm");
        jsonToken.Header["alg"].Should().Be("HS256", "Token should use HS256 algorithm");
        jsonToken.Header.Should().ContainKey("typ", "Token should specify type");
        jsonToken.Header["typ"].Should().Be("JWT", "Token should be JWT type");
    }

    [Fact]
    public async Task JwtService_ShouldHandleTokenWithUserPages()
    {
        // Arrange
        var user = await _appUserManager.FindByNameAsync("admin");
        user.Should().NotBeNull("Test user should exist");

        // Act
        var userPages = _jwtService.GetUserPages(user!.Id);

        // Assert
        userPages.Should().NotBeNull("User pages should be retrieved");
        // Note: The actual implementation of GetUserPages would determine the specific assertions
    }
}
