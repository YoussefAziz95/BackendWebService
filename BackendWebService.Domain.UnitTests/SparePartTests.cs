using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class SparePartTests
{
    [Fact]
    public void SparePart_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var sparePart = new SparePart();

        // Assert
        sparePart.Should().NotBeNull();
    }

    [Fact]
    public void SparePart_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var sparePart = new SparePart();

        // Act
        var result = sparePart.ToString();

        // Assert
        result.Should().Contain("SparePart");
    }

    [Fact]
    public void SparePart_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var sparePart = new SparePart();

        // Act & Assert
        sparePart.Should().BeAssignableTo<BaseEntity>();
        sparePart.Should().BeAssignableTo<IEntity>();
        sparePart.Should().BeAssignableTo<ITimeModification>();
    }
}
