using Domain;
using Domain.Enums;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class ZoneTests
{
    [Fact]
    public void Zone_DefaultConstructor_ShouldCreateInstance()
    {
        // Arrange & Act
        var zone = new Zone();

        // Assert
        zone.Should().NotBeNull();
        zone.Name.Should().BeNull();
        zone.Description.Should().BeNull();
        zone.ParentZoneId.Should().BeNull();
        zone.ParentZone.Should().BeNull();
        zone.SubZones.Should().NotBeNull();
        zone.SubZones.Should().BeEmpty();
        zone.IsActive.Should().BeTrue();
        zone.IsDeleted.Should().BeFalse();
        zone.IsSystem.Should().BeFalse();
        zone.CreatedDate.Should().NotBeNull();
    }

    [Theory]
    [InlineData("North Zone")]
    [InlineData("South Zone")]
    [InlineData("East Zone")]
    [InlineData("West Zone")]
    [InlineData("Central Zone")]
    public void Zone_Name_ShouldBeSettable(string name)
    {
        // Arrange
        var zone = new Zone();

        // Act
        zone.Name = name;

        // Assert
        zone.Name.Should().Be(name);
    }

    [Theory]
    [InlineData("A zone for testing")]
    [InlineData("")]
    [InlineData("Very long description that might exceed normal length expectations")]
    public void Zone_Description_ShouldBeSettable(string description)
    {
        // Arrange
        var zone = new Zone();

        // Act
        zone.Description = description;

        // Assert
        zone.Description.Should().Be(description);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MaxValue)]
    public void Zone_ParentZoneId_ShouldBeSettable(int? parentZoneId)
    {
        // Arrange
        var zone = new Zone();

        // Act
        zone.ParentZoneId = parentZoneId;

        // Assert
        zone.ParentZoneId.Should().Be(parentZoneId);
    }

    [Fact]
    public void Zone_ParentZone_ShouldBeSettable()
    {
        // Arrange
        var zone = new Zone();
        var parentZone = new Zone { Name = "Parent Zone" };

        // Act
        zone.ParentZone = parentZone;

        // Assert
        zone.ParentZone.Should().Be(parentZone);
    }

    [Fact]
    public void Zone_SubZones_ShouldAcceptMultipleItems()
    {
        // Arrange
        var zone = new Zone();
        var subZone1 = new Zone { Name = "Sub Zone 1" };
        var subZone2 = new Zone { Name = "Sub Zone 2" };

        // Act
        zone.SubZones.Add(subZone1);
        zone.SubZones.Add(subZone2);

        // Assert
        zone.SubZones.Should().HaveCount(2);
        zone.SubZones.Should().Contain(subZone1);
        zone.SubZones.Should().Contain(subZone2);
    }

    [Fact]
    public void Zone_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var zone = new Zone
        {
            Name = "Test Zone"
        };

        // Assert
        zone.Name.Should().Be("Test Zone");
        zone.Description.Should().BeNull();
        zone.ParentZoneId.Should().BeNull();
        zone.IsActive.Should().BeTrue();
    }

    [Fact]
    public void Zone_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange & Act
        var parentZone = new Zone { Name = "Parent Zone" };
        var zone = new Zone
        {
            Name = "Child Zone",
            Description = "A child zone for testing",
            ParentZoneId = 1,
            ParentZone = parentZone
        };

        // Assert
        zone.Name.Should().Be("Child Zone");
        zone.Description.Should().Be("A child zone for testing");
        zone.ParentZoneId.Should().Be(1);
        zone.ParentZone.Should().Be(parentZone);
    }

    [Fact]
    public void Zone_WithNullName_ShouldBeCreatable()
    {
        // Arrange & Act
        var zone = new Zone
        {
            Name = null!
        };

        // Assert
        zone.Name.Should().BeNull();
        zone.IsActive.Should().BeTrue();
    }

    [Fact]
    public void Zone_WithEmptyName_ShouldBeCreatable()
    {
        // Arrange & Act
        var zone = new Zone
        {
            Name = ""
        };

        // Assert
        zone.Name.Should().Be("");
        zone.IsActive.Should().BeTrue();
    }

    [Fact]
    public void Zone_WithZeroParentZoneId_ShouldBeCreatable()
    {
        // Arrange & Act
        var zone = new Zone
        {
            Name = "Test Zone",
            ParentZoneId = 0
        };

        // Assert
        zone.ParentZoneId.Should().Be(0);
        zone.Name.Should().Be("Test Zone");
    }

    [Fact]
    public void Zone_WithNegativeParentZoneId_ShouldBeCreatable()
    {
        // Arrange & Act
        var zone = new Zone
        {
            Name = "Test Zone",
            ParentZoneId = -1
        };

        // Assert
        zone.ParentZoneId.Should().Be(-1);
        zone.Name.Should().Be("Test Zone");
    }

    [Fact]
    public void Zone_WithNullParentZone_ShouldBeCreatable()
    {
        // Arrange & Act
        var zone = new Zone
        {
            Name = "Test Zone",
            ParentZone = null
        };

        // Assert
        zone.ParentZone.Should().BeNull();
        zone.Name.Should().Be("Test Zone");
    }

    [Fact]
    public void Zone_SubZones_ShouldBeInitializedAsEmptyList()
    {
        // Arrange & Act
        var zone = new Zone();

        // Assert
        zone.SubZones.Should().NotBeNull();
        zone.SubZones.Should().BeEmpty();
    }

    [Fact]
    public void Zone_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var zone = new Zone { Name = "Test Zone" };

        // Act
        var result = zone.ToString();

        // Assert
        result.Should().Contain("Zone");
    }

    [Fact]
    public void Zone_ShouldInheritFromBaseEntity()
    {
        // Arrange & Act
        var zone = new Zone();

        // Assert
        zone.Should().BeAssignableTo<BaseEntity>();
        zone.Should().BeAssignableTo<IEntity>();
        zone.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void Zone_AllProperties_ShouldBeSettable()
    {
        // Arrange
        var zone = new Zone();
        var parentZone = new Zone { Name = "Parent" };
        var subZone = new Zone { Name = "Sub" };

        // Act
        zone.Name = "Test Zone";
        zone.Description = "Test Description";
        zone.ParentZoneId = 1;
        zone.ParentZone = parentZone;
        zone.SubZones.Add(subZone);

        // Assert
        zone.Name.Should().Be("Test Zone");
        zone.Description.Should().Be("Test Description");
        zone.ParentZoneId.Should().Be(1);
        zone.ParentZone.Should().Be(parentZone);
        zone.SubZones.Should().Contain(subZone);
    }
}
