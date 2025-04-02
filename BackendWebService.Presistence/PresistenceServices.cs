using Application.Contracts.Presistence;
using Application.Contracts.Presistence.Identities;
using Application.Contracts.Presistence.Notifications;
using Application.Contracts.Presistence.Organization;
using Application.Contracts.Presistence.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using Persistence.Repositories;
using Persistence.Repositories.Common;
using Persistence.Repositories.FileSystem;
using Persistence.Repositories.Identity;
using Persistence.Repositories.Notifications;
using Persistence.Repositories.Organiztations;
using Persistence.Repositories.Product;

namespace Persistence
{
    public static class PresistenceServices
    {
        public static IServiceCollection AddPresistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(DbConnection.DefaultConnection);
            });
            //services.AddSingleton<IDesignTimeDbContextFactory<ApplicationDbContext>>(provider =>
            //{
            //    return new ApplicationDbContextFactory();
            //});

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISupplierDocumentRepository, SupplierDocumentRepository>();
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISP_Call, SP_Call>();
            services.AddScoped<ILoggingRepository, LoggingRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();





            return services;
        }
    }
}

