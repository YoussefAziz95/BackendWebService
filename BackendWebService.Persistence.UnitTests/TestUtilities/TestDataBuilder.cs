using Domain;
using Domain.Enums;
using Persistence.Data;

namespace BackendWebService.Persistence.UnitTests.TestUtilities;

public static class TestDataBuilder
{
    public static class Entities
    {
        public static User CreateUser(
            string? email = null, 
            string? userName = null, 
            string? firstName = null, 
            string? lastName = null,
            int? id = null)
        {
            return new User
            {
                Id = id ?? 1,
                Email = email ?? "test@example.com",
                UserName = userName ?? "testuser",
                FirstName = firstName ?? "Test",
                LastName = lastName ?? "User",
                PhoneNumber = "123-456-7890",
                EmailConfirmed = true,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                NormalizedEmail = (email ?? "test@example.com").ToUpperInvariant(),
                NormalizedUserName = (userName ?? "testuser").ToUpperInvariant(),
                CreatedDate = DateTime.UtcNow,
                CreatedBy = "Test",
                IsActive = true,
                IsDeleted = false,
                IsSystem = false
            };
        }

        public static Role CreateRole(string? name = null, string? displayName = null)
        {
            return new Role
            {
                Id = 1,
                Name = name ?? "TestRole",
                NormalizedName = (name ?? "TestRole").ToUpperInvariant(),
                DisplayName = displayName ?? "Test Role Display Name",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.UtcNow,
                CreatedBy = "Test",
                IsActive = true,
                IsDeleted = false,
                IsSystem = false
            };
        }

        public static Category CreateCategory(
            string? name = null, 
            int? organizationId = null)
        {
            return new Category
            {
                Id = 1,
                Name = name ?? "Test Category",
                OrganizationId = organizationId ?? 1,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = "Test",
                IsActive = true,
                IsDeleted = false,
                IsSystem = false
            };
        }

        public static Organization CreateOrganization(
            string? name = null, 
            string? country = null,
            string? city = null)
        {
            return new Organization
            {
                Id = 1,
                Name = name ?? "Test Organization",
                Country = country ?? "Test Country",
                City = city ?? "Test City",
                StreetAddress = "Test Street Address",
                Type = Domain.Enums.OrganizationEnum.Company,
                FaxNo = "123-456-7890",
                Phone = "098-765-4321",
                Email = "test@organization.com",
                TaxNo = "TAX123456",
                FileId = 1,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = "Test",
                IsActive = true,
                IsDeleted = false,
                IsSystem = false
            };
        }

        public static Company CreateCompany(
            string? companyName = null, 
            string? registrationNumber = null, 
            int? organizationId = null)
        {
            return new Company
            {
                Id = 1,
                CompanyName = companyName ?? "Test Company",
                RegistrationNumber = registrationNumber ?? "REG123456",
                OrganizationId = organizationId ?? 1,
                ContactEmail = "company@test.com",
                ContactPhone = "123-456-7890",
                Status = Domain.Enums.StatusEnum.Active,
                Chairman = "Test Chairman",
                QualityCertificates = "ISO9001",
                ViceChairman = "Test Vice Chairman",
                ProductType = "Test Products",
                CreatedDate = DateTime.UtcNow,
                CreatedBy = "Test",
                IsActive = true,
                IsDeleted = false,
                IsSystem = false
            };
        }

        public static Supplier CreateSupplier(
            string? bankAccount = null, 
            decimal? rating = null, 
            int? organizationId = null)
        {
            return new Supplier
            {
                Id = 1,
                BankAccount = bankAccount ?? "BANK123456789",
                Rating = rating ?? 4.5m,
                OrganizationId = organizationId ?? 1,
                Status = Domain.Enums.StatusEnum.Active,
                SupplierCategories = new List<SupplierCategory>(),
                CreatedDate = DateTime.UtcNow,
                CreatedBy = "Test",
                IsActive = true,
                IsDeleted = false,
                IsSystem = false
            };
        }

        public static Logging CreateLogging(
            string? message = null, 
            LogTypeEnum? logType = null, 
            int? userId = null)
        {
            return new Logging
            {
                Id = 1,
                UserId = userId ?? 1,
                Message = message ?? "Test log message",
                Suggestion = null,
                LogType = logType ?? LogTypeEnum.Info,
                Timestamp = DateTime.UtcNow,
                SourceLayer = "Test",
                SourceClass = "TestClass",
                SourceLineNumber = 0,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = "Test",
                IsActive = true,
                IsDeleted = false,
                IsSystem = false
            };
        }

        public static UserRefreshToken CreateUserRefreshToken(
            int? userId = null, 
            DateTime? createdAt = null)
        {
            return new UserRefreshToken
            {
                Id = Guid.NewGuid(),
                UserId = userId ?? 1,
                CreatedAt = createdAt ?? DateTime.UtcNow,
                IsValid = true,
                OrganizationId = 1,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = "Test",
                IsActive = true,
                IsDeleted = false,
                IsSystem = false
            };
        }
    }

    public static class Collections
    {
        public static List<User> CreateUsers(int count = 3)
        {
            var users = new List<User>();
            for (int i = 1; i <= count; i++)
            {
                users.Add(Entities.CreateUser(
                    $"user{i}@example.com", 
                    $"user{i}", 
                    $"User{i}", 
                    $"LastName{i}",
                    i));
            }
            return users;
        }

        public static List<Role> CreateRoles(int count = 3)
        {
            var roles = new List<Role>();
            for (int i = 1; i <= count; i++)
            {
                var role = Entities.CreateRole($"Role{i}", $"Role {i} Display Name");
                role.Id = i;
                roles.Add(role);
            }
            return roles;
        }

        public static List<Category> CreateCategories(int count = 3, int? organizationId = null)
        {
            var categories = new List<Category>();
            for (int i = 1; i <= count; i++)
            {
                var category = Entities.CreateCategory(
                    $"Category{i}", 
                    organizationId);
                category.Id = i;
                categories.Add(category);
            }
            return categories;
        }
    }
}
