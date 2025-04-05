using Application.Middleware;
using Application.Model.Jwt;
using Api;
using BackendWebServiceApplication.ServiceConfiguration;
using BackendWebServiceInfrastructure.Persistence.ServiceConfiguration;
using CrossCuttingConcerns;
using CrossCuttingConcerns.ConfigHubs;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Persistence.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

Activity.DefaultIdFormat = ActivityIdFormat.W3C;

builder.Services.Configure<IdentitySettings>(configuration.GetSection(nameof(IdentitySettings)));

var identitySettings = configuration.GetSection(nameof(IdentitySettings)).Get<IdentitySettings>();

// Add services to the container.
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
    options.SuppressMapClientErrors = true;
});

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
                .AddPersistenceServices(configuration, identitySettings)
                .AddCrossCuttingConcernsServices();
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
