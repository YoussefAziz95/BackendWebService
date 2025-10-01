using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class UserTokenTests
{
    [Fact]
    public void UserToken_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var userToken = new UserToken();

        // Assert
        userToken.Should().NotBeNull();
    }

    [Fact]
    public void UserToken_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var userToken = new UserToken();

        // Act
        var result = userToken.ToString();

        // Assert
        result.Should().Contain("UserToken");
    }

    [Fact]
    public void UserToken_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var userToken = new UserToken();

        // Act & Assert
        userToken.Should().BeAssignableTo<Microsoft.AspNetCore.Identity.IdentityUserToken<int>>();
        userToken.Should().BeAssignableTo<IEntity>();
        userToken.Should().BeAssignableTo<ITimeModification>();
    }
}
