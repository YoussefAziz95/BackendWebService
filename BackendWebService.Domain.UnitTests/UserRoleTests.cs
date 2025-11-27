using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class UserRoleTests
{
    [Fact]
    public void UserRole_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var userRole = new UserRole();

        // Assert
        userRole.Should().NotBeNull();
    }

    [Fact]
    public void UserRole_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var userRole = new UserRole();

        // Act
        var result = userRole.ToString();

        // Assert
        result.Should().Contain("UserRole");
    }

    [Fact]
    public void UserRole_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var userRole = new UserRole();

        // Act & Assert
        userRole.Should().BeAssignableTo<Microsoft.AspNetCore.Identity.IdentityUserRole<int>>();
        userRole.Should().BeAssignableTo<IEntity>();
        userRole.Should().BeAssignableTo<ITimeModification>();
    }
}
