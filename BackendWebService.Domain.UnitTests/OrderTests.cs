using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class OrderTests
{
    [Fact]
    public void Order_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var order = new Order();

        // Assert
        order.Should().NotBeNull();
    }

    [Fact]
    public void Order_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var order = new Order();

        // Act
        var result = order.ToString();

        // Assert
        result.Should().Contain("Order");
    }

    [Fact]
    public void Order_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var order = new Order();

        // Act & Assert
        order.Should().BeAssignableTo<BaseEntity>();
        order.Should().BeAssignableTo<IEntity>();
        order.Should().BeAssignableTo<ITimeModification>();
    }
}
