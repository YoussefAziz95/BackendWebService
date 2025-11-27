using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class ManagerTests
{
    [Fact]
    public void Manager_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var manager = new Manager();

        // Assert
        manager.Should().NotBeNull();
    }

    [Fact]
    public void Manager_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var manager = new Manager();

        // Act
        var result = manager.ToString();

        // Assert
        result.Should().Contain("Manager");
    }

    [Fact]
    public void Manager_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var manager = new Manager();

        // Act & Assert
        manager.Should().BeAssignableTo<BaseEntity>();
        manager.Should().BeAssignableTo<IEntity>();
        manager.Should().BeAssignableTo<ITimeModification>();
    }
}
