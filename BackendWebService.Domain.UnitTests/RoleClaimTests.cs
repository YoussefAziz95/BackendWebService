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

    #region Business Logic Tests

    [Fact]
    public void RoleClaim_Constructor_ShouldSetCreatedDate()
    {
        // Arrange & Act
        var roleClaim = new RoleClaim();

        // Assert
        roleClaim.CreatedDate.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void RoleClaim_ConstructorWithParameters_ShouldSetValues()
    {
        // Arrange
        var claimType = "Permission";
        var claimValue = "Read";

        // Act
        var roleClaim = new RoleClaim(claimValue, claimType);

        // Assert
        roleClaim.ClaimType.Should().Be(claimType);
        roleClaim.ClaimValue.Should().Be(claimValue);
        roleClaim.CreatedDate.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void RoleClaim_ToClaim_ShouldCreateValidClaim()
    {
        // Arrange
        var roleClaim = new RoleClaim
        {
            ClaimType = "Permission",
            ClaimValue = "Read"
        };

        // Act
        var claim = roleClaim.ToClaim();

        // Assert
        claim.Should().NotBeNull();
        claim.Type.Should().Be("Permission");
        claim.Value.Should().Be("Read");
    }

    [Fact]
    public void RoleClaim_ToClaim_WithNullValues_ShouldThrowException()
    {
        // Arrange
        var roleClaim = new RoleClaim
        {
            ClaimType = null,
            ClaimValue = null
        };

        // Act & Assert
        var action = () => roleClaim.ToClaim();
        action.Should().Throw<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'type')");
    }

    [Fact]
    public void RoleClaim_InitializeFromClaim_ShouldSetValues()
    {
        // Arrange
        var roleClaim = new RoleClaim();
        var claim = new System.Security.Claims.Claim("Permission", "Write");

        // Act
        roleClaim.InitializeFromClaim(claim);

        // Assert
        roleClaim.ClaimType.Should().Be("Permission");
        roleClaim.ClaimValue.Should().Be("Write");
    }

    [Fact]
    public void RoleClaim_InitializeFromClaim_WithNullClaim_ShouldSetNullValues()
    {
        // Arrange
        var roleClaim = new RoleClaim();

        // Act
        roleClaim.InitializeFromClaim(null);

        // Assert
        roleClaim.ClaimType.Should().BeNull();
        roleClaim.ClaimValue.Should().BeNull();
    }

    [Fact]
    public void RoleClaim_InitializeFromClaim_WithEmptyClaimTypeAndValue_ShouldSetEmptyValues()
    {
        // Arrange
        var roleClaim = new RoleClaim();
        var claim = new System.Security.Claims.Claim(string.Empty, string.Empty);

        // Act
        roleClaim.InitializeFromClaim(claim);

        // Assert
        roleClaim.ClaimType.Should().Be(string.Empty);
        roleClaim.ClaimValue.Should().Be(string.Empty);
    }

    #endregion
}
