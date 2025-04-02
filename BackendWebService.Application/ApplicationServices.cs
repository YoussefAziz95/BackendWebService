using Application.Contracts.Services;
using Application.Implementations;
using Application.Middlewares;
using Application.Permissions;
using FluentValidation;
using Application.Implementations.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    /// <summary>
    /// Extension methods to register application services in the service collection.
    /// </summary>
    public static class ApplicationServices
    {
        /// <summary>
        /// Adds application services to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
        /// <returns>The <see cref="IServiceCollection"/> instance with the application services added.</returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Automatically register AutoMapper profiles from the executing assembly
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Register validators from the executing assembly
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Add transient services
            services.AddTransient<GlobalExceptionHandler>();

            services.AddTransient<OtpVerificationMiddleware>();

            // Add singleton services
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            services.AddSingleton<AuthenticationFactory>();

            // Add scoped services
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IApplicationRoleService, ApplicationRoleService>();
            services.AddScoped<IUtilityService, UtilityService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<ICompanyService, CompanyService>();

            services.AddScoped<ISupplierDocumentService, SupplierDocumentService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPreDocumentService, PreDocumentService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IDropdownService, DropdownService>();
            services.AddScoped<IFileSystemService, FileSystemService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IExceptionLogService, ExceptionLogService>();

            services.AddScoped<ILoggingService, LoggingService>();

            services.AddTransient<ExceptionHandlingMiddleware>();

            services.AddScoped<IOrganizationService, OrganizationService>();



            return services;
        }
    }
}
