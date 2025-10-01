using Domain;
using Domain.Enums;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class StorageUnitTests
{
    [Fact]
    public void StorageUnit_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var storageUnit = new StorageUnit();

        // Assert
        storageUnit.Should().NotBeNull();
        storageUnit.InventoryId.Should().Be(0);
        storageUnit.Inventory.Should().BeNull();
        storageUnit.PortionTypeId.Should().BeNull();
        storageUnit.PortionType.Should().BeNull();
        storageUnit.FullQuantity.Should().Be(0);
        storageUnit.Unit.Should().Be((UnitEnum)0);
    }

    [Fact]
    public void StorageUnit_AllProperties_ShouldBeSettable()
    {
        // Arrange
        var storageUnit = new StorageUnit();
        var inventory = new Inventory();
        var portionType = new PortionType();

        // Act
        storageUnit.InventoryId = 123;
        storageUnit.Inventory = inventory;
        storageUnit.PortionTypeId = 456;
        storageUnit.PortionType = portionType;
        storageUnit.FullQuantity = 100;
        storageUnit.Unit = UnitEnum.Kg;

        // Assert
        storageUnit.InventoryId.Should().Be(123);
        storageUnit.Inventory.Should().BeSameAs(inventory);
        storageUnit.PortionTypeId.Should().Be(456);
        storageUnit.PortionType.Should().BeSameAs(portionType);
        storageUnit.FullQuantity.Should().Be(100);
        storageUnit.Unit.Should().Be(UnitEnum.Kg);
    }

    [Fact]
    public void StorageUnit_WithNullValues_ShouldBeCreatable()
    {
        // Arrange & Act
        var storageUnit = new StorageUnit
        {
            Inventory = null,
            PortionTypeId = null,
            PortionType = null
        };

        // Assert
        storageUnit.Inventory.Should().BeNull();
        storageUnit.PortionTypeId.Should().BeNull();
        storageUnit.PortionType.Should().BeNull();
    }

    [Fact]
    public void StorageUnit_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var storageUnit = new StorageUnit
        {
            InventoryId = 1,
            FullQuantity = 50,
            Unit = UnitEnum.L
        };

        // Assert
        storageUnit.InventoryId.Should().Be(1);
        storageUnit.FullQuantity.Should().Be(50);
        storageUnit.Unit.Should().Be(UnitEnum.L);
    }

    [Fact]
    public void StorageUnit_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange
        var inventory = new Inventory { Id = 789 };
        var portionType = new PortionType { Id = 101 };

        // Act
        var storageUnit = new StorageUnit
        {
            InventoryId = 789,
            Inventory = inventory,
            PortionTypeId = 101,
            PortionType = portionType,
            FullQuantity = 200,
            Unit = UnitEnum.Piece
        };

        // Assert
        storageUnit.InventoryId.Should().Be(789);
        storageUnit.Inventory.Should().BeSameAs(inventory);
        storageUnit.PortionTypeId.Should().Be(101);
        storageUnit.PortionType.Should().BeSameAs(portionType);
        storageUnit.FullQuantity.Should().Be(200);
        storageUnit.Unit.Should().Be(UnitEnum.Piece);
    }

    [Fact]
    public void StorageUnit_WithNegativeInventoryId_ShouldBeCreatable()
    {
        // Arrange & Act
        var storageUnit = new StorageUnit
        {
            InventoryId = -1
        };

        // Assert
        storageUnit.InventoryId.Should().Be(-1);
    }

    [Fact]
    public void StorageUnit_WithZeroInventoryId_ShouldBeCreatable()
    {
        // Arrange & Act
        var storageUnit = new StorageUnit
        {
            InventoryId = 0
        };

        // Assert
        storageUnit.InventoryId.Should().Be(0);
    }

    [Fact]
    public void StorageUnit_WithNegativeFullQuantity_ShouldBeCreatable()
    {
        // Arrange & Act
        var storageUnit = new StorageUnit
        {
            FullQuantity = -100
        };

        // Assert
        storageUnit.FullQuantity.Should().Be(-100);
    }

    [Fact]
    public void StorageUnit_WithZeroFullQuantity_ShouldBeCreatable()
    {
        // Arrange & Act
        var storageUnit = new StorageUnit
        {
            FullQuantity = 0
        };

        // Assert
        storageUnit.FullQuantity.Should().Be(0);
    }

    [Fact]
    public void StorageUnit_WithLargeFullQuantity_ShouldBeCreatable()
    {
        // Arrange & Act
        var storageUnit = new StorageUnit
        {
            FullQuantity = int.MaxValue
        };

        // Assert
        storageUnit.FullQuantity.Should().Be(int.MaxValue);
    }

    [Fact]
    public void StorageUnit_WithNegativePortionTypeId_ShouldBeCreatable()
    {
        // Arrange & Act
        var storageUnit = new StorageUnit
        {
            PortionTypeId = -1
        };

        // Assert
        storageUnit.PortionTypeId.Should().Be(-1);
    }

    [Fact]
    public void StorageUnit_WithZeroPortionTypeId_ShouldBeCreatable()
    {
        // Arrange & Act
        var storageUnit = new StorageUnit
        {
            PortionTypeId = 0
        };

        // Assert
        storageUnit.PortionTypeId.Should().Be(0);
    }

    [Fact]
    public void StorageUnit_ShouldInheritFromBaseEntity()
    {
        // Arrange
        var storageUnit = new StorageUnit();

        // Assert
        storageUnit.Should().BeAssignableTo<BaseEntity>();
        storageUnit.Should().BeAssignableTo<IEntity>();
        storageUnit.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void StorageUnit_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var storageUnit = new StorageUnit { Id = 888 };

        // Act
        var result = storageUnit.ToString();

        // Assert
        result.Should().Contain("StorageUnit");
    }

    [Theory]
    [InlineData(100, 50, UnitEnum.Kg)]
    [InlineData(200, 75, UnitEnum.L)]
    [InlineData(0, 0, UnitEnum.Piece)]
    public void StorageUnit_WithVariousValues_ShouldBeCreatable(int inventoryId, int fullQuantity, UnitEnum unit)
    {
        // Arrange & Act
        var storageUnit = new StorageUnit
        {
            InventoryId = inventoryId,
            FullQuantity = fullQuantity,
            Unit = unit
        };

        // Assert
        storageUnit.InventoryId.Should().Be(inventoryId);
        storageUnit.FullQuantity.Should().Be(fullQuantity);
        storageUnit.Unit.Should().Be(unit);
    }
}
