using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class EmployeeJobTests
{
    [Fact]
    public void EmployeeJob_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var employeeJob = new EmployeeJob();

        // Assert
        employeeJob.Should().NotBeNull();
    }

    [Fact]
    public void EmployeeJob_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var employeeJob = new EmployeeJob();

        // Act
        var result = employeeJob.ToString();

        // Assert
        result.Should().Contain("EmployeeJob");
    }

    [Fact]
    public void EmployeeJob_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var employeeJob = new EmployeeJob();

        // Act & Assert
        employeeJob.Should().BeAssignableTo<BaseEntity>();
        employeeJob.Should().BeAssignableTo<IEntity>();
        employeeJob.Should().BeAssignableTo<ITimeModification>();
    }
}
