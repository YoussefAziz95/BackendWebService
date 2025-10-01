using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class EmployeeAccountTests
{
    [Fact]
    public void EmployeeAccount_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var employeeAccount = new EmployeeAccount();

        // Assert
        employeeAccount.Should().NotBeNull();
    }

    [Fact]
    public void EmployeeAccount_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var employeeAccount = new EmployeeAccount();

        // Act
        var result = employeeAccount.ToString();

        // Assert
        result.Should().Contain("EmployeeAccount");
    }

    [Fact]
    public void EmployeeAccount_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var employeeAccount = new EmployeeAccount();

        // Act & Assert
        employeeAccount.Should().BeAssignableTo<BaseEntity>();
        employeeAccount.Should().BeAssignableTo<IEntity>();
        employeeAccount.Should().BeAssignableTo<ITimeModification>();
    }
}
