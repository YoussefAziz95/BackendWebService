using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class ActionActorTests
{
    [Fact]
    public void ActionActor_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var actionActor = new ActionActor();

        // Assert
        actionActor.Should().NotBeNull();
    }

    [Fact]
    public void ActionActor_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var actionActor = new ActionActor();

        // Act
        var result = actionActor.ToString();

        // Assert
        result.Should().Contain("ActionActor");
    }

    [Fact]
    public void ActionActor_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var actionActor = new ActionActor();

        // Act & Assert
        actionActor.Should().BeAssignableTo<BaseEntity>();
        actionActor.Should().BeAssignableTo<IEntity>();
        actionActor.Should().BeAssignableTo<ITimeModification>();
    }
}
