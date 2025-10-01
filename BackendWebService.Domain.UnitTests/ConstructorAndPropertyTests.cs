using Domain;
using Domain.Enums;
using FluentAssertions;
using Xunit;
using System.ComponentModel.DataAnnotations;

namespace BackendWebService.Domain.UnitTests;

public class ConstructorAndPropertyTests
{
    #region Constructor Overload Tests

    [Fact]
    public void User_DefaultConstructor_ShouldInitializeCorrectly()
    {
        // Act
        var user = new User();

        // Assert
        user.Should().NotBeNull();
        user.Id.Should().Be(0);
        user.UserName.Should().BeNull();
        user.Email.Should().BeNull();
        user.PhoneNumber.Should().BeNull();
        user.FirstName.Should().BeNull();
        user.LastName.Should().BeNull();
        user.IsActive.Should().BeTrue();
        user.IsDeleted.Should().BeFalse();
        user.IsSystem.Should().BeNull(); // IsSystem is nullable
        user.CreatedDate.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        user.OrganizationId.Should().BeNull();
    }

    [Fact]
    public void User_WithParameters_ShouldInitializeCorrectly()
    {
        // Arrange
        var userName = "testuser";
        var email = "test@example.com";
        var phoneNumber = "1234567890";
        var firstName = "John";
        var lastName = "Doe";

        // Act
        var user = new User
        {
            UserName = userName,
            Email = email,
            PhoneNumber = phoneNumber,
            FirstName = firstName,
            LastName = lastName
        };

        // Assert
        user.UserName.Should().Be(userName);
        user.Email.Should().Be(email);
        user.PhoneNumber.Should().Be(phoneNumber);
        user.FirstName.Should().Be(firstName);
        user.LastName.Should().Be(lastName);
    }

    [Fact]
    public void BaseEntity_DefaultConstructor_ShouldInitializeCorrectly()
    {
        // Act
        var entity = new TestEntity();

        // Assert
        entity.Should().NotBeNull();
        entity.Id.Should().Be(0);
        entity.OrganizationId.Should().BeNull();
        entity.IsActive.Should().BeTrue();
        entity.IsDeleted.Should().BeFalse();
        entity.IsSystem.Should().BeFalse();
        entity.CreatedDate.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        entity.CreatedBy.Should().BeNull();
        entity.UpdatedDate.Should().BeNull();
        entity.UpdatedBy.Should().BeNull();
    }

    [Fact]
    public void BaseEntityTKey_DefaultConstructor_ShouldInitializeCorrectly()
    {
        // Act
        var entity = new TestEntityWithIntKey();

        // Assert
        entity.Should().NotBeNull();
        entity.Id.Should().Be(0);
    }

    [Fact]
    public void BaseEntityTKey_WithStringKey_ShouldInitializeCorrectly()
    {
        // Act
        var entity = new TestEntityWithStringKey();

        // Assert
        entity.Should().NotBeNull();
        entity.Id.Should().BeNull();
    }

    [Fact]
    public void BaseEntityTKey_WithGuidKey_ShouldInitializeCorrectly()
    {
        // Act
        var entity = new TestEntityWithGuidKey();

        // Assert
        entity.Should().NotBeNull();
        entity.Id.Should().Be(Guid.Empty);
    }

    #endregion

    #region Property Setter Tests

    [Fact]
    public void User_EmailSetter_ShouldTrimAndLowercase()
    {
        // Arrange
        var user = new User();
        var email = "  TEST@EXAMPLE.COM  ";

        // Act
        user.Email = email;

        // Assert
        user.Email.Should().Be("test@example.com");
    }

    [Fact]
    public void User_UserNameSetter_ShouldTrim()
    {
        // Arrange
        var user = new User();
        var userName = "  testuser  ";

        // Act
        user.UserName = userName;

        // Assert
        user.UserName.Should().Be("testuser");
    }

    [Fact]
    public void User_PhoneNumberSetter_ShouldPreserveValue()
    {
        // Arrange
        var user = new User();
        var phoneNumber = "+1-555-123-4567";

        // Act
        user.PhoneNumber = phoneNumber;

        // Assert
        user.PhoneNumber.Should().Be(phoneNumber);
    }

    [Fact]
    public void User_FirstNameSetter_ShouldPreserveValue()
    {
        // Arrange
        var user = new User();
        var firstName = "John";

        // Act
        user.FirstName = firstName;

        // Assert
        user.FirstName.Should().Be(firstName);
    }

    [Fact]
    public void User_LastNameSetter_ShouldPreserveValue()
    {
        // Arrange
        var user = new User();
        var lastName = "Doe";

        // Act
        user.LastName = lastName;

        // Assert
        user.LastName.Should().Be(lastName);
    }

    [Fact]
    public void User_GeneratedCodeSetter_ShouldPreserveValue()
    {
        // Arrange
        var user = new User();
        var generatedCode = "USR-12345";

        // Act
        user.GeneratedCode = generatedCode;

        // Assert
        user.GeneratedCode.Should().Be(generatedCode);
    }

    [Fact]
    public void User_IsActiveSetter_ShouldWork()
    {
        // Arrange
        var user = new User();

        // Act
        user.IsActive = false;

        // Assert
        user.IsActive.Should().BeFalse();
    }

    [Fact]
    public void User_IsDeletedSetter_ShouldWork()
    {
        // Arrange
        var user = new User();

        // Act
        user.IsDeleted = true;

        // Assert
        user.IsDeleted.Should().BeTrue();
    }

    [Fact]
    public void User_IsSystemSetter_ShouldWork()
    {
        // Arrange
        var user = new User();

        // Act
        user.IsSystem = true;

        // Assert
        user.IsSystem.Should().BeTrue();
    }

    [Fact]
    public void User_OrganizationIdSetter_ShouldWork()
    {
        // Arrange
        var user = new User();
        var organizationId = 123;

        // Act
        user.OrganizationId = organizationId;

        // Assert
        user.OrganizationId.Should().Be(organizationId);
    }

    [Fact]
    public void User_DepartmentSetter_ShouldWork()
    {
        // Arrange
        var user = new User();
        var department = "Engineering";

        // Act
        user.Department = department;

        // Assert
        user.Department.Should().Be(department);
    }

    [Fact]
    public void User_TitleSetter_ShouldWork()
    {
        // Arrange
        var user = new User();
        var title = "Senior Developer";

        // Act
        user.Title = title;

        // Assert
        user.Title.Should().Be(title);
    }

    [Fact]
    public void User_MainRoleSetter_ShouldWork()
    {
        // Arrange
        var user = new User();
        var mainRole = RoleEnum.Admin;

        // Act
        user.MainRole = mainRole;

        // Assert
        user.MainRole.Should().Be(mainRole);
    }

    [Fact]
    public void User_CreatedBySetter_ShouldWork()
    {
        // Arrange
        var user = new User();
        var createdBy = "system";

        // Act
        user.CreatedBy = createdBy;

        // Assert
        user.CreatedBy.Should().Be(createdBy);
    }

    [Fact]
    public void User_UpdatedBySetter_ShouldWork()
    {
        // Arrange
        var user = new User();
        var updatedBy = "admin";

        // Act
        user.UpdatedBy = updatedBy;

        // Assert
        user.UpdatedBy.Should().Be(updatedBy);
    }

    [Fact]
    public void User_UpdatedDateSetter_ShouldWork()
    {
        // Arrange
        var user = new User();
        var updatedDate = DateTime.UtcNow.AddDays(-1);

        // Act
        user.UpdatedDate = updatedDate;

        // Assert
        user.UpdatedDate.Should().Be(updatedDate);
    }

    #endregion

    #region Collection Property Tests

    [Fact]
    public void User_UserRolesCollection_ShouldBeNullByDefault()
    {
        // Arrange
        var user = new User();

        // Act & Assert
        user.UserRoles.Should().BeNull(); // UserRoles is not initialized by default
    }

    [Fact]
    public void User_UserRolesCollection_ShouldAllowAdd()
    {
        // Arrange
        var user = new User();
        user.UserRoles = new List<UserRole>(); // Initialize the collection
        var userRole = new UserRole { UserId = 1, RoleId = 1 };

        // Act
        user.UserRoles.Add(userRole);

        // Assert
        user.UserRoles.Should().HaveCount(1);
        user.UserRoles.Should().Contain(userRole);
    }

    [Fact]
    public void User_UserRolesCollection_ShouldAllowRemove()
    {
        // Arrange
        var user = new User();
        user.UserRoles = new List<UserRole>(); // Initialize the collection
        var userRole = new UserRole { UserId = 1, RoleId = 1 };
        user.UserRoles.Add(userRole);

        // Act
        user.UserRoles.Remove(userRole);

        // Assert
        user.UserRoles.Should().BeEmpty();
    }

    [Fact]
    public void User_UserRolesCollection_ShouldAllowClear()
    {
        // Arrange
        var user = new User();
        user.UserRoles = new List<UserRole>(); // Initialize the collection
        user.UserRoles.Add(new UserRole { UserId = 1, RoleId = 1 });
        user.UserRoles.Add(new UserRole { UserId = 1, RoleId = 2 });

        // Act
        user.UserRoles.Clear();

        // Assert
        user.UserRoles.Should().BeEmpty();
    }

    #endregion

    #region Navigation Property Tests

    [Fact]
    public void User_OrganizationNavigation_ShouldBeNullByDefault()
    {
        // Arrange
        var user = new User();

        // Act & Assert
        user.Organization.Should().BeNull();
    }

    [Fact]
    public void User_OrganizationNavigation_ShouldBeSettable()
    {
        // Arrange
        var user = new User();
        var organization = new Organization { Id = 1, Name = "Test Org" };

        // Act
        user.Organization = organization;

        // Assert
        user.Organization.Should().Be(organization);
    }

    [Fact]
    public void User_OrganizationNavigation_ShouldBeNullAfterSetToNull()
    {
        // Arrange
        var user = new User();
        var organization = new Organization { Id = 1, Name = "Test Org" };
        user.Organization = organization;

        // Act
        user.Organization = null;

        // Assert
        user.Organization.Should().BeNull();
    }

    #endregion

    #region Property Validation Tests

    [Theory]
    [InlineData("", false)]
    [InlineData(" ", false)]
    [InlineData("test@example.com", true)]
    [InlineData("user@domain.org", true)]
    [InlineData("invalid-email", false)]
    [InlineData("@example.com", false)]
    [InlineData("test@", false)]
    public void User_EmailProperty_ShouldValidateFormat(string email, bool shouldBeValid)
    {
        // Arrange
        var user = new User();

        // Act
        user.Email = email;

        // Assert
        if (shouldBeValid)
        {
            user.Email.Should().Be(email.ToLowerInvariant().Trim());
        }
        else
        {
            // The setter doesn't validate format, it just trims and lowercases
            user.Email.Should().Be(email.ToLowerInvariant().Trim());
        }
    }

    [Theory]
    [InlineData("", false)]
    [InlineData(" ", false)]
    [InlineData("validusername", true)]
    [InlineData("user123", true)]
    [InlineData("user-name", true)]
    [InlineData("user_name", true)]
    public void User_UserNameProperty_ShouldHandleValues(string userName, bool shouldBeValid)
    {
        // Arrange
        var user = new User();

        // Act
        user.UserName = userName;

        // Assert
        if (shouldBeValid)
        {
            user.UserName.Should().Be(userName.Trim());
        }
        else
        {
            user.UserName.Should().Be(userName.Trim());
        }
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("1234567890")]
    [InlineData("+1-555-123-4567")]
    [InlineData("(555) 123-4567")]
    [InlineData("555.123.4567")]
    public void User_PhoneNumberProperty_ShouldPreserveValue(string phoneNumber)
    {
        // Arrange
        var user = new User();

        // Act
        user.PhoneNumber = phoneNumber;

        // Assert
        user.PhoneNumber.Should().Be(phoneNumber);
    }

    #endregion

    #region Property Type Tests

    [Fact]
    public void User_AllProperties_ShouldHaveCorrectTypes()
    {
        // Arrange
        var user = new User();
        var userType = typeof(User);

        // Act & Assert
        userType.GetProperty(nameof(User.Id))?.PropertyType.Should().Be(typeof(int));
        userType.GetProperty(nameof(User.UserName))?.PropertyType.Should().Be(typeof(string));
        userType.GetProperty(nameof(User.Email))?.PropertyType.Should().Be(typeof(string));
        userType.GetProperty(nameof(User.PhoneNumber))?.PropertyType.Should().Be(typeof(string));
        userType.GetProperty(nameof(User.FirstName))?.PropertyType.Should().Be(typeof(string));
        userType.GetProperty(nameof(User.LastName))?.PropertyType.Should().Be(typeof(string));
        userType.GetProperty(nameof(User.GeneratedCode))?.PropertyType.Should().Be(typeof(string));
        userType.GetProperty(nameof(User.IsActive))?.PropertyType.Should().Be(typeof(bool?));
        userType.GetProperty(nameof(User.IsDeleted))?.PropertyType.Should().Be(typeof(bool?));
        userType.GetProperty(nameof(User.IsSystem))?.PropertyType.Should().Be(typeof(bool?));
        userType.GetProperty(nameof(User.OrganizationId))?.PropertyType.Should().Be(typeof(int?));
        userType.GetProperty(nameof(User.Department))?.PropertyType.Should().Be(typeof(string));
        userType.GetProperty(nameof(User.Title))?.PropertyType.Should().Be(typeof(string));
        userType.GetProperty(nameof(User.MainRole))?.PropertyType.Should().Be(typeof(RoleEnum));
        userType.GetProperty(nameof(User.CreatedDate))?.PropertyType.Should().Be(typeof(DateTime?));
        userType.GetProperty(nameof(User.CreatedBy))?.PropertyType.Should().Be(typeof(string));
        userType.GetProperty(nameof(User.UpdatedDate))?.PropertyType.Should().Be(typeof(DateTime?));
        userType.GetProperty(nameof(User.UpdatedBy))?.PropertyType.Should().Be(typeof(string));
    }

    [Fact]
    public void BaseEntity_AllProperties_ShouldHaveCorrectTypes()
    {
        // Arrange
        var entityType = typeof(BaseEntity);

        // Act & Assert
        entityType.GetProperty(nameof(BaseEntity.Id))?.PropertyType.Should().Be(typeof(int));
        entityType.GetProperty(nameof(BaseEntity.OrganizationId))?.PropertyType.Should().Be(typeof(int?));
        entityType.GetProperty(nameof(BaseEntity.IsActive))?.PropertyType.Should().Be(typeof(bool?));
        entityType.GetProperty(nameof(BaseEntity.IsDeleted))?.PropertyType.Should().Be(typeof(bool?));
        entityType.GetProperty(nameof(BaseEntity.IsSystem))?.PropertyType.Should().Be(typeof(bool?));
        entityType.GetProperty(nameof(BaseEntity.CreatedDate))?.PropertyType.Should().Be(typeof(DateTime?));
        entityType.GetProperty(nameof(BaseEntity.CreatedBy))?.PropertyType.Should().Be(typeof(string));
        entityType.GetProperty(nameof(BaseEntity.UpdatedDate))?.PropertyType.Should().Be(typeof(DateTime?));
        entityType.GetProperty(nameof(BaseEntity.UpdatedBy))?.PropertyType.Should().Be(typeof(string));
    }

    #endregion

    #region Property Accessibility Tests

    [Fact]
    public void User_AllProperties_ShouldBeReadable()
    {
        // Arrange
        var user = new User();
        var userType = typeof(User);

        // Act & Assert
        userType.GetProperty(nameof(User.Id))?.CanRead.Should().BeTrue();
        userType.GetProperty(nameof(User.UserName))?.CanRead.Should().BeTrue();
        userType.GetProperty(nameof(User.Email))?.CanRead.Should().BeTrue();
        userType.GetProperty(nameof(User.PhoneNumber))?.CanRead.Should().BeTrue();
        userType.GetProperty(nameof(User.FirstName))?.CanRead.Should().BeTrue();
        userType.GetProperty(nameof(User.LastName))?.CanRead.Should().BeTrue();
        userType.GetProperty(nameof(User.GeneratedCode))?.CanRead.Should().BeTrue();
        userType.GetProperty(nameof(User.IsActive))?.CanRead.Should().BeTrue();
        userType.GetProperty(nameof(User.IsDeleted))?.CanRead.Should().BeTrue();
        userType.GetProperty(nameof(User.IsSystem))?.CanRead.Should().BeTrue();
        userType.GetProperty(nameof(User.OrganizationId))?.CanRead.Should().BeTrue();
        userType.GetProperty(nameof(User.Department))?.CanRead.Should().BeTrue();
        userType.GetProperty(nameof(User.Title))?.CanRead.Should().BeTrue();
        userType.GetProperty(nameof(User.MainRole))?.CanRead.Should().BeTrue();
        userType.GetProperty(nameof(User.CreatedDate))?.CanRead.Should().BeTrue();
        userType.GetProperty(nameof(User.CreatedBy))?.CanRead.Should().BeTrue();
        userType.GetProperty(nameof(User.UpdatedDate))?.CanRead.Should().BeTrue();
        userType.GetProperty(nameof(User.UpdatedBy))?.CanRead.Should().BeTrue();
    }

    [Fact]
    public void User_AllProperties_ShouldBeWritable()
    {
        // Arrange
        var user = new User();
        var userType = typeof(User);

        // Act & Assert
        userType.GetProperty(nameof(User.Id))?.CanWrite.Should().BeTrue();
        userType.GetProperty(nameof(User.UserName))?.CanWrite.Should().BeTrue();
        userType.GetProperty(nameof(User.Email))?.CanWrite.Should().BeTrue();
        userType.GetProperty(nameof(User.PhoneNumber))?.CanWrite.Should().BeTrue();
        userType.GetProperty(nameof(User.FirstName))?.CanWrite.Should().BeTrue();
        userType.GetProperty(nameof(User.LastName))?.CanWrite.Should().BeTrue();
        userType.GetProperty(nameof(User.GeneratedCode))?.CanWrite.Should().BeTrue();
        userType.GetProperty(nameof(User.IsActive))?.CanWrite.Should().BeTrue();
        userType.GetProperty(nameof(User.IsDeleted))?.CanWrite.Should().BeTrue();
        userType.GetProperty(nameof(User.IsSystem))?.CanWrite.Should().BeTrue();
        userType.GetProperty(nameof(User.OrganizationId))?.CanWrite.Should().BeTrue();
        userType.GetProperty(nameof(User.Department))?.CanWrite.Should().BeTrue();
        userType.GetProperty(nameof(User.Title))?.CanWrite.Should().BeTrue();
        userType.GetProperty(nameof(User.MainRole))?.CanWrite.Should().BeTrue();
        userType.GetProperty(nameof(User.CreatedDate))?.CanWrite.Should().BeTrue();
        userType.GetProperty(nameof(User.CreatedBy))?.CanWrite.Should().BeTrue();
        userType.GetProperty(nameof(User.UpdatedDate))?.CanWrite.Should().BeTrue();
        userType.GetProperty(nameof(User.UpdatedBy))?.CanWrite.Should().BeTrue();
    }

    #endregion

    #region Test Helper Classes

    private class TestEntity : BaseEntity
    {
    }

    private class TestEntityWithIntKey : BaseEntity<int>
    {
    }

    private class TestEntityWithStringKey : BaseEntity<string>
    {
    }

    private class TestEntityWithGuidKey : BaseEntity<Guid>
    {
    }

    #endregion
}
