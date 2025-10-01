using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class PortionTests
{
    [Fact]
    public void Portion_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var portion = new Portion();

        // Assert
        portion.Should().NotBeNull();
    }

    [Fact]
    public void Portion_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var portion = new Portion();

        // Act
        var result = portion.ToString();

        // Assert
        result.Should().Contain("Portion");
    }

    [Fact]
    public void Portion_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var portion = new Portion();

        // Act & Assert
        portion.Should().BeAssignableTo<BaseEntity>();
        portion.Should().BeAssignableTo<IEntity>();
        portion.Should().BeAssignableTo<ITimeModification>();
    }
}
