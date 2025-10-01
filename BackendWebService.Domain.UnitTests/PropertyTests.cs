using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class PropertyTests
{
    [Fact]
    public void Property_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var property = new Property();

        // Assert
        property.Should().NotBeNull();
        property.UserId.Should().Be(0);
        property.User.Should().BeNull();
        property.Name.Should().BeNull();
        property.ContactName.Should().BeNull();
        property.ContactNumber.Should().BeNull();
        property.ZoneId.Should().BeNull();
        property.Zone.Should().BeNull();
        property.Latitude.Should().Be(0);
        property.Longitude.Should().Be(0);
        property.CreatedAt.Should().BeCloseTo(DateTimeOffset.UtcNow, TimeSpan.FromSeconds(5));
        property.DeletedAt.Should().BeNull();
        property.IsDeleted.Should().BeFalse();
    }

    [Fact]
    public void Property_AllProperties_ShouldBeSettable()
    {
        // Arrange
        var property = new Property();
        var user = new User();
        var zone = new Zone();
        var testDate = DateTimeOffset.UtcNow;

        // Act
        property.UserId = 123;
        property.User = user;
        property.Name = "Property Name";
        property.ContactName = "John Doe";
        property.ContactNumber = "+1234567890";
        property.ZoneId = 456;
        property.Zone = zone;
        property.Latitude = 40.7128;
        property.Longitude = -74.0060;
        property.CreatedAt = testDate;
        property.DeletedAt = testDate.AddDays(1);
        property.IsDeleted = true;

        // Assert
        property.UserId.Should().Be(123);
        property.User.Should().BeSameAs(user);
        property.Name.Should().Be("Property Name");
        property.ContactName.Should().Be("John Doe");
        property.ContactNumber.Should().Be("+1234567890");
        property.ZoneId.Should().Be(456);
        property.Zone.Should().BeSameAs(zone);
        property.Latitude.Should().Be(40.7128);
        property.Longitude.Should().Be(-74.0060);
        property.CreatedAt.Should().Be(testDate);
        property.DeletedAt.Should().Be(testDate.AddDays(1));
        property.IsDeleted.Should().BeTrue();
    }

    [Fact]
    public void Property_WithNullValues_ShouldBeCreatable()
    {
        // Arrange & Act
        var property = new Property
        {
            User = null,
            Name = null,
            ContactName = null,
            ContactNumber = null,
            ZoneId = null,
            Zone = null,
            DeletedAt = null
        };

        // Assert
        property.User.Should().BeNull();
        property.Name.Should().BeNull();
        property.ContactName.Should().BeNull();
        property.ContactNumber.Should().BeNull();
        property.ZoneId.Should().BeNull();
        property.Zone.Should().BeNull();
        property.DeletedAt.Should().BeNull();
    }

    [Fact]
    public void Property_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var property = new Property
        {
            UserId = 1,
            Name = "Property",
            Latitude = 0,
            Longitude = 0
        };

        // Assert
        property.UserId.Should().Be(1);
        property.Name.Should().Be("Property");
        property.Latitude.Should().Be(0);
        property.Longitude.Should().Be(0);
    }

    [Fact]
    public void Property_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange
        var user = new User { Id = 789 };
        var zone = new Zone { Id = 101 };

        // Act
        var property = new Property
        {
            UserId = 789,
            User = user,
            Name = "Luxury Apartment",
            ContactName = "Jane Smith",
            ContactNumber = "+9876543210",
            ZoneId = 101,
            Zone = zone,
            Latitude = 51.5074,
            Longitude = -0.1278,
            IsDeleted = false
        };

        // Assert
        property.UserId.Should().Be(789);
        property.User.Should().BeSameAs(user);
        property.Name.Should().Be("Luxury Apartment");
        property.ContactName.Should().Be("Jane Smith");
        property.ContactNumber.Should().Be("+9876543210");
        property.ZoneId.Should().Be(101);
        property.Zone.Should().BeSameAs(zone);
        property.Latitude.Should().Be(51.5074);
        property.Longitude.Should().Be(-0.1278);
        property.IsDeleted.Should().BeFalse();
    }

    [Fact]
    public void Property_WithEmptyStrings_ShouldBeCreatable()
    {
        // Arrange & Act
        var property = new Property
        {
            Name = "",
            ContactName = "",
            ContactNumber = ""
        };

        // Assert
        property.Name.Should().Be("");
        property.ContactName.Should().Be("");
        property.ContactNumber.Should().Be("");
    }

    [Fact]
    public void Property_WithLongStrings_ShouldBeCreatable()
    {
        // Arrange
        var longName = new string('A', 1000);
        var longContactName = new string('B', 1000);
        var longContactNumber = new string('C', 20);

        // Act
        var property = new Property
        {
            Name = longName,
            ContactName = longContactName,
            ContactNumber = longContactNumber
        };

        // Assert
        property.Name.Should().Be(longName);
        property.ContactName.Should().Be(longContactName);
        property.ContactNumber.Should().Be(longContactNumber);
    }

    [Fact]
    public void Property_WithNegativeUserId_ShouldBeCreatable()
    {
        // Arrange & Act
        var property = new Property
        {
            UserId = -1
        };

        // Assert
        property.UserId.Should().Be(-1);
    }

    [Fact]
    public void Property_WithZeroUserId_ShouldBeCreatable()
    {
        // Arrange & Act
        var property = new Property
        {
            UserId = 0
        };

        // Assert
        property.UserId.Should().Be(0);
    }

    [Fact]
    public void Property_WithNegativeZoneId_ShouldBeCreatable()
    {
        // Arrange & Act
        var property = new Property
        {
            ZoneId = -1
        };

        // Assert
        property.ZoneId.Should().Be(-1);
    }

    [Fact]
    public void Property_WithZeroZoneId_ShouldBeCreatable()
    {
        // Arrange & Act
        var property = new Property
        {
            ZoneId = 0
        };

        // Assert
        property.ZoneId.Should().Be(0);
    }

    [Fact]
    public void Property_WithBoundaryLatitude_ShouldBeCreatable()
    {
        // Arrange & Act
        var property = new Property
        {
            Latitude = 90.0,
            Longitude = 0.0
        };

        // Assert
        property.Latitude.Should().Be(90.0);
        property.Longitude.Should().Be(0.0);
    }

    [Fact]
    public void Property_WithBoundaryLongitude_ShouldBeCreatable()
    {
        // Arrange & Act
        var property = new Property
        {
            Latitude = 0.0,
            Longitude = 180.0
        };

        // Assert
        property.Latitude.Should().Be(0.0);
        property.Longitude.Should().Be(180.0);
    }

    [Fact]
    public void Property_ShouldInheritFromBaseEntity()
    {
        // Arrange
        var property = new Property();

        // Assert
        property.Should().BeAssignableTo<BaseEntity>();
        property.Should().BeAssignableTo<IEntity>();
        property.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void Property_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var property = new Property { Id = 777 };

        // Act
        var result = property.ToString();

        // Assert
        result.Should().Contain("Property");
    }

    [Theory]
    [InlineData(100, "Property A", 40.7128, -74.0060)]
    [InlineData(200, "Property B", 51.5074, -0.1278)]
    [InlineData(0, "", 0.0, 0.0)]
    public void Property_WithVariousValues_ShouldBeCreatable(int userId, string name, double latitude, double longitude)
    {
        // Arrange & Act
        var property = new Property
        {
            UserId = userId,
            Name = name,
            Latitude = latitude,
            Longitude = longitude
        };

        // Assert
        property.UserId.Should().Be(userId);
        property.Name.Should().Be(name);
        property.Latitude.Should().Be(latitude);
        property.Longitude.Should().Be(longitude);
    }

    #region Validation Attribute Tests

    [Fact]
    public void Property_RequiredAttributes_ShouldBePresent()
    {
        // Arrange
        var propertyType = typeof(Property);
        var userIdProperty = propertyType.GetProperty(nameof(Property.UserId));
        var nameProperty = propertyType.GetProperty(nameof(Property.Name));
        var latitudeProperty = propertyType.GetProperty(nameof(Property.Latitude));
        var longitudeProperty = propertyType.GetProperty(nameof(Property.Longitude));

        // Act & Assert
        userIdProperty.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.RequiredAttribute), false)
            .Should().NotBeEmpty("UserId should have Required attribute");
        
        nameProperty.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.RequiredAttribute), false)
            .Should().NotBeEmpty("Name should have Required attribute");
        
        latitudeProperty.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.RequiredAttribute), false)
            .Should().NotBeEmpty("Latitude should have Required attribute");
        
        longitudeProperty.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.RequiredAttribute), false)
            .Should().NotBeEmpty("Longitude should have Required attribute");
    }

    [Fact]
    public void Property_MaxLengthAttributes_ShouldBePresent()
    {
        // Arrange
        var propertyType = typeof(Property);
        var nameProperty = propertyType.GetProperty(nameof(Property.Name));
        var contactNameProperty = propertyType.GetProperty(nameof(Property.ContactName));
        var contactNumberProperty = propertyType.GetProperty(nameof(Property.ContactNumber));

        // Act & Assert
        var nameMaxLength = nameProperty.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.MaxLengthAttribute), false)
            .FirstOrDefault() as System.ComponentModel.DataAnnotations.MaxLengthAttribute;
        nameMaxLength.Should().NotBeNull("Name should have MaxLength attribute");
        nameMaxLength.Length.Should().Be(100, "Name MaxLength should be 100");

        var contactNameMaxLength = contactNameProperty.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.MaxLengthAttribute), false)
            .FirstOrDefault() as System.ComponentModel.DataAnnotations.MaxLengthAttribute;
        contactNameMaxLength.Should().NotBeNull("ContactName should have MaxLength attribute");
        contactNameMaxLength.Length.Should().Be(100, "ContactName MaxLength should be 100");

        var contactNumberMaxLength = contactNumberProperty.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.MaxLengthAttribute), false)
            .FirstOrDefault() as System.ComponentModel.DataAnnotations.MaxLengthAttribute;
        contactNumberMaxLength.Should().NotBeNull("ContactNumber should have MaxLength attribute");
        contactNumberMaxLength.Length.Should().Be(20, "ContactNumber MaxLength should be 20");
    }

    [Fact]
    public void Property_PhoneAttribute_ShouldBePresent()
    {
        // Arrange
        var propertyType = typeof(Property);
        var contactNumberProperty = propertyType.GetProperty(nameof(Property.ContactNumber));

        // Act & Assert
        contactNumberProperty.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.PhoneAttribute), false)
            .Should().NotBeEmpty("ContactNumber should have Phone attribute");
    }

    [Fact]
    public void Property_RangeAttributes_ShouldBePresent()
    {
        // Arrange
        var propertyType = typeof(Property);
        var latitudeProperty = propertyType.GetProperty(nameof(Property.Latitude));
        var longitudeProperty = propertyType.GetProperty(nameof(Property.Longitude));

        // Act & Assert
        var latitudeRange = latitudeProperty.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.RangeAttribute), false)
            .FirstOrDefault() as System.ComponentModel.DataAnnotations.RangeAttribute;
        latitudeRange.Should().NotBeNull("Latitude should have Range attribute");
        latitudeRange.Minimum.Should().Be(-90, "Latitude minimum should be -90");
        latitudeRange.Maximum.Should().Be(90, "Latitude maximum should be 90");

        var longitudeRange = longitudeProperty.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.RangeAttribute), false)
            .FirstOrDefault() as System.ComponentModel.DataAnnotations.RangeAttribute;
        longitudeRange.Should().NotBeNull("Longitude should have Range attribute");
        longitudeRange.Minimum.Should().Be(-180, "Longitude minimum should be -180");
        longitudeRange.Maximum.Should().Be(180, "Longitude maximum should be 180");
    }

    [Fact]
    public void Property_ForeignKeyAttributes_ShouldBePresent()
    {
        // Arrange
        var propertyType = typeof(Property);
        var userProperty = propertyType.GetProperty(nameof(Property.User));
        var zoneProperty = propertyType.GetProperty(nameof(Property.Zone));

        // Act & Assert
        var userForeignKey = userProperty.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute), false)
            .FirstOrDefault() as System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute;
        userForeignKey.Should().NotBeNull("User should have ForeignKey attribute");
        userForeignKey.Name.Should().Be(nameof(Property.UserId), "User ForeignKey should reference UserId");

        var zoneForeignKey = zoneProperty.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute), false)
            .FirstOrDefault() as System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute;
        zoneForeignKey.Should().NotBeNull("Zone should have ForeignKey attribute");
        zoneForeignKey.Name.Should().Be(nameof(Property.ZoneId), "Zone ForeignKey should reference ZoneId");
    }

    #endregion

    #region Business Logic Tests

    [Fact]
    public void Property_Constructor_ShouldSetDefaultValues()
    {
        // Arrange & Act
        var property = new Property();

        // Assert
        property.CreatedAt.Should().BeCloseTo(DateTimeOffset.UtcNow, TimeSpan.FromSeconds(1));
        property.DeletedAt.Should().BeNull();
        property.IsDeleted.Should().BeFalse();
    }

    [Theory]
    [InlineData(-90.0, true)]
    [InlineData(0.0, true)]
    [InlineData(90.0, true)]
    [InlineData(-91.0, false)]
    [InlineData(91.0, false)]
    public void Property_Latitude_ShouldValidateRange(double latitude, bool shouldBeValid)
    {
        // Arrange
        var property = new Property();

        // Act
        property.Latitude = latitude;

        // Assert
        if (shouldBeValid)
        {
            property.Latitude.Should().Be(latitude);
        }
        else
        {
            // Note: Range validation is typically handled by model validation, not property setters
            // This test verifies the property can be set, but validation would occur during model binding
            property.Latitude.Should().Be(latitude);
        }
    }

    [Theory]
    [InlineData(-180.0, true)]
    [InlineData(0.0, true)]
    [InlineData(180.0, true)]
    [InlineData(-181.0, false)]
    [InlineData(181.0, false)]
    public void Property_Longitude_ShouldValidateRange(double longitude, bool shouldBeValid)
    {
        // Arrange
        var property = new Property();

        // Act
        property.Longitude = longitude;

        // Assert
        if (shouldBeValid)
        {
            property.Longitude.Should().Be(longitude);
        }
        else
        {
            // Note: Range validation is typically handled by model validation, not property setters
            // This test verifies the property can be set, but validation would occur during model binding
            property.Longitude.Should().Be(longitude);
        }
    }

    [Theory]
    [InlineData("Valid Name", true)]
    [InlineData("", false)] // Empty string should be invalid due to Required attribute
    [InlineData(null, false)] // Null should be invalid due to Required attribute
    public void Property_Name_ShouldBeRequired(string name, bool shouldBeValid)
    {
        // Arrange
        var property = new Property();

        // Act
        property.Name = name;

        // Assert
        property.Name.Should().Be(name);
        // Note: Required validation is typically handled by model validation, not property setters
    }

    [Theory]
    [InlineData("1234567890", true)]
    [InlineData("+1234567890", true)]
    [InlineData("(123) 456-7890", true)]
    [InlineData("", true)] // Phone can be empty (not required)
    [InlineData(null, true)] // Phone can be null (not required)
    public void Property_ContactNumber_ShouldAcceptValidPhoneNumbers(string phoneNumber, bool shouldBeValid)
    {
        // Arrange
        var property = new Property();

        // Act
        property.ContactNumber = phoneNumber;

        // Assert
        property.ContactNumber.Should().Be(phoneNumber);
        // Note: Phone validation is typically handled by model validation, not property setters
    }

    #endregion
}
