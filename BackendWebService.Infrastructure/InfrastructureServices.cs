using Application.Contracts.Infrastructure;
using Infrastructure.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    /// <summary>
    /// Extension methods to configure infrastructure services.
    /// </summary>
    public static class InfrastructureServices
    {
        /// <summary>
        /// Adds infrastructure services to the service collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // Register email service as a scoped service
            services.AddScoped<IEmailService, EmailService>();

            // Register file handler as a singleton service
            services.AddSingleton<IFileHandler, FileHandler>();

            return services;
        }
    }
}
