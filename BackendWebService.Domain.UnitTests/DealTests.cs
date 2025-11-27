using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class DealTests
{
    [Fact]
    public void Deal_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var deal = new Deal();

        // Assert
        deal.Should().NotBeNull();
    }

    [Fact]
    public void Deal_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var deal = new Deal();

        // Act
        var result = deal.ToString();

        // Assert
        result.Should().Contain("Deal");
    }

    [Fact]
    public void Deal_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var deal = new Deal();

        // Act & Assert
        deal.Should().BeAssignableTo<BaseEntity>();
        deal.Should().BeAssignableTo<IEntity>();
        deal.Should().BeAssignableTo<ITimeModification>();
    }
}
