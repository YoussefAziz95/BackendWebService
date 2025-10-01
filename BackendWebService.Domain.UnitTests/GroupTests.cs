using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class GroupTests
{
    [Fact]
    public void Group_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var group = new Group();

        // Assert
        group.Should().NotBeNull();
    }

    [Fact]
    public void Group_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var group = new Group();

        // Act
        var result = group.ToString();

        // Assert
        result.Should().Contain("Group");
    }

    [Fact]
    public void Group_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var group = new Group();

        // Act & Assert
        group.Should().BeAssignableTo<BaseEntity>();
        group.Should().BeAssignableTo<IEntity>();
        group.Should().BeAssignableTo<ITimeModification>();
    }
}
