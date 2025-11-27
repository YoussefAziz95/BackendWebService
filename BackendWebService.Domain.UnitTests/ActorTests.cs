using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class ActorTests
{
    [Fact]
    public void Actor_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var actor = new Actor();

        // Assert
        actor.Should().NotBeNull();
    }

    [Fact]
    public void Actor_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var actor = new Actor();

        // Act
        var result = actor.ToString();

        // Assert
        result.Should().Contain("Actor");
    }

    [Fact]
    public void Actor_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var actor = new Actor();

        // Act & Assert
        actor.Should().BeAssignableTo<BaseEntity>();
        actor.Should().BeAssignableTo<IEntity>();
        actor.Should().BeAssignableTo<ITimeModification>();
    }
}
