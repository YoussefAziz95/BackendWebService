using FluentAssertions;
using Domain;
using Domain.Enums;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class LinqAndQueryTests
{
    #region Collection Query Tests

    [Fact]
    public void User_UserRoles_WhereQuery_ShouldWork()
    {
        // Arrange
        var user = new User
        {
            Id = 1,
            UserName = "testuser",
            UserRoles = new List<UserRole>
            {
                new UserRole { UserId = 1, RoleId = 1 },
                new UserRole { UserId = 1, RoleId = 2 },
                new UserRole { UserId = 2, RoleId = 1 }
            }
        };

        // Act
        var userRoles = user.UserRoles?.Where(ur => ur.UserId == 1).ToList();

        // Assert
        userRoles.Should().NotBeNull();
        userRoles!.Should().HaveCount(2);
        userRoles.Should().AllSatisfy(ur => ur.UserId.Should().Be(1));
    }

    [Fact]
    public void Organization_Addresses_SelectQuery_ShouldWork()
    {
        // Arrange
        var organization = new Organization
        {
            Id = 1,
            Name = "Test Organization",
            Addresses = new List<Address>
            {
                new Address { Id = 1, Street = "123 Main St", City = "New York" },
                new Address { Id = 2, Street = "456 Oak Ave", City = "Los Angeles" },
                new Address { Id = 3, Street = "789 Pine Rd", City = "Chicago" }
            }
        };

        // Act
        var cities = organization.Addresses?.Select(a => a.City).ToList();

        // Assert
        cities.Should().NotBeNull();
        cities!.Should().HaveCount(3);
        cities.Should().Contain("New York");
        cities.Should().Contain("Los Angeles");
        cities.Should().Contain("Chicago");
    }

    [Fact]
    public void Department_SubDepartments_AnyQuery_ShouldWork()
    {
        // Arrange
        var department = new Department
        {
            Id = 1,
            Name = "IT Department",
            SubDepartments = new List<Department>
            {
                new Department { Id = 2, Name = "Software Development" },
                new Department { Id = 3, Name = "Network Administration" }
            }
        };

        // Act
        var hasSubDepartments = department.SubDepartments?.Any() ?? false;
        var hasActiveSubDepartments = department.SubDepartments?.Any(d => d.IsActive) ?? false;

        // Assert
        hasSubDepartments.Should().BeTrue();
        hasActiveSubDepartments.Should().BeTrue();
    }

    [Fact]
    public void User_UserRoles_CountQuery_ShouldWork()
    {
        // Arrange
        var user = new User
        {
            Id = 1,
            UserName = "testuser",
            UserRoles = new List<UserRole>
            {
                new UserRole { UserId = 1, RoleId = 1 },
                new UserRole { UserId = 1, RoleId = 2 },
                new UserRole { UserId = 1, RoleId = 3 }
            }
        };

        // Act
        var roleCount = user.UserRoles?.Count ?? 0;
        var activeRoleCount = user.UserRoles?.Count(ur => ur.UserId == 1) ?? 0;

        // Assert
        roleCount.Should().Be(3);
        activeRoleCount.Should().Be(3);
    }

    #endregion

    #region Filtering Tests

    [Fact]
    public void User_UserRoles_FilterByRoleId_ShouldWork()
    {
        // Arrange
        var user = new User
        {
            Id = 1,
            UserName = "testuser",
            UserRoles = new List<UserRole>
            {
                new UserRole { UserId = 1, RoleId = 1 },
                new UserRole { UserId = 1, RoleId = 2 },
                new UserRole { UserId = 1, RoleId = 3 }
            }
        };

        // Act
        var specificRole = user.UserRoles?.FirstOrDefault(ur => ur.RoleId == 2);

        // Assert
        specificRole.Should().NotBeNull();
        specificRole!.RoleId.Should().Be(2);
    }

    [Fact]
    public void Organization_Addresses_FilterByCity_ShouldWork()
    {
        // Arrange
        var organization = new Organization
        {
            Id = 1,
            Name = "Test Organization",
            Addresses = new List<Address>
            {
                new Address { Id = 1, Street = "123 Main St", City = "New York" },
                new Address { Id = 2, Street = "456 Oak Ave", City = "Los Angeles" },
                new Address { Id = 3, Street = "789 Pine Rd", City = "New York" }
            }
        };

        // Act
        var newYorkAddresses = organization.Addresses?.Where(a => a.City == "New York").ToList();

        // Assert
        newYorkAddresses.Should().NotBeNull();
        newYorkAddresses!.Should().HaveCount(2);
        newYorkAddresses.Should().AllSatisfy(a => a.City.Should().Be("New York"));
    }

    #endregion

    #region Sorting Tests

    [Fact]
    public void User_UserRoles_OrderByRoleId_ShouldWork()
    {
        // Arrange
        var user = new User
        {
            Id = 1,
            UserName = "testuser",
            UserRoles = new List<UserRole>
            {
                new UserRole { UserId = 1, RoleId = 3 },
                new UserRole { UserId = 1, RoleId = 1 },
                new UserRole { UserId = 1, RoleId = 2 }
            }
        };

        // Act
        var sortedRoles = user.UserRoles?.OrderBy(ur => ur.RoleId).ToList();

        // Assert
        sortedRoles.Should().NotBeNull();
        sortedRoles!.Should().HaveCount(3);
        sortedRoles![0].RoleId.Should().Be(1);
        sortedRoles![1].RoleId.Should().Be(2);
        sortedRoles![2].RoleId.Should().Be(3);
    }

    [Fact]
    public void Organization_Addresses_OrderByCity_ShouldWork()
    {
        // Arrange
        var organization = new Organization
        {
            Id = 1,
            Name = "Test Organization",
            Addresses = new List<Address>
            {
                new Address { Id = 1, Street = "123 Main St", City = "Chicago" },
                new Address { Id = 2, Street = "456 Oak Ave", City = "New York" },
                new Address { Id = 3, Street = "789 Pine Rd", City = "Los Angeles" }
            }
        };

        // Act
        var sortedAddresses = organization.Addresses?.OrderBy(a => a.City).ToList();

        // Assert
        sortedAddresses.Should().NotBeNull();
        sortedAddresses!.Should().HaveCount(3);
        sortedAddresses![0].City.Should().Be("Chicago");
        sortedAddresses![1].City.Should().Be("Los Angeles");
        sortedAddresses![2].City.Should().Be("New York");
    }

    #endregion

    #region Grouping Tests

    [Fact]
    public void User_UserRoles_GroupByUserId_ShouldWork()
    {
        // Arrange
        var userRoles = new List<UserRole>
        {
            new UserRole { UserId = 1, RoleId = 1 },
            new UserRole { UserId = 1, RoleId = 2 },
            new UserRole { UserId = 2, RoleId = 1 },
            new UserRole { UserId = 2, RoleId = 3 }
        };

        // Act
        var groupedRoles = userRoles.GroupBy(ur => ur.UserId).ToList();

        // Assert
        groupedRoles.Should().HaveCount(2);
        groupedRoles.Should().Contain(g => g.Key == 1 && g.Count() == 2);
        groupedRoles.Should().Contain(g => g.Key == 2 && g.Count() == 2);
    }

    [Fact]
    public void Organization_Addresses_GroupByCity_ShouldWork()
    {
        // Arrange
        var addresses = new List<Address>
        {
            new Address { Id = 1, Street = "123 Main St", City = "New York" },
            new Address { Id = 2, Street = "456 Oak Ave", City = "Los Angeles" },
            new Address { Id = 3, Street = "789 Pine Rd", City = "New York" },
            new Address { Id = 4, Street = "321 Elm St", City = "Los Angeles" }
        };

        // Act
        var groupedAddresses = addresses.GroupBy(a => a.City).ToList();

        // Assert
        groupedAddresses.Should().HaveCount(2);
        groupedAddresses.Should().Contain(g => g.Key == "New York" && g.Count() == 2);
        groupedAddresses.Should().Contain(g => g.Key == "Los Angeles" && g.Count() == 2);
    }

    #endregion

    #region Aggregation Tests

    [Fact]
    public void User_UserRoles_SumQuery_ShouldWork()
    {
        // Arrange
        var user = new User
        {
            Id = 1,
            UserName = "testuser",
            UserRoles = new List<UserRole>
            {
                new UserRole { UserId = 1, RoleId = 1 },
                new UserRole { UserId = 1, RoleId = 2 },
                new UserRole { UserId = 1, RoleId = 3 }
            }
        };

        // Act
        var totalRoleIds = user.UserRoles?.Sum(ur => ur.RoleId) ?? 0;

        // Assert
        totalRoleIds.Should().Be(6);
    }

    [Fact]
    public void Organization_Addresses_AverageQuery_ShouldWork()
    {
        // Arrange
        var organization = new Organization
        {
            Id = 1,
            Name = "Test Organization",
            Addresses = new List<Address>
            {
                new Address { Id = 1, Street = "123 Main St", City = "New York" },
                new Address { Id = 2, Street = "456 Oak Ave", City = "Los Angeles" },
                new Address { Id = 3, Street = "789 Pine Rd", City = "Chicago" }
            }
        };

        // Act
        var averageId = organization.Addresses?.Average(a => a.Id) ?? 0;

        // Assert
        averageId.Should().Be(2);
    }

    [Fact]
    public void User_UserRoles_MaxMinQuery_ShouldWork()
    {
        // Arrange
        var user = new User
        {
            Id = 1,
            UserName = "testuser",
            UserRoles = new List<UserRole>
            {
                new UserRole { UserId = 1, RoleId = 1 },
                new UserRole { UserId = 1, RoleId = 5 },
                new UserRole { UserId = 1, RoleId = 3 }
            }
        };

        // Act
        var maxRoleId = user.UserRoles?.Max(ur => ur.RoleId) ?? 0;
        var minRoleId = user.UserRoles?.Min(ur => ur.RoleId) ?? 0;

        // Assert
        maxRoleId.Should().Be(5);
        minRoleId.Should().Be(1);
    }

    #endregion

    #region Complex Query Tests

    [Fact]
    public void User_ComplexQuery_ShouldWork()
    {
        // Arrange
        var users = new List<User>
        {
            new User { Id = 1, UserName = "user1", Email = "user1@example.com", IsActive = true },
            new User { Id = 2, UserName = "user2", Email = "user2@example.com", IsActive = false },
            new User { Id = 3, UserName = "user3", Email = "user3@example.com", IsActive = true }
        };

        // Act
        var activeUsers = users
            .Where(u => u.IsActive == true)
            .Where(u => u.Email != null)
            .OrderBy(u => u.UserName)
            .Select(u => new { u.Id, u.UserName, u.Email })
            .ToList();

        // Assert
        activeUsers.Should().HaveCount(2);
        activeUsers[0].UserName.Should().Be("user1");
        activeUsers[1].UserName.Should().Be("user3");
    }

    [Fact]
    public void Organization_ComplexQuery_ShouldWork()
    {
        // Arrange
        var organizations = new List<Organization>
        {
            new Organization { Id = 1, Name = "Org1", Type = OrganizationEnum.Company, IsActive = true },
            new Organization { Id = 2, Name = "Org2", Type = OrganizationEnum.Supplier, IsActive = false },
            new Organization { Id = 3, Name = "Org3", Type = OrganizationEnum.Company, IsActive = true }
        };

        // Act
        var activeCompanies = organizations
            .Where(o => o.IsActive == true)
            .Where(o => o.Type == OrganizationEnum.Company)
            .OrderBy(o => o.Name)
            .Select(o => new { o.Id, o.Name, o.Type })
            .ToList();

        // Assert
        activeCompanies.Should().HaveCount(2);
        activeCompanies[0].Name.Should().Be("Org1");
        activeCompanies[1].Name.Should().Be("Org3");
    }

    #endregion

    #region Null Handling Tests

    [Fact]
    public void User_UserRoles_NullHandling_ShouldWork()
    {
        // Arrange
        var user = new User
        {
            Id = 1,
            UserName = "testuser",
            UserRoles = null!
        };

        // Act
        var roleCount = user.UserRoles?.Count ?? 0;
        var hasRoles = user.UserRoles?.Any() ?? false;

        // Assert
        roleCount.Should().Be(0);
        hasRoles.Should().BeFalse();
    }

    [Fact]
    public void Organization_Addresses_NullHandling_ShouldWork()
    {
        // Arrange
        var organization = new Organization
        {
            Id = 1,
            Name = "Test Organization",
            Addresses = null
        };

        // Act
        var addressCount = organization.Addresses?.Count ?? 0;
        var hasAddresses = organization.Addresses?.Any() ?? false;

        // Assert
        addressCount.Should().Be(0);
        hasAddresses.Should().BeFalse();
    }

    #endregion

    #region Performance Tests

    [Fact]
    public void Linq_Performance_WithLargeCollection_ShouldBeReasonable()
    {
        // Arrange
        var users = Enumerable.Range(1, 10000)
            .Select(i => new User
            {
                Id = i,
                UserName = $"user{i}",
                Email = $"user{i}@example.com",
                IsActive = i % 2 == 0
            })
            .ToList();

        // Act
        var startTime = DateTime.UtcNow;
        var activeUsers = users
            .Where(u => u.IsActive == true)
            .OrderBy(u => u.UserName)
            .Take(100)
            .ToList();
        var endTime = DateTime.UtcNow;

        // Assert
        activeUsers.Should().HaveCount(100);
        (endTime - startTime).TotalMilliseconds.Should().BeLessThan(1000);
    }

    #endregion

    #region Helper Classes

    private class TestEntity : BaseEntity
    {
    }

    #endregion
}
