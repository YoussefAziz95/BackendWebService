using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class EmployeeServiceTests
{
    [Fact]
    public void EmployeeService_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var employeeService = new EmployeeService();

        // Assert
        employeeService.Should().NotBeNull();
    }

    [Fact]
    public void EmployeeService_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var employeeService = new EmployeeService();

        // Act
        var result = employeeService.ToString();

        // Assert
        result.Should().Contain("EmployeeService");
    }

    [Fact]
    public void EmployeeService_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var employeeService = new EmployeeService();

        // Act & Assert
        employeeService.Should().BeAssignableTo<BaseEntity>();
        employeeService.Should().BeAssignableTo<IEntity>();
        employeeService.Should().BeAssignableTo<ITimeModification>();
    }
}
