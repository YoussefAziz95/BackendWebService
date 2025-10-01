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
        // Arrange & Act
        var client = new Client();

        // Assert
        client.Should().NotBeNull();
        client.UserId.Should().Be(0);
        client.User.Should().BeNull();
        client.MFAEnabled.Should().BeFalse();
        client.Role.Should().Be(RoleEnum.Customer);
        client.Status.Should().Be(StatusEnum.Active);
        client.ClientProperties.Should().BeNull();
        client.IsActive.Should().BeTrue();
        client.IsDeleted.Should().BeFalse();
        client.IsSystem.Should().BeFalse();
        client.CreatedDate.Should().NotBeNull();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MaxValue)]
    public void Client_UserId_ShouldBeSettable(int userId)
    {
        // Arrange
        var client = new Client();

        // Act
        client.UserId = userId;

        // Assert
        client.UserId.Should().Be(userId);
    }

    [Fact]
    public void Client_User_ShouldBeSettable()
    {
        // Arrange
        var client = new Client();
        var user = new User();

        // Act
        client.User = user;

        // Assert
        client.User.Should().Be(user);
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
    [InlineData(StatusEnum.Pending)]
    [InlineData(StatusEnum.Active)]
    [InlineData(StatusEnum.Disabled)]
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

    [Fact]
    public void Client_ClientProperties_ShouldBeSettable()
    {
        // Arrange
        var client = new Client();
        var property = new ClientProperty();

        // Act
        client.ClientProperties = new List<ClientProperty> { property };

        // Assert
        client.ClientProperties.Should().NotBeNull();
        client.ClientProperties.Should().Contain(property);
    }

    [Fact]
    public void Client_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var client = new Client
        {
            UserId = 1
        };

        // Assert
        client.UserId.Should().Be(1);
        client.MFAEnabled.Should().BeFalse();
        client.Role.Should().Be(RoleEnum.Customer);
        client.Status.Should().Be(StatusEnum.Active);
        client.IsActive.Should().BeTrue();
    }

    [Fact]
    public void Client_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange & Act
        var user = new User();
        var property = new ClientProperty();
        var client = new Client
        {
            UserId = 1,
            User = user,
            MFAEnabled = true,
            Role = RoleEnum.Customer,
            Status = StatusEnum.Active,
            ClientProperties = new List<ClientProperty> { property }
        };

        // Assert
        client.UserId.Should().Be(1);
        client.User.Should().Be(user);
        client.MFAEnabled.Should().BeTrue();
        client.Role.Should().Be(RoleEnum.Customer);
        client.Status.Should().Be(StatusEnum.Active);
        client.ClientProperties.Should().Contain(property);
    }

    [Fact]
    public void Client_WithNullUser_ShouldBeCreatable()
    {
        // Arrange & Act
        var client = new Client
        {
            UserId = 1,
            User = null
        };

        // Assert
        client.UserId.Should().Be(1);
        client.User.Should().BeNull();
    }

    [Fact]
    public void Client_WithNullClientProperties_ShouldBeCreatable()
    {
        // Arrange & Act
        var client = new Client
        {
            UserId = 1,
            ClientProperties = null
        };

        // Assert
        client.UserId.Should().Be(1);
        client.ClientProperties.Should().BeNull();
    }

    [Fact]
    public void Client_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var client = new Client { UserId = 1 };

        // Act
        var result = client.ToString();

        // Assert
        result.Should().Contain("Client");
    }

    [Fact]
    public void Client_ShouldInheritFromBaseEntity()
    {
        // Arrange & Act
        var client = new Client();

        // Assert
        client.Should().BeAssignableTo<BaseEntity>();
        client.Should().BeAssignableTo<IEntity>();
        client.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void Client_AllProperties_ShouldBeSettable()
    {
        // Arrange
        var client = new Client();
        var user = new User();
        var property = new ClientProperty();

        // Act
        client.UserId = 1;
        client.User = user;
        client.MFAEnabled = true;
        client.Role = RoleEnum.Customer;
        client.Status = StatusEnum.Active;
        client.ClientProperties = new List<ClientProperty> { property };

        // Assert
        client.UserId.Should().Be(1);
        client.User.Should().Be(user);
        client.MFAEnabled.Should().BeTrue();
        client.Role.Should().Be(RoleEnum.Customer);
        client.Status.Should().Be(StatusEnum.Active);
        client.ClientProperties.Should().Contain(property);
    }
}
