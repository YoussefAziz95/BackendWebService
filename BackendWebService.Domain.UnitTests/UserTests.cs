using Xunit;
using FluentAssertions;
using Domain;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BackendWebService.Domain.UnitTests;

public class UserTests
{
    #region Constructor Tests

    [Fact]
    public void User_Constructor_ShouldSetDefaultValues()
    {
        // Arrange & Act
        var user = new User();

        // Assert
        user.GeneratedCode.Should().NotBeNullOrEmpty();
        user.GeneratedCode.Should().HaveLength(8);
        user.CreatedDate.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        user.IsActive.Should().BeTrue();
        user.IsDeleted.Should().BeFalse();
        user.IsSystem.Should().BeNull();
    }

    [Fact]
    public void User_Constructor_ShouldGenerateUniqueCodes()
    {
        // Arrange & Act
        var user1 = new User();
        var user2 = new User();

        // Assert
        user1.GeneratedCode.Should().NotBe(user2.GeneratedCode);
    }

    #endregion

    #region Property Validation Tests

    [Theory]
    [InlineData("John", true)]
    [InlineData("Jane", true)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void User_FirstName_ShouldValidateCorrectly(string firstName, bool isValid)
    {
        // Arrange
        var user = new User
        {
            FirstName = firstName,
            LastName = "Doe",
            Email = "test@example.com",
            UserName = "testuser"
        };

        // Act
        var validationContext = new ValidationContext(user) { MemberName = nameof(User.FirstName) };
        var validationResults = new List<ValidationResult>();
        var actualIsValid = Validator.TryValidateProperty(user.FirstName, validationContext, validationResults);

        // Assert
        actualIsValid.Should().Be(isValid);
        if (!isValid)
        {
            validationResults.Should().NotBeEmpty();
        }
        else
        {
            validationResults.Should().BeEmpty();
        }
    }

    [Theory]
    [InlineData("Doe", true)]
    [InlineData("Smith", true)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void User_LastName_ShouldValidateCorrectly(string lastName, bool isValid)
    {
        // Arrange
        var user = new User
        {
            FirstName = "John",
            LastName = lastName,
            Email = "test@example.com",
            UserName = "testuser"
        };

        // Act
        var validationContext = new ValidationContext(user) { MemberName = nameof(User.LastName) };
        var validationResults = new List<ValidationResult>();
        var actualIsValid = Validator.TryValidateProperty(user.LastName, validationContext, validationResults);

        // Assert
        actualIsValid.Should().Be(isValid);
        if (!isValid)
        {
            validationResults.Should().NotBeEmpty();
        }
        else
        {
            validationResults.Should().BeEmpty();
        }
    }

    [Theory]
    [InlineData("test@example.com", true)]
    [InlineData("user@domain.org", true)]
    [InlineData("", false)]
    [InlineData("invalid-email", false)]
    [InlineData(null, false)]
    public void User_Email_ShouldValidateCorrectly(string email, bool isValid)
    {
        // Arrange
        var user = new User
        {
            FirstName = "John",
            LastName = "Doe",
            Email = email,
            UserName = "testuser"
        };

        // Act
        var validationContext = new ValidationContext(user) { MemberName = nameof(User.Email) };
        var validationResults = new List<ValidationResult>();
        var actualIsValid = Validator.TryValidateProperty(user.Email, validationContext, validationResults);

        // Assert
        actualIsValid.Should().Be(isValid);
        if (!isValid)
        {
            validationResults.Should().NotBeEmpty();
        }
        else
        {
            validationResults.Should().BeEmpty();
        }
    }

    [Theory]
    [InlineData("testuser", true)]
    [InlineData("user123", true)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void User_UserName_ShouldValidateCorrectly(string userName, bool isValid)
    {
        // Arrange
        var user = new User
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "test@example.com",
            UserName = userName
        };

        // Act
        var validationContext = new ValidationContext(user) { MemberName = nameof(User.UserName) };
        var validationResults = new List<ValidationResult>();
        var actualIsValid = Validator.TryValidateProperty(user.UserName, validationContext, validationResults);

        // Assert
        actualIsValid.Should().Be(isValid);
        if (!isValid)
        {
            validationResults.Should().NotBeEmpty();
        }
        else
        {
            validationResults.Should().BeEmpty();
        }
    }

    #endregion

    #region Business Logic Tests

    [Fact]
    public void User_UserName_ShouldTrimWhitespace()
    {
        // Arrange
        var user = new User();
        var userNameWithSpaces = "  testuser  ";

        // Act
        user.UserName = userNameWithSpaces;

        // Assert
        user.UserName.Should().Be("testuser");
    }

    [Fact]
    public void User_Email_ShouldTrimAndLowercase()
    {
        // Arrange
        var user = new User();
        var emailWithSpaces = "  TEST@EXAMPLE.COM  ";

        // Act
        user.Email = emailWithSpaces;

        // Assert
        user.Email.Should().Be("test@example.com");
    }

    [Fact]
    public void User_PhoneNumber_ShouldBeSettable()
    {
        // Arrange
        var user = new User();
        var phoneNumber = "+1234567890";

        // Act
        user.PhoneNumber = phoneNumber;

        // Assert
        user.PhoneNumber.Should().Be(phoneNumber);
    }

    [Theory]
    [InlineData(RoleEnum.Admin)]
    [InlineData(RoleEnum.Employee)]
    [InlineData(RoleEnum.Customer)]
    public void User_MainRole_ShouldBeSettable(RoleEnum role)
    {
        // Arrange
        var user = new User();

        // Act
        user.MainRole = role;

        // Assert
        user.MainRole.Should().Be(role);
    }

    #endregion

    #region Security and System Flags Tests

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    [InlineData(null)]
    public void User_IsActive_ShouldBeSettable(bool? isActive)
    {
        // Arrange
        var user = new User();

        // Act
        user.IsActive = isActive;

        // Assert
        user.IsActive.Should().Be(isActive);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    [InlineData(null)]
    public void User_IsDeleted_ShouldBeSettable(bool? isDeleted)
    {
        // Arrange
        var user = new User();

        // Act
        user.IsDeleted = isDeleted;

        // Assert
        user.IsDeleted.Should().Be(isDeleted);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    [InlineData(null)]
    public void User_IsSystem_ShouldBeSettable(bool? isSystem)
    {
        // Arrange
        var user = new User();

        // Act
        user.IsSystem = isSystem;

        // Assert
        user.IsSystem.Should().Be(isSystem);
    }

    #endregion

    #region Organization and Department Tests

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(null)]
    public void User_OrganizationId_ShouldBeSettable(int? organizationId)
    {
        // Arrange
        var user = new User();

        // Act
        user.OrganizationId = organizationId;

        // Assert
        user.OrganizationId.Should().Be(organizationId);
    }

    [Theory]
    [InlineData("Engineering")]
    [InlineData("Sales")]
    [InlineData("Marketing")]
    [InlineData("")]
    [InlineData(null)]
    public void User_Department_ShouldBeSettable(string department)
    {
        // Arrange
        var user = new User();

        // Act
        user.Department = department;

        // Assert
        user.Department.Should().Be(department);
    }

    [Theory]
    [InlineData("Software Engineer")]
    [InlineData("Manager")]
    [InlineData("Director")]
    [InlineData("")]
    [InlineData(null)]
    public void User_Title_ShouldBeSettable(string title)
    {
        // Arrange
        var user = new User();

        // Act
        user.Title = title;

        // Assert
        user.Title.Should().Be(title);
    }

    #endregion

    #region Audit Information Tests

    [Fact]
    public void User_CreatedDate_ShouldBeSetOnConstruction()
    {
        // Arrange & Act
        var user = new User();

        // Assert
        user.CreatedDate.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void User_CreatedDate_ShouldBeSettable()
    {
        // Arrange
        var user = new User();
        var customDate = DateTime.UtcNow.AddDays(-1);

        // Act
        user.CreatedDate = customDate;

        // Assert
        user.CreatedDate.Should().Be(customDate);
    }

    [Theory]
    [InlineData("admin")]
    [InlineData("system")]
    [InlineData("")]
    [InlineData(null)]
    public void User_CreatedBy_ShouldBeSettable(string createdBy)
    {
        // Arrange
        var user = new User();

        // Act
        user.CreatedBy = createdBy;

        // Assert
        user.CreatedBy.Should().Be(createdBy);
    }

    [Fact]
    public void User_UpdatedDate_ShouldBeSettable()
    {
        // Arrange
        var user = new User();
        var updateDate = DateTime.UtcNow;

        // Act
        user.UpdatedDate = updateDate;

        // Assert
        user.UpdatedDate.Should().Be(updateDate);
    }

    [Theory]
    [InlineData("admin")]
    [InlineData("user")]
    [InlineData("")]
    [InlineData(null)]
    public void User_UpdatedBy_ShouldBeSettable(string updatedBy)
    {
        // Arrange
        var user = new User();

        // Act
        user.UpdatedBy = updatedBy;

        // Assert
        user.UpdatedBy.Should().Be(updatedBy);
    }

    #endregion

    #region Collection Properties Tests

    [Fact]
    public void User_UserRoles_ShouldBeInitialized()
    {
        // Arrange & Act
        var user = new User();

        // Assert
        user.UserRoles.Should().NotBeNull();
    }

    [Fact]
    public void User_UserGroups_ShouldBeInitialized()
    {
        // Arrange & Act
        var user = new User();

        // Assert
        user.UserGroups.Should().NotBeNull();
    }

    [Fact]
    public void User_Logins_ShouldBeInitialized()
    {
        // Arrange & Act
        var user = new User();

        // Assert
        user.Logins.Should().NotBeNull();
    }

    [Fact]
    public void User_Claims_ShouldBeInitialized()
    {
        // Arrange & Act
        var user = new User();

        // Assert
        user.Claims.Should().NotBeNull();
    }

    [Fact]
    public void User_Tokens_ShouldBeInitialized()
    {
        // Arrange & Act
        var user = new User();

        // Assert
        user.Tokens.Should().NotBeNull();
    }

    [Fact]
    public void User_UserRefreshTokens_ShouldBeInitialized()
    {
        // Arrange & Act
        var user = new User();

        // Assert
        user.UserRefreshTokens.Should().NotBeNull();
    }

    #endregion

    #region Edge Cases Tests

    [Fact]
    public void User_WithMinimalData_ShouldBeValid()
    {
        // Arrange
        var user = new User
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            UserName = "johndoe"
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(user, new ValidationContext(user), validationResults, true);

        // Assert
        isValid.Should().BeTrue();
        validationResults.Should().BeEmpty();
    }

    [Fact]
    public void User_WithCompleteData_ShouldBeValid()
    {
        // Arrange
        var user = new User
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            UserName = "johndoe",
            PhoneNumber = "+1234567890",
            OrganizationId = 1,
            Department = "Engineering",
            Title = "Software Engineer",
            MainRole = RoleEnum.Admin,
            IsActive = true,
            IsDeleted = false,
            IsSystem = false,
            CreatedBy = "admin",
            UpdatedBy = "admin"
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(user, new ValidationContext(user), validationResults, true);

        // Assert
        isValid.Should().BeTrue();
        validationResults.Should().BeEmpty();
    }

    [Fact]
    public void User_GeneratedCode_ShouldBeUniqueAcrossInstances()
    {
        // Arrange & Act
        var users = new List<User>();
        for (int i = 0; i < 100; i++)
        {
            users.Add(new User());
        }

        // Assert
        var uniqueCodes = users.Select(u => u.GeneratedCode).Distinct();
        uniqueCodes.Should().HaveCount(100);
    }

    [Fact]
    public void User_GeneratedCode_ShouldContainOnlyValidCharacters()
    {
        // Arrange & Act
        var user = new User();

        // Assert
        user.GeneratedCode.Should().MatchRegex("^[a-zA-Z0-9]{8}$");
    }

    #endregion

    #region Boundary Values Tests

    [Theory]
    [InlineData("A", true)] // Minimum length
    [InlineData("John", true)] // Normal length
    [InlineData("VeryLongFirstNameThatExceedsNormalLength", true)] // Long name
    public void User_FirstName_ShouldHandleVariousLengths(string firstName, bool expectedValid)
    {
        // Arrange
        var user = new User
        {
            FirstName = firstName,
            LastName = "Doe",
            Email = "test@example.com",
            UserName = "testuser"
        };

        // Act
        var validationContext = new ValidationContext(user) { MemberName = nameof(User.FirstName) };
        var validationResults = new List<ValidationResult>();
        var actualIsValid = Validator.TryValidateProperty(user.FirstName, validationContext, validationResults);

        // Assert
        actualIsValid.Should().Be(expectedValid);
    }

    [Theory]
    [InlineData("a@b.co", true)] // Minimum valid email
    [InlineData("user@example.com", true)] // Normal email
    [InlineData("very.long.email.address@very.long.domain.name.com", true)] // Long email
    public void User_Email_ShouldHandleVariousFormats(string email, bool expectedValid)
    {
        // Arrange
        var user = new User
        {
            FirstName = "John",
            LastName = "Doe",
            Email = email,
            UserName = "testuser"
        };

        // Act
        var validationContext = new ValidationContext(user) { MemberName = nameof(User.Email) };
        var validationResults = new List<ValidationResult>();
        var actualIsValid = Validator.TryValidateProperty(user.Email, validationContext, validationResults);

        // Assert
        actualIsValid.Should().Be(expectedValid);
    }

    #endregion
}
