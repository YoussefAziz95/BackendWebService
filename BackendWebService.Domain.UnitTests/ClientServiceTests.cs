using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class ClientServiceTests
{
    [Fact]
    public void ClientService_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var clientService = new ClientService();

        // Assert
        clientService.Should().NotBeNull();
    }

    [Fact]
    public void ClientService_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var clientService = new ClientService();

        // Act
        var result = clientService.ToString();

        // Assert
        result.Should().Contain("ClientService");
    }

    [Fact]
    public void ClientService_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var clientService = new ClientService();

        // Act & Assert
        clientService.Should().BeAssignableTo<BaseEntity>();
        clientService.Should().BeAssignableTo<IEntity>();
        clientService.Should().BeAssignableTo<ITimeModification>();
    }
}
