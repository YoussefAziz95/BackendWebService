using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class BranchLocationTests
{
    [Fact]
    public void BranchLocation_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var branchLocation = new BranchLocation();

        // Assert
        branchLocation.Should().NotBeNull();
    }

    [Fact]
    public void BranchLocation_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var branchLocation = new BranchLocation();

        // Act
        var result = branchLocation.ToString();

        // Assert
        result.Should().Contain("BranchLocation");
    }

    [Fact]
    public void BranchLocation_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var branchLocation = new BranchLocation();

        // Act & Assert
        branchLocation.Should().BeAssignableTo<BaseEntity>();
        branchLocation.Should().BeAssignableTo<IEntity>();
        branchLocation.Should().BeAssignableTo<ITimeModification>();
    }
}
