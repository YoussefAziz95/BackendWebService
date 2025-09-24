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
        services.AddScoped<IRequestHandlerAsync<LoginPhoneRequest, LoginResponse>, LoginPhoneRequestHandler>();
        services.AddScoped<IRequestHandlerAsync<LoginEmailRequest, LoginResponse>, LoginEmailRequestHandler>();
        services.AddScoped<IRequestHandlerAsync<SignUpRequest, LoginResponse>, SignUpRequestHandler>();
        services.AddScoped<IRequestHandlerAsync<RefreshTokenRequest, RefreshTokenResponse>, RefreshTokenRequestHandler>();
        services.AddScoped<IRequestHandlerAsync<ResetPasswordRequest, LoginResponse>, ResetPasswordRequestHandler>();
        services.AddScoped<IRequestHandlerAsync<ConfirmResetPasswordRequest, LoginResponse>, ConfirmResetPasswordRequestHandler>();
        //services.AddScoped<IRequestHandlerAsync<ConfirmPhoneNumberRequest, LoginResponse>, ConfirmPhoneNumberHandler>();
        //services.AddScoped<IRequestHandlerAsync<PhoneNumberRequest, LoginResponse>, SendOtpHandler>();
        //services.AddScoped<IRequestHandlerAsync<OtpVerifyRequest, LoginResponse>, OtpVerifyHandler>();

        return services;
    }
    public static void ConfigureGrpcPipeline(this WebApplication app)
    {

    }
}
