using Microsoft.Extensions.DependencyInjection;

namespace CrossCuttingConcerns
{
    public static class CrossCuttingConcernsServices
    {
        public static IServiceCollection AddCrossCuttingConcernsServices(this IServiceCollection services)
        {

            services.AddSignalR(options => // activate SignalR
            {
                options.EnableDetailedErrors = true; // Send detailed errors to the frontend for debugging. Remove this when deploying.
            });

            return services;
        }
    }
}
