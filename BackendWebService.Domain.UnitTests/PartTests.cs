using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class PartTests
{
    [Fact]
    public void Part_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var part = new Part();

        // Assert
        part.Should().NotBeNull();
    }

    [Fact]
    public void Part_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var part = new Part();

        // Act
        var result = part.ToString();

        // Assert
        result.Should().Contain("Part");
    }

    [Fact]
    public void Part_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var part = new Part();

        // Act & Assert
        part.Should().BeAssignableTo<BaseEntity>();
        part.Should().BeAssignableTo<IEntity>();
        part.Should().BeAssignableTo<ITimeModification>();
    }
}
