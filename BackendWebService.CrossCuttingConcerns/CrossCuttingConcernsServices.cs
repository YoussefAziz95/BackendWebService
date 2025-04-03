using Application.Contracts.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCuttingConcerns
{
    /// <summary>
    /// A static class providing extension methods to configure cross-cutting concerns services.
    /// </summary>
    public static class CrossCuttingConcernsServices
    {
        /// <summary>
        /// Adds cross-cutting concerns services to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <returns>The same instance of the <see cref="IServiceCollection"/> for chaining.</returns>
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
