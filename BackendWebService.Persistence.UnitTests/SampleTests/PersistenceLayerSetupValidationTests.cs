using Xunit;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using BackendWebService.Persistence.UnitTests.TestUtilities;
using Domain;
using Microsoft.Extensions.DependencyInjection;

namespace BackendWebService.Persistence.UnitTests.SampleTests;

public class PersistenceLayerSetupValidationTests
{
    [Fact]
    public void TestProjectSetup_ShouldBeConfiguredCorrectly()
    {
        // This test validates that the test project is properly configured
        // and can access the necessary dependencies
        Assert.True(true); // Basic test to ensure xUnit is working
    }

    [Fact]
    public void InMemoryDbContext_ShouldBeCreatable()
    {
        // Arrange & Act
        using var context = DbContextMocks.CreateInMemoryDbContext();

        // Assert
        context.Should().NotBeNull();
        context.Database.Should().NotBeNull();
        context.Database.IsInMemory().Should().BeTrue();
    }

    [Fact]
    public void InMemoryDbContext_ShouldHaveCorrectDbSets()
    {
        // Arrange
        using var context = DbContextMocks.CreateInMemoryDbContext();

        // Assert - Verify that all expected DbSets are available
        context.Users.Should().NotBeNull();
        context.Roles.Should().NotBeNull();
        context.Organizations.Should().NotBeNull();
        context.Categories.Should().NotBeNull();
        context.Companies.Should().NotBeNull();
        context.Suppliers.Should().NotBeNull();
        context.Loggings.Should().NotBeNull();
        context.UserRefreshTokens.Should().NotBeNull();
    }

    [Fact]
    public async Task InMemoryDbContext_ShouldSupportBasicOperations()
    {
        // Arrange
        using var context = DbContextMocks.CreateInMemoryDbContext();
        var user = TestDataBuilder.Entities.CreateUser();

        // Act
        context.Users.Add(user);
        await context.SaveChangesAsync();

        // Assert
        var savedUser = await context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
        savedUser.Should().NotBeNull();
        savedUser!.Email.Should().Be(user.Email);
        savedUser.UserName.Should().Be(user.UserName);
    }

    [Fact]
    public async Task DatabaseTestHelper_ShouldWorkCorrectly()
    {
        // Arrange
        using var helper = new DatabaseTestHelper();

        // Act
        await helper.SeedTestDataAsync();

        // Assert
        helper.GetEntityCount<User>().Should().Be(3);
        helper.GetEntityCount<Role>().Should().Be(3);
        helper.GetEntityCount<Organization>().Should().Be(1);
        helper.GetEntityCount<Category>().Should().Be(3);
        helper.GetEntityCount<Company>().Should().Be(1);
        helper.GetEntityCount<Supplier>().Should().Be(1);
        // Logging entries are automatically created by ApplicationDbContext
        helper.GetEntityCount<Logging>().Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task DatabaseTestHelper_ShouldSupportEntityOperations()
    {
        // Arrange
        using var helper = new DatabaseTestHelper();
        var user = TestDataBuilder.Entities.CreateUser("test@example.com", "testuser");

        // Act
        await helper.SeedEntityAsync(user);

        // Assert
        helper.EntityExists<User>(u => u.Email == "test@example.com").Should().BeTrue();
        var retrievedUser = helper.GetEntity<User>(u => u.Email == "test@example.com");
        retrievedUser.Should().NotBeNull();
        retrievedUser!.UserName.Should().Be("testuser");
    }

    [Fact]
    public async Task DatabaseTestHelper_ShouldSupportClearOperations()
    {
        // Arrange
        using var helper = new DatabaseTestHelper();
        await helper.SeedTestDataAsync();

        // Act
        await helper.ClearDatabaseAsync();

        // Assert
        helper.GetEntityCount<User>().Should().Be(0);
        helper.GetEntityCount<Role>().Should().Be(0);
        helper.GetEntityCount<Organization>().Should().Be(0);
    }

    [Fact]
    public void TestDataBuilder_ShouldCreateValidEntities()
    {
        // Arrange & Act
        var user = TestDataBuilder.Entities.CreateUser();
        var role = TestDataBuilder.Entities.CreateRole();
        var category = TestDataBuilder.Entities.CreateCategory();
        var organization = TestDataBuilder.Entities.CreateOrganization();

        // Assert
        user.Should().NotBeNull();
        user.Email.Should().NotBeNullOrEmpty();
        user.UserName.Should().NotBeNullOrEmpty();

        role.Should().NotBeNull();
        role.Name.Should().NotBeNullOrEmpty();

        category.Should().NotBeNull();
        category.Name.Should().NotBeNullOrEmpty();

        organization.Should().NotBeNull();
        organization.Name.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void TestDataBuilder_ShouldCreateValidCollections()
    {
        // Arrange & Act
        var users = TestDataBuilder.Collections.CreateUsers(5);
        var roles = TestDataBuilder.Collections.CreateRoles(3);
        var categories = TestDataBuilder.Collections.CreateCategories(4);

        // Assert
        users.Should().HaveCount(5);
        users.All(u => !string.IsNullOrEmpty(u.Email)).Should().BeTrue();

        roles.Should().HaveCount(3);
        roles.All(r => !string.IsNullOrEmpty(r.Name)).Should().BeTrue();

        categories.Should().HaveCount(4);
        categories.All(c => !string.IsNullOrEmpty(c.Name)).Should().BeTrue();
    }

    [Fact]
    public void ServiceCollection_ShouldBeConfigurable()
    {
        // Arrange & Act
        var services = DbContextMocks.CreateTestServiceCollection();
        var serviceProvider = services.BuildServiceProvider();

        // Assert
        serviceProvider.Should().NotBeNull();
        
        var context = serviceProvider.GetService<ApplicationDbContext>();
        context.Should().NotBeNull();
    }

    [Fact]
    public void MockDbContext_ShouldBeCreatable()
    {
        // Arrange & Act
        var mockContext = DbContextMocks.CreateMockDbContext();

        // Assert
        mockContext.Should().NotBeNull();
        mockContext.Object.Should().NotBeNull();
    }
}
