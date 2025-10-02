using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Persistence.Data;
using Domain;
using Domain.Enums;
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
        Console.WriteLine("🌱 Starting data seeding...");
        
        // CRITICAL ORDER: Dependencies first!
        // 1. FileType and FileLog (no dependencies, required by Organization)
        await SeedFileTypesAndFileLogsAsync();
        Console.WriteLine("✅ Step 1: FileTypes and FileLogs seeded");
        
        // 2. Organizations (depends on FileLog)
        await SeedOrganizationsAsync();
        Console.WriteLine("✅ Step 2: Organizations seeded");
        
        // 3. Roles (no dependencies)
        await SeedRolesAsync();
        Console.WriteLine("✅ Step 3: Roles seeded");
        
        // 4. Users (depends on Organizations and Roles)
        await SeedUsersAsync();
        Console.WriteLine("✅ Step 4: Users seeded");
        
        // 5. Business entities (depend on Organizations)
        await SeedCompaniesAsync();
        await SeedCategoriesAsync();
        Console.WriteLine("✅ Step 5: Companies and Categories seeded");
        
        // await SeedActionActorsAsync(); // Commented out for now
        
        Console.WriteLine("✅ Data seeding complete!");
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
                organizationId: 1,
                phoneNumber: "123-456-7890"), // Add phone number for authentication
            TestDataFactory.CreateUser(
                email: "user@example.com",
                userName: "user",
                firstName: "Regular",
                lastName: "User",
                organizationId: 1,
                phoneNumber: "123-456-7891"), // Add phone number for authentication
            TestDataFactory.CreateUser(
                email: "testuser1@example.com",
                userName: "testuser1",
                firstName: "Test",
                lastName: "User1",
                organizationId: 1,
                phoneNumber: "123-456-7892") // Add phone number for authentication
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
        try
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
        catch (Exception ex)
        {
            Console.WriteLine($"Error assigning roles: {ex.Message}");
            // Continue without failing the test
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
        {
            Console.WriteLine("✅ Categories already exist, skipping...");
            return;
        }

        // PERMANENT FIX: Insert parent categories first to avoid FK constraint issues
        var parentCategories = new List<Category>
        {
            TestDataFactory.CreateCategory(
                name: "Electronics",
                organizationId: 1),
            TestDataFactory.CreateCategory(
                name: "Books",
                organizationId: 1),
            TestDataFactory.CreateCategory(
                name: "Clothing",
                organizationId: 1)
        };

        _context.Categories.AddRange(parentCategories);
        await _context.SaveChangesAsync();
        Console.WriteLine($"✅ Seeded {parentCategories.Count} parent categories");
        
        // Get the IDs of the parent categories
        var electronics = await _context.Categories.FirstOrDefaultAsync(c => c.Name == "Electronics");
        var books = await _context.Categories.FirstOrDefaultAsync(c => c.Name == "Books");
        
        // Now insert child categories with valid parent IDs
        var childCategories = new List<Category>
        {
            TestDataFactory.CreateCategory(
                name: "Laptops",
                organizationId: 1,
                parentId: electronics?.Id), // Electronics subcategory
            TestDataFactory.CreateCategory(
                name: "Fiction",
                organizationId: 1,
                parentId: books?.Id) // Books subcategory
        };

        _context.Categories.AddRange(childCategories);
        await _context.SaveChangesAsync();
        Console.WriteLine($"✅ Seeded {childCategories.Count} child categories");
        
        // Clear ChangeTracker after seeding
        _context.ChangeTracker.Clear();
    }

    public async Task SeedFileTypesAndFileLogsAsync()
    {
        // Clear ChangeTracker before seeding
        _context.ChangeTracker.Clear();
        
        if (await _context.FileLogs.AnyAsync())
        {
            Console.WriteLine("✅ FileLogs already exist, skipping...");
            return;
        }

        // PERMANENT FIX: Seed FileType and FileLog with explicit IDs
        // Note: FileLog.OrganizationId set to NULL initially to break circular dependency
        await _context.Database.ExecuteSqlRawAsync(@"
            SET IDENTITY_INSERT [FileType] ON;
            INSERT INTO [FileType] ([Id], [Type], [Extentions], [CreatedDate], [CreatedBy], [IsActive], [IsDeleted], [IsSystem])
            VALUES (1, 0, '.pdf,.doc,.docx', GETUTCDATE(), 'System', 1, 0, 1);
            SET IDENTITY_INSERT [FileType] OFF;
            
            SET IDENTITY_INSERT [FileLog] ON;
            INSERT INTO [FileLog] ([Id], [FileName], [FullPath], [Extention], [FileTypeId], [OrganizationId], [CreatedDate], [CreatedBy], [IsActive], [IsDeleted], [IsSystem])
            VALUES (1, 'test-file.pdf', '/test/path/test-file.pdf', '.pdf', 1, NULL, GETUTCDATE(), 'System', 1, 0, 1);
            SET IDENTITY_INSERT [FileLog] OFF;
        ");
        
        Console.WriteLine($"✅ Seeded FileType and FileLog with ID=1");
        
        // Clear ChangeTracker after seeding
        _context.ChangeTracker.Clear();
    }

    public async Task SeedOrganizationsAsync()
    {
        // Clear ChangeTracker before seeding
        _context.ChangeTracker.Clear();
        
        if (await _context.Organizations.AnyAsync())
        {
            Console.WriteLine("✅ Organizations already exist, skipping...");
            return;
        }

        // PERMANENT FIX: Use raw SQL to insert with explicit ID=1 for FK references
        await _context.Database.ExecuteSqlRawAsync(@"
            SET IDENTITY_INSERT [Organization] ON;
            
            INSERT INTO [Organization] 
                ([Id], [Name], [Country], [City], [StreetAddress], [Type], [Phone], [FaxNo], [Email], [TaxNo], [FileId], [CreatedDate], [CreatedBy], [IsActive], [IsDeleted], [IsSystem])
            VALUES 
                (1, 'Test Organization', 'USA', 'Test City', '123 Test St', 0, '123-456-7890', '123-456-7891', 'test@testorg.com', 'TAX123456', 1, GETUTCDATE(), 'System', 1, 0, 1);
            
            SET IDENTITY_INSERT [Organization] OFF;
        ");
        
        Console.WriteLine($"✅ Seeded organization with ID=1");
        
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