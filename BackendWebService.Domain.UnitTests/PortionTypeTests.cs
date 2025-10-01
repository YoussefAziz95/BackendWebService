using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class PortionTypeTests
{
    [Fact]
    public void PortionType_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var portionType = new PortionType();

        // Assert
        portionType.Should().NotBeNull();
        portionType.Name.Should().BeNull();
        portionType.Description.Should().BeNull();
        portionType.UnitOfMeasure.Should().BeNull();
        portionType.Portions.Should().BeNull();
    }

    [Fact]
    public void PortionType_AllProperties_ShouldBeSettable()
    {
        // Arrange
        var portionType = new PortionType();
        var portions = new List<Portion>();

        // Act
        portionType.Name = "Small";
        portionType.Description = "Small portion size";
        portionType.UnitOfMeasure = "grams";
        portionType.Portions = portions;

        // Assert
        portionType.Name.Should().Be("Small");
        portionType.Description.Should().Be("Small portion size");
        portionType.UnitOfMeasure.Should().Be("grams");
        portionType.Portions.Should().BeSameAs(portions);
    }

    [Fact]
    public void PortionType_WithNullValues_ShouldBeCreatable()
    {
        // Arrange & Act
        var portionType = new PortionType
        {
            Name = null!,
            Description = null!,
            UnitOfMeasure = null!,
            Portions = null!
        };

        // Assert
        portionType.Name.Should().BeNull();
        portionType.Description.Should().BeNull();
        portionType.UnitOfMeasure.Should().BeNull();
        portionType.Portions.Should().BeNull();
    }

    [Fact]
    public void PortionType_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var portionType = new PortionType
        {
            Name = "Medium"
        };

        // Assert
        portionType.Name.Should().Be("Medium");
        portionType.Description.Should().BeNull();
        portionType.UnitOfMeasure.Should().BeNull();
    }

    [Fact]
    public void PortionType_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange
        var portions = new List<Portion> { new Portion() };

        // Act
        var portionType = new PortionType
        {
            Name = "Large",
            Description = "Large portion size for big appetites",
            UnitOfMeasure = "kilograms",
            Portions = portions
        };

        // Assert
        portionType.Name.Should().Be("Large");
        portionType.Description.Should().Be("Large portion size for big appetites");
        portionType.UnitOfMeasure.Should().Be("kilograms");
        portionType.Portions.Should().BeSameAs(portions);
    }

    [Fact]
    public void PortionType_WithEmptyStrings_ShouldBeCreatable()
    {
        // Arrange & Act
        var portionType = new PortionType
        {
            Name = "",
            Description = "",
            UnitOfMeasure = ""
        };

        // Assert
        portionType.Name.Should().Be("");
        portionType.Description.Should().Be("");
        portionType.UnitOfMeasure.Should().Be("");
    }

    [Fact]
    public void PortionType_WithLongStrings_ShouldBeCreatable()
    {
        // Arrange
        var longName = new string('A', 1000);
        var longDescription = new string('B', 2000);
        var longUnitOfMeasure = new string('C', 500);

        // Act
        var portionType = new PortionType
        {
            Name = longName,
            Description = longDescription,
            UnitOfMeasure = longUnitOfMeasure
        };

        // Assert
        portionType.Name.Should().Be(longName);
        portionType.Description.Should().Be(longDescription);
        portionType.UnitOfMeasure.Should().Be(longUnitOfMeasure);
    }

    [Fact]
    public void PortionType_WithValidUnits_ShouldBeCreatable()
    {
        // Arrange & Act
        var portionType = new PortionType
        {
            UnitOfMeasure = "ml"
        };

        // Assert
        portionType.UnitOfMeasure.Should().Be("ml");
    }

    [Fact]
    public void PortionType_WithSpecialCharacters_ShouldBeCreatable()
    {
        // Arrange & Act
        var portionType = new PortionType
        {
            Name = "Extra-Large",
            Description = "Extra large portion (XL) 🍕",
            UnitOfMeasure = "oz"
        };

        // Assert
        portionType.Name.Should().Be("Extra-Large");
        portionType.Description.Should().Be("Extra large portion (XL) 🍕");
        portionType.UnitOfMeasure.Should().Be("oz");
    }

    [Fact]
    public void PortionType_WithNumericUnits_ShouldBeCreatable()
    {
        // Arrange & Act
        var portionType = new PortionType
        {
            UnitOfMeasure = "100g"
        };

        // Assert
        portionType.UnitOfMeasure.Should().Be("100g");
    }

    [Fact]
    public void PortionType_WithEmptyPortions_ShouldBeCreatable()
    {
        // Arrange & Act
        var portionType = new PortionType
        {
            Portions = new List<Portion>()
        };

        // Assert
        portionType.Portions.Should().NotBeNull();
        portionType.Portions.Should().BeEmpty();
    }

    [Fact]
    public void PortionType_WithMultiplePortions_ShouldBeCreatable()
    {
        // Arrange
        var portions = new List<Portion>
        {
            new Portion { Id = 1 },
            new Portion { Id = 2 },
            new Portion { Id = 3 }
        };

        // Act
        var portionType = new PortionType
        {
            Portions = portions
        };

        // Assert
        portionType.Portions.Should().HaveCount(3);
        portionType.Portions.Should().Contain(portions);
    }

    [Fact]
    public void PortionType_ShouldInheritFromBaseEntity()
    {
        // Arrange
        var portionType = new PortionType();

        // Assert
        portionType.Should().BeAssignableTo<BaseEntity>();
        portionType.Should().BeAssignableTo<IEntity>();
        portionType.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void PortionType_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var portionType = new PortionType { Id = 555 };

        // Act
        var result = portionType.ToString();

        // Assert
        result.Should().Contain("PortionType");
    }

    [Theory]
    [InlineData("Tiny", "Very small portion", "mg")]
    [InlineData("Huge", "Very large portion", "kg")]
    [InlineData("", "", "")]
    public void PortionType_WithVariousValues_ShouldBeCreatable(string name, string description, string unitOfMeasure)
    {
        // Arrange & Act
        var portionType = new PortionType
        {
            Name = name,
            Description = description,
            UnitOfMeasure = unitOfMeasure
        };

        // Assert
        portionType.Name.Should().Be(name);
        portionType.Description.Should().Be(description);
        portionType.UnitOfMeasure.Should().Be(unitOfMeasure);
    }
}
