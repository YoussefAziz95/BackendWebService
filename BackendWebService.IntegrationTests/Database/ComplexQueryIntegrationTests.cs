using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using Domain;
using BackendWebService.IntegrationTests.Base;
using BackendWebService.IntegrationTests.Infrastructure;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Application.Contracts.Persistence;
using Persistence.Repositories.Common;

namespace BackendWebService.IntegrationTests.Database;

/// <summary>
/// Integration tests for complex database queries and operations
/// </summary>
public class ComplexQueryIntegrationTests : BaseIntegrationTest
{
    private readonly ApplicationDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public ComplexQueryIntegrationTests(IntegrationTestWebApplicationFactory factory) 
        : base(factory)
    {
        _context = ServiceProvider.GetRequiredService<ApplicationDbContext>();
        _unitOfWork = ServiceProvider.GetRequiredService<IUnitOfWork>();
    }

    [Fact]
    public async Task ComplexQuery_ShouldJoinMultipleTables()
    {
        // Arrange - Ensure we have test data
        await SeedTestDataAsync();

        // Act - Complex query joining Users, Companies, and Organizations
        var complexQuery = await _context.Users
            .Include(u => u.Organization)
            .Where(u => u.IsActive == true)
            .Select(u => new
            {
                UserId = u.Id,
                UserName = u.UserName,
                FullName = $"{u.FirstName} {u.LastName}",
                OrganizationName = u.Organization != null ? u.Organization.Name : "No Organization",
                CompanyCount = _context.Companies.Count(c => c.OrganizationId == u.OrganizationId)
            })
            .ToListAsync();

        // Assert
        complexQuery.Should().NotBeEmpty("Complex query should return results");
        complexQuery.Should().OnlyContain(u => !string.IsNullOrEmpty(u.UserName), "All users should have usernames");
        complexQuery.Should().OnlyContain(u => !string.IsNullOrEmpty(u.FullName), "All users should have full names");
    }

    [Fact]
    public async Task ComplexQuery_ShouldFilterWithMultipleConditions()
    {
        // Arrange
        await SeedTestDataAsync();

        // Act - Complex filtering with multiple conditions
        var filteredResults = await _context.Companies
            .Where(c => c.OrganizationId == 1 && 
                       c.IsActive == true &&
                       c.CreatedDate >= DateTime.UtcNow.AddDays(-30))
            .OrderByDescending(c => c.CreatedDate)
            .Take(10)
            .ToListAsync();

        // Assert
        filteredResults.Should().NotBeEmpty("Filtered query should return results");
        filteredResults.Should().OnlyContain(c => c.OrganizationId == 1, "All results should have correct organization");
        filteredResults.Should().OnlyContain(c => c.IsActive == true, "All results should be active");
        filteredResults.Should().BeInDescendingOrder(c => c.CreatedDate, "Results should be ordered by creation date");
    }

    [Fact]
    public async Task ComplexQuery_ShouldGroupAndAggregate()
    {
        // Arrange
        await SeedTestDataAsync();

        // Act - Group by organization and count companies
        var groupedResults = await _context.Companies
            .GroupBy(c => c.OrganizationId)
            .Select(g => new
            {
                OrganizationId = g.Key,
                CompanyCount = g.Count(),
                ActiveCompanyCount = g.Count(c => c.IsActive == true),
                LatestCreated = g.Max(c => c.CreatedDate)
            })
            .ToListAsync();

        // Assert
        groupedResults.Should().NotBeEmpty("Grouped query should return results");
        groupedResults.Should().OnlyContain(g => g.CompanyCount > 0, "All groups should have companies");
        groupedResults.Should().OnlyContain(g => g.ActiveCompanyCount >= 0, "Active count should be non-negative");
    }

    [Fact]
    public async Task ComplexQuery_ShouldHandlePagination()
    {
        // Arrange
        await SeedTestDataAsync();
        const int pageSize = 5;
        const int pageNumber = 1;

        // Act - Paginated query
        var paginatedResults = await _context.Categories
            .Where(c => c.IsActive == true)
            .OrderBy(c => c.Name)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var totalCount = await _context.Categories
            .Where(c => c.IsActive == true)
            .CountAsync();

        // Assert
        paginatedResults.Should().NotBeEmpty("Paginated query should return results");
        paginatedResults.Count.Should().BeLessOrEqualTo(pageSize, "Page size should not exceed limit");
        totalCount.Should().BeGreaterOrEqualTo(paginatedResults.Count, "Total count should be accurate");
    }

    [Fact]
    public async Task ComplexQuery_ShouldHandleSubqueries()
    {
        // Arrange
        await SeedTestDataAsync();

        // Act - Subquery to find users with companies in their organization
        var usersWithCompanies = await _context.Users
            .Where(u => _context.Companies.Any(c => c.OrganizationId == u.OrganizationId))
            .Select(u => new
            {
                UserId = u.Id,
                UserName = u.UserName,
                CompanyCount = _context.Companies.Count(c => c.OrganizationId == u.OrganizationId)
            })
            .ToListAsync();

        // Assert
        usersWithCompanies.Should().NotBeEmpty("Subquery should return results");
        usersWithCompanies.Should().OnlyContain(u => u.CompanyCount > 0, "All users should have companies in their organization");
    }

    [Fact] // PERMANENT FIX: Now using real SQL Server - raw SQL works!
    public async Task ComplexQuery_ShouldHandleRawSql()
    {
        // Arrange
        await SeedTestDataAsync();

        // Act - Raw SQL query
        var rawSqlResults = await _context.Users
            .FromSqlRaw("SELECT * FROM AspNetUsers WHERE IsActive = 1")
            .ToListAsync();

        // Assert
        rawSqlResults.Should().NotBeEmpty("Raw SQL query should return results");
        rawSqlResults.Should().OnlyContain(u => u.IsActive == true, "All results should be active users");
    }

    [Fact]
    public async Task ComplexQuery_ShouldHandleConcurrentReads()
    {
        // Arrange
        await SeedTestDataAsync();

        // Act - Simulate concurrent reads
        var tasks = new List<Task<List<User>>>();
        for (int i = 0; i < 5; i++)
        {
            tasks.Add(Task.Run(async () =>
            {
                using var scope = ServiceProvider.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                return await context.Users.ToListAsync();
            }));
        }

        var results = await Task.WhenAll(tasks);

        // Assert
        results.Should().HaveCount(5, "All concurrent tasks should complete");
        results.Should().OnlyContain(r => r.Any(), "All concurrent reads should return data");
    }

    private async Task SeedTestDataAsync()
    {
        // Ensure we have sufficient test data for complex queries
        if (!await _context.Users.AnyAsync())
        {
            var userManager = ServiceProvider.GetRequiredService<UserManager<User>>();
            var users = new List<User>
            {
                new User
                {
                    UserName = "user1@test.com",
                    Email = "user1@test.com",
                    FirstName = "User",
                    LastName = "One",
                    PhoneNumber = "111-111-1111",
                    OrganizationId = 1,
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow.AddDays(-10)
                },
                new User
                {
                    UserName = "user2@test.com",
                    Email = "user2@test.com",
                    FirstName = "User",
                    LastName = "Two",
                    PhoneNumber = "222-222-2222",
                    OrganizationId = 1,
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow.AddDays(-5)
                }
            };

            foreach (var user in users)
            {
                await userManager.CreateAsync(user, "TestPassword123!");
            }
        }

        if (!await _context.Companies.AnyAsync())
        {
            var companies = new List<Company>
            {
                new Company
                {
                    CompanyName = "Test Company 1",
                    OrganizationId = 1,
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow.AddDays(-15)
                },
                new Company
                {
                    CompanyName = "Test Company 2",
                    OrganizationId = 1,
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow.AddDays(-8)
                },
                new Company
                {
                    CompanyName = "Test Company 3",
                    OrganizationId = 2,
                    IsActive = false,
                    CreatedDate = DateTime.UtcNow.AddDays(-20)
                }
            };

            _context.Companies.AddRange(companies);
        }

        if (!await _context.Categories.AnyAsync())
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Name = "Electronics",
                    OrganizationId = 1,
                    IsActive = true
                },
                new Category
                {
                    Name = "Books",
                    OrganizationId = 1,
                    IsActive = true
                },
                new Category
                {
                    Name = "Clothing",
                    OrganizationId = 2,
                    IsActive = true
                }
            };

            _context.Categories.AddRange(categories);
        }

        await _context.SaveChangesAsync();
    }
}
