using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class CriteriaTests
{
    [Fact]
    public void Criteria_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var criteria = new Criteria();

        // Assert
        criteria.Should().NotBeNull();
    }

    [Fact]
    public void Criteria_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var criteria = new Criteria();

        // Act
        var result = criteria.ToString();

        // Assert
        result.Should().Contain("Criteria");
    }

    [Fact]
    public void Criteria_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var criteria = new Criteria();

        // Act & Assert
        criteria.Should().BeAssignableTo<BaseEntity>();
        criteria.Should().BeAssignableTo<IEntity>();
        criteria.Should().BeAssignableTo<ITimeModification>();
    }
}
