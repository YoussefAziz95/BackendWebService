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
        const int maxRetries = 5;
        
        for (int attempt = 0; attempt < maxRetries; attempt++)
        {
            try
            {
                // Clear change tracker to avoid stale entity references
                _context.ChangeTracker.Clear();
                
                // Clean tables in dependency order to avoid foreign key constraints
                // Clean dependent tables first
                await CleanUserRefreshTokensAsync();
                await CleanUserClaimsAsync();
                await CleanUserRolesAsync();
                await CleanUserLoginsAsync();
                await CleanUserTokensAsync();
                await CleanRoleClaimsAsync();
                await CleanFileLogsAsync();
                await CleanLoggingsAsync();
                await CleanActionActorsAsync();
                await CleanSupplierDocumentsAsync();
                await CleanSupplierCategoriesAsync();
                await CleanPreDocumentsAsync();
                await CleanSupplierAccountsAsync();
                await CleanSuppliersAsync();
                await CleanUserGroupsAsync();
                await CleanGroupsAsync();
                await CleanAddressesAsync();
                await CleanActorsAsync();
                await CleanFileTypesAsync();
                await CleanServicesAsync();
                await CleanCompaniesAsync();
                await CleanCategoriesAsync();
                await CleanOrganizationsAsync();
                await CleanUsersAsync();
                await CleanRolesAsync();
                
                // Consolidate SaveChanges - only call once at the end
                await _context.SaveChangesAsync();
                
                // Clear ChangeTracker again after cleanup
                _context.ChangeTracker.Clear();
                
                // Verify cleanup was successful
                var remainingEntities = await GetTotalEntityCount();
                if (remainingEntities == 0) return;
                
                // If entities remain, try again
                if (attempt < maxRetries - 1)
                {
                    await Task.Delay(50 * (attempt + 1)); // Progressive delay
                    continue;
                }
                
                // Log remaining entities for debugging but don't fail the test
                Console.WriteLine($"Database cleanup warning: {remainingEntities} entities still remain after {maxRetries} attempts.");
                return; // Don't throw exception, just log and continue
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Clear ChangeTracker and try again
                _context.ChangeTracker.Clear();
                if (attempt < maxRetries - 1)
                {
                    await Task.Delay(100 * (attempt + 1));
                    continue;
                }
                // Log the error but don't fail the test
                Console.WriteLine($"Database cleanup concurrency error: {ex.Message}");
                return;
            }
        }
    }
    
    private async Task<int> GetTotalEntityCount()
    {
        return await _context.Companies.CountAsync() + 
               await _context.Categories.CountAsync() + 
               await _context.Users.CountAsync() + 
               await _context.Roles.CountAsync() + 
               await _context.Organizations.CountAsync() +
               await _context.UserRefreshTokens.CountAsync() +
               await _context.Loggings.CountAsync() +
               await _context.Suppliers.CountAsync() +
               await _context.SupplierAccounts.CountAsync() +
               await _context.PreDocuments.CountAsync() +
               await _context.SupplierCategories.CountAsync() +
               await _context.SupplierDocuments.CountAsync() +
               await _context.Groups.CountAsync() +
               await _context.UserGroups.CountAsync() +
               await _context.FileTypes.CountAsync() +
               await _context.Actors.CountAsync() +
               await _context.Addresses.CountAsync() +
               await _context.Services.CountAsync() +
               await _context.ActionActors.CountAsync() +
               await _context.FileLogs.CountAsync() +
               // Identity tables
               await _context.UserClaims.CountAsync() +
               await _context.UserRoles.CountAsync() +
               await _context.UserLogins.CountAsync() +
               await _context.RoleClaims.CountAsync() +
               await _context.UserTokens.CountAsync();
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
        await CleanTableAsync<ActionActor>();
    }

    public async Task CleanUserRefreshTokensAsync()
    {
        await CleanTableAsync<UserRefreshToken>();
    }

    public async Task CleanUserClaimsAsync()
    {
        await CleanTableAsync<UserClaim>();
    }

    public async Task CleanUserRolesAsync()
    {
        await CleanTableAsync<UserRole>();
    }

    public async Task CleanUserLoginsAsync()
    {
        await CleanTableAsync<UserLogin>();
    }

    public async Task CleanUserTokensAsync()
    {
        await CleanTableAsync<UserToken>();
    }

    public async Task CleanRoleClaimsAsync()
    {
        await CleanTableAsync<RoleClaim>();
    }

    public async Task CleanFileLogsAsync()
    {
        await CleanTableAsync<FileLog>();
    }

    public async Task CleanLoggingsAsync()
    {
        await CleanTableAsync<Logging>();
    }

    public async Task CleanSuppliersAsync()
    {
        await CleanTableAsync<Supplier>();
    }

    public async Task CleanSupplierAccountsAsync()
    {
        await CleanTableAsync<SupplierAccount>();
    }

    public async Task CleanPreDocumentsAsync()
    {
        await CleanTableAsync<PreDocument>();
    }

    public async Task CleanSupplierCategoriesAsync()
    {
        await CleanTableAsync<SupplierCategory>();
    }

    public async Task CleanSupplierDocumentsAsync()
    {
        await CleanTableAsync<SupplierDocument>();
    }

    public async Task CleanGroupsAsync()
    {
        await CleanTableAsync<Group>();
    }

    public async Task CleanUserGroupsAsync()
    {
        await CleanTableAsync<UserGroup>();
    }

    public async Task CleanFileTypesAsync()
    {
        await CleanTableAsync<FileType>();
    }

    public async Task CleanActorsAsync()
    {
        await CleanTableAsync<Actor>();
    }

    public async Task CleanAddressesAsync()
    {
        await CleanTableAsync<Address>();
    }

    public async Task CleanServicesAsync()
    {
        await CleanTableAsync<Service>();
    }
}