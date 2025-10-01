using Domain;
using Domain.Enums;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class ClientTests
{
    [Fact]
    public void Client_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var client = new Client();

        // Assert
        client.Should().NotBeNull();
        client.MFAEnabled.Should().BeFalse();
        client.Role.Should().Be(RoleEnum.Customer);
        client.Status.Should().Be(StatusEnum.Active);
    }

    [Fact]
    public void Client_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange
        var userId = 123;

        // Act
        var client = new Client
        {
            UserId = userId
        };

        // Assert
        client.UserId.Should().Be(userId);
        client.MFAEnabled.Should().BeFalse();
        client.Role.Should().Be(RoleEnum.Customer);
        client.Status.Should().Be(StatusEnum.Active);
    }

    [Fact]
    public void Client_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange
        var userId = 456;
        var mfaEnabled = true;
        var role = RoleEnum.Admin;
        var status = StatusEnum.Pending;

        // Act
        var client = new Client
        {
            UserId = userId,
            MFAEnabled = mfaEnabled,
            Role = role,
            Status = status
        };

        // Assert
        client.UserId.Should().Be(userId);
        client.MFAEnabled.Should().Be(mfaEnabled);
        client.Role.Should().Be(role);
        client.Status.Should().Be(status);
    }

    [Theory]
    [InlineData(RoleEnum.Admin)]
    [InlineData(RoleEnum.Employee)]
    [InlineData(RoleEnum.Customer)]
    public void Client_Role_ShouldBeSettable(RoleEnum role)
    {
        // Arrange
        var client = new Client();

        // Act
        client.Role = role;

        // Assert
        client.Role.Should().Be(role);
    }

    [Theory]
    [InlineData(StatusEnum.Active)]
    [InlineData(StatusEnum.Pending)]
    [InlineData(StatusEnum.Completed)]
    [InlineData(StatusEnum.Returned)]
    [InlineData(StatusEnum.Deleted)]
    public void Client_Status_ShouldBeSettable(StatusEnum status)
    {
        // Arrange
        var client = new Client();

        // Act
        client.Status = status;

        // Assert
        client.Status.Should().Be(status);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Client_MFAEnabled_ShouldBeSettable(bool mfaEnabled)
    {
        // Arrange
        var client = new Client();

        // Act
        client.MFAEnabled = mfaEnabled;

        // Assert
        client.MFAEnabled.Should().Be(mfaEnabled);
    }

    [Fact]
    public void Client_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var client = new Client();

        // Act
        var result = client.ToString();

        // Assert
        result.Should().Contain("Client");
    }

    [Fact]
    public void Client_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var client = new Client();

        // Act & Assert
        client.Should().BeAssignableTo<BaseEntity>();
        client.Should().BeAssignableTo<IEntity>();
        client.Should().BeAssignableTo<ITimeModification>();
    }
}