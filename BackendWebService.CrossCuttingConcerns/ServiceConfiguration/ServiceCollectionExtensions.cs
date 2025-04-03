using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCuttingConcerns.ServiceConfiguration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCrossCuttingConcernsServices(this IServiceCollection services)
    {
        services.AddSignalR(options => // activate SignalR
        {
            options.EnableDetailedErrors = true; // Send detailed errors to the frontend for debugging. Remove this when deploying.
        });

        return services;
    }



    public static async Task ApplyMigrationsAsync(this WebApplication app)
    {

    }
}