using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Persistence.Data;
using Domain;
using BackendWebService.IntegrationTests.Utilities;

namespace BackendWebService.IntegrationTests.Infrastructure;

/// <summary>
/// Implementation of test data seeder
/// </summary>
public class TestDataSeeder : ITestDataSeeder
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public TestDataSeeder(ApplicationDbContext context, UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task SeedAllAsync()
    {
        await SeedOrganizationsAsync();
        await SeedRolesAsync();
        await SeedUsersAsync();
        await SeedCompaniesAsync();
        await SeedCategoriesAsync();
        // await SeedActionActorsAsync(); // Commented out for now
    }

    public async Task SeedUsersAsync()
    {
        // Clear ChangeTracker before seeding to prevent tracking issues
        _context.ChangeTracker.Clear();
        
        // Check if users already exist and handle gracefully
        var existingUsers = await _context.Users.ToListAsync();
        if (existingUsers.Any())
        {
            // Users already exist, skip creation but ensure roles are assigned
            await AssignRolesToExistingUsers();
            return;
        }

        var users = new List<User>
        {
            TestDataFactory.CreateUser(
                email: "admin@example.com",
                userName: "admin",
                firstName: "Admin",
                lastName: "User",
                organizationId: 1),
            TestDataFactory.CreateUser(
                email: "user@example.com",
                userName: "user",
                firstName: "Regular",
                lastName: "User",
                organizationId: 1),
            TestDataFactory.CreateUser(
                email: "testuser1@example.com",
                userName: "testuser1",
                firstName: "Test",
                lastName: "User1",
                organizationId: 1)
        };

        foreach (var user in users)
        {
            Console.WriteLine($"Creating user: {user.UserName} with email: {user.Email}");
            var result = await _userManager.CreateAsync(user, "TestPassword123!");
            Console.WriteLine($"User creation result for {user.UserName}: Succeeded={result.Succeeded}");
            if (!result.Succeeded)
            {
                Console.WriteLine($"Errors for {user.UserName}: {string.Join(", ", result.Errors.Select(e => $"{e.Code}: {e.Description}"))}");
                // If user already exists, continue with next user
                if (result.Errors.Any(e => e.Code == "DuplicateUserName"))
                {
                    Console.WriteLine($"User {user.UserName} already exists, skipping...");
                    continue;
                }
                throw new InvalidOperationException($"Failed to create user {user.UserName}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
            Console.WriteLine($"Successfully created user: {user.UserName}");
        }

        // Explicitly save changes after creating all users
        Console.WriteLine("Saving changes after user creation...");
        await _context.SaveChangesAsync();
        Console.WriteLine($"SaveChanges result: {await _context.Users.CountAsync()} users in database after SaveChanges");

        // Assign roles to users
        await AssignRolesToExistingUsers();
    }

    private async Task AssignRolesToExistingUsers()
    {
        var adminUser = await _userManager.FindByNameAsync("admin");
        var regularUser = await _userManager.FindByNameAsync("user");
        var testUser = await _userManager.FindByNameAsync("testuser1");

        var adminRole = await _roleManager.FindByNameAsync("Admin");
        var userRole = await _roleManager.FindByNameAsync("User");

        if (adminUser != null && adminRole != null)
        {
            var userRoles = await _userManager.GetRolesAsync(adminUser);
            if (!userRoles.Contains(adminRole.Name!))
            {
                await _userManager.AddToRoleAsync(adminUser, adminRole.Name!);
            }
        }

        if (regularUser != null && userRole != null)
        {
            var userRoles = await _userManager.GetRolesAsync(regularUser);
            if (!userRoles.Contains(userRole.Name!))
            {
                await _userManager.AddToRoleAsync(regularUser, userRole.Name!);
            }
        }

        if (testUser != null && userRole != null)
        {
            var userRoles = await _userManager.GetRolesAsync(testUser);
            if (!userRoles.Contains(userRole.Name!))
            {
                await _userManager.AddToRoleAsync(testUser, userRole.Name!);
            }
        }
    }

    public async Task SeedRolesAsync()
    {
        // Clear ChangeTracker before seeding
        _context.ChangeTracker.Clear();
        
        if (await _context.Roles.AnyAsync())
            return;

        var roles = new List<Role>
        {
            TestDataFactory.CreateRole(
                name: "Admin",
                displayName: "Administrator"),
            TestDataFactory.CreateRole(
                name: "User",
                displayName: "Standard User"),
            TestDataFactory.CreateRole(
                name: "Manager",
                displayName: "Manager")
        };

        foreach (var role in roles)
        {
            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                // If role already exists, continue with next role
                if (result.Errors.Any(e => e.Code == "DuplicateRoleName"))
                {
                    continue;
                }
                throw new InvalidOperationException($"Failed to create role {role.Name}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
    }

    public async Task SeedCompaniesAsync()
    {
        // Clear ChangeTracker before seeding
        _context.ChangeTracker.Clear();
        
        if (await _context.Companies.AnyAsync())
            return;

        var companies = new List<Company>
        {
            TestDataFactory.CreateCompany(
                companyName: "Test Company 1",
                organizationId: 1),
            TestDataFactory.CreateCompany(
                companyName: "Test Company 2",
                organizationId: 1),
            TestDataFactory.CreateCompany(
                companyName: "Test Company 3",
                organizationId: 1)
        };

        _context.Companies.AddRange(companies);
        await _context.SaveChangesAsync();
        
        // Clear ChangeTracker after seeding
        _context.ChangeTracker.Clear();
    }

    public async Task SeedCategoriesAsync()
    {
        // Clear ChangeTracker before seeding
        _context.ChangeTracker.Clear();
        
        if (await _context.Categories.AnyAsync())
            return;

        var categories = new List<Category>
        {
            TestDataFactory.CreateCategory(
                name: "Electronics",
                organizationId: 1),
            TestDataFactory.CreateCategory(
                name: "Books",
                organizationId: 1),
            TestDataFactory.CreateCategory(
                name: "Clothing",
                organizationId: 1),
            TestDataFactory.CreateCategory(
                name: "Laptops",
                organizationId: 1,
                parentId: 1), // Electronics subcategory
            TestDataFactory.CreateCategory(
                name: "Fiction",
                organizationId: 1,
                parentId: 2) // Books subcategory
        };

        _context.Categories.AddRange(categories);
        await _context.SaveChangesAsync();
        
        // Clear ChangeTracker after seeding
        _context.ChangeTracker.Clear();
    }

    public async Task SeedOrganizationsAsync()
    {
        // Clear ChangeTracker before seeding
        _context.ChangeTracker.Clear();
        
        if (await _context.Organizations.AnyAsync())
            return;

        var organizations = new List<Organization>
        {
            TestDataFactory.CreateOrganization(
                name: "Test Organization 1",
                country: "Test Country 1"),
            TestDataFactory.CreateOrganization(
                name: "Test Organization 2",
                country: "Test Country 2")
        };

        _context.Organizations.AddRange(organizations);
        await _context.SaveChangesAsync();
        
        // Clear ChangeTracker after seeding
        _context.ChangeTracker.Clear();
    }

    public async Task SeedActionActorsAsync()
    {
        // Commented out for now - ActionActor table not available in current context
        // if (await _context.ActionActor.AnyAsync())
        //     return;

        // var actionActors = new List<ActionActor>
        // {
        //     TestDataFactory.CreateActionActor(
        //         name: "System",
        //         description: "System actor"),
        //     TestDataFactory.CreateActionActor(
        //         name: "User",
        //         description: "User actor"),
        //     TestDataFactory.CreateActionActor(
        //         name: "Admin",
        //         description: "Administrator actor")
        // };

        // _context.ActionActor.AddRange(actionActors);
        // await _context.SaveChangesAsync();
    }
}