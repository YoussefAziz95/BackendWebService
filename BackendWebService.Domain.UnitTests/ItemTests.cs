using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class ItemTests
{
    [Fact]
    public void Item_DefaultConstructor_ShouldCreateInstance()
    {
        // Arrange & Act
        var item = new Item();

        // Assert
        item.Should().NotBeNull();
        item.Name.Should().BeNull();
        item.Description.Should().BeNull();
        item.UnitPrice.Should().Be(0);
        item.CategoryId.Should().Be(0);
        item.Category.Should().BeNull();
        item.PreparationTimeMinutes.Should().Be(0);
        item.PortionItems.Should().BeNull();
        item.IsActive.Should().BeTrue();
        item.IsDeleted.Should().BeFalse();
        item.IsSystem.Should().BeFalse();
        item.CreatedDate.Should().NotBeNull();
    }

    [Theory]
    [InlineData("Test Item")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("Very long item name that might exceed normal length expectations")]
    public void Item_Name_ShouldBeSettable(string name)
    {
        // Arrange
        var item = new Item();

        // Act
        item.Name = name;

        // Assert
        item.Name.Should().Be(name);
    }

    [Theory]
    [InlineData("Test Description")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("Very long description that might exceed normal length expectations")]
    public void Item_Description_ShouldBeSettable(string description)
    {
        // Arrange
        var item = new Item();

        // Act
        item.Description = description;

        // Assert
        item.Description.Should().Be(description);
    }

    [Theory]
    [InlineData(0.01)]
    [InlineData(10.50)]
    [InlineData(999.99)]
    [InlineData(0)]
    [InlineData(-1.50)]
    [InlineData(999999.99)]
    public void Item_UnitPrice_ShouldBeSettable(decimal unitPrice)
    {
        // Arrange
        var item = new Item();

        // Act
        item.UnitPrice = unitPrice;

        // Assert
        item.UnitPrice.Should().Be(unitPrice);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MaxValue)]
    public void Item_CategoryId_ShouldBeSettable(int categoryId)
    {
        // Arrange
        var item = new Item();

        // Act
        item.CategoryId = categoryId;

        // Assert
        item.CategoryId.Should().Be(categoryId);
    }

    [Fact]
    public void Item_Category_ShouldBeSettable()
    {
        // Arrange
        var item = new Item();
        var category = new Category();

        // Act
        item.Category = category;

        // Assert
        item.Category.Should().Be(category);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(30)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(1440)]
    [InlineData(int.MaxValue)]
    public void Item_PreparationTimeMinutes_ShouldBeSettable(int preparationTimeMinutes)
    {
        // Arrange
        var item = new Item();

        // Act
        item.PreparationTimeMinutes = preparationTimeMinutes;

        // Assert
        item.PreparationTimeMinutes.Should().Be(preparationTimeMinutes);
    }

    [Fact]
    public void Item_PortionItems_ShouldBeSettable()
    {
        // Arrange
        var item = new Item();
        var portionItem = new PortionItem();

        // Act
        item.PortionItems = new List<PortionItem> { portionItem };

        // Assert
        item.PortionItems.Should().NotBeNull();
        item.PortionItems.Should().Contain(portionItem);
    }

    [Fact]
    public void Item_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var item = new Item
        {
            Name = "Test Item",
            CategoryId = 1
        };

        // Assert
        item.Name.Should().Be("Test Item");
        item.CategoryId.Should().Be(1);
        item.UnitPrice.Should().Be(0);
        item.PreparationTimeMinutes.Should().Be(0);
        item.IsActive.Should().BeTrue();
    }

    [Fact]
    public void Item_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange & Act
        var category = new Category();
        var portionItem = new PortionItem();
        var item = new Item
        {
            Name = "Test Item",
            Description = "Test Description",
            UnitPrice = 15.99m,
            CategoryId = 1,
            Category = category,
            PreparationTimeMinutes = 30,
            PortionItems = new List<PortionItem> { portionItem }
        };

        // Assert
        item.Name.Should().Be("Test Item");
        item.Description.Should().Be("Test Description");
        item.UnitPrice.Should().Be(15.99m);
        item.CategoryId.Should().Be(1);
        item.Category.Should().Be(category);
        item.PreparationTimeMinutes.Should().Be(30);
        item.PortionItems.Should().Contain(portionItem);
    }

    [Fact]
    public void Item_WithNullName_ShouldBeCreatable()
    {
        // Arrange & Act
        var item = new Item
        {
            Name = null,
            CategoryId = 1
        };

        // Assert
        item.Name.Should().BeNull();
        item.CategoryId.Should().Be(1);
    }

    [Fact]
    public void Item_WithEmptyName_ShouldBeCreatable()
    {
        // Arrange & Act
        var item = new Item
        {
            Name = "",
            CategoryId = 1
        };

        // Assert
        item.Name.Should().Be("");
        item.CategoryId.Should().Be(1);
    }

    [Fact]
    public void Item_WithZeroCategoryId_ShouldBeCreatable()
    {
        // Arrange & Act
        var item = new Item
        {
            Name = "Test Item",
            CategoryId = 0
        };

        // Assert
        item.Name.Should().Be("Test Item");
        item.CategoryId.Should().Be(0);
    }

    [Fact]
    public void Item_WithNegativeCategoryId_ShouldBeCreatable()
    {
        // Arrange & Act
        var item = new Item
        {
            Name = "Test Item",
            CategoryId = -1
        };

        // Assert
        item.Name.Should().Be("Test Item");
        item.CategoryId.Should().Be(-1);
    }

    [Fact]
    public void Item_WithNullCategory_ShouldBeCreatable()
    {
        // Arrange & Act
        var item = new Item
        {
            Name = "Test Item",
            CategoryId = 1,
            Category = null
        };

        // Assert
        item.Name.Should().Be("Test Item");
        item.CategoryId.Should().Be(1);
        item.Category.Should().BeNull();
    }

    [Fact]
    public void Item_WithNullPortionItems_ShouldBeCreatable()
    {
        // Arrange & Act
        var item = new Item
        {
            Name = "Test Item",
            CategoryId = 1,
            PortionItems = null
        };

        // Assert
        item.Name.Should().Be("Test Item");
        item.CategoryId.Should().Be(1);
        item.PortionItems.Should().BeNull();
    }

    [Fact]
    public void Item_WithNegativeUnitPrice_ShouldBeCreatable()
    {
        // Arrange & Act
        var item = new Item
        {
            Name = "Test Item",
            CategoryId = 1,
            UnitPrice = -10.50m
        };

        // Assert
        item.Name.Should().Be("Test Item");
        item.CategoryId.Should().Be(1);
        item.UnitPrice.Should().Be(-10.50m);
    }

    [Fact]
    public void Item_WithNegativePreparationTime_ShouldBeCreatable()
    {
        // Arrange & Act
        var item = new Item
        {
            Name = "Test Item",
            CategoryId = 1,
            PreparationTimeMinutes = -30
        };

        // Assert
        item.Name.Should().Be("Test Item");
        item.CategoryId.Should().Be(1);
        item.PreparationTimeMinutes.Should().Be(-30);
    }

    [Fact]
    public void Item_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var item = new Item { Name = "Test Item" };

        // Act
        var result = item.ToString();

        // Assert
        result.Should().Contain("Item");
    }

    [Fact]
    public void Item_ShouldInheritFromBaseEntity()
    {
        // Arrange & Act
        var item = new Item();

        // Assert
        item.Should().BeAssignableTo<BaseEntity>();
        item.Should().BeAssignableTo<IEntity>();
        item.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void Item_AllProperties_ShouldBeSettable()
    {
        // Arrange
        var item = new Item();
        var category = new Category();
        var portionItem = new PortionItem();

        // Act
        item.Name = "Test Item";
        item.Description = "Test Description";
        item.UnitPrice = 15.99m;
        item.CategoryId = 1;
        item.Category = category;
        item.PreparationTimeMinutes = 30;
        item.PortionItems = new List<PortionItem> { portionItem };

        // Assert
        item.Name.Should().Be("Test Item");
        item.Description.Should().Be("Test Description");
        item.UnitPrice.Should().Be(15.99m);
        item.CategoryId.Should().Be(1);
        item.Category.Should().Be(category);
        item.PreparationTimeMinutes.Should().Be(30);
        item.PortionItems.Should().Contain(portionItem);
    }
}
