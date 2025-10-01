using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class InventoryTests
{
    [Fact]
    public void Inventory_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var inventory = new Inventory();

        // Assert
        inventory.Should().NotBeNull();
        inventory.Name.Should().BeNull();
        inventory.CategoryId.Should().BeNull();
        inventory.Category.Should().BeNull();
        inventory.StorageUnits.Should().BeNull();
        inventory.Items.Should().BeNull();
    }

    [Fact]
    public void Inventory_AllProperties_ShouldBeSettable()
    {
        // Arrange
        var inventory = new Inventory();
        var category = new Category();
        var storageUnits = new List<StorageUnit>();
        var items = new List<Item>();

        // Act
        inventory.Name = "Main Warehouse";
        inventory.CategoryId = 123;
        inventory.Category = category;
        inventory.StorageUnits = storageUnits;
        inventory.Items = items;

        // Assert
        inventory.Name.Should().Be("Main Warehouse");
        inventory.CategoryId.Should().Be(123);
        inventory.Category.Should().BeSameAs(category);
        inventory.StorageUnits.Should().BeSameAs(storageUnits);
        inventory.Items.Should().BeSameAs(items);
    }

    [Fact]
    public void Inventory_WithNullValues_ShouldBeCreatable()
    {
        // Arrange & Act
        var inventory = new Inventory
        {
            Name = null!,
            CategoryId = null!,
            Category = null!,
            StorageUnits = null!,
            Items = null!
        };

        // Assert
        inventory.Name.Should().BeNull();
        inventory.CategoryId.Should().BeNull();
        inventory.Category.Should().BeNull();
        inventory.StorageUnits.Should().BeNull();
        inventory.Items.Should().BeNull();
    }

    [Fact]
    public void Inventory_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var inventory = new Inventory
        {
            Name = "Storage Room"
        };

        // Assert
        inventory.Name.Should().Be("Storage Room");
        inventory.CategoryId.Should().BeNull();
        inventory.Category.Should().BeNull();
        inventory.StorageUnits.Should().BeNull();
        inventory.Items.Should().BeNull();
    }

    [Fact]
    public void Inventory_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange
        var category = new Category { Id = 456 };
        var storageUnits = new List<StorageUnit> { new StorageUnit() };
        var items = new List<Item> { new Item() };

        // Act
        var inventory = new Inventory
        {
            Name = "Distribution Center",
            CategoryId = 456,
            Category = category,
            StorageUnits = storageUnits,
            Items = items
        };

        // Assert
        inventory.Name.Should().Be("Distribution Center");
        inventory.CategoryId.Should().Be(456);
        inventory.Category.Should().BeSameAs(category);
        inventory.StorageUnits.Should().BeSameAs(storageUnits);
        inventory.Items.Should().BeSameAs(items);
    }

    [Fact]
    public void Inventory_WithEmptyStrings_ShouldBeCreatable()
    {
        // Arrange & Act
        var inventory = new Inventory
        {
            Name = ""
        };

        // Assert
        inventory.Name.Should().Be("");
    }

    [Fact]
    public void Inventory_WithLongStrings_ShouldBeCreatable()
    {
        // Arrange
        var longName = new string('A', 1000);

        // Act
        var inventory = new Inventory
        {
            Name = longName
        };

        // Assert
        inventory.Name.Should().Be(longName);
    }

    [Fact]
    public void Inventory_WithNegativeCategoryId_ShouldBeCreatable()
    {
        // Arrange & Act
        var inventory = new Inventory
        {
            CategoryId = -1
        };

        // Assert
        inventory.CategoryId.Should().Be(-1);
    }

    [Fact]
    public void Inventory_WithZeroCategoryId_ShouldBeCreatable()
    {
        // Arrange & Act
        var inventory = new Inventory
        {
            CategoryId = 0
        };

        // Assert
        inventory.CategoryId.Should().Be(0);
    }

    [Fact]
    public void Inventory_WithEmptyCollections_ShouldBeCreatable()
    {
        // Arrange & Act
        var inventory = new Inventory
        {
            StorageUnits = new List<StorageUnit>(),
            Items = new List<Item>()
        };

        // Assert
        inventory.StorageUnits.Should().NotBeNull();
        inventory.StorageUnits.Should().BeEmpty();
        inventory.Items.Should().NotBeNull();
        inventory.Items.Should().BeEmpty();
    }

    [Fact]
    public void Inventory_WithMultipleStorageUnits_ShouldBeCreatable()
    {
        // Arrange
        var storageUnits = new List<StorageUnit>
        {
            new StorageUnit { Id = 1 },
            new StorageUnit { Id = 2 },
            new StorageUnit { Id = 3 }
        };

        // Act
        var inventory = new Inventory
        {
            StorageUnits = storageUnits
        };

        // Assert
        inventory.StorageUnits.Should().HaveCount(3);
        inventory.StorageUnits.Should().Contain(storageUnits);
    }

    [Fact]
    public void Inventory_WithMultipleItems_ShouldBeCreatable()
    {
        // Arrange
        var items = new List<Item>
        {
            new Item { Id = 1 },
            new Item { Id = 2 },
            new Item { Id = 3 }
        };

        // Act
        var inventory = new Inventory
        {
            Items = items
        };

        // Assert
        inventory.Items.Should().HaveCount(3);
        inventory.Items.Should().Contain(items);
    }

    [Fact]
    public void Inventory_ShouldInheritFromBaseEntity()
    {
        // Arrange
        var inventory = new Inventory();

        // Assert
        inventory.Should().BeAssignableTo<BaseEntity>();
        inventory.Should().BeAssignableTo<IEntity>();
        inventory.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void Inventory_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var inventory = new Inventory { Id = 999 };

        // Act
        var result = inventory.ToString();

        // Assert
        result.Should().Contain("Inventory");
    }

    [Theory]
    [InlineData("Warehouse A", 100)]
    [InlineData("Cold Storage", 200)]
    [InlineData("", 0)]
    public void Inventory_WithVariousValues_ShouldBeCreatable(string name, int? categoryId)
    {
        // Arrange & Act
        var inventory = new Inventory
        {
            Name = name,
            CategoryId = categoryId
        };

        // Assert
        inventory.Name.Should().Be(name);
        inventory.CategoryId.Should().Be(categoryId);
    }
}
