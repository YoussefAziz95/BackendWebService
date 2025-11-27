using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class AdministratorTests
{
    [Fact]
    public void Administrator_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var administrator = new Administrator
        {
            UserId = 1,
            User = new User { Id = 1, UserName = "testuser" }
        };

        // Assert
        administrator.Should().NotBeNull();
    }

    [Fact]
    public void Administrator_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var administrator = new Administrator
        {
            UserId = 1,
            User = new User { Id = 1, UserName = "testuser" }
        };

        // Act
        var result = administrator.ToString();

        // Assert
        result.Should().Contain("Administrator");
    }

    [Fact]
    public void Administrator_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var administrator = new Administrator
        {
            UserId = 1,
            User = new User { Id = 1, UserName = "testuser" }
        };

        // Act & Assert
        administrator.Should().BeAssignableTo<BaseEntity>();
        administrator.Should().BeAssignableTo<IEntity>();
        administrator.Should().BeAssignableTo<ITimeModification>();
    }
}
