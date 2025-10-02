using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using Domain;
using BackendWebService.IntegrationTests.Base;
using BackendWebService.IntegrationTests.Infrastructure;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace BackendWebService.IntegrationTests.Database;

/// <summary>
/// Integration tests for database performance and stress testing
/// </summary>
public class PerformanceIntegrationTests : BaseIntegrationTest
{
    private readonly ApplicationDbContext _context;

    public PerformanceIntegrationTests(IntegrationTestWebApplicationFactory factory) 
        : base(factory)
    {
        _context = ServiceProvider.GetRequiredService<ApplicationDbContext>();
    }

    [Fact]
    public async Task Performance_ShouldHandleBulkInserts()
    {
        // Arrange
        var companies = new List<Company>();
        for (int i = 0; i < 100; i++)
        {
            companies.Add(new Company
            {
                CompanyName = $"Bulk Company {i}",
                OrganizationId = 1,
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            });
        }

        var stopwatch = Stopwatch.StartNew();

        // Act
        _context.Companies.AddRange(companies);
        await _context.SaveChangesAsync();
        stopwatch.Stop();

        // Assert
        var savedCount = await _context.Companies.CountAsync(c => c.CompanyName.StartsWith("Bulk Company"));
        savedCount.Should().Be(100, "All bulk companies should be saved");
        
        stopwatch.ElapsedMilliseconds.Should().BeLessThan(5000, "Bulk insert should complete within 5 seconds");
    }

    [Fact]
    public async Task Performance_ShouldHandleBulkUpdates()
    {
        // Arrange
        await SeedBulkDataAsync();
        var companies = await _context.Companies
            .Where(c => c.CompanyName.StartsWith("Bulk Update"))
            .ToListAsync();

        var stopwatch = Stopwatch.StartNew();

        // Act
        foreach (var company in companies)
        {
            company.CompanyName = company.CompanyName.Replace("Bulk Update", "Updated Bulk");
        }
        await _context.SaveChangesAsync();
        stopwatch.Stop();

        // Assert
        var updatedCount = await _context.Companies.CountAsync(c => c.CompanyName.StartsWith("Updated Bulk"));
        updatedCount.Should().Be(companies.Count, "All companies should be updated");
        
        stopwatch.ElapsedMilliseconds.Should().BeLessThan(3000, "Bulk update should complete within 3 seconds");
    }

    [Fact]
    public async Task Performance_ShouldHandleLargeResultSets()
    {
        // Arrange
        await SeedBulkDataAsync();
        var stopwatch = Stopwatch.StartNew();

        // Act
        var allCompanies = await _context.Companies
            .Where(c => c.IsActive == true)
            .OrderBy(c => c.CompanyName)
            .ToListAsync();
        stopwatch.Stop();

        // Assert
        allCompanies.Should().NotBeEmpty("Should return companies");
        allCompanies.Should().BeInAscendingOrder(c => c.CompanyName, "Results should be ordered");
        
        stopwatch.ElapsedMilliseconds.Should().BeLessThan(2000, "Large result set query should complete within 2 seconds");
    }

    [Fact]
    public async Task Performance_ShouldHandleComplexJoins()
    {
        // Arrange
        await SeedBulkDataAsync();
        var stopwatch = Stopwatch.StartNew();

        // Act
        var complexQuery = await _context.Users
            .Include(u => u.Organization)
            .Where(u => u.IsActive == true)
            .Select(u => new
            {
                UserId = u.Id,
                UserName = u.UserName,
                OrganizationName = u.Organization != null ? u.Organization.Name : "No Organization",
                CompanyCount = _context.Companies.Count(c => c.OrganizationId == u.OrganizationId)
            })
            .ToListAsync();
        stopwatch.Stop();

        // Assert
        complexQuery.Should().NotBeEmpty("Complex query should return results");
        stopwatch.ElapsedMilliseconds.Should().BeLessThan(3000, "Complex join should complete within 3 seconds");
    }

    [Fact]
    public async Task Performance_ShouldHandleConcurrentReads()
    {
        // Arrange
        await SeedBulkDataAsync();
        var stopwatch = Stopwatch.StartNew();

        // Act - Simulate concurrent reads
        var tasks = new List<Task<List<Company>>>();
        for (int i = 0; i < 10; i++)
        {
            tasks.Add(Task.Run(async () =>
            {
                using var scope = ServiceProvider.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                return await context.Companies
                    .Where(c => c.IsActive == true)
                    .Take(50)
                    .ToListAsync();
            }));
        }

        var results = await Task.WhenAll(tasks);
        stopwatch.Stop();

        // Assert
        results.Should().HaveCount(10, "All concurrent tasks should complete");
        results.Should().OnlyContain(r => r.Any(), "All concurrent reads should return data");
        
        stopwatch.ElapsedMilliseconds.Should().BeLessThan(5000, "Concurrent reads should complete within 5 seconds");
    }

    [Fact]
    public async Task Performance_ShouldHandleConcurrentWrites()
    {
        // Arrange
        var stopwatch = Stopwatch.StartNew();

        // Act - Simulate concurrent writes
        var tasks = new List<Task>();
        for (int i = 0; i < 5; i++)
        {
            int index = i; // Capture loop variable
            tasks.Add(Task.Run(async () =>
            {
                using var scope = ServiceProvider.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                
                var company = new Company
                {
                    CompanyName = $"Concurrent Company {index}",
                    OrganizationId = 1,
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow
                };

                context.Companies.Add(company);
                await context.SaveChangesAsync();
            }));
        }

        await Task.WhenAll(tasks);
        stopwatch.Stop();

        // Assert
        var concurrentCount = await _context.Companies.CountAsync(c => c.CompanyName.StartsWith("Concurrent Company"));
        concurrentCount.Should().Be(5, "All concurrent writes should succeed");
        
        stopwatch.ElapsedMilliseconds.Should().BeLessThan(3000, "Concurrent writes should complete within 3 seconds");
    }

    [Fact]
    public async Task Performance_ShouldHandleMemoryUsage()
    {
        // Arrange
        var initialMemory = GC.GetTotalMemory(false);

        // Act - Create and process large dataset
        var companies = new List<Company>();
        for (int i = 0; i < 1000; i++)
        {
            companies.Add(new Company
            {
                CompanyName = $"Memory Test Company {i}",
                OrganizationId = 1,
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            });
        }

        _context.Companies.AddRange(companies);
        await _context.SaveChangesAsync();

        // Process the data
        var allCompanies = await _context.Companies
            .Where(c => c.CompanyName.StartsWith("Memory Test"))
            .ToListAsync();

        var finalMemory = GC.GetTotalMemory(false);
        var memoryIncrease = finalMemory - initialMemory;

        // Assert
        allCompanies.Should().HaveCount(1000, "All companies should be saved");
        memoryIncrease.Should().BeLessThan(50 * 1024 * 1024, "Memory increase should be less than 50MB");
    }

    [Fact]
    public async Task Performance_ShouldHandleQueryOptimization()
    {
        // Arrange
        await SeedBulkDataAsync();
        var stopwatch = Stopwatch.StartNew();

        // Act - Optimized query with proper indexing simulation
        var optimizedQuery = await _context.Companies
            .Where(c => c.OrganizationId == 1 && c.IsActive == true)
            .Select(c => new { c.Id, c.CompanyName })
            .OrderBy(c => c.CompanyName)
            .Take(100)
            .ToListAsync();
        stopwatch.Stop();

        // Assert
        optimizedQuery.Should().NotBeEmpty("Optimized query should return results");
        optimizedQuery.Should().BeInAscendingOrder(c => c.CompanyName, "Results should be ordered");
        
        stopwatch.ElapsedMilliseconds.Should().BeLessThan(1000, "Optimized query should complete within 1 second");
    }

    [Fact]
    public async Task Performance_ShouldHandlePaginationEfficiency()
    {
        // Arrange
        await SeedBulkDataAsync();
        const int pageSize = 20;
        const int totalPages = 5;
        var stopwatch = Stopwatch.StartNew();

        // Act - Test pagination efficiency
        for (int page = 1; page <= totalPages; page++)
        {
            var pagedResults = await _context.Companies
                .Where(c => c.IsActive == true)
                .OrderBy(c => c.CompanyName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            pagedResults.Should().HaveCountLessOrEqualTo(pageSize, $"Page {page} should not exceed page size");
        }
        stopwatch.Stop();

        // Assert
        stopwatch.ElapsedMilliseconds.Should().BeLessThan(2000, "Pagination should complete within 2 seconds");
    }

    [Fact]
    public async Task Performance_ShouldHandleConnectionPooling()
    {
        // Arrange
        var stopwatch = Stopwatch.StartNew();

        // Act - Test connection pooling with multiple operations
        var tasks = new List<Task>();
        for (int i = 0; i < 20; i++)
        {
            int index = i; // Capture loop variable
            tasks.Add(Task.Run(async () =>
            {
                using var scope = ServiceProvider.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                
                var company = new Company
                {
                    CompanyName = $"Connection Pool Company {index}",
                    OrganizationId = 1,
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow
                };

                context.Companies.Add(company);
                await context.SaveChangesAsync();
            }));
        }

        await Task.WhenAll(tasks);
        stopwatch.Stop();

        // Assert
        var connectionPoolCount = await _context.Companies.CountAsync(c => c.CompanyName.StartsWith("Connection Pool"));
        connectionPoolCount.Should().Be(20, "All connection pool operations should succeed");
        
        stopwatch.ElapsedMilliseconds.Should().BeLessThan(5000, "Connection pooling should complete within 5 seconds");
    }

    [Fact]
    public async Task Performance_ShouldHandleStressTest()
    {
        // Arrange
        var stopwatch = Stopwatch.StartNew();
        var successCount = 0;
        var errorCount = 0;

        // Act - Stress test with mixed operations
        var tasks = new List<Task>();
        for (int i = 0; i < 50; i++)
        {
            int index = i; // Capture loop variable
            tasks.Add(Task.Run(async () =>
            {
                try
                {
                    using var scope = ServiceProvider.CreateScope();
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    
                    // Mix of read and write operations
                    if (index % 2 == 0)
                    {
                        // Write operation
                        var company = new Company
                        {
                            CompanyName = $"Stress Test Company {index}",
                            OrganizationId = 1,
                            IsActive = true,
                            CreatedDate = DateTime.UtcNow
                        };
                        context.Companies.Add(company);
                        await context.SaveChangesAsync();
                    }
                    else
                    {
                        // Read operation
                        var companies = await context.Companies
                            .Where(c => c.IsActive == true)
                            .Take(10)
                            .ToListAsync();
                    }
                    
                    Interlocked.Increment(ref successCount);
                }
                catch
                {
                    Interlocked.Increment(ref errorCount);
                }
            }));
        }

        await Task.WhenAll(tasks);
        stopwatch.Stop();

        // Assert
        successCount.Should().BeGreaterThan(40, "Most stress test operations should succeed");
        errorCount.Should().BeLessThan(10, "Few stress test operations should fail");
        
        stopwatch.ElapsedMilliseconds.Should().BeLessThan(10000, "Stress test should complete within 10 seconds");
    }

    private async Task SeedBulkDataAsync()
    {
        // Ensure we have bulk test data
        if (!await _context.Companies.AnyAsync(c => c.CompanyName.StartsWith("Bulk")))
        {
            var companies = new List<Company>();
            for (int i = 0; i < 200; i++)
            {
                companies.Add(new Company
                {
                    CompanyName = $"Bulk Update Company {i}",
                    OrganizationId = 1,
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow
                });
            }

            _context.Companies.AddRange(companies);
            await _context.SaveChangesAsync();
        }
    }
}
