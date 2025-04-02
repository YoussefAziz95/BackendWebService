using System.Diagnostics;
using Asp.Versioning.Builder;
using Carter;
using Application.Models.Common;
using Application.ServiceConfiguration;
using Domain.Entities.User;
using Infrastructure.CrossCutting.Logging;
using Infrastructure.Identity.Identity.Dtos;
using Infrastructure.Identity.Identity.SeedDatabaseService;
using Infrastructure.Identity.Jwt;
using Infrastructure.Identity.ServiceConfiguration;
using Infrastructure.Persistence;
using Infrastructure.Persistence.ServiceConfiguration;
using SharedKernel.Extensions;
using SharedKernel.ValidationBase;
using SharedKernel.ValidationBase.Contracts;
using Web.Api.Controllers.V1.UserManagement;
using Web.Plugins.Grpc;
using WebFramework.EndpointFilters;
using WebFramework.Filters;
using WebFramework.Middlewares;
using WebFramework.ServiceConfiguration;
using WebFramework.Swagger;
using WebFramework.WebExtensions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(LoggingConfiguration.ConfigureLogger);

var configuration = builder.Configuration;

Activity.DefaultIdFormat = ActivityIdFormat.W3C;

builder.Services.Configure<IdentitySettings>(configuration.GetSection(nameof(IdentitySettings)));

var identitySettings = configuration.GetSection(nameof(IdentitySettings)).Get<IdentitySettings>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(OkResultAttribute));
    options.Filters.Add(typeof(NotFoundResultAttribute));
    options.Filters.Add(typeof(ContentResultFilterAttribute));
    options.Filters.Add(typeof(ModelStateValidationAttribute));
    options.Filters.Add(typeof(BadRequestResultFilterAttribute));

}).ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
    options.SuppressMapClientErrors = true;
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddCarter(configurator: configurator => { configurator.WithEmptyValidators();});

builder.Services.AddApplicationServices()
    .RegisterIdentityServices(identitySettings)
    .AddPersistenceServices(configuration)
    .AddWebFrameworkServices();

builder.Services.RegisterValidatorsAsServices();
builder.Services.AddExceptionHandler<ExceptionHandler>();


#region Plugin Services Configuration

builder.Services.ConfigureGrpcPluginServices();

#endregion

builder.Services.AddAutoMapper(typeof(User), typeof(JwtService), typeof(UserController));

var app = builder.Build();


await app.ApplyMigrationsAsync();
await app.SeedDefaultUsersAsync();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseExceptionHandler(_=>{});
app.UseSwaggerAndUI();

app.MapCarter();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.ConfigureGrpcPipeline();

await app.RunAsync();



