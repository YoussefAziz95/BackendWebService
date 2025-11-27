using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class UserLoginTests
{
    [Fact]
    public void UserLogin_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var userLogin = new UserLogin();

        // Assert
        userLogin.Should().NotBeNull();
    }

    [Fact]
    public void UserLogin_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var userLogin = new UserLogin();

        // Act
        var result = userLogin.ToString();

        // Assert
        result.Should().Contain("UserLogin");
    }

    [Fact]
    public void UserLogin_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var userLogin = new UserLogin();

        // Act & Assert
        userLogin.Should().BeAssignableTo<Microsoft.AspNetCore.Identity.IdentityUserLogin<int>>();
        userLogin.Should().BeAssignableTo<IEntity>();
        userLogin.Should().BeAssignableTo<ITimeModification>();
    }
}
