using Application.Model.Notifications;
using SharedKernel.Extensions;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;
using Domain;

namespace Persistence.Data;

public class ApplicationDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public UserInfo userInfo { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<SupplierAccount> SupplierAccounts { get; set; }
    public DbSet<PreDocument> PreDocuments { get; set; }
    public DbSet<SupplierCategory> SupplierCategories { get; set; }
    public DbSet<SupplierDocument> SupplierDocuments { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<FileType> FileTypes { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Logging> Loggings { get; set; }
    public DbSet<WAction> WActions { get; internal set; }
    public DbSet<UserRefreshToken> UserRefreshTokens { get; internal set; }
    public DbSet<FileLog> FileLogs { get; internal set; }
    public override async ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
    {
        var baseEntity = entity as BaseEntity;
        if (baseEntity != null)
        {
            if (baseEntity.OrganizationId == null && userInfo is not null)
            {
                baseEntity.OrganizationId = userInfo.OrganizationId;
                entity = baseEntity as TEntity;
            }
        }

        // Call the base AddAsync method
        var result = await base.AddAsync(entity, cancellationToken);

        // Custom behavior after calling the base implementation
        Console.WriteLine("Custom logic after adding an entity asynchronously.");

        return result;
    }

    public override EntityEntry<TEntity> Add<TEntity>(TEntity entity)
    {
        var baseEntity = entity as BaseEntity;
        if (baseEntity != null)
        {
            if (baseEntity.OrganizationId == null && userInfo is not null)
            {
                baseEntity.OrganizationId = userInfo is null ? 0 : userInfo.OrganizationId;
                entity = baseEntity as TEntity;
            }

        }

        // Call the base method if needed
        var result = base.Add(entity);

        // Custom behavior after calling the base implementation
        Console.WriteLine("Custom logic after adding an entity.");

        return result;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var entitiesAssembly = typeof(IEntity).Assembly;
        modelBuilder.RegisterAllEntities<IEntity>(entitiesAssembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    private void _cleanString()
    {
        var changedEntities = ChangeTracker.Entries()
            .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
        foreach (var item in changedEntities)
        {
            if (item.Entity == null)
                continue;

            var properties = item.Entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));

            foreach (var property in properties)
            {
                var propName = property.Name;
                var val = (string)property.GetValue(item.Entity, null);

                if (val.HasValue())
                {
                    var newVal = val.Fa2En().FixPersianChars();
                    if (newVal == val)
                        continue;
                    property.SetValue(item.Entity, newVal, null);
                }
            }
        }
    }

    public override int SaveChanges()
    {
        commonActionsBeforeSave(userInfo is not null ? userInfo.Username : "System");
        var result = base.SaveChanges();
        LogEntityChanges();
        return result;
    }

    private void LogEntityChanges()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);

        foreach (var entry in entries.ToList())
        {
            var entityName = entry.Entity.GetType().Name;
            if (entityName == nameof(Logging) || entityName == nameof(ExceptionLog))
            {
                continue;
            }
            var entityId = entry.Entity.GetType().GetProperty("Id")?.GetValue(entry.Entity);

            string logMessage = entry.State switch
            {
                EntityState.Added => $"Added {entityName} with Id {entityId}",
                EntityState.Modified => $"Updated {entityName} with Id {entityId}",
                EntityState.Deleted => $"Deleted {entityName} with Id {entityId}",
                _ => null
            };

            if (logMessage != null)
            {
                var log = new Logging
                {
                    UserId = 0,
                    Message = logMessage,
                    Suggestion = null,
                    LogType = "EntityAction",
                    Timestamp = DateTime.UtcNow,
                    SourceLayer = entry.Entity.GetType().Namespace?? "",
                    SourceClass = entry.Entity.GetType().Name,
                    SourceLineNumber = 0
                };
                if (userInfo is not null)
                    log.UserId = userInfo.UserId;


                this.Loggings.Add(log);
            }
        }
    }
    private void log( string logMessage)
    {
        var log = new Logging
        {
            UserId = 0,
            Message = logMessage,
            Suggestion = null,
            LogType = "EntityAction",
            Timestamp = DateTime.UtcNow,
            SourceLayer = "Persistence.Data",
            SourceClass = "ApplicationDbContext",
            SourceLineNumber = 0
        };
        if (userInfo is not null)
            log.UserId = userInfo.UserId;
    }
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        LogEntityChanges();
        commonActionsBeforeSave(userInfo is not null ? userInfo.Username : "System");
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void commonActionsBeforeSave(string userId)
    {
        this.ChangeTracker.DetectChanges();
        var added = this.ChangeTracker.Entries()
                    .Where(t => t.State == EntityState.Added)
                    .Select(t => t.Entity)
                    .ToArray();

        foreach (var entity in added)
        {
            setAddedValue(entity, userId);
        }

        var modified = this.ChangeTracker.Entries()
                    .Where(t => t.State == EntityState.Modified)
                    .Select(t => t.Entity)
                    .ToArray();

        foreach (var entity in modified)
        {
            setUpdatedValue(entity, userId);
        }
    }

    private void setDeletedValue(object entity, string userId)
    {
        PropertyInfo PropertyInfos = entity.GetType().GetProperty("DeletedBy")!;
        PropertyInfos.SetValue(entity, userId);
    }

    private void setUpdatedValue(object entity, string userId)
    {
        PropertyInfo[] PropertyInfos = entity.GetType().GetProperties();
        foreach (PropertyInfo pInfo in PropertyInfos)
        {
            try
            {
                if (pInfo.Name == "UpdateDate" && pInfo.CanWrite) pInfo.SetValue(entity, DateTime.UtcNow);
                if (pInfo.Name == "UpdatedBy" && pInfo.CanWrite) pInfo.SetValue(entity, userId);
                else if (pInfo.Name == "IsDeleted" && (pInfo.GetValue(entity)?.Equals(true)??false) && pInfo.CanWrite)
                    setDeletedValue(entity, userId);
            }
            catch (Exception e)
            {
                log($"Error setting {pInfo.Name} value: {e.Message}");
            }            
        }
    }

    private void setAddedValue(object entity, string userId)
    {
        PropertyInfo[] PropertyInfos = entity.GetType().GetProperties();
        foreach (PropertyInfo pInfo in PropertyInfos)
        {
            if (pInfo.Name == "CreatedDate" && pInfo.CanWrite) pInfo.SetValue(entity, DateTime.UtcNow);
            else if (pInfo.Name == "CreatedBy" && pInfo.CanWrite) pInfo.SetValue(entity, userId);
            else if (pInfo.Name == "IsActive" && pInfo.CanWrite) pInfo.SetValue(entity, true);
            else if (pInfo.Name == "IsDeleted" && pInfo.CanWrite) pInfo.SetValue(entity, false);
            else if (pInfo.Name == "IsSystem" && pInfo.CanWrite) setIsSystem(entity, userId);
        }
    }

    private void setIsSystem(object entity, string userId)
    {
        bool isSystem = userId == "System";

        PropertyInfo PropertyInfos = entity.GetType().GetProperty("IsSystem")!;
        PropertyInfos.SetValue(entity, isSystem);
    }
}
