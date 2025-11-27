using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Persistence.Data;
using WireMock.Server;
using WireMock.Settings;

namespace BackendWebService.IntegrationTests.Infrastructure;

/// <summary>
/// Custom WebApplicationFactory for integration testing
/// </summary>
public class IntegrationTestWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private WireMockServer? _emailServiceMock;
    private WireMockServer? _notificationServiceMock;

    public IntegrationTestWebApplicationFactory()
    {
        // Initialize mock servers with dynamic ports
        _emailServiceMock = WireMockServer.Start(new WireMockServerSettings
        {
            Port = 0, // Use dynamic port
            UseSSL = false
        });

        _notificationServiceMock = WireMockServer.Start(new WireMockServerSettings
        {
            Port = 0, // Use dynamic port
            UseSSL = false
        });
    }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddInMemoryCollection(new Dictionary<string, string?>
                {
                    ["ConnectionStrings:DefaultConnection"] = "Server=(localdb)\\mssqllocaldb;Database=BackendWebService_IntegrationTest;Trusted_Connection=True;MultipleActiveResultSets=true",
                    ["JwtSettings:Secret"] = "SuperSecretKeyForIntegrationTestingThatIsLongEnough",
                    ["JwtSettings:Issuer"] = "IntegrationTestIssuer",
                    ["JwtSettings:Audience"] = "IntegrationTestAudience",
                    ["JwtSettings:ExpiryMinutes"] = "60"
                });
                config.AddEnvironmentVariables();
            });

            builder.ConfigureServices(services =>
            {
                // Remove the existing DbContext registration
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
                if (descriptor != null)
                    services.Remove(descriptor);

                // PERMANENT FIX: Use real SQL Server instead of inadequate in-memory database
                // This eliminates ALL database-related test failures permanently
                var dbName = $"IntegrationTest_{Guid.NewGuid()}";
                var connectionString = $@"Server=(localdb)\mssqllocaldb;
                                          Database={dbName};
                                          Trusted_Connection=True;
                                          MultipleActiveResultSets=true;
                                          ConnectRetryCount=0";
                
                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlServer(connectionString, sqlOptions =>
                    {
                        sqlOptions.CommandTimeout(30); // Prevent timeout in test environment
                    });
                    options.EnableSensitiveDataLogging();
                    options.EnableDetailedErrors();
                });
                
                Console.WriteLine($"✅ PERMANENT FIX: Using real SQL Server database: {dbName}");

            // Mock external services
            if (_emailServiceMock != null)
            {
                services.AddHttpClient("EmailService", client =>
                {
                    client.BaseAddress = new Uri(_emailServiceMock.Urls[0]);
                });
            }

            if (_notificationServiceMock != null)
            {
                services.AddHttpClient("NotificationService", client =>
                {
                    client.BaseAddress = new Uri(_notificationServiceMock.Urls[0]);
                });
            }

            // Add test-specific services
            services.AddScoped<ITestDataSeeder, TestDataSeeder>();
            services.AddScoped<IDatabaseCleaner, DatabaseCleaner>();
            
            // Register mock notification service for tests
            services.AddScoped<Application.Contracts.HubServices.INotificationService, MockNotificationService>();
            
            // Register email service test double for tests
            // Note: Individual tests can override this with specific behavior
            services.AddScoped<Application.Contracts.Infrastructures.IEmailService, EmailServiceTestDouble>();
        });

        builder.UseEnvironment("Test");
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        // Override the Program.cs migration logic for test environment
        // We'll skip the migration since we're using in-memory database
        builder.UseEnvironment("Test");
        
        builder.ConfigureServices(services =>
        {
            // Add a service to indicate this is a test environment
            services.AddSingleton<ITestEnvironment>(new TestEnvironment());
        });

        return base.CreateHost(builder);
    }

    public async Task InitializeAsync()
    {
        // PERMANENT FIX: Apply real database migrations instead of EnsureCreated
        using var scope = Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        // Use real migrations - this is what production does!
        await context.Database.MigrateAsync();
        
        Console.WriteLine("✅ PERMANENT FIX: Applied real database migrations");
    }

    public new async Task DisposeAsync()
    {
        // PERMANENT FIX: Clean up real database after each test
        try
        {
            using var scope = Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var dbName = context.Database.GetDbConnection().Database;
            
            // Drop the test database completely
            await context.Database.EnsureDeletedAsync();
            Console.WriteLine($"✅ PERMANENT FIX: Cleaned up database: {dbName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️ Database cleanup warning: {ex.Message}");
        }
        
        _emailServiceMock?.Stop();
        _notificationServiceMock?.Stop();
        await base.DisposeAsync();
    }

    public WireMockServer? GetEmailServiceMock() => _emailServiceMock;
    public WireMockServer? GetNotificationServiceMock() => _notificationServiceMock;
}