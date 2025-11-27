using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Domain;
using BackendWebService.IntegrationTests.Utilities;
using FluentAssertions;
using Xunit;

namespace BackendWebService.IntegrationTests;

/// <summary>
/// Simple integration tests that don't require the full API startup
/// </summary>
public class SimpleIntegrationTests
{
    [Fact]
    public void TestDataFactory_ShouldCreateValidUsers()
    {
        // Act
        var user = TestDataFactory.CreateUser();
        var users = TestDataFactory.CreateUsers(3);

        // Assert
        user.Should().NotBeNull("User should be created");
        user.UserName.Should().NotBeNullOrEmpty("User name should be set");
        user.Email.Should().NotBeNullOrEmpty("Email should be set");
        user.OrganizationId.Should().Be(1, "Organization ID should be set");

        users.Should().HaveCount(3, "Should create 3 users");
        users.Should().AllSatisfy(u => u.UserName.Should().NotBeNullOrEmpty());
    }

    [Fact]
    public void TestDataFactory_ShouldCreateValidRoles()
    {
        // Act
        var role = TestDataFactory.CreateRole();
        var roles = TestDataFactory.CreateRoles(2);

        // Assert
        role.Should().NotBeNull("Role should be created");
        role.Name.Should().NotBeNullOrEmpty("Role name should be set");
        role.DisplayName.Should().NotBeNullOrEmpty("Display name should be set");

        roles.Should().HaveCount(2, "Should create 2 roles");
        roles.Should().AllSatisfy(r => r.Name.Should().NotBeNullOrEmpty());
    }

    [Fact]
    public void TestDataFactory_ShouldCreateValidCompanies()
    {
        // Act
        var company = TestDataFactory.CreateCompany();
        var companies = TestDataFactory.CreateCompanies(2);

        // Assert
        company.Should().NotBeNull("Company should be created");
        company.CompanyName.Should().NotBeNullOrEmpty("Company name should be set");
        company.OrganizationId.Should().Be(1, "Organization ID should be set");

        companies.Should().HaveCount(2, "Should create 2 companies");
        companies.Should().AllSatisfy(c => c.CompanyName.Should().NotBeNullOrEmpty());
    }

    [Fact]
    public void TestDataFactory_ShouldCreateValidCategories()
    {
        // Act
        var category = TestDataFactory.CreateCategory();
        var categories = TestDataFactory.CreateCategories(2);

        // Assert
        category.Should().NotBeNull("Category should be created");
        category.Name.Should().NotBeNullOrEmpty("Category name should be set");
        category.OrganizationId.Should().Be(1, "Organization ID should be set");

        categories.Should().HaveCount(2, "Should create 2 categories");
        categories.Should().AllSatisfy(c => c.Name.Should().NotBeNullOrEmpty());
    }

    [Fact]
    public void TestDataFactory_ShouldCreateValidOrganizations()
    {
        // Act
        var organization = TestDataFactory.CreateOrganization();

        // Assert
        organization.Should().NotBeNull("Organization should be created");
        organization.Name.Should().NotBeNullOrEmpty("Organization name should be set");
        organization.Country.Should().NotBeNullOrEmpty("Country should be set");
    }

    [Fact]
    public void TestDataFactory_ShouldCreateValidActionActors()
    {
        // Act
        var actionActor = TestDataFactory.CreateActionActor();

        // Assert
        actionActor.Should().NotBeNull("Action actor should be created");
        actionActor.Name.Should().NotBeNullOrEmpty("Name should be set");
        actionActor.Description.Should().NotBeNullOrEmpty("Description should be set");
    }

    [Fact]
    public void TestDataFactory_ShouldCreateValidLogging()
    {
        // Act
        var logging = TestDataFactory.CreateLogging();

        // Assert
        logging.Should().NotBeNull("Logging should be created");
        logging.SourceClass.Should().NotBeNullOrEmpty("Source class should be set");
        logging.Message.Should().NotBeNullOrEmpty("Message should be set");
    }

    [Fact]
    public void TestDataFactory_ShouldCreateValidUserRefreshToken()
    {
        // Act
        var refreshToken = TestDataFactory.CreateUserRefreshToken(1);

        // Assert
        refreshToken.Should().NotBeNull("Refresh token should be created");
        refreshToken.UserId.Should().Be(1, "User ID should be set");
        refreshToken.IsValid.Should().BeTrue("Token should be valid");
        refreshToken.CreatedAt.Should().BeBefore(DateTime.UtcNow.AddMinutes(1), "Created date should be recent");
    }

    [Fact]
    public void TestConfigurationHelper_ShouldCreateValidJwtToken()
    {
        // Arrange
        var secret = "TestSecretKey";
        var issuer = "TestIssuer";
        var audience = "TestAudience";
        var userId = "1";
        var username = "testuser";

        // Act
        var token = TestConfigurationHelper.CreateTestJwtToken(secret, issuer, audience, userId, username);

        // Assert
        token.Should().NotBeNullOrEmpty("JWT token should be created");
        token.Should().Contain(".", "JWT token should have proper format");
    }

    [Fact]
    public void TestConfigurationHelper_ShouldGetTestConnectionString()
    {
        // Act
        var connectionString = TestConfigurationHelper.GetTestConnectionString();

        // Assert
        connectionString.Should().NotBeNullOrEmpty("Connection string should be retrieved");
        connectionString.Should().Contain("Database=", "Connection string should contain database name");
    }

    [Fact]
    public void TestConfigurationHelper_ShouldCreateValidConfiguration()
    {
        // Act
        var configuration = TestConfigurationHelper.CreateTestConfiguration();
        var isValid = TestConfigurationHelper.ValidateTestConfiguration(configuration);

        // Assert
        isValid.Should().BeTrue("Test configuration should be valid");
    }

    [Fact]
    public void TestConfigurationHelper_ShouldHaveRequiredSettings()
    {
        // Act
        var configuration = TestConfigurationHelper.CreateTestConfiguration();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var jwtSecret = configuration["JwtSettings:Secret"];
        var jwtIssuer = configuration["JwtSettings:Issuer"];
        var jwtAudience = configuration["JwtSettings:Audience"];

        // Assert
        connectionString.Should().NotBeNullOrEmpty("Connection string should be configured");
        jwtSecret.Should().NotBeNullOrEmpty("JWT secret should be configured");
        jwtIssuer.Should().NotBeNullOrEmpty("JWT issuer should be configured");
        jwtAudience.Should().NotBeNullOrEmpty("JWT audience should be configured");
    }
}
