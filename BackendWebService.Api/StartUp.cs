using Application.Contracts.Features;
using Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace Api;

public static class Startup
{
    public static IServiceCollection ConfigureGrpcPluginServices(this IServiceCollection services)
    {
        services.AddGrpc();
        services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
        });

        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV"; // e.g., v1, v2
            options.SubstituteApiVersionInUrl = true;
        });
        return services;
    }
    public static IServiceCollection ConfigureCQRS(this IServiceCollection services)
    {
        services.AddScoped<IMediator, Mediator>();
        
        // AUTO-REGISTER ALL HANDLERS using reflection
        var assembly = typeof(LoginPhoneRequestHandler).Assembly; // Application assembly
        
        // Register all IRequestHandlerAsync<,> implementations
        var asyncHandlerTypes = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .SelectMany(t => t.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandlerAsync<,>))
                .Select(i => new { Interface = i, Implementation = t }))
            .ToList();
        
        foreach (var handler in asyncHandlerTypes)
        {
            services.AddScoped(handler.Interface, handler.Implementation);
        }
        
        // Register all IRequestHandler<,> implementations (sync handlers)
        var syncHandlerTypes = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .SelectMany(t => t.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>))
                .Select(i => new { Interface = i, Implementation = t }))
            .ToList();
        
        foreach (var handler in syncHandlerTypes)
        {
            services.AddScoped(handler.Interface, handler.Implementation);
        }
        
        return services;
    }
    public static void ConfigureGrpcPipeline(this WebApplication app)
    {

    }
}
