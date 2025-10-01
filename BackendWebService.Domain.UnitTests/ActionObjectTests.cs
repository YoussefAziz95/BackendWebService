using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class ActionObjectTests
{
    [Fact]
    public void ActionObject_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var actionObject = new ActionObject();

        // Assert
        actionObject.Should().NotBeNull();
    }

    [Fact]
    public void ActionObject_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var actionObject = new ActionObject();

        // Act
        var result = actionObject.ToString();

        // Assert
        result.Should().Contain("ActionObject");
    }

    [Fact]
    public void ActionObject_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var actionObject = new ActionObject();

        // Act & Assert
        actionObject.Should().BeAssignableTo<BaseEntity>();
        actionObject.Should().BeAssignableTo<IEntity>();
        actionObject.Should().BeAssignableTo<ITimeModification>();
    }
}
