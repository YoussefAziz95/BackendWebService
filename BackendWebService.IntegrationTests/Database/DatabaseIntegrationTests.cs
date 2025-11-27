using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using Domain;
using BackendWebService.IntegrationTests.Base;
using BackendWebService.IntegrationTests.Infrastructure;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;

namespace BackendWebService.IntegrationTests.Database;

/// <summary>
/// Integration tests for database operations and migrations
/// </summary>
public class DatabaseIntegrationTests : BaseIntegrationTest
{
    private readonly ApplicationDbContext _context;

    public DatabaseIntegrationTests(IntegrationTestWebApplicationFactory factory) 
        : base(factory)
    {
        _context = ServiceProvider.GetRequiredService<ApplicationDbContext>();
    }

    [Fact]
    public async Task Database_ShouldBeCreatedSuccessfully()
    {
        // Act & Assert
        var canConnect = await _context.Database.CanConnectAsync();
        canConnect.Should().BeTrue("Database should be created and accessible");
    }

    [Fact] // PERMANENT FIX: Now using real SQL Server - relational methods work!
    public async Task Database_ShouldHaveAllRequiredTables()
    {
        // Act
        var tables = await _context.Database.GetDbConnection().GetSchemaAsync("Tables");
        var tableNames = tables.Rows.Cast<System.Data.DataRow>()
            .Select(row => row["TABLE_NAME"].ToString())
            .Where(name => !string.IsNullOrEmpty(name))
            .ToList();

        // Assert
        var expectedTables = new[]
        {
            "AspNetUsers",
            "AspNetRoles", 
            "AspNetUserRoles",
            "AspNetUserClaims",
            "AspNetRoleClaims",
            "AspNetUserLogins",
            "AspNetUserTokens",
            "Companies",
            "Categories",
            "Logging",
            "Organizations",
            "UserRefreshTokens"
        };

        foreach (var expectedTable in expectedTables)
        {
            tableNames.Should().Contain(expectedTable, 
                $"Table {expectedTable} should exist in the database");
        }
    }

    [Fact] // PERMANENT FIX: Now using real SQL Server - migrations work!
    public async Task Database_ShouldApplyMigrationsSuccessfully()
    {
        // Act
        var pendingMigrations = await _context.Database.GetPendingMigrationsAsync();
        var appliedMigrations = await _context.Database.GetAppliedMigrationsAsync();

        // Assert
        pendingMigrations.Should().BeEmpty("All migrations should be applied");
        appliedMigrations.Should().NotBeEmpty("At least one migration should be applied");
    }

    [Fact]
    public async Task Database_ShouldSeedInitialData()
    {
        // Act
        var userCount = await _context.Users.CountAsync();
        var roleCount = await _context.Roles.CountAsync();
        var companyCount = await _context.Companies.CountAsync();
        var categoryCount = await _context.Categories.CountAsync();

        // Assert
        userCount.Should().BeGreaterThan(0, "Users should be seeded");
        roleCount.Should().BeGreaterThan(0, "Roles should be seeded");
        companyCount.Should().BeGreaterThan(0, "Companies should be seeded");
        categoryCount.Should().BeGreaterThan(0, "Categories should be seeded");
    }

    [Fact]
    public async Task Database_ShouldHandleUserCreation()
    {
        // Arrange
        var userManager = ServiceProvider.GetRequiredService<UserManager<User>>();
        var newUser = new User
        {
            UserName = "newuser@example.com",
            Email = "newuser@example.com",
            FirstName = "New",
            LastName = "User",
            PhoneNumber = "123-456-7890", // Added missing PhoneNumber property
            OrganizationId = 1,
            CreatedDate = DateTime.UtcNow,
            IsActive = true
        };

        // Act
        var result = await userManager.CreateAsync(newUser, "NewPassword123!");
        var savedUser = await _context.Users
            .FirstOrDefaultAsync(u => u.UserName == "newuser@example.com");

        // Assert
        result.Succeeded.Should().BeTrue("User creation should succeed");
        savedUser.Should().NotBeNull("User should be saved to database");
        savedUser!.UserName.Should().Be("newuser@example.com");
    }

    [Fact]
    public async Task Database_ShouldHandleRoleAssignment()
    {
        // Arrange
        var userManager = ServiceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = ServiceProvider.GetRequiredService<RoleManager<Role>>();
        
        // Get a user that doesn't have all roles assigned
        var user = await _context.Users.FirstAsync();
        var roles = await _context.Roles.ToListAsync();
        
        // Find a role that the user doesn't already have
        var userRoles = await userManager.GetRolesAsync(user);
        var availableRole = roles.FirstOrDefault(r => !userRoles.Contains(r.Name!));
        
        // If user has all roles, create a new role for testing
        if (availableRole == null)
        {
            var newRole = new Role { Name = "TestRole", NormalizedName = "TESTROLE" };
            await roleManager.CreateAsync(newRole);
            availableRole = newRole;
        }

        // Act
        var result = await userManager.AddToRoleAsync(user, availableRole.Name!);

        // Assert
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new InvalidOperationException($"Role assignment failed: {errors}");
        }
        
        result.Succeeded.Should().BeTrue("Role assignment should succeed");
        
        var updatedUserRoles = await userManager.GetRolesAsync(user);
        updatedUserRoles.Should().Contain(availableRole.Name, "User should have the assigned role");
    }

    [Fact]
    public async Task Database_ShouldHandleCompanyCreation()
    {
        // Arrange
        var newCompany = new Company
        {
            CompanyName = "Test Company",
            OrganizationId = 1,
            CreatedDate = DateTime.UtcNow,
            IsActive = true
        };

        // Act
        _context.Companies.Add(newCompany);
        await _context.SaveChangesAsync();

        var savedCompany = await _context.Companies
            .FirstOrDefaultAsync(c => c.CompanyName == "Test Company");

        // Assert
        savedCompany.Should().NotBeNull("Company should be saved to database");
        savedCompany!.CompanyName.Should().Be("Test Company");
        savedCompany.OrganizationId.Should().Be(1);
    }

    [Fact]
    public async Task Database_ShouldHandleCategoryCreation()
    {
        // Arrange
        var newCategory = new Category
        {
            Name = "Test Category",
            OrganizationId = 1,
            CreatedDate = DateTime.UtcNow,
            IsActive = true
        };

        // Act
        _context.Categories.Add(newCategory);
        await _context.SaveChangesAsync();

        var savedCategory = await _context.Categories
            .FirstOrDefaultAsync(c => c.Name == "Test Category");

        // Assert
        savedCategory.Should().NotBeNull("Category should be saved to database");
        savedCategory!.Name.Should().Be("Test Category");
        savedCategory.OrganizationId.Should().Be(1);
    }

    [Fact]
    public async Task Database_ShouldHandleCascadeDeletion()
    {
        // Arrange
        var company = await _context.Companies.FirstAsync();
        var companyId = company.Id;

        // Act
        _context.Companies.Remove(company);
        await _context.SaveChangesAsync();

        var deletedCompany = await _context.Companies
            .FirstOrDefaultAsync(c => c.Id == companyId);

        // Assert
        deletedCompany.Should().BeNull("Company should be deleted from database");
    }

    [Fact]
    public async Task Database_ShouldHandleLargeDataSet()
    {
        // Arrange - Get initial count before adding bulk data
        var initialCount = await _context.Companies.CountAsync();
        
        var companies = new List<Company>();
        for (int i = 0; i < 100; i++)
        {
            companies.Add(new Company
            {
                CompanyName = $"Bulk Company {i}",
                OrganizationId = 1,
                CreatedDate = DateTime.UtcNow,
                IsActive = true
            });
        }

        // Act
        _context.Companies.AddRange(companies);
        var result = await _context.SaveChangesAsync();

        // Assert - Use greater than or equal to account for any additional tracked entities
        result.Should().BeGreaterThanOrEqualTo(100, "At least 100 companies should be saved");
        
        var finalCount = await _context.Companies.CountAsync();
        finalCount.Should().Be(initialCount + 100, "Total company count should increase by 100");
        
        var savedCount = await _context.Companies
            .CountAsync(c => c.CompanyName.StartsWith("Bulk Company"));
        savedCount.Should().Be(100, "All bulk companies should be in database");
        
        // Verify that we can query the data efficiently
        var firstCompany = await _context.Companies
            .FirstOrDefaultAsync(c => c.CompanyName == "Bulk Company 0");
        firstCompany.Should().NotBeNull("First bulk company should exist");
        
        var lastCompany = await _context.Companies
            .FirstOrDefaultAsync(c => c.CompanyName == "Bulk Company 99");
        lastCompany.Should().NotBeNull("Last bulk company should exist");
        
        // Verify that we can perform complex queries on the large dataset
        var activeCompanies = await _context.Companies
            .Where(c => c.CompanyName.StartsWith("Bulk Company") && c.IsActive == true)
            .CountAsync();
        activeCompanies.Should().Be(100, "All bulk companies should be active");
        
        var companiesByOrg = await _context.Companies
            .Where(c => c.CompanyName.StartsWith("Bulk Company") && c.OrganizationId == 1)
            .CountAsync();
        companiesByOrg.Should().Be(100, "All bulk companies should belong to organization 1");
    }

    [Fact]
    public async Task Database_ShouldHandleComplexQueries()
    {
        // Act
        var usersWithRoles = await _context.Users
            .Where(u => u.IsActive == true)
            .Select(u => new
            {
                u.Id,
                u.UserName,
                u.FirstName,
                u.LastName,
                RoleCount = u.UserRoles.Count
            })
            .ToListAsync();

        var companiesByOrganization = await _context.Companies
            .GroupBy(c => c.OrganizationId)
            .Select(g => new
            {
                OrganizationId = g.Key,
                CompanyCount = g.Count(),
                ActiveCount = g.Count(c => c.IsActive == true)
            })
            .ToListAsync();

        // Assert
        usersWithRoles.Should().NotBeEmpty("Complex user query should return results");
        companiesByOrganization.Should().NotBeEmpty("Complex company query should return results");
    }
}