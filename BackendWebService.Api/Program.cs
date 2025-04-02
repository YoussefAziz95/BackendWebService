using Application;
using Application.Contracts.HubServices;
using Application.Contracts.Proxy;
using Application.DTOs.Notification;
using Application.Middlewares;
using Application.Model.Jwt;
using CrossCuttingConcerns;
using CrossCuttingConcerns.ConfigHub;

using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Persistence;
using Persistence.Data;
using Presentation;
using Presentation.HubServices;
using Presentation.Proxy;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Rest App", Version = "v1" });
    option.AddSecurityDefinition("token", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        In = ParameterLocation.Header,
        Name = HeaderNames.Authorization,
        Scheme = "Bearer"
    });

    option.OperationFilter<SecureEndpointAuthRequirementFilter>();
});

builder.Services.AddApplicationServices()
                .AddInfrastructureServices()
                .AddPresistenceServices()
                .AddCrossCuttingConcernsServices();
builder.Services.AddSignalR();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));
builder.Services.AddIdentity<User, Role>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(o =>
    {
        o.RequireHttpsMetadata = false;
        o.SaveToken = false;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["JwtOptions:Issuer"],
            ValidAudience = builder.Configuration["JwtOptions:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtOptions:Key"]!)),
            ClockSkew = TimeSpan.Zero
        };
        //// Configure the Authority to the expected value for
        //// the authentication provider. This ensures the token
        //// is appropriately validated.
        //o.Authority = "Authority URL"; // TODO: Update URL

        // We have to hook the OnMessageReceived event in order to
        // allow the JWT authentication handler to read the access
        // token from the query string when a WebSocket or 
        // Server-Sent Events request comes in.
        o.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];

                // If the request is for our hub...
                var path = context.HttpContext.Request.Path;
                if (!string.IsNullOrEmpty(accessToken) &&
                    (path.StartsWithSegments("/NotificationHub")))
                {
                    // Read the token out of the query string
                    context.Token = accessToken;
                }
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("_AllowAnyOriginPolicy",
        builder =>
        {
            builder.WithOrigins().WithOrigins("http://localhost:4200");
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
            builder.AllowCredentials();
            builder.SetIsOriginAllowed((hosts) => true);
        });

});

builder.Services.AddSignalR();

builder.Services.AddTransient<INotificationService, NotificationService>();
builder.Services.AddTransient<INotificationProxy<NotificationHubResponse>, NotificationProxy>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".YourApp.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

app.UseStaticFiles();


//Seeding
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var userManager = services.GetRequiredService<UserManager<User>>();
        var dbcontext = services.GetRequiredService<ApplicationDbContext>();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSession();

app.UseHttpsRedirection();

app.UseCors("_AllowAnyOriginPolicy");

app.UseAuthentication();

app.UseOtpVerificationMiddleware();

app.UseRouting();



app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    try
    {
        var x = endpoints.MapHub<NotificationHub>("/NotificationHub");
        endpoints.MapControllers();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
});


app.Run();
