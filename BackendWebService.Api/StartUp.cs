namespace Api;

public static class Startup
{
    public static IServiceCollection ConfigureGrpcPluginServices(this IServiceCollection services)
    {
        services.AddGrpc();
        return services;
    }

    public static void ConfigureGrpcPipeline(this WebApplication app)
    {
    }
}
