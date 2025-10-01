using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class OrderItemTests
{
    [Fact]
    public void OrderItem_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var orderItem = new OrderItem();

        // Assert
        orderItem.Should().NotBeNull();
    }

    [Fact]
    public void OrderItem_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var orderItem = new OrderItem();

        // Act
        var result = orderItem.ToString();

        // Assert
        result.Should().Contain("OrderItem");
    }

    [Fact]
    public void OrderItem_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var orderItem = new OrderItem();

        // Act & Assert
        orderItem.Should().BeAssignableTo<BaseEntity>();
        orderItem.Should().BeAssignableTo<IEntity>();
        orderItem.Should().BeAssignableTo<ITimeModification>();
    }
}
