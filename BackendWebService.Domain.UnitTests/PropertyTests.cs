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
}
