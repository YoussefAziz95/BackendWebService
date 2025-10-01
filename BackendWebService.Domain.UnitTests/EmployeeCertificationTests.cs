using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class EmployeeCertificationTests
{
    [Fact]
    public void EmployeeCertification_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var employeeCertification = new EmployeeCertification();

        // Assert
        employeeCertification.Should().NotBeNull();
    }

    [Fact]
    public void EmployeeCertification_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var employeeCertification = new EmployeeCertification();

        // Act
        var result = employeeCertification.ToString();

        // Assert
        result.Should().Contain("EmployeeCertification");
    }

    [Fact]
    public void EmployeeCertification_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var employeeCertification = new EmployeeCertification();

        // Act & Assert
        employeeCertification.Should().BeAssignableTo<BaseEntity>();
        employeeCertification.Should().BeAssignableTo<IEntity>();
        employeeCertification.Should().BeAssignableTo<ITimeModification>();
    }
}
