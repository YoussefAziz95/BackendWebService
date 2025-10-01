using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class BranchServiceTests
{
    [Fact]
    public void BranchService_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var branchService = new BranchService();

        // Assert
        branchService.Should().NotBeNull();
    }

    [Fact]
    public void BranchService_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var branchService = new BranchService();

        // Act
        var result = branchService.ToString();

        // Assert
        result.Should().Contain("BranchService");
    }

    [Fact]
    public void BranchService_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var branchService = new BranchService();

        // Act & Assert
        branchService.Should().BeAssignableTo<BaseEntity>();
        branchService.Should().BeAssignableTo<IEntity>();
        branchService.Should().BeAssignableTo<ITimeModification>();
    }
}
