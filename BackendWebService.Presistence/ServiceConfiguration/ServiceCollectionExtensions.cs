using Application.Contracts.Persistence;
using Application.Contracts.Persistences;
using Application.DTOs.Common;
using Application.Manager;
using Application.Model.Jwt;
using Application.Persistence.Repositories;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistence.Data;
using Persistence.Repositories;
using Persistence.Repositories.Common;
using Persistence.Repositories.FileSystem;
using Persistence.Repositories.Identity;
using Persistence.Repositories.Notifications;
using Persistence.Store;
using Presistence.Repositories.Common;
using SharedKernel.Extensions;
using System.Security.Claims;
using System.Text;

namespace nfrastructure.Persistence.ServiceConfiguration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        string connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options
                .UseSqlServer(connectionString);
        });
        services.AddScoped<IUserRefreshTokenRepository, UserRefreshTokenRepository>();
        services.AddScoped<ISP_Call, SP_Call>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        //services.AddScoped<ICompanyRepository, CompanyRepository>();
        //services.AddScoped<ISupplierRepository, SupplierRepository>();
        //services.AddScoped<ICategoryRepository, CategoryRepository>();
        //services.AddScoped<ISupplierDocumentRepository, SupplierDocumentRepository>();
        services.AddScoped<IFileRepository, FileRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ILoggingRepository, LoggingRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddIdentity<User, Role>(options =>
        {
            options.Stores.ProtectPersonalData = false;

            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequireUppercase = false;

            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = true;

            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = false;
            options.User.RequireUniqueEmail = false;

            //options.Stores.ProtectPersonalData = true;


        }).AddUserStore<AppUserStore>()
                .AddRoleStore<RoleStore>().
                //.AddUserValidator<AppUserValidator>().
                //AddRoleValidator<AppRoleValidator>().
                AddUserManager<AppUserManager>().
                AddRoleManager<AppRoleManager>().
                AddErrorDescriber<AppErrorDescriber>()
                //.AddClaimsPrincipalFactory<AppUserClaimsPrincipleFactory>()
                .AddDefaultTokenProviders().
                AddSignInManager<AppSignInManager>()
                .AddDefaultTokenProviders()
                .AddPasswordlessLoginTotpTokenProvider();


        //For [ProtectPersonalData] Attribute In Identity

        //services.AddScoped<ILookupProtectorKeyRing, KeyRing>();

        //services.AddScoped<ILookupProtector, LookupProtector>();

        //services.AddScoped<IPersonalDataProtector, PersonalDataProtector>();

        var identitySettings = configuration.GetSection(nameof(IdentitySettings)).Get<IdentitySettings>();


        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(options =>
        {

            var secretKey = Encoding.UTF8.GetBytes(identitySettings.SecretKey);
            var encryptionKey = Encoding.UTF8.GetBytes(identitySettings.Encryptkey);

            options.RequireHttpsMetadata = false;
            options.SaveToken = true;

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ClockSkew = TimeSpan.Zero,
                RequireSignedTokens = true,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKey),

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ValidateAudience = true,
                ValidAudience = identitySettings.Audience,

                ValidateIssuer = true,
                ValidIssuer = identitySettings.Issuer,

                TokenDecryptionKey = new SymmetricSecurityKey(encryptionKey)
            };

            options.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context =>
                {
                    // Optionally log errors here
                    return Task.CompletedTask;
                },

                OnTokenValidated = async context =>
                {
                    var signInManager = context.HttpContext.RequestServices.GetRequiredService<AppSignInManager>();
                    var claimsIdentity = context.Principal.Identity as ClaimsIdentity;

                    if (claimsIdentity?.Claims?.Any() != true)
                        context.Fail("This token has no claims.");

                    var securityStamp = claimsIdentity.FindFirstValue(new ClaimsIdentityOptions().SecurityStampClaimType);
                    if (!securityStamp.HasValue())
                        context.Fail("This token has no security stamp.");

                    var validatedUser = await signInManager.ValidateSecurityStampAsync(context.Principal);
                    if (validatedUser == null)
                        context.Fail("Token security stamp is not valid.");
                },

                OnChallenge = async context =>
                {
                    context.HandleResponse();
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                    var message = context.AuthenticateFailure switch
                    {
                        SecurityTokenExpiredException => "Token is expired. Please refresh.",
                        _ when context.AuthenticateFailure != null => "Token is not valid.",
                        _ => "Invalid access token. Please login."
                    };

                    await context.Response.WriteAsJsonAsync(new Response(false, ApiResultStatusCode.UnAuthorized, message));
                },

                OnForbidden = async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsJsonAsync(new Response(false, ApiResultStatusCode.Forbidden, ApiResultStatusCode.Forbidden.ToDisplay()));
                }
            };
        });

        return services;
    }



    public static async Task ApplyMigrationsAsync(this WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

        if (context is null)
            throw new Exception("Database Context Not Found");

        await context.Database.MigrateAsync();
    }
}