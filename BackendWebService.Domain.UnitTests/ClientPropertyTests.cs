using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class ClientPropertyTests
{
    [Fact]
    public void ClientProperty_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var clientProperty = new ClientProperty();

        // Assert
        clientProperty.Should().NotBeNull();
    }

    [Fact]
    public void ClientProperty_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var clientProperty = new ClientProperty();

        // Act
        var result = clientProperty.ToString();

        // Assert
        result.Should().Contain("ClientProperty");
    }

    [Fact]
    public void ClientProperty_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var clientProperty = new ClientProperty();

        // Act & Assert
        clientProperty.Should().BeAssignableTo<BaseEntity>();
        clientProperty.Should().BeAssignableTo<IEntity>();
        clientProperty.Should().BeAssignableTo<ITimeModification>();
    }
}
