using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class UserRefreshTokenTests
{
    [Fact]
    public void UserRefreshToken_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var userRefreshToken = new UserRefreshToken();

        // Assert
        userRefreshToken.Should().NotBeNull();
    }

    [Fact]
    public void UserRefreshToken_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var userRefreshToken = new UserRefreshToken();

        // Act
        var result = userRefreshToken.ToString();

        // Assert
        result.Should().Contain("UserRefreshToken");
    }

    [Fact]
    public void UserRefreshToken_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var userRefreshToken = new UserRefreshToken();

        // Act & Assert
        userRefreshToken.Should().BeAssignableTo<BaseEntity<Guid>>();
        userRefreshToken.Should().BeAssignableTo<IEntity>();
        userRefreshToken.Should().BeAssignableTo<ITimeModification>();
    }
}
