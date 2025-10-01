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

    #region Business Logic Tests

    [Fact]
    public void User_EmailSetter_ShouldTrimAndLowercase()
    {
        // Arrange
        var user = new User();
        var testEmail = "  TEST@EXAMPLE.COM  ";

        // Act
        user.Email = testEmail;

        // Assert
        user.Email.Should().Be("test@example.com");
    }

    [Fact]
    public void User_EmailSetter_ShouldHandleNull()
    {
        // Arrange
        var user = new User();

        // Act
        user.Email = null;

        // Assert
        user.Email.Should().BeNull();
    }

    [Fact]
    public void User_UserNameSetter_ShouldTrim()
    {
        // Arrange
        var user = new User();
        var testUserName = "  testuser  ";

        // Act
        user.UserName = testUserName;

        // Assert
        user.UserName.Should().Be("testuser");
    }

    [Fact]
    public void User_UserNameSetter_ShouldHandleNull()
    {
        // Arrange
        var user = new User();

        // Act
        user.UserName = null;

        // Assert
        user.UserName.Should().BeNull();
    }

    [Fact]
    public void User_PhoneNumberSetter_ShouldPreserveValue()
    {
        // Arrange
        var user = new User();
        var testPhone = "+1234567890";

        // Act
        user.PhoneNumber = testPhone;

        // Assert
        user.PhoneNumber.Should().Be(testPhone);
    }

    [Fact]
    public void User_GeneratedCode_ShouldBeValidGuidSubstring()
    {
        // Arrange & Act
        var user = new User();

        // Assert
        user.GeneratedCode.Should().MatchRegex("^[a-fA-F0-9]{8}$");
    }

    [Fact]
    public void User_GeneratedCode_ShouldBeConsistent()
    {
        // Arrange & Act
        var user = new User();
        var code1 = user.GeneratedCode;
        var code2 = user.GeneratedCode;

        // Assert
        code1.Should().Be(code2);
    }

    #endregion

    #region Property Setting Tests

    [Theory]
    [InlineData("John")]
    [InlineData("Jane")]
    [InlineData("")]
    [InlineData(null)]
    public void User_FirstName_ShouldBeSettable(string firstName)
    {
        // Arrange
        var user = new User();

        // Act
        user.FirstName = firstName;

        // Assert
        user.FirstName.Should().Be(firstName);
    }

    [Theory]
    [InlineData("Doe")]
    [InlineData("Smith")]
    [InlineData("")]
    [InlineData(null)]
    public void User_LastName_ShouldBeSettable(string lastName)
    {
        // Arrange
        var user = new User();

        // Act
        user.LastName = lastName;

        // Assert
        user.LastName.Should().Be(lastName);
    }

    [Theory]
    [InlineData("test@example.com")]
    [InlineData("user@domain.org")]
    [InlineData("")]
    [InlineData(null)]
    public void User_Email_ShouldBeSettable(string email)
    {
        // Arrange
        var user = new User();

        // Act
        user.Email = email;

        // Assert
        user.Email.Should().Be(email);
    }

    [Theory]
    [InlineData("testuser")]
    [InlineData("user123")]
    [InlineData("")]
    [InlineData(null)]
    public void User_UserName_ShouldBeSettable(string userName)
    {
        // Arrange
        var user = new User();

        // Act
        user.UserName = userName;

        // Assert
        user.UserName.Should().Be(userName);
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
    public void User_UserRoles_ShouldBeSettable()
    {
        // Arrange
        var user = new User();
        var userRoles = new List<UserRole>();

        // Act
        user.UserRoles = userRoles;

        // Assert
        user.UserRoles.Should().BeSameAs(userRoles);
    }

    [Fact]
    public void User_UserGroups_ShouldBeSettable()
    {
        // Arrange
        var user = new User();
        var userGroups = new List<UserGroup>();

        // Act
        user.UserGroups = userGroups;

        // Assert
        user.UserGroups.Should().BeSameAs(userGroups);
    }

    [Fact]
    public void User_Logins_ShouldBeSettable()
    {
        // Arrange
        var user = new User();
        var logins = new List<UserLogin>();

        // Act
        user.Logins = logins;

        // Assert
        user.Logins.Should().BeSameAs(logins);
    }

    [Fact]
    public void User_Claims_ShouldBeSettable()
    {
        // Arrange
        var user = new User();
        var claims = new List<UserClaim>();

        // Act
        user.Claims = claims;

        // Assert
        user.Claims.Should().BeSameAs(claims);
    }

    [Fact]
    public void User_Tokens_ShouldBeSettable()
    {
        // Arrange
        var user = new User();
        var tokens = new List<UserToken>();

        // Act
        user.Tokens = tokens;

        // Assert
        user.Tokens.Should().BeSameAs(tokens);
    }

    [Fact]
    public void User_UserRefreshTokens_ShouldBeSettable()
    {
        // Arrange
        var user = new User();
        var refreshTokens = new List<UserRefreshToken>();

        // Act
        user.UserRefreshTokens = refreshTokens;

        // Assert
        user.UserRefreshTokens.Should().BeSameAs(refreshTokens);
    }

    #endregion

    #region Edge Cases Tests

    [Fact]
    public void User_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var user = new User
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            UserName = "johndoe"
        };

        // Assert
        user.FirstName.Should().Be("John");
        user.LastName.Should().Be("Doe");
        user.Email.Should().Be("john.doe@example.com");
        user.UserName.Should().Be("johndoe");
    }

    [Fact]
    public void User_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange & Act
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

        // Assert
        user.FirstName.Should().Be("John");
        user.LastName.Should().Be("Doe");
        user.Email.Should().Be("john.doe@example.com");
        user.UserName.Should().Be("johndoe");
        user.PhoneNumber.Should().Be("+1234567890");
        user.OrganizationId.Should().Be(1);
        user.Department.Should().Be("Engineering");
        user.Title.Should().Be("Software Engineer");
        user.MainRole.Should().Be(RoleEnum.Admin);
        user.IsActive.Should().BeTrue();
        user.IsDeleted.Should().BeFalse();
        user.IsSystem.Should().BeFalse();
        user.CreatedBy.Should().Be("admin");
        user.UpdatedBy.Should().Be("admin");
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
