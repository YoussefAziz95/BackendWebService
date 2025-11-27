using Domain;
using Domain.Enums;
using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackendWebService.Domain.UnitTests;

public class EdgeCaseAndBoundaryTests
{
    #region User Edge Cases

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("\t\n\r")]
    [InlineData("a")]
    [InlineData("verylongusernamethatexceedstypicallimitsandshouldbestillhandledcorrectlybythesystem")]
    public void User_UserName_ShouldHandleEdgeCases(string userName)
    {
        // Arrange
        var user = new User();

        // Act
        user.UserName = userName;

        // Assert
        user.UserName.Should().Be(userName?.Trim());
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("test@example.com")]
    [InlineData("TEST@EXAMPLE.COM")]
    [InlineData("  test@example.com  ")]
    [InlineData("verylongemailaddressthatexceedstypicallimitsandshouldbestillhandledcorrectlybythesystem@example.com")]
    public void User_Email_ShouldHandleEdgeCases(string email)
    {
        // Arrange
        var user = new User();

        // Act
        user.Email = email;

        // Assert
        user.Email.Should().Be(email?.Trim().ToLower());
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("1234567890")]
    [InlineData("+1234567890")]
    [InlineData("(123) 456-7890")]
    [InlineData("verylongphonenumberthatexceedstypicallimitsandshouldbestillhandledcorrectlybythesystem")]
    public void User_PhoneNumber_ShouldHandleEdgeCases(string phoneNumber)
    {
        // Arrange
        var user = new User();

        // Act
        user.PhoneNumber = phoneNumber;

        // Assert
        user.PhoneNumber.Should().Be(phoneNumber);
    }

    [Fact]
    public void User_GeneratedCode_ShouldBeUnique()
    {
        // Arrange & Act
        var users = new List<User>();
        for (int i = 0; i < 100; i++)
        {
            users.Add(new User());
        }

        // Assert
        var codes = users.Select(u => u.GeneratedCode).ToList();
        codes.Should().OnlyHaveUniqueItems();
        codes.Should().AllSatisfy(code => code.Should().HaveLength(8));
    }

    [Fact]
    public void User_Constructor_ShouldSetCreatedDate()
    {
        // Arrange
        var beforeCreation = DateTime.UtcNow;

        // Act
        var user = new User();

        // Assert
        user.CreatedDate.Should().BeCloseTo(beforeCreation, TimeSpan.FromSeconds(5));
        user.CreatedDate.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
    }

    #endregion

    #region Property Edge Cases

    [Theory]
    [InlineData(-90.0, -180.0)] // Minimum valid coordinates
    [InlineData(90.0, 180.0)]   // Maximum valid coordinates
    [InlineData(0.0, 0.0)]      // Origin
    [InlineData(45.0, -45.0)]   // Typical coordinates
    [InlineData(-89.999, -179.999)] // Just inside boundaries
    [InlineData(89.999, 179.999)]   // Just inside boundaries
    public void Property_Coordinates_ShouldHandleBoundaryValues(double latitude, double longitude)
    {
        // Arrange
        var property = new Property
        {
            UserId = 1,
            Name = "Test Property"
        };

        // Act
        property.Latitude = latitude;
        property.Longitude = longitude;

        // Assert
        property.Latitude.Should().Be(latitude);
        property.Longitude.Should().Be(longitude);
    }

    [Theory]
    [InlineData(-90.1)] // Just below minimum
    [InlineData(90.1)]  // Just above maximum
    [InlineData(-91.0)] // Well below minimum
    [InlineData(91.0)]  // Well above maximum
    public void Property_Latitude_ShouldHandleInvalidValues(double invalidLatitude)
    {
        // Arrange
        var property = new Property
        {
            UserId = 1,
            Name = "Test Property"
        };

        // Act
        property.Latitude = invalidLatitude;

        // Assert
        // The property setter doesn't validate, but the value is set
        property.Latitude.Should().Be(invalidLatitude);
        
        // Validation would occur during model binding, not property setting
        // This test verifies the property can be set to any double value
    }

    [Theory]
    [InlineData(-180.1)] // Just below minimum
    [InlineData(180.1)]  // Just above maximum
    [InlineData(-181.0)] // Well below minimum
    [InlineData(181.0)]  // Well above maximum
    public void Property_Longitude_ShouldHandleInvalidValues(double invalidLongitude)
    {
        // Arrange
        var property = new Property
        {
            UserId = 1,
            Name = "Test Property"
        };

        // Act
        property.Longitude = invalidLongitude;

        // Assert
        // The property setter doesn't validate, but the value is set
        property.Longitude.Should().Be(invalidLongitude);
        
        // Validation would occur during model binding, not property setting
        // This test verifies the property can be set to any double value
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("a")]
    [InlineData("verylongnamethatexceedsthemaximumlengthofonehundredcharactersandshouldcauseproblems")]
    public void Property_Name_ShouldHandleEdgeCases(string name)
    {
        // Arrange
        var property = new Property
        {
            UserId = 1,
            Name = name
        };

        // Act & Assert
        // The property setter doesn't validate, but the value is set
        property.Name.Should().Be(name);
        
        // Validation would occur during model binding, not property setting
        // This test verifies the property can be set to any string value
    }

    [Theory]
    [InlineData("")]
    [InlineData("1234567890")]
    [InlineData("+1234567890")]
    [InlineData("(123) 456-7890")]
    [InlineData("invalid-phone")]
    [InlineData("verylongphonenumberthatexceedstypicallimitsandshouldbestillhandledcorrectlybythesystem")]
    public void Property_ContactNumber_ShouldHandleEdgeCases(string contactNumber)
    {
        // Arrange
        var property = new Property
        {
            UserId = 1,
            Name = "Test Property",
            ContactNumber = contactNumber
        };

        // Act & Assert
        // The property setter doesn't validate, but the value is set
        property.ContactNumber.Should().Be(contactNumber);
        
        // Validation would occur during model binding, not property setting
        // This test verifies the property can be set to any string value
    }

    #endregion

    #region BaseEntity Edge Cases

    [Fact]
    public void BaseEntity_Equals_ShouldHandleNullObjects()
    {
        // Arrange
        var entity1 = new TestEntity { Id = 1 };
        TestEntity? entity2 = null!;

        // Act & Assert
        entity1.Equals(entity2!).Should().BeFalse();
        entity1.Equals(null!).Should().BeFalse();
    }

    [Fact]
    public void BaseEntity_Equals_ShouldHandleSameReference()
    {
        // Arrange
        var entity = new TestEntity { Id = 1 };

        // Act & Assert
        entity.Equals(entity).Should().BeTrue();
    }

    [Fact]
    public void BaseEntity_Equals_ShouldHandleDifferentTypes()
    {
        // Arrange
        var entity1 = new TestEntity { Id = 1 };
        var entity2 = new AnotherTestEntity { Id = 1 };

        // Act & Assert
        entity1.Equals(entity2!).Should().BeFalse();
    }

    [Fact]
    public void BaseEntity_Equals_ShouldHandleSameIdDifferentInstances()
    {
        // Arrange
        var entity1 = new TestEntity { Id = 1 };
        var entity2 = new TestEntity { Id = 1 };

        // Act & Assert
        entity1.Equals(entity2!).Should().BeTrue();
    }

    [Fact]
    public void BaseEntity_Equals_ShouldHandleDifferentIds()
    {
        // Arrange
        var entity1 = new TestEntity { Id = 1 };
        var entity2 = new TestEntity { Id = 2 };

        // Act & Assert
        entity1.Equals(entity2!).Should().BeFalse();
    }

    [Fact]
    public void BaseEntity_GetHashCode_ShouldBeConsistent()
    {
        // Arrange
        var entity = new TestEntity { Id = 1 };
        var hash1 = entity.GetHashCode();
        var hash2 = entity.GetHashCode();

        // Act & Assert
        hash1.Should().Be(hash2);
    }

    [Fact]
    public void BaseEntity_GetHashCode_ShouldBeDifferentForDifferentIds()
    {
        // Arrange
        var entity1 = new TestEntity { Id = 1 };
        var entity2 = new TestEntity { Id = 2 };

        // Act & Assert
        entity1.GetHashCode().Should().NotBe(entity2.GetHashCode());
    }

    [Fact]
    public void BaseEntity_OperatorEquality_ShouldHandleNulls()
    {
        // Arrange
        TestEntity? entity1 = null!;
        TestEntity? entity2 = null!;
        var entity3 = new TestEntity { Id = 1 };

        // Act & Assert
        (entity1 == entity2).Should().BeTrue();
        (entity1 == entity3).Should().BeFalse();
        (entity3 == entity1).Should().BeFalse();
    }

    [Fact]
    public void BaseEntity_OperatorInequality_ShouldHandleNulls()
    {
        // Arrange
        TestEntity? entity1 = null!;
        TestEntity? entity2 = null!;
        var entity3 = new TestEntity { Id = 1 };

        // Act & Assert
        (entity1 != entity2).Should().BeFalse();
        (entity1 != entity3).Should().BeTrue();
        (entity3 != entity1).Should().BeTrue();
    }

    #endregion

    #region Enum Edge Cases

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    [InlineData(11)]
    [InlineData(12)]
    [InlineData(13)]
    [InlineData(14)]
    [InlineData(15)]
    [InlineData(16)]
    public void StatusEnum_ShouldHandleAllValues(int value)
    {
        // Arrange & Act
        var status = (StatusEnum)value;

        // Assert
        status.Should().BeDefined();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(17)]
    [InlineData(100)]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    public void StatusEnum_ShouldHandleInvalidValues(int invalidValue)
    {
        // Arrange & Act
        var status = (StatusEnum)invalidValue;

        // Assert
        // Invalid enum values should not be defined
        Enum.IsDefined(typeof(StatusEnum), status).Should().BeFalse();
        status.Should().NotBeDefined();
    }

    [Theory]
    [InlineData("Active")]
    [InlineData("New")]
    [InlineData("Pending")]
    [InlineData("Completed")]
    [InlineData("Returned")]
    [InlineData("Accepted")]
    [InlineData("Suspended")]
    [InlineData("Deleted")]
    [InlineData("Saved")]
    [InlineData("Hold")]
    [InlineData("Scored")]
    [InlineData("Disabled")]
    [InlineData("OnTheWay")]
    [InlineData("Arrived")]
    [InlineData("InProgress")]
    [InlineData("IssueReported")]
    [InlineData("PendingApproval")]
    public void StatusEnum_ShouldParseValidStrings(string statusString)
    {
        // Arrange & Act
        var canParse = Enum.TryParse<StatusEnum>(statusString, out var status);

        // Assert
        canParse.Should().BeTrue();
        status.Should().BeDefined();
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("invalid")]
    [InlineData("ACTIVE")]
    [InlineData("active")]
    public void StatusEnum_ShouldHandleInvalidStrings(string invalidString)
    {
        // Arrange & Act
        var canParse = Enum.TryParse<StatusEnum>(invalidString, out var status);

        // Assert
        canParse.Should().BeFalse();
        status.Should().Be(default(StatusEnum));
    }

    #endregion

    #region Collection Edge Cases

    [Fact]
    public void User_UserRoles_ShouldHandleNullCollection()
    {
        // Arrange
        var user = new User();

        // Act
        user.UserRoles = null!;

        // Assert
        user.UserRoles.Should().BeNull();
    }

    [Fact]
    public void User_UserRoles_ShouldHandleEmptyCollection()
    {
        // Arrange
        var user = new User();
        user.UserRoles = new List<UserRole>();

        // Act
        var count = user.UserRoles.Count;

        // Assert
        count.Should().Be(0);
    }

    [Fact]
    public void User_UserRoles_ShouldHandleLargeCollection()
    {
        // Arrange
        var user = new User();
        user.UserRoles = new List<UserRole>();
        var roles = new List<UserRole>();

        // Act
        for (int i = 0; i < 10000; i++)
        {
            roles.Add(new UserRole { UserId = 1, RoleId = i });
        }
        user.UserRoles = roles;

        // Assert
        user.UserRoles.Should().HaveCount(10000);
    }

    [Fact]
    public void User_UserRoles_ShouldHandleDuplicateItems()
    {
        // Arrange
        var user = new User();
        user.UserRoles = new List<UserRole>();
        var role1 = new UserRole { UserId = 1, RoleId = 1 };
        var role2 = new UserRole { UserId = 1, RoleId = 1 }; // Duplicate

        // Act
        user.UserRoles.Add(role1);
        user.UserRoles.Add(role2);

        // Assert
        user.UserRoles.Should().HaveCount(2);
        user.UserRoles.Should().Contain(role1);
        user.UserRoles.Should().Contain(role2);
    }

    #endregion

    #region DateTime Edge Cases

    [Fact]
    public void Property_CreatedAt_ShouldHandleMinValue()
    {
        // Arrange
        var property = new Property
        {
            UserId = 1,
            Name = "Test Property",
            CreatedAt = DateTimeOffset.MinValue
        };

        // Assert
        property.CreatedAt.Should().Be(DateTimeOffset.MinValue);
    }

    [Fact]
    public void Property_CreatedAt_ShouldHandleMaxValue()
    {
        // Arrange
        var property = new Property
        {
            UserId = 1,
            Name = "Test Property",
            CreatedAt = DateTimeOffset.MaxValue
        };

        // Assert
        property.CreatedAt.Should().Be(DateTimeOffset.MaxValue);
    }

    [Fact]
    public void Property_CreatedAt_ShouldHandleUtcNow()
    {
        // Arrange
        var beforeCreation = DateTimeOffset.UtcNow;
        var property = new Property
        {
            UserId = 1,
            Name = "Test Property"
        };

        // Assert
        property.CreatedAt.Should().BeCloseTo(beforeCreation, TimeSpan.FromSeconds(5));
    }

    [Fact]
    public void Property_DeletedAt_ShouldHandleNull()
    {
        // Arrange
        var property = new Property
        {
            UserId = 1,
            Name = "Test Property",
            DeletedAt = null
        };

        // Assert
        property.DeletedAt.Should().BeNull();
    }

    [Fact]
    public void Property_DeletedAt_ShouldHandleValidDate()
    {
        // Arrange
        var deletedAt = DateTimeOffset.UtcNow;
        var property = new Property
        {
            UserId = 1,
            Name = "Test Property",
            DeletedAt = deletedAt
        };

        // Assert
        property.DeletedAt.Should().Be(deletedAt);
    }

    #endregion

    #region String Edge Cases

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("\t\n\r")]
    [InlineData("a")]
    [InlineData("verylongstringthatexceedstypicallimitsandshouldbestillhandledcorrectlybythesystem")]
    [InlineData("string with spaces")]
    [InlineData("string-with-dashes")]
    [InlineData("string_with_underscores")]
    [InlineData("string.with.dots")]
    [InlineData("string@with#special$chars%")]
    public void User_FirstName_ShouldHandleEdgeCases(string firstName)
    {
        // Arrange
        var user = new User();

        // Act
        user.FirstName = firstName;

        // Assert
        user.FirstName.Should().Be(firstName);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("\t\n\r")]
    [InlineData("a")]
    [InlineData("verylongstringthatexceedstypicallimitsandshouldbestillhandledcorrectlybythesystem")]
    [InlineData("string with spaces")]
    [InlineData("string-with-dashes")]
    [InlineData("string_with_underscores")]
    [InlineData("string.with.dots")]
    [InlineData("string@with#special$chars%")]
    public void User_LastName_ShouldHandleEdgeCases(string lastName)
    {
        // Arrange
        var user = new User();

        // Act
        user.LastName = lastName;

        // Assert
        user.LastName.Should().Be(lastName);
    }

    #endregion

    #region Boolean Edge Cases

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void User_IsActive_ShouldHandleBooleanValues(bool isActive)
    {
        // Arrange
        var user = new User();

        // Act
        user.IsActive = isActive;

        // Assert
        user.IsActive.Should().Be(isActive);
    }

    [Fact]
    public void User_IsActive_ShouldHandleNull()
    {
        // Arrange
        var user = new User();

        // Act
        user.IsActive = null!;

        // Assert
        user.IsActive.Should().BeNull();
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void User_IsDeleted_ShouldHandleBooleanValues(bool isDeleted)
    {
        // Arrange
        var user = new User();

        // Act
        user.IsDeleted = isDeleted;

        // Assert
        user.IsDeleted.Should().Be(isDeleted);
    }

    [Fact]
    public void User_IsDeleted_ShouldHandleNull()
    {
        // Arrange
        var user = new User();

        // Act
        user.IsDeleted = null!;

        // Assert
        user.IsDeleted.Should().BeNull();
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void User_IsSystem_ShouldHandleBooleanValues(bool isSystem)
    {
        // Arrange
        var user = new User();

        // Act
        user.IsSystem = isSystem;

        // Assert
        user.IsSystem.Should().Be(isSystem);
    }

    [Fact]
    public void User_IsSystem_ShouldHandleNull()
    {
        // Arrange
        var user = new User();

        // Act
        user.IsSystem = null!;

        // Assert
        user.IsSystem.Should().BeNull();
    }

    #endregion

    #region Helper Classes

    private class TestEntity : BaseEntity<int>
    {
        public string Name { get; set; } = "Test";
    }

    private class AnotherTestEntity : BaseEntity<int>
    {
        public string Name { get; set; } = "AnotherTest";
    }

    #endregion
}
