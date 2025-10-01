using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Domain;

namespace BackendWebService.Persistence.UnitTests.TestUtilities;

public class DatabaseTestHelper : IDisposable
{
    public ApplicationDbContext Context { get; }
    private readonly string _databaseName;

    public DatabaseTestHelper(string? databaseName = null)
    {
        _databaseName = databaseName ?? Guid.NewGuid().ToString();
        Context = DbContextMocks.CreateInMemoryDbContext(_databaseName);
    }

    /// <summary>
    /// Seeds the database with test data
    /// </summary>
    public async Task SeedTestDataAsync()
    {
        // Add test users
        var users = TestDataBuilder.Collections.CreateUsers(3);
        Context.Users.AddRange(users);

        // Add test roles
        var roles = TestDataBuilder.Collections.CreateRoles(3);
        Context.Roles.AddRange(roles);

        // Add test organization
        var organization = TestDataBuilder.Entities.CreateOrganization();
        Context.Organizations.Add(organization);

        // Add test categories
        var categories = TestDataBuilder.Collections.CreateCategories(3, organization.Id);
        Context.Categories.AddRange(categories);

        // Add test companies
        var company = TestDataBuilder.Entities.CreateCompany(organizationId: organization.Id);
        Context.Companies.Add(company);

        // Add test suppliers
        var supplier = TestDataBuilder.Entities.CreateSupplier(organizationId: organization.Id);
        Context.Suppliers.Add(supplier);

        // Note: Logging entries are automatically created by ApplicationDbContext
        // when SaveChanges is called, so we don't need to add them manually

        await Context.SaveChangesAsync();
    }

    /// <summary>
    /// Seeds the database with specific entities
    /// </summary>
    public async Task SeedEntitiesAsync<T>(IEnumerable<T> entities) where T : class
    {
        Context.Set<T>().AddRange(entities);
        await Context.SaveChangesAsync();
    }

    /// <summary>
    /// Seeds the database with a single entity
    /// </summary>
    public async Task SeedEntityAsync<T>(T entity) where T : class
    {
        Context.Set<T>().Add(entity);
        await Context.SaveChangesAsync();
    }

    /// <summary>
    /// Clears all data from the database
    /// </summary>
    public async Task ClearDatabaseAsync()
    {
        // Delete in order to respect foreign key constraints
        // Delete dependent entities first
        Context.UserRefreshTokens.RemoveRange(Context.UserRefreshTokens);
        Context.Companies.RemoveRange(Context.Companies);
        Context.Suppliers.RemoveRange(Context.Suppliers);
        Context.Categories.RemoveRange(Context.Categories);
        Context.Loggings.RemoveRange(Context.Loggings);
        
        // Delete independent entities
        Context.Users.RemoveRange(Context.Users);
        Context.Roles.RemoveRange(Context.Roles);
        Context.Organizations.RemoveRange(Context.Organizations);
        
        await Context.SaveChangesAsync();
    }

    /// <summary>
    /// Gets the count of entities in a specific DbSet
    /// </summary>
    public int GetEntityCount<T>() where T : class
    {
        return Context.Set<T>().Count();
    }

    /// <summary>
    /// Gets all entities of a specific type
    /// </summary>
    public IQueryable<T> GetEntities<T>() where T : class
    {
        return Context.Set<T>();
    }

    /// <summary>
    /// Verifies that an entity exists in the database
    /// </summary>
    public bool EntityExists<T>(Func<T, bool> predicate) where T : class
    {
        return Context.Set<T>().Any(predicate);
    }

    /// <summary>
    /// Gets the first entity matching the predicate
    /// </summary>
    public T? GetEntity<T>(Func<T, bool> predicate) where T : class
    {
        return Context.Set<T>().FirstOrDefault(predicate);
    }

    public void Dispose()
    {
        Context?.Dispose();
    }
}
