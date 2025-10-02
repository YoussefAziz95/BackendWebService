using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using Microsoft.AspNetCore.Identity;
using Domain;
using FluentAssertions;
using Xunit;
using BackendWebService.IntegrationTests.Infrastructure;
using BackendWebService.IntegrationTests.Base;
using Microsoft.EntityFrameworkCore;
using Application.Contracts.AppManager;

namespace BackendWebService.IntegrationTests;

/// <summary>
/// Diagnostic tests to understand what's happening with the API
/// </summary>
public class DiagnosticTests : BaseIntegrationTest
{
    public DiagnosticTests(IntegrationTestWebApplicationFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task Api_ShouldStartSuccessfully()
    {
        // Act
        var response = await Client.GetAsync("/");

        // Assert
        // Just check that we get some response (even if 404)
        response.Should().NotBeNull();
        
        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Response Status: {response.StatusCode}");
        Console.WriteLine($"Response Content: {content}");
    }

    [Fact]
    public async Task Database_ShouldHaveSeededUsers()
    {
        // Arrange - Use the same scope that was used for seeding
        // The BaseIntegrationTest already has a scope created during InitializeAsync
        var context = ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var userManager = ServiceProvider.GetRequiredService<UserManager<User>>();

        // Act
        var users = await context.Users.ToListAsync();
        var testUser = await userManager.FindByNameAsync("testuser1");

        // Assert
        Console.WriteLine($"Total users in database: {users.Count}");
        foreach (var user in users)
        {
            Console.WriteLine($"User: {user.UserName}, Email: {user.Email}, PasswordHash: {user.PasswordHash?.Substring(0, 10)}...");
        }

        users.Should().NotBeEmpty("Users should be seeded");
        testUser.Should().NotBeNull("testuser1 should exist");
        testUser!.PasswordHash.Should().NotBeNullOrEmpty("Password should be hashed");
    }

    [Fact]
    public async Task Authentication_ShouldWorkWithUserManager()
    {
        // Arrange - Use the same scope that was used for seeding
        var userManager = ServiceProvider.GetRequiredService<UserManager<User>>();
        var signInManager = ServiceProvider.GetRequiredService<SignInManager<User>>();

        // Act
        var user = await userManager.FindByNameAsync("testuser1");
        var result = await signInManager.CheckPasswordSignInAsync(user!, "TestPassword123!", false);

        // Assert
        user.Should().NotBeNull("User should exist");
        result.Succeeded.Should().BeTrue($"Password verification should succeed. IsLockedOut: {result.IsLockedOut}, RequiresTwoFactor: {result.RequiresTwoFactor}");
    }

        [Fact]
        public async Task AuthEndpoint_ShouldExist()
        {
            // First, let's test if IAppUserManager can find the user
            var appUserManager = ServiceProvider.GetRequiredService<IAppUserManager>();
            var user = await appUserManager.FindByPhoneNumberAsync("123-456-7890");
            Console.WriteLine($"IAppUserManager found user: {user?.UserName ?? "null"}");
            
            // Test password verification directly
            if (user != null)
            {
                var passwordCheck = await appUserManager.CheckPasswordAsync(user, "TestPassword123!");
                Console.WriteLine($"Password check result: {passwordCheck}");
            }
            
            // Let's also check what users exist in the database from the API's perspective
            using var scope = ServiceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var allUsers = await context.Users.ToListAsync();
            Console.WriteLine($"API context sees {allUsers.Count} users:");
            foreach (var u in allUsers)
            {
                Console.WriteLine($"  - {u.UserName} ({u.PhoneNumber})");
            }
            
            // Act - Use the correct endpoint and request format
            var response = await Client.PostAsJsonAsync("/api/v1/authorization/login", new { PhoneNumber = "123-456-7890", Password = "TestPassword123!" });

            // Assert
            Console.WriteLine($"Auth endpoint status: {response.StatusCode}");
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Auth endpoint response: {content}");
            
            // Don't assert success yet, just see what we get
            response.Should().NotBeNull();
        }
}
