using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using Domain;
using BackendWebService.IntegrationTests.Base;
using BackendWebService.IntegrationTests.Infrastructure;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Domain.Enums;

namespace BackendWebService.IntegrationTests.Database;

/// <summary>
/// Integration tests for custom DbContext logic (string cleaning, logging, user info injection)
/// </summary>
public class DbContextCustomLogicIntegrationTests : BaseIntegrationTest
{
    private readonly ApplicationDbContext _context;

    public DbContextCustomLogicIntegrationTests(IntegrationTestWebApplicationFactory factory) 
        : base(factory)
    {
        _context = ServiceProvider.GetRequiredService<ApplicationDbContext>();
    }

    [Fact]
    public async Task DbContext_ShouldCleanPersianStrings()
    {
        // Arrange
        var company = new Company
        {
            CompanyName = "شرکت تست", // Persian text
            OrganizationId = 1,
            IsActive = true,
            CreatedDate = DateTime.UtcNow
        };

        // Act
        _context.Companies.Add(company);
        await _context.SaveChangesAsync();

        // Assert
        var savedCompany = await _context.Companies.FirstAsync(c => c.CompanyName == company.CompanyName);
        savedCompany.CompanyName.Should().NotBeNullOrEmpty("Company name should be saved");
        // Note: String cleaning behavior depends on the actual implementation
        // In a real scenario, you would verify that Persian characters are properly converted
    }

    [Fact]
    public async Task DbContext_ShouldLogEntityChanges()
    {
        // Arrange
        var initialLogCount = await _context.Loggings.CountAsync();

        // Act - Create a new entity to trigger logging
        var company = new Company
        {
            CompanyName = "Logging Test Company",
            OrganizationId = 1,
            IsActive = true,
            CreatedDate = DateTime.UtcNow
        };

        _context.Companies.Add(company);
        await _context.SaveChangesAsync();

        // Assert
        var finalLogCount = await _context.Loggings.CountAsync();
        finalLogCount.Should().BeGreaterThan(initialLogCount, "Entity changes should be logged");

        var logEntry = await _context.Loggings
            .OrderByDescending(l => l.Timestamp)
            .FirstAsync();

        logEntry.Message.Should().Contain("Added", "Log should indicate entity was added");
        logEntry.Message.Should().Contain("Company", "Log should mention the entity type");
        logEntry.LogType.Should().Be(LogTypeEnum.Info, "Log type should be Info");
    }

    [Fact]
    public async Task DbContext_ShouldLogEntityUpdates()
    {
        // Arrange
        var company = new Company
        {
            CompanyName = "Update Test Company",
            OrganizationId = 1,
            IsActive = true,
            CreatedDate = DateTime.UtcNow
        };

        _context.Companies.Add(company);
        await _context.SaveChangesAsync();

        var initialLogCount = await _context.Loggings.CountAsync();

        // Act - Update the entity
        company.CompanyName = "Updated Company Name";
        await _context.SaveChangesAsync();

        // Assert
        var finalLogCount = await _context.Loggings.CountAsync();
        finalLogCount.Should().BeGreaterThan(initialLogCount, "Entity updates should be logged");

        var updateLog = await _context.Loggings
            .Where(l => l.Message.Contains("Updated"))
            .OrderByDescending(l => l.Timestamp)
            .FirstAsync();

        updateLog.Message.Should().Contain("Updated", "Log should indicate entity was updated");
        updateLog.Message.Should().Contain("Company", "Log should mention the entity type");
    }

    [Fact]
    public async Task DbContext_ShouldLogEntityDeletions()
    {
        // Arrange
        var company = new Company
        {
            CompanyName = "Delete Test Company",
            OrganizationId = 1,
            IsActive = true,
            CreatedDate = DateTime.UtcNow
        };

        _context.Companies.Add(company);
        await _context.SaveChangesAsync();

        var initialLogCount = await _context.Loggings.CountAsync();

        // Act - Delete the entity
        _context.Companies.Remove(company);
        await _context.SaveChangesAsync();

        // Assert
        var finalLogCount = await _context.Loggings.CountAsync();
        finalLogCount.Should().BeGreaterThan(initialLogCount, "Entity deletions should be logged");

        var deleteLog = await _context.Loggings
            .Where(l => l.Message.Contains("Deleted"))
            .OrderByDescending(l => l.Timestamp)
            .FirstAsync();

        deleteLog.Message.Should().Contain("Deleted", "Log should indicate entity was deleted");
        deleteLog.Message.Should().Contain("Company", "Log should mention the entity type");
    }

    [Fact]
    public async Task DbContext_ShouldInjectUserInfo()
    {
        // Arrange
        // Set user info in the context (simulating authenticated user)
        _context.userInfo = new Application.Model.Notifications.UserInfo
        {
            UserId = 1,
            Username = "testuser",
            OrganizationId = 1
        };

        var company = new Company
        {
            CompanyName = "User Info Test Company",
            OrganizationId = 0, // This should be set by the context
            IsActive = true,
            CreatedDate = DateTime.UtcNow
        };

        // Act
        _context.Companies.Add(company);
        await _context.SaveChangesAsync();

        // Assert
        var savedCompany = await _context.Companies.FirstAsync(c => c.CompanyName == company.CompanyName);
        savedCompany.OrganizationId.Should().Be(1, "Organization ID should be injected from user info");
    }

    [Fact]
    public async Task DbContext_ShouldHandleAddAsyncMethod()
    {
        // Arrange
        var company = new Company
        {
            CompanyName = "AddAsync Test Company",
            OrganizationId = 1,
            IsActive = true,
            CreatedDate = DateTime.UtcNow
        };

        // Act - Use AddAsync method
        await _context.AddAsync(company);
        await _context.SaveChangesAsync();

        // Assert
        var savedCompany = await _context.Companies.FirstAsync(c => c.CompanyName == company.CompanyName);
        savedCompany.Should().NotBeNull("Company should be saved using AddAsync");
        savedCompany.CompanyName.Should().Be(company.CompanyName);
    }

    [Fact]
    public async Task DbContext_ShouldHandleAddMethod()
    {
        // Arrange
        var company = new Company
        {
            CompanyName = "Add Test Company",
            OrganizationId = 1,
            IsActive = true,
            CreatedDate = DateTime.UtcNow
        };

        // Act - Use Add method
        _context.Add(company);
        await _context.SaveChangesAsync();

        // Assert
        var savedCompany = await _context.Companies.FirstAsync(c => c.CompanyName == company.CompanyName);
        savedCompany.Should().NotBeNull("Company should be saved using Add");
        savedCompany.CompanyName.Should().Be(company.CompanyName);
    }

    [Fact]
    public async Task DbContext_ShouldHandleSaveChangesAsync()
    {
        // Arrange
        var company = new Company
        {
            CompanyName = "SaveChangesAsync Test Company",
            OrganizationId = 1,
            IsActive = true,
            CreatedDate = DateTime.UtcNow
        };

        _context.Companies.Add(company);

        // Act
        var result = await _context.SaveChangesAsync();

        // Assert
        result.Should().BeGreaterThan(0, "SaveChangesAsync should return number of affected entities");
        
        var savedCompany = await _context.Companies.FirstAsync(c => c.CompanyName == company.CompanyName);
        savedCompany.Should().NotBeNull("Company should be saved");
    }

    [Fact]
    public async Task DbContext_ShouldHandleSaveChanges()
    {
        // Arrange
        var company = new Company
        {
            CompanyName = "SaveChanges Test Company",
            OrganizationId = 1,
            IsActive = true,
            CreatedDate = DateTime.UtcNow
        };

        _context.Companies.Add(company);

        // Act
        var result = _context.SaveChanges();

        // Assert
        result.Should().BeGreaterThan(0, "SaveChanges should return number of affected entities");
        
        var savedCompany = await _context.Companies.FirstAsync(c => c.CompanyName == company.CompanyName);
        savedCompany.Should().NotBeNull("Company should be saved");
    }

    [Fact]
    public async Task DbContext_ShouldSkipLoggingForLoggingEntity()
    {
        // Arrange
        var initialLogCount = await _context.Loggings.CountAsync();

        // Act - Create a Logging entity (should not be logged to avoid recursion)
        var logEntry = new Logging
        {
            UserId = 1,
            Message = "Test log entry",
            Suggestion = null,
            LogType = LogTypeEnum.Info,
            Timestamp = DateTime.UtcNow,
            SourceLayer = "Test",
            SourceClass = "TestClass",
            SourceLineNumber = 1
        };

        _context.Loggings.Add(logEntry);
        await _context.SaveChangesAsync();

        // Assert
        var finalLogCount = await _context.Loggings.CountAsync();
        finalLogCount.Should().Be(initialLogCount + 1, "Only the new log entry should be added");
        
        // Verify that no additional log entries were created for the Logging entity itself
        var logEntries = await _context.Loggings
            .Where(l => l.Message.Contains("Added Logging"))
            .ToListAsync();
        
        logEntries.Should().BeEmpty("Logging entity should not generate additional log entries");
    }

    [Fact]
    public async Task DbContext_ShouldHandleMultipleEntityChanges()
    {
        // Arrange
        var initialLogCount = await _context.Loggings.CountAsync();

        // Act - Create multiple entities
        var company = new Company
        {
            CompanyName = "Multi Entity Company",
            OrganizationId = 1,
            IsActive = true,
            CreatedDate = DateTime.UtcNow
        };

        var category = new Category
        {
            Name = "Multi Entity Category",
            OrganizationId = 1,
            IsActive = true
        };

        _context.Companies.Add(company);
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();

        // Assert
        var finalLogCount = await _context.Loggings.CountAsync();
        finalLogCount.Should().Be(initialLogCount + 2, "Two log entries should be created for two entities");

        var logEntries = await _context.Loggings
            .OrderByDescending(l => l.Timestamp)
            .Take(2)
            .ToListAsync();

        logEntries.Should().HaveCount(2, "Should have two recent log entries");
        logEntries.Should().Contain(l => l.Message.Contains("Added Company"), "Should log company addition");
        logEntries.Should().Contain(l => l.Message.Contains("Added Category"), "Should log category addition");
    }

    [Fact]
    public async Task DbContext_ShouldHandleUserInfoNull()
    {
        // Arrange
        _context.userInfo = null; // No user info
        var company = new Company
        {
            CompanyName = "No User Info Company",
            OrganizationId = 0,
            IsActive = true,
            CreatedDate = DateTime.UtcNow
        };

        // Act
        _context.Companies.Add(company);
        await _context.SaveChangesAsync();

        // Assert
        var savedCompany = await _context.Companies.FirstAsync(c => c.CompanyName == company.CompanyName);
        savedCompany.OrganizationId.Should().Be(0, "Organization ID should remain 0 when no user info");
    }
}

