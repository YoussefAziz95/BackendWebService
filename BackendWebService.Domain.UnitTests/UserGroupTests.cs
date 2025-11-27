using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class UserGroupTests
{
    [Fact]
    public void UserGroup_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var userGroup = new UserGroup
        {
            GroupId = 1,
            UserId = 1,
            User = new User { Id = 1, UserName = "testuser" },
            Group = new Group { Id = 1, Name = "testgroup" }
        };

        // Assert
        userGroup.Should().NotBeNull();
    }

    [Fact]
    public void UserGroup_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var userGroup = new UserGroup
        {
            GroupId = 1,
            UserId = 1,
            User = new User { Id = 1, UserName = "testuser" },
            Group = new Group { Id = 1, Name = "testgroup" }
        };

        // Act
        var result = userGroup.ToString();

        // Assert
        result.Should().Contain("UserGroup");
    }

    [Fact]
    public void UserGroup_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var userGroup = new UserGroup
        {
            GroupId = 1,
            UserId = 1,
            User = new User { Id = 1, UserName = "testuser" },
            Group = new Group { Id = 1, Name = "testgroup" }
        };

        // Act & Assert
        userGroup.Should().BeAssignableTo<BaseEntity>();
        userGroup.Should().BeAssignableTo<IEntity>();
        userGroup.Should().BeAssignableTo<ITimeModification>();
    }
}
