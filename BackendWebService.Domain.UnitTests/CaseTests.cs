using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class CaseTests
{
    [Fact]
    public void Case_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var caseEntity = new Case();

        // Assert
        caseEntity.Should().NotBeNull();
        caseEntity.ActionIndex.Should().Be(0);
    }

    [Fact]
    public void Case_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange
        var actionIndex = 1;
        var workflowId = 123;
        var statusId = 456;

        // Act
        var caseEntity = new Case
        {
            ActionIndex = actionIndex,
            WorkflowId = workflowId,
            StatusId = statusId
        };

        // Assert
        caseEntity.ActionIndex.Should().Be(actionIndex);
        caseEntity.WorkflowId.Should().Be(workflowId);
        caseEntity.StatusId.Should().Be(statusId);
    }

    [Fact]
    public void Case_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange
        var actionIndex = 2;
        var workflowId = 123;
        var statusId = 456;
        var companySupplierId = 789;
        var userId = 101;

        // Act
        var caseEntity = new Case
        {
            ActionIndex = actionIndex,
            WorkflowId = workflowId,
            StatusId = statusId,
            CompanySupplierId = companySupplierId,
            UserId = userId
        };

        // Assert
        caseEntity.ActionIndex.Should().Be(actionIndex);
        caseEntity.WorkflowId.Should().Be(workflowId);
        caseEntity.StatusId.Should().Be(statusId);
        caseEntity.CompanySupplierId.Should().Be(companySupplierId);
        caseEntity.UserId.Should().Be(userId);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(int.MaxValue)]
    public void Case_ActionIndex_ShouldBeSettable(int actionIndex)
    {
        // Arrange
        var caseEntity = new Case();

        // Act
        caseEntity.ActionIndex = actionIndex;

        // Assert
        caseEntity.ActionIndex.Should().Be(actionIndex);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(999)]
    public void Case_WorkflowId_ShouldBeSettable(int workflowId)
    {
        // Arrange
        var caseEntity = new Case();

        // Act
        caseEntity.WorkflowId = workflowId;

        // Assert
        caseEntity.WorkflowId.Should().Be(workflowId);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(999)]
    public void Case_StatusId_ShouldBeSettable(int statusId)
    {
        // Arrange
        var caseEntity = new Case();

        // Act
        caseEntity.StatusId = statusId;

        // Assert
        caseEntity.StatusId.Should().Be(statusId);
    }

    [Fact]
    public void Case_OptionalProperties_ShouldBeNullable()
    {
        // Arrange
        var caseEntity = new Case();

        // Act & Assert
        caseEntity.CompanySupplierId.Should().BeNull();
        caseEntity.UserId.Should().BeNull();
        caseEntity.CaseActions.Should().BeNull();
    }

    [Fact]
    public void Case_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var caseEntity = new Case();

        // Act
        var result = caseEntity.ToString();

        // Assert
        result.Should().Contain("Case");
    }

    [Fact]
    public void Case_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var caseEntity = new Case();

        // Act & Assert
        caseEntity.Should().BeAssignableTo<BaseEntity>();
        caseEntity.Should().BeAssignableTo<IEntity>();
        caseEntity.Should().BeAssignableTo<ITimeModification>();
    }
}
