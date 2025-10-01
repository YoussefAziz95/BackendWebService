using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class UserClaimTests
{
    [Fact]
    public void UserClaim_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var userClaim = new UserClaim();

        // Assert
        userClaim.Should().NotBeNull();
    }

    [Fact]
    public void UserClaim_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var userClaim = new UserClaim();

        // Act
        var result = userClaim.ToString();

        // Assert
        result.Should().Contain("UserClaim");
    }

    [Fact]
    public void UserClaim_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var userClaim = new UserClaim();

        // Act & Assert
        userClaim.Should().BeAssignableTo<Microsoft.AspNetCore.Identity.IdentityUserClaim<int>>();
        userClaim.Should().BeAssignableTo<IEntity>();
        userClaim.Should().BeAssignableTo<ITimeModification>();
    }
}
