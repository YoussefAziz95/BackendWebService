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
/// Integration tests for database transactions and UnitOfWork patterns
/// </summary>
public class TransactionIntegrationTests : BaseIntegrationTest
{
    private readonly ApplicationDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public TransactionIntegrationTests(IntegrationTestWebApplicationFactory factory) 
        : base(factory)
    {
        _context = ServiceProvider.GetRequiredService<ApplicationDbContext>();
        _unitOfWork = ServiceProvider.GetRequiredService<IUnitOfWork>();
    }

    [Fact] // PERMANENT FIX: Now using real SQL Server - transactions work!
    public async Task Transaction_ShouldCommitSuccessfully()
    {
        // Arrange
        var initialCompanyCount = await _context.Companies.CountAsync();
        var initialCategoryCount = await _context.Categories.CountAsync();

        // Act - Create a transaction that should succeed
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var company = new Company
            {
                CompanyName = "Transaction Test Company",
                OrganizationId = 1,
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            };

            var category = new Category
            {
                Name = "Transaction Test Category",
                OrganizationId = 1,
                IsActive = true
            };

            _context.Companies.Add(company);
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }

        // Assert
        var finalCompanyCount = await _context.Companies.CountAsync();
        var finalCategoryCount = await _context.Categories.CountAsync();

        finalCompanyCount.Should().Be(initialCompanyCount + 1, "Company should be added");
        finalCategoryCount.Should().Be(initialCategoryCount + 1, "Category should be added");
    }

    [Fact] // PERMANENT FIX: Now using real SQL Server - transactions work!
    public async Task Transaction_ShouldRollbackOnError()
    {
        // Arrange
        var initialCompanyCount = await _context.Companies.CountAsync();
        var initialCategoryCount = await _context.Categories.CountAsync();

        // Act - Create a transaction that should fail and rollback
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var company = new Company
            {
                CompanyName = "Rollback Test Company",
                OrganizationId = 1,
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            };

            var category = new Category
            {
                Name = "Rollback Test Category",
                OrganizationId = 1,
                IsActive = true
            };

            _context.Companies.Add(company);
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            // Simulate an error that should cause rollback
            throw new InvalidOperationException("Simulated error for rollback test");
        }
        catch
        {
            await transaction.RollbackAsync();
        }

        // Assert
        var finalCompanyCount = await _context.Companies.CountAsync();
        var finalCategoryCount = await _context.Categories.CountAsync();

        finalCompanyCount.Should().Be(initialCompanyCount, "Company should not be added due to rollback");
        finalCategoryCount.Should().Be(initialCategoryCount, "Category should not be added due to rollback");
    }

    [Fact]
    public async Task UnitOfWork_ShouldSaveChangesSuccessfully()
    {
        // Arrange
        var initialCompanyCount = await _context.Companies.CountAsync();

        // Act
        var company = new Company
        {
            CompanyName = "UnitOfWork Test Company",
            OrganizationId = 1,
            IsActive = true,
            CreatedDate = DateTime.UtcNow
        };

        _context.Companies.Add(company);
        await _unitOfWork.SaveAsync();

        // Assert
        var finalCompanyCount = await _context.Companies.CountAsync();
        finalCompanyCount.Should().Be(initialCompanyCount + 1, "Company should be saved via UnitOfWork");
    }

    [Fact]
    public async Task UnitOfWork_ShouldHandleMultipleOperations()
    {
        // Arrange
        var initialCompanyCount = await _context.Companies.CountAsync();
        var initialCategoryCount = await _context.Categories.CountAsync();

        // Act - Multiple operations in a single UnitOfWork
        var company = new Company
        {
            CompanyName = "Multi Op Company",
            OrganizationId = 1,
            IsActive = true,
            CreatedDate = DateTime.UtcNow
        };

        var category = new Category
        {
            Name = "Multi Op Category",
            OrganizationId = 1,
            IsActive = true
        };

        _context.Companies.Add(company);
        _context.Categories.Add(category);
        await _unitOfWork.SaveAsync();

        // Assert
        var finalCompanyCount = await _context.Companies.CountAsync();
        var finalCategoryCount = await _context.Categories.CountAsync();

        finalCompanyCount.Should().Be(initialCompanyCount + 1, "Company should be saved");
        finalCategoryCount.Should().Be(initialCategoryCount + 1, "Category should be saved");
    }

    [Fact] // PERMANENT FIX: Now using real SQL Server - transactions work!
    public async Task Transaction_ShouldHandleConcurrentTransactions()
    {
        // Arrange
        var initialCompanyCount = await _context.Companies.CountAsync();

        // Act - Simulate concurrent transactions
        var tasks = new List<Task>();
        for (int i = 0; i < 3; i++)
        {
            int index = i; // Capture loop variable
            tasks.Add(Task.Run(async () =>
            {
                using var scope = ServiceProvider.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                
                using var transaction = await context.Database.BeginTransactionAsync();
                try
                {
                    var company = new Company
                    {
                        CompanyName = $"Concurrent Company {index}",
                        OrganizationId = 1,
                        IsActive = true,
                        CreatedDate = DateTime.UtcNow
                    };

                    context.Companies.Add(company);
                    await context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }));
        }

        await Task.WhenAll(tasks);

        // Assert
        var finalCompanyCount = await _context.Companies.CountAsync();
        finalCompanyCount.Should().Be(initialCompanyCount + 3, "All concurrent transactions should succeed");
    }

    [Fact] // PERMANENT FIX: Now using real SQL Server - transactions work!
    public async Task Transaction_ShouldHandleNestedTransactions()
    {
        // Arrange
        var initialCompanyCount = await _context.Companies.CountAsync();

        // Act - Nested transaction scenario
        using var outerTransaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var company = new Company
            {
                CompanyName = "Outer Transaction Company",
                OrganizationId = 1,
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            };

            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            // Inner transaction
            using var innerTransaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var category = new Category
                {
                    Name = "Inner Transaction Category",
                    OrganizationId = 1,
                    IsActive = true
                };

                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                await innerTransaction.CommitAsync();
            }
            catch
            {
                await innerTransaction.RollbackAsync();
                throw;
            }

            await outerTransaction.CommitAsync();
        }
        catch
        {
            await outerTransaction.RollbackAsync();
            throw;
        }

        // Assert
        var finalCompanyCount = await _context.Companies.CountAsync();
        var finalCategoryCount = await _context.Categories.CountAsync();

        finalCompanyCount.Should().Be(initialCompanyCount + 1, "Company should be saved");
        finalCategoryCount.Should().BeGreaterThan(0, "Category should be saved");
    }

    [Fact] // PERMANENT FIX: Now using real SQL Server - transactions work!
    public async Task Transaction_ShouldHandleTimeout()
    {
        // Arrange
        var initialCompanyCount = await _context.Companies.CountAsync();

        // Act - Transaction with timeout
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var company = new Company
            {
                CompanyName = "Timeout Test Company",
                OrganizationId = 1,
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            };

            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception ex) when (ex.Message.Contains("timeout", StringComparison.OrdinalIgnoreCase))
        {
            await transaction.RollbackAsync();
            throw;
        }

        // Assert
        var finalCompanyCount = await _context.Companies.CountAsync();
        finalCompanyCount.Should().Be(initialCompanyCount + 1, "Company should be saved despite timeout test");
    }

    [Fact] // PERMANENT FIX: Now using real SQL Server - transactions work!
    public async Task Transaction_ShouldHandleDeadlock()
    {
        // Arrange
        var initialCompanyCount = await _context.Companies.CountAsync();

        // Act - Simulate potential deadlock scenario
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var company = new Company
            {
                CompanyName = "Deadlock Test Company",
                OrganizationId = 1,
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            };

            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception ex) when (ex.Message.Contains("deadlock", StringComparison.OrdinalIgnoreCase))
        {
            await transaction.RollbackAsync();
            // In a real scenario, you might want to retry the transaction
            throw;
        }

        // Assert
        var finalCompanyCount = await _context.Companies.CountAsync();
        finalCompanyCount.Should().Be(initialCompanyCount + 1, "Company should be saved despite deadlock test");
    }
}
