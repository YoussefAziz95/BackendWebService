using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class EmployeeAssignmentTests
{
    [Fact]
    public void EmployeeAssignment_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var employeeAssignment = new EmployeeAssignment();

        // Assert
        employeeAssignment.Should().NotBeNull();
    }

    [Fact]
    public void EmployeeAssignment_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var employeeAssignment = new EmployeeAssignment();

        // Act
        var result = employeeAssignment.ToString();

        // Assert
        result.Should().Contain("EmployeeAssignment");
    }

    [Fact]
    public void EmployeeAssignment_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var employeeAssignment = new EmployeeAssignment();

        // Act & Assert
        employeeAssignment.Should().BeAssignableTo<BaseEntity>();
        employeeAssignment.Should().BeAssignableTo<IEntity>();
        employeeAssignment.Should().BeAssignableTo<ITimeModification>();
    }
}
