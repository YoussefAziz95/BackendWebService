using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class BranchWorkingHourTests
{
    [Fact]
    public void BranchWorkingHour_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var branchWorkingHour = new BranchWorkingHour();

        // Assert
        branchWorkingHour.Should().NotBeNull();
    }

    [Fact]
    public void BranchWorkingHour_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var branchWorkingHour = new BranchWorkingHour();

        // Act
        var result = branchWorkingHour.ToString();

        // Assert
        result.Should().Contain("BranchWorkingHour");
    }

    [Fact]
    public void BranchWorkingHour_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var branchWorkingHour = new BranchWorkingHour();

        // Act & Assert
        branchWorkingHour.Should().BeAssignableTo<BaseEntity>();
        branchWorkingHour.Should().BeAssignableTo<IEntity>();
        branchWorkingHour.Should().BeAssignableTo<ITimeModification>();
    }
}
