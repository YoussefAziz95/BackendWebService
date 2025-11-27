using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class SpareTests
{
    [Fact]
    public void Spare_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var spare = new Spare();

        // Assert
        spare.Should().NotBeNull();
        spare.IsAvailable.Should().BeNull();
        spare.RequiredAmount.Should().BeNull();
        spare.AvailableAmount.Should().BeNull();
        spare.ProductId.Should().BeNull();
        spare.Product.Should().BeNull();
    }

    [Fact]
    public void Spare_AllProperties_ShouldBeSettable()
    {
        // Arrange
        var spare = new Spare();
        var product = new Product();

        // Act
        spare.IsAvailable = true;
        spare.RequiredAmount = 10;
        spare.AvailableAmount = 5;
        spare.ProductId = 123;
        spare.Product = product;

        // Assert
        spare.IsAvailable.Should().BeTrue();
        spare.RequiredAmount.Should().Be(10);
        spare.AvailableAmount.Should().Be(5);
        spare.ProductId.Should().Be(123);
        spare.Product.Should().BeSameAs(product);
    }

    [Fact]
    public void Spare_WithNullValues_ShouldBeCreatable()
    {
        // Arrange & Act
        var spare = new Spare
        {
            IsAvailable = null!,
            RequiredAmount = null!,
            AvailableAmount = null!,
            ProductId = null!,
            Product = null!
        };

        // Assert
        spare.IsAvailable.Should().BeNull();
        spare.RequiredAmount.Should().BeNull();
        spare.AvailableAmount.Should().BeNull();
        spare.ProductId.Should().BeNull();
        spare.Product.Should().BeNull();
    }

    [Fact]
    public void Spare_WithNegativeAmounts_ShouldBeCreatable()
    {
        // Arrange & Act
        var spare = new Spare
        {
            RequiredAmount = -5,
            AvailableAmount = -2
        };

        // Assert
        spare.RequiredAmount.Should().Be(-5);
        spare.AvailableAmount.Should().Be(-2);
    }

    [Fact]
    public void Spare_WithZeroAmounts_ShouldBeCreatable()
    {
        // Arrange & Act
        var spare = new Spare
        {
            RequiredAmount = 0,
            AvailableAmount = 0
        };

        // Assert
        spare.RequiredAmount.Should().Be(0);
        spare.AvailableAmount.Should().Be(0);
    }

    [Fact]
    public void Spare_WithLargeAmounts_ShouldBeCreatable()
    {
        // Arrange & Act
        var spare = new Spare
        {
            RequiredAmount = int.MaxValue,
            AvailableAmount = int.MaxValue - 1
        };

        // Assert
        spare.RequiredAmount.Should().Be(int.MaxValue);
        spare.AvailableAmount.Should().Be(int.MaxValue - 1);
    }

    [Fact]
    public void Spare_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var spare = new Spare
        {
            IsAvailable = true,
            RequiredAmount = 1
        };

        // Assert
        spare.IsAvailable.Should().BeTrue();
        spare.RequiredAmount.Should().Be(1);
        spare.AvailableAmount.Should().BeNull();
        spare.ProductId.Should().BeNull();
    }

    [Fact]
    public void Spare_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange
        var product = new Product { Id = 456 };

        // Act
        var spare = new Spare
        {
            IsAvailable = true,
            RequiredAmount = 20,
            AvailableAmount = 15,
            ProductId = 456,
            Product = product
        };

        // Assert
        spare.IsAvailable.Should().BeTrue();
        spare.RequiredAmount.Should().Be(20);
        spare.AvailableAmount.Should().Be(15);
        spare.ProductId.Should().Be(456);
        spare.Product.Should().BeSameAs(product);
    }

    [Fact]
    public void Spare_ShouldInheritFromBaseEntity()
    {
        // Arrange
        var spare = new Spare();

        // Assert
        spare.Should().BeAssignableTo<BaseEntity>();
        spare.Should().BeAssignableTo<IEntity>();
        spare.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void Spare_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var spare = new Spare { Id = 789 };

        // Act
        var result = spare.ToString();

        // Assert
        result.Should().Contain("Spare");
    }

    [Theory]
    [InlineData(true, 10, 5)]
    [InlineData(false, 0, 0)]
    [InlineData(null!, 100, 50)]
    public void Spare_WithVariousValues_ShouldBeCreatable(bool? isAvailable, int? requiredAmount, int? availableAmount)
    {
        // Arrange & Act
        var spare = new Spare
        {
            IsAvailable = isAvailable,
            RequiredAmount = requiredAmount,
            AvailableAmount = availableAmount
        };

        // Assert
        spare.IsAvailable.Should().Be(isAvailable);
        spare.RequiredAmount.Should().Be(requiredAmount);
        spare.AvailableAmount.Should().Be(availableAmount);
    }
}
