using Persistence.Data;

namespace BackendWebService.IntegrationTests.Infrastructure;

/// <summary>
/// Interface for cleaning test database
/// </summary>
public interface IDatabaseCleaner
{
    /// <summary>
    /// Cleans all data from the database
    /// </summary>
    Task ClearAllTablesAsync();

    /// <summary>
    /// Cleans specific table
    /// </summary>
    Task CleanTableAsync<TEntity>() where TEntity : class;

    /// <summary>
    /// Cleans users table
    /// </summary>
    Task CleanUsersAsync();

    /// <summary>
    /// Cleans roles table
    /// </summary>
    Task CleanRolesAsync();

    /// <summary>
    /// Cleans companies table
    /// </summary>
    Task CleanCompaniesAsync();

    /// <summary>
    /// Cleans categories table
    /// </summary>
    Task CleanCategoriesAsync();

    /// <summary>
    /// Cleans organizations table
    /// </summary>
    Task CleanOrganizationsAsync();

    /// <summary>
    /// Cleans action actors table
    /// </summary>
    Task CleanActionActorsAsync();
}
