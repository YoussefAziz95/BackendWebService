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

    public static void ConfigureGrpcPipeline(this WebApplication app)
    {

    }
}
