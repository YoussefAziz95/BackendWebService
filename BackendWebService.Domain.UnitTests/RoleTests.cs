using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class RoleTests
{
    [Fact]
    public void Role_DefaultConstructor_ShouldCreateInstance()
    {
        // Arrange & Act
        var role = new Role();

        // Assert
        role.Should().NotBeNull();
        role.OrganizationId.Should().BeNull();
        role.IsActive.Should().BeTrue();
        role.IsDeleted.Should().BeFalse();
        role.IsSystem.Should().BeNull();
        role.CreatedDate.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(5));
        role.CreatedBy.Should().BeNull();
        role.UpdatedDate.Should().BeNull();
        role.UpdatedBy.Should().BeNull();
        role.ParentId.Should().BeNull();
        role.DisplayName.Should().BeNull();
        role.Claims.Should().BeNull();
        role.Users.Should().BeNull();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MaxValue)]
    public void Role_OrganizationId_ShouldBeSettable(int? organizationId)
    {
        // Arrange
        var role = new Role();

        // Act
        role.OrganizationId = organizationId;

        // Assert
        role.OrganizationId.Should().Be(organizationId);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    [InlineData(null)]
    public void Role_IsActive_ShouldBeSettable(bool? isActive)
    {
        // Arrange
        var role = new Role();

        // Act
        role.IsActive = isActive;

        // Assert
        role.IsActive.Should().Be(isActive);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    [InlineData(null)]
    public void Role_IsDeleted_ShouldBeSettable(bool? isDeleted)
    {
        // Arrange
        var role = new Role();

        // Act
        role.IsDeleted = isDeleted;

        // Assert
        role.IsDeleted.Should().Be(isDeleted);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    [InlineData(null)]
    public void Role_IsSystem_ShouldBeSettable(bool? isSystem)
    {
        // Arrange
        var role = new Role();

        // Act
        role.IsSystem = isSystem;

        // Assert
        role.IsSystem.Should().Be(isSystem);
    }

    [Fact]
    public void Role_CreatedDate_ShouldBeSettable()
    {
        // Arrange
        var role = new Role();
        var createdDate = DateTime.UtcNow.AddDays(-1);

        // Act
        role.CreatedDate = createdDate;

        // Assert
        role.CreatedDate.Should().Be(createdDate);
    }

    [Theory]
    [InlineData("admin")]
    [InlineData("user")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("Very long created by name that might exceed normal length expectations")]
    public void Role_CreatedBy_ShouldBeSettable(string createdBy)
    {
        // Arrange
        var role = new Role();

        // Act
        role.CreatedBy = createdBy;

        // Assert
        role.CreatedBy.Should().Be(createdBy);
    }

    [Fact]
    public void Role_UpdatedDate_ShouldBeSettable()
    {
        // Arrange
        var role = new Role();
        var updatedDate = DateTime.UtcNow.AddDays(-1);

        // Act
        role.UpdatedDate = updatedDate;

        // Assert
        role.UpdatedDate.Should().Be(updatedDate);
    }

    [Theory]
    [InlineData("admin")]
    [InlineData("user")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("Very long updated by name that might exceed normal length expectations")]
    public void Role_UpdatedBy_ShouldBeSettable(string updatedBy)
    {
        // Arrange
        var role = new Role();

        // Act
        role.UpdatedBy = updatedBy;

        // Assert
        role.UpdatedBy.Should().Be(updatedBy);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MaxValue)]
    public void Role_ParentId_ShouldBeSettable(int? parentId)
    {
        // Arrange
        var role = new Role();

        // Act
        role.ParentId = parentId;

        // Assert
        role.ParentId.Should().Be(parentId);
    }

    [Theory]
    [InlineData("Admin Role")]
    [InlineData("User Role")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("Very long display name that might exceed normal length expectations")]
    public void Role_DisplayName_ShouldBeSettable(string displayName)
    {
        // Arrange
        var role = new Role();

        // Act
        role.DisplayName = displayName;

        // Assert
        role.DisplayName.Should().Be(displayName);
    }

    [Fact]
    public void Role_Claims_ShouldBeSettable()
    {
        // Arrange
        var role = new Role();
        var claim = new RoleClaim();

        // Act
        role.Claims = new List<RoleClaim> { claim };

        // Assert
        role.Claims.Should().NotBeNull();
        role.Claims.Should().Contain(claim);
    }

    [Fact]
    public void Role_Users_ShouldBeSettable()
    {
        // Arrange
        var role = new Role();
        var userRole = new UserRole();

        // Act
        role.Users = new List<UserRole> { userRole };

        // Assert
        role.Users.Should().NotBeNull();
        role.Users.Should().Contain(userRole);
    }

    [Fact]
    public void Role_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var role = new Role
        {
            Name = "TestRole",
            DisplayName = "Test Role"
        };

        // Assert
        role.Name.Should().Be("TestRole");
        role.DisplayName.Should().Be("Test Role");
        role.IsActive.Should().BeTrue();
        role.IsDeleted.Should().BeFalse();
    }

    [Fact]
    public void Role_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange & Act
        var createdDate = DateTime.UtcNow.AddDays(-1);
        var updatedDate = DateTime.UtcNow;
        var claim = new RoleClaim();
        var userRole = new UserRole();
        var role = new Role
        {
            Name = "TestRole",
            OrganizationId = 1,
            IsActive = true,
            IsDeleted = false,
            IsSystem = false,
            CreatedDate = createdDate,
            CreatedBy = "admin",
            UpdatedDate = updatedDate,
            UpdatedBy = "admin",
            ParentId = 1,
            DisplayName = "Test Role",
            Claims = new List<RoleClaim> { claim },
            Users = new List<UserRole> { userRole }
        };

        // Assert
        role.Name.Should().Be("TestRole");
        role.OrganizationId.Should().Be(1);
        role.IsActive.Should().BeTrue();
        role.IsDeleted.Should().BeFalse();
        role.IsSystem.Should().BeFalse();
        role.CreatedDate.Should().Be(createdDate);
        role.CreatedBy.Should().Be("admin");
        role.UpdatedDate.Should().Be(updatedDate);
        role.UpdatedBy.Should().Be("admin");
        role.ParentId.Should().Be(1);
        role.DisplayName.Should().Be("Test Role");
        role.Claims.Should().Contain(claim);
        role.Users.Should().Contain(userRole);
    }

    [Fact]
    public void Role_WithNullValues_ShouldBeCreatable()
    {
        // Arrange & Act
        var role = new Role
        {
            Name = "TestRole",
            OrganizationId = null,
            IsActive = null,
            IsDeleted = null,
            IsSystem = null,
            CreatedDate = null,
            CreatedBy = null,
            UpdatedDate = null,
            UpdatedBy = null,
            ParentId = null,
            DisplayName = null,
            Claims = null,
            Users = null
        };

        // Assert
        role.Name.Should().Be("TestRole");
        role.OrganizationId.Should().BeNull();
        role.IsActive.Should().BeNull();
        role.IsDeleted.Should().BeNull();
        role.IsSystem.Should().BeNull();
        role.CreatedDate.Should().BeNull();
        role.CreatedBy.Should().BeNull();
        role.UpdatedDate.Should().BeNull();
        role.UpdatedBy.Should().BeNull();
        role.ParentId.Should().BeNull();
        role.DisplayName.Should().BeNull();
        role.Claims.Should().BeNull();
        role.Users.Should().BeNull();
    }

    [Fact]
    public void Role_WithEmptyStrings_ShouldBeCreatable()
    {
        // Arrange & Act
        var role = new Role
        {
            Name = "TestRole",
            CreatedBy = "",
            UpdatedBy = "",
            DisplayName = ""
        };

        // Assert
        role.Name.Should().Be("TestRole");
        role.CreatedBy.Should().Be("");
        role.UpdatedBy.Should().Be("");
        role.DisplayName.Should().Be("");
    }

    [Fact]
    public void Role_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var role = new Role { Name = "TestRole" };

        // Act
        var result = role.ToString();

        // Assert
        result.Should().Contain("Role");
    }

    [Fact]
    public void Role_ShouldInheritFromIdentityRole()
    {
        // Arrange & Act
        var role = new Role();

        // Assert
        role.Should().BeAssignableTo<Microsoft.AspNetCore.Identity.IdentityRole<int>>();
        role.Should().BeAssignableTo<IEntity>();
        role.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void Role_AllProperties_ShouldBeSettable()
    {
        // Arrange
        var role = new Role();
        var createdDate = DateTime.UtcNow.AddDays(-1);
        var updatedDate = DateTime.UtcNow;
        var claim = new RoleClaim();
        var userRole = new UserRole();

        // Act
        role.Name = "TestRole";
        role.OrganizationId = 1;
        role.IsActive = true;
        role.IsDeleted = false;
        role.IsSystem = false;
        role.CreatedDate = createdDate;
        role.CreatedBy = "admin";
        role.UpdatedDate = updatedDate;
        role.UpdatedBy = "admin";
        role.ParentId = 1;
        role.DisplayName = "Test Role";
        role.Claims = new List<RoleClaim> { claim };
        role.Users = new List<UserRole> { userRole };

        // Assert
        role.Name.Should().Be("TestRole");
        role.OrganizationId.Should().Be(1);
        role.IsActive.Should().BeTrue();
        role.IsDeleted.Should().BeFalse();
        role.IsSystem.Should().BeFalse();
        role.CreatedDate.Should().Be(createdDate);
        role.CreatedBy.Should().Be("admin");
        role.UpdatedDate.Should().Be(updatedDate);
        role.UpdatedBy.Should().Be("admin");
        role.ParentId.Should().Be(1);
        role.DisplayName.Should().Be("Test Role");
        role.Claims.Should().Contain(claim);
        role.Users.Should().Contain(userRole);
    }
}
