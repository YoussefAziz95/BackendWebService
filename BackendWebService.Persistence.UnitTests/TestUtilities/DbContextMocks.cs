using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using Domain;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace BackendWebService.Persistence.UnitTests.TestUtilities;

public static class DbContextMocks
{
    /// <summary>
    /// Creates an in-memory database context for testing
    /// </summary>
    /// <param name="databaseName">Optional database name (defaults to Guid.NewGuid())</param>
    /// <returns>ApplicationDbContext configured for in-memory testing</returns>
    public static ApplicationDbContext CreateInMemoryDbContext(string? databaseName = null)
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName ?? Guid.NewGuid().ToString())
            .Options;

        return new ApplicationDbContext(options);
    }

    /// <summary>
    /// Creates a service collection with in-memory database context
    /// </summary>
    /// <param name="databaseName">Optional database name</param>
    /// <returns>ServiceCollection configured for testing</returns>
    public static IServiceCollection CreateTestServiceCollection(string? databaseName = null)
    {
        var services = new ServiceCollection();
        
        // Add Entity Framework with InMemory provider
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase(databaseName ?? Guid.NewGuid().ToString()));

        // Add Identity services for testing
        services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }

    /// <summary>
    /// Creates a scoped service provider with in-memory database
    /// </summary>
    /// <param name="databaseName">Optional database name</param>
    /// <returns>IServiceProvider configured for testing</returns>
    public static IServiceProvider CreateTestServiceProvider(string? databaseName = null)
    {
        var services = CreateTestServiceCollection(databaseName);
        return services.BuildServiceProvider();
    }

    /// <summary>
    /// Creates a mock ApplicationDbContext using Moq
    /// </summary>
    /// <returns>Mock<ApplicationDbContext></returns>
    public static Mock<ApplicationDbContext> CreateMockDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new Mock<ApplicationDbContext>(options);
    }
}
