using Persistence.Data;

namespace BackendWebService.IntegrationTests.Infrastructure;

/// <summary>
/// Interface for seeding test data
/// </summary>
public interface ITestDataSeeder
{
    /// <summary>
    /// Seeds all test data
    /// </summary>
    Task SeedAllAsync();

    /// <summary>
    /// Seeds users
    /// </summary>
    Task SeedUsersAsync();

    /// <summary>
    /// Seeds roles
    /// </summary>
    Task SeedRolesAsync();

    /// <summary>
    /// Seeds companies
    /// </summary>
    Task SeedCompaniesAsync();

    /// <summary>
    /// Seeds categories
    /// </summary>
    Task SeedCategoriesAsync();

    /// <summary>
    /// Seeds organizations
    /// </summary>
    Task SeedOrganizationsAsync();

    /// <summary>
    /// Seeds action actors
    /// </summary>
    Task SeedActionActorsAsync();
}