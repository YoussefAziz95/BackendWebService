using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Domain;
using BackendWebService.IntegrationTests.Infrastructure;

namespace BackendWebService.IntegrationTests.Utilities;

/// <summary>
/// Helper class for configuring test environment
/// </summary>
public static class TestConfigurationHelper
{
    /// <summary>
    /// Creates a test configuration
    /// </summary>
    public static IConfiguration CreateTestConfiguration()
    {
        return new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["ConnectionStrings:DefaultConnection"] = "Server=(localdb)\\mssqllocaldb;Database=BackendWebService_IntegrationTest;Trusted_Connection=True;MultipleActiveResultSets=true",
                ["JwtSettings:Secret"] = "SuperSecretKeyForIntegrationTestingThatIsLongEnough",
                ["JwtSettings:Issuer"] = "IntegrationTestIssuer",
                ["JwtSettings:Audience"] = "IntegrationTestAudience",
                ["JwtSettings:ExpiryMinutes"] = "60"
            })
            .AddEnvironmentVariables()
            .Build();
    }

    /// <summary>
    /// Creates a test service collection with database context
    /// </summary>
    public static IServiceCollection CreateTestServiceCollection(string connectionString)
    {
        var services = new ServiceCollection();

        // Add logging
        services.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.SetMinimumLevel(LogLevel.Warning);
        });

        // Add database context
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
            options.EnableSensitiveDataLogging(false);
            options.EnableServiceProviderCaching(false);
        });

        // Add Identity
        services.AddIdentity<User, Role>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
            options.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

        // Add other services as needed
        services.AddScoped<ITestDataSeeder, TestDataSeeder>();
        services.AddScoped<IDatabaseCleaner, DatabaseCleaner>();

        return services;
    }

    /// <summary>
    /// Creates a test host builder
    /// </summary>
    public static IHostBuilder CreateTestHostBuilder(string connectionString)
    {
        return Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.Test.json", optional: true, reloadOnChange: true);
                config.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
                config.AddEnvironmentVariables();
            })
            .ConfigureServices((context, services) =>
            {
                var configuration = context.Configuration;
                
                // Add database context
                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                    options.EnableSensitiveDataLogging(false);
                    options.EnableServiceProviderCaching(false);
                });

                // Add Identity
                services.AddIdentity<User, Role>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 8;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireLowercase = true;
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

                // Add other services
                services.AddScoped<ITestDataSeeder, TestDataSeeder>();
                services.AddScoped<IDatabaseCleaner, DatabaseCleaner>();
            });
    }

    /// <summary>
    /// Ensures database is created and migrated
    /// </summary>
    public static async Task EnsureDatabaseCreatedAsync(ApplicationDbContext context)
    {
        await context.Database.EnsureCreatedAsync();
        await context.Database.MigrateAsync();
    }

    /// <summary>
    /// Cleans up test database
    /// </summary>
    public static async Task CleanupTestDatabaseAsync(ApplicationDbContext context)
    {
        // Delete all data from tables in dependency order
        await context.Database.ExecuteSqlRawAsync("DELETE FROM UserRoles");
        await context.Database.ExecuteSqlRawAsync("DELETE FROM UserClaims");
        await context.Database.ExecuteSqlRawAsync("DELETE FROM UserLogins");
        await context.Database.ExecuteSqlRawAsync("DELETE FROM UserTokens");
        await context.Database.ExecuteSqlRawAsync("DELETE FROM RoleClaims");
        await context.Database.ExecuteSqlRawAsync("DELETE FROM UserRefreshTokens");
        await context.Database.ExecuteSqlRawAsync("DELETE FROM Users");
        await context.Database.ExecuteSqlRawAsync("DELETE FROM Roles");
        await context.Database.ExecuteSqlRawAsync("DELETE FROM Categories");
        await context.Database.ExecuteSqlRawAsync("DELETE FROM Companies");
        await context.Database.ExecuteSqlRawAsync("DELETE FROM Logging");
        await context.Database.ExecuteSqlRawAsync("DELETE FROM ActionActor");
        await context.Database.ExecuteSqlRawAsync("DELETE FROM Organizations");
    }

    /// <summary>
    /// Gets a test connection string
    /// </summary>
    public static string GetTestConnectionString()
    {
        var configuration = CreateTestConfiguration();
        return configuration.GetConnectionString("DefaultConnection") 
            ?? "Server=(localdb)\\mssqllocaldb;Database=BackendWebService_IntegrationTest;Trusted_Connection=True;MultipleActiveResultSets=true";
    }

    /// <summary>
    /// Creates a test JWT token
    /// </summary>
    public static string CreateTestJwtToken(string secret, string issuer, string audience, string userId, string username)
    {
        // This is a simplified JWT token creation for testing
        // In a real implementation, you would use a proper JWT library
        var header = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("{\"alg\":\"HS256\",\"typ\":\"JWT\"}"));
        var payload = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{{\"sub\":\"{userId}\",\"name\":\"{username}\",\"iat\":{DateTimeOffset.UtcNow.ToUnixTimeSeconds()},\"exp\":{DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds()},\"iss\":\"{issuer}\",\"aud\":\"{audience}\"}}"));
        var signature = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{header}.{payload}.{secret}"));
        
        return $"{header}.{payload}.{signature}";
    }

    /// <summary>
    /// Validates test configuration
    /// </summary>
    public static bool ValidateTestConfiguration(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))
        {
            return false;
        }

        var jwtSecret = configuration["JwtSettings:Secret"];
        if (string.IsNullOrEmpty(jwtSecret))
        {
            return false;
        }

        var jwtIssuer = configuration["JwtSettings:Issuer"];
        if (string.IsNullOrEmpty(jwtIssuer))
        {
            return false;
        }

        var jwtAudience = configuration["JwtSettings:Audience"];
        if (string.IsNullOrEmpty(jwtAudience))
        {
            return false;
        }

        return true;
    }
}
