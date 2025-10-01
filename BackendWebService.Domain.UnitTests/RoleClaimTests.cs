using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class RoleClaimTests
{
    [Fact]
    public void RoleClaim_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var roleClaim = new RoleClaim();

        // Assert
        roleClaim.Should().NotBeNull();
    }

    [Fact]
    public void RoleClaim_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var roleClaim = new RoleClaim();

        // Act
        var result = roleClaim.ToString();

        // Assert
        result.Should().Contain("RoleClaim");
    }

    [Fact]
    public void RoleClaim_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var roleClaim = new RoleClaim();

        // Act & Assert
        roleClaim.Should().BeAssignableTo<Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>>();
        roleClaim.Should().BeAssignableTo<IEntity>();
        roleClaim.Should().BeAssignableTo<ITimeModification>();
    }
}
