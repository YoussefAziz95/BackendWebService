using Api;
using Api.Profiles;
using Application.AppManager;
using Application.Middleware;
using Application.Model.Jwt;
using Application.ServiceConfiguration;
using CrossCuttingConcerns;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using nfrastructure.Persistence.ServiceConfiguration;
using Persistence.Data;
using System.Diagnostics;
var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

Activity.DefaultIdFormat = ActivityIdFormat.W3C;

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var identitySettings = configuration.GetSection(nameof(IdentitySettings)).Get<IdentitySettings>();

// Add services to the container.
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
    options.SuppressMapClientErrors = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Rest App API", Version = "v1" });
    options.SwaggerDoc("v2", new OpenApiInfo { Title = "Rest App API", Version = "v2" });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });

    options.OperationFilter<SecureEndpointAuthRequirementFilter>();
});

builder.Services.AddApplicationServices()
                .AddPersistenceServices(configuration)
                .AddCrossCuttingConcernsServices()
                .ConfigureGrpcPluginServices(); 
builder.Services.AddSignalR();

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

builder.Services.AddSignalR(options => // activate SignalR
{
    options.EnableDetailedErrors = true; // Send detailed errors to the frontend for debugging. Remove this when deploying.
});

builder.Services.AddAutoMapper(typeof(RegisterMapper).Assembly);

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".YourApp.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();

// Apply migrations at startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate(); // Applies pending migrations
}

app.UseStaticFiles();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var roleManager = services.GetRequiredService<AppRoleManager>();
        var userManager = services.GetRequiredService<AppUserManager>();
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
    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint(
                $"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }

        options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
    });
}

app.UseSession();

app.UseHttpsRedirection();

app.UseCors("_AllowAnyOriginPolicy");

app.UseAuthentication();

app.UseRouting();



app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

//app.UseEndpoints(endpoints =>
//{
//    try
//    {
//        var x = endpoints.MapHub<NotificationHub>("/NotificationHub");
//        endpoints.MapControllers();
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex);
//    }
//});


app.Run();
