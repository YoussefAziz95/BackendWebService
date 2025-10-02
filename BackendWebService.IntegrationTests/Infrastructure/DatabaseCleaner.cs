using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace BackendWebService.IntegrationTests.Infrastructure;

/// <summary>
/// Implementation of database cleaner
/// </summary>
public class DatabaseCleaner : IDatabaseCleaner
{
    private readonly ApplicationDbContext _context;

    public DatabaseCleaner(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task ClearAllTablesAsync()
    {
        // Clear ChangeTracker to prevent entity tracking issues
        _context.ChangeTracker.Clear();
        
        // Clean tables in dependency order to avoid foreign key constraints
        await CleanUsersAsync();
        await CleanRolesAsync();
        await CleanCompaniesAsync();
        await CleanCategoriesAsync();
        // await CleanActionActorsAsync(); // Commented out for now
        await CleanOrganizationsAsync();
        
        // Consolidate SaveChanges - only call once at the end
        await _context.SaveChangesAsync();
        
        // Clear ChangeTracker again after cleanup
        _context.ChangeTracker.Clear();
        
        // Verify cleanup was successful
        var remainingEntities = await _context.Companies.CountAsync() + 
                               await _context.Categories.CountAsync() + 
                               await _context.Users.CountAsync() + 
                               await _context.Roles.CountAsync() + 
                               await _context.Organizations.CountAsync();
        
        if (remainingEntities > 0)
        {
            throw new InvalidOperationException($"Database cleanup failed. {remainingEntities} entities still remain.");
        }
    }

    public async Task CleanTableAsync<TEntity>() where TEntity : class
    {
        var entities = await _context.Set<TEntity>().ToListAsync();
        if (entities.Any())
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }
    }

    public async Task CleanUsersAsync()
    {
        // Clean user-related tables first
        // Note: Identity tables are not directly accessible in in-memory database
        // They are managed by the Identity framework
        await CleanTableAsync<UserRefreshToken>();
        await CleanTableAsync<User>();
    }

    public async Task CleanRolesAsync()
    {
        // Note: Identity tables are not directly accessible in in-memory database
        // They are managed by the Identity framework
        await CleanTableAsync<Role>();
    }

    public async Task CleanCompaniesAsync()
    {
        await CleanTableAsync<Company>();
    }

    public async Task CleanCategoriesAsync()
    {
        await CleanTableAsync<Category>();
    }

    public async Task CleanOrganizationsAsync()
    {
        await CleanTableAsync<Organization>();
    }

    public async Task CleanActionActorsAsync()
    {
        // Commented out for now - ActionActor table not available in current context
        // await CleanTableAsync<ActionActor>();
    }
}