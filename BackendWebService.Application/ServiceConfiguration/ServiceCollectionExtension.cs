using Application.Contracts.Infrastructures;
using Application.Contracts.Services;
using Application.Identity.Jwt;
using Application.Implementations.Common;
using Application.Manager;
using Application.Middleware;
using Application.Permissions;
using Application.ServicesImplementation.Common;
using Application.Utilities;
using BackendWebService.Application.Contracts.Manager;
using Contracts.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BackendWebServiceApplication.ServiceConfiguration;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        // Register AutoMapper with the current assembly
        //services.AddAutoMapper(typeof(MappingProfile));

        // Register custom pipeline behavior (if needed)
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateCommandBehavior<,>));

        // Add transient services
        services.AddTransient<GlobalExceptionHandler>();

        services.AddTransient<OtpVerificationMiddleware>();

        // Add singleton services
        services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
        //services.AddSingleton<AuthenticationFactory>();

        // Add scoped services
        services.AddScoped<IAppSignInManager, AppSignInManager>();
        services.AddScoped<IAppUserManager, AppUserManager>();
        services.AddScoped<IAppRoleManager, AppRoleManager>();
        services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IFileSystemService, FileSystemService>();
        //services.AddScoped<IUserService, UserService>();
        //services.AddScoped<IUtilityService, UtilityService>();
        //services.AddScoped<IPermissionService, PermissionService>();
        //services.AddScoped<ICompanyService, CompanyService>();

        //services.AddScoped<ISupplierDocumentService, SupplierDocumentService>();
        //services.AddScoped<ICategoryService, CategoryService>();
        //services.AddScoped<IPreDocumentService, PreDocumentService>();
        //services.AddScoped<ISupplierService, SupplierService>();
        //services.AddScoped<IDropdownService, DropdownService>();
        //services.AddScoped<IServiceImplementation, ServiceImplementation>();
        services.AddScoped<IExceptionLogService, ExceptionLogService>();

        services.AddScoped<ILoggingService, LoggingService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IFileService, FileService>();
        services.AddTransient<ExceptionHandlingMiddleware>();

        //services.AddScoped<IOrganizationService, OrganizationService>();

        return services;
    }


}