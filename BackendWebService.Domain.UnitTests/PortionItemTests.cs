using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class PortionItemTests
{
    [Fact]
    public void PortionItem_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var portionItem = new PortionItem();

        // Assert
        portionItem.Should().NotBeNull();
    }

    [Fact]
    public void PortionItem_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var portionItem = new PortionItem();

        // Act
        var result = portionItem.ToString();

        // Assert
        result.Should().Contain("PortionItem");
    }

    [Fact]
    public void PortionItem_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var portionItem = new PortionItem();

        // Act & Assert
        portionItem.Should().BeAssignableTo<BaseEntity>();
        portionItem.Should().BeAssignableTo<IEntity>();
        portionItem.Should().BeAssignableTo<ITimeModification>();
    }
}
