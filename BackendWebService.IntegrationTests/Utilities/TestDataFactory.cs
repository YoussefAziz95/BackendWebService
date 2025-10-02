using Domain;
using Domain.Enums;

namespace BackendWebService.IntegrationTests.Utilities;

/// <summary>
/// Factory for creating test data in integration tests
/// </summary>
public static class TestDataFactory
{
    /// <summary>
    /// Creates a test user
    /// </summary>
    public static User CreateUser(
        string? email = null,
        string? userName = null,
        string? firstName = null,
        string? lastName = null,
        int? organizationId = null,
        string? phoneNumber = null)
    {
        return new User
        {
            Id = 0, // Let EF assign the ID
            Email = email ?? "test@example.com",
            UserName = userName ?? "testuser",
            FirstName = firstName ?? "Test",
            LastName = lastName ?? "User",
            PhoneNumber = phoneNumber ?? "123-456-7890",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            TwoFactorEnabled = false,
            LockoutEnabled = true,
            AccessFailedCount = 0,
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            NormalizedEmail = (email ?? "test@example.com").ToUpperInvariant(),
            NormalizedUserName = (userName ?? "testuser").ToUpperInvariant(),
            OrganizationId = organizationId ?? 1,
            CreatedDate = DateTime.UtcNow,
            CreatedBy = "Test",
            IsActive = true,
            IsDeleted = false,
            IsSystem = false
        };
    }

    /// <summary>
    /// Creates a test role
    /// </summary>
    public static Role CreateRole(
        string? name = null,
        string? displayName = null,
        int? parentId = null)
    {
        return new Role
        {
            Id = 0, // Let EF assign the ID
            Name = name ?? "TestRole",
            NormalizedName = (name ?? "TestRole").ToUpperInvariant(),
            DisplayName = displayName ?? "Test Role",
            ParentId = parentId,
            CreatedDate = DateTime.UtcNow,
            CreatedBy = "Test",
            IsActive = true,
            IsDeleted = false,
            IsSystem = false
        };
    }

    /// <summary>
    /// Creates a test company
    /// </summary>
    public static Company CreateCompany(
        string? companyName = null,
        int? organizationId = null)
    {
        return new Company
        {
            Id = 0, // Let EF assign the ID
            CompanyName = companyName ?? "Test Company",
            OrganizationId = organizationId ?? 1,
            CreatedDate = DateTime.UtcNow,
            CreatedBy = "Test",
            IsActive = true,
            IsDeleted = false,
            IsSystem = false
        };
    }

    /// <summary>
    /// Creates a test category
    /// </summary>
    public static Category CreateCategory(
        string? name = null,
        int? organizationId = null,
        int? parentId = null)
    {
        return new Category
        {
            Id = 0, // Let EF assign the ID
            Name = name ?? "Test Category",
            OrganizationId = organizationId ?? 1,
            ParentId = parentId,
            CreatedDate = DateTime.UtcNow,
            CreatedBy = "Test",
            IsActive = true,
            IsDeleted = false,
            IsSystem = false
        };
    }

        /// <summary>
        /// Creates a test organization
        /// </summary>
        public static Organization CreateOrganization(
            string? name = null,
            string? country = null)
        {
            return new Organization
            {
                Id = 0, // Let EF assign the ID
                Name = name ?? "Test Organization",
                Country = country ?? "Test Country",
                City = "Test City",
                StreetAddress = "Test Street",
                Type = OrganizationEnum.Company,
                Phone = "123-456-7890",
                FaxNo = "123-456-7891", // Added missing FaxNo property
                Email = "test@organization.com",
                TaxNo = "123456789",
                FileId = 1,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = "Test",
                IsActive = true,
                IsDeleted = false,
                IsSystem = false
            };
        }

    /// <summary>
    /// Creates a test action actor
    /// </summary>
    public static ActionActor CreateActionActor(
        string? name = null,
        string? description = null)
    {
        return new ActionActor
        {
            Id = 0, // Let EF assign the ID
            Name = name ?? "Test Action Actor",
            Description = description ?? "Test Action Actor Description",
            CreatedDate = DateTime.UtcNow,
            CreatedBy = "Test",
            IsActive = true,
            IsDeleted = false,
            IsSystem = false
        };
    }

    /// <summary>
    /// Creates a test logging entry
    /// </summary>
    public static Logging CreateLogging(
        string? sourceClass = null,
        string? message = null)
    {
        return new Logging
        {
            Id = 0, // Let EF assign the ID
            SourceClass = sourceClass ?? "TestClass",
            Message = message ?? "Test log message",
            LogType = LogTypeEnum.Info,
            Timestamp = DateTime.UtcNow,
            SourceLayer = "TestLayer",
            SourceLineNumber = 1,
            CorrelationId = Guid.NewGuid().ToString(),
            CreatedDate = DateTime.UtcNow,
            CreatedBy = "Test",
            IsActive = true,
            IsDeleted = false,
            IsSystem = false
        };
    }

    /// <summary>
    /// Creates a test user refresh token
    /// </summary>
    public static UserRefreshToken CreateUserRefreshToken(
        int userId,
        bool isValid = true)
    {
        return new UserRefreshToken
        {
            Id = Guid.NewGuid(), // UserRefreshToken uses Guid as ID
            UserId = userId,
            IsValid = isValid,
            OrganizationId = 1,
            CreatedAt = DateTime.UtcNow,
            CreatedDate = DateTime.UtcNow,
            CreatedBy = "Test",
            IsActive = true,
            IsDeleted = false,
            IsSystem = false
        };
    }

    /// <summary>
    /// Creates multiple test users
    /// </summary>
    public static List<User> CreateUsers(int count, int? organizationId = null)
    {
        var users = new List<User>();
        for (int i = 1; i <= count; i++)
        {
            users.Add(CreateUser(
                email: $"user{i}@example.com",
                userName: $"user{i}",
                firstName: $"User{i}",
                lastName: $"LastName{i}",
                organizationId: organizationId));
        }
        return users;
    }

    /// <summary>
    /// Creates multiple test roles
    /// </summary>
    public static List<Role> CreateRoles(int count, int? parentId = null)
    {
        var roles = new List<Role>();
        for (int i = 1; i <= count; i++)
        {
            roles.Add(CreateRole(
                name: $"Role{i}",
                displayName: $"Test Role {i}",
                parentId: parentId));
        }
        return roles;
    }

    /// <summary>
    /// Creates multiple test companies
    /// </summary>
    public static List<Company> CreateCompanies(int count, int? organizationId = null)
    {
        var companies = new List<Company>();
        for (int i = 1; i <= count; i++)
        {
            companies.Add(CreateCompany(
                companyName: $"Test Company {i}",
                organizationId: organizationId));
        }
        return companies;
    }

    /// <summary>
    /// Creates multiple test categories
    /// </summary>
    public static List<Category> CreateCategories(int count, int? organizationId = null, int? parentId = null)
    {
        var categories = new List<Category>();
        for (int i = 1; i <= count; i++)
        {
            categories.Add(CreateCategory(
                name: $"Test Category {i}",
                organizationId: organizationId,
                parentId: parentId));
        }
        return categories;
    }
}
