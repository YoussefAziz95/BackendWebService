using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class BranchEmployeeTests
{
    [Fact]
    public void BranchEmployee_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var branchEmployee = new BranchEmployee();

        // Assert
        branchEmployee.Should().NotBeNull();
    }

    [Fact]
    public void BranchEmployee_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var branchEmployee = new BranchEmployee();

        // Act
        var result = branchEmployee.ToString();

        // Assert
        result.Should().Contain("BranchEmployee");
    }

    [Fact]
    public void BranchEmployee_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var branchEmployee = new BranchEmployee();

        // Act & Assert
        branchEmployee.Should().BeAssignableTo<BaseEntity>();
        branchEmployee.Should().BeAssignableTo<IEntity>();
        branchEmployee.Should().BeAssignableTo<ITimeModification>();
    }
}
