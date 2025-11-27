using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class CaseActionTests
{
    [Fact]
    public void CaseAction_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var caseAction = new CaseAction();

        // Assert
        caseAction.Should().NotBeNull();
    }

    [Fact]
    public void CaseAction_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var caseAction = new CaseAction();

        // Act
        var result = caseAction.ToString();

        // Assert
        result.Should().Contain("CaseAction");
    }

    [Fact]
    public void CaseAction_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var caseAction = new CaseAction();

        // Act & Assert
        caseAction.Should().BeAssignableTo<BaseEntity>();
        caseAction.Should().BeAssignableTo<IEntity>();
        caseAction.Should().BeAssignableTo<ITimeModification>();
    }
}
