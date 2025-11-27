using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class WorkflowCycleTests
{
    [Fact]
    public void WorkflowCycle_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var workflowCycle = new WorkflowCycle();

        // Assert
        workflowCycle.Should().NotBeNull();
    }

    [Fact]
    public void WorkflowCycle_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var workflowCycle = new WorkflowCycle();

        // Act
        var result = workflowCycle.ToString();

        // Assert
        result.Should().Contain("WorkflowCycle");
    }

    [Fact]
    public void WorkflowCycle_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var workflowCycle = new WorkflowCycle();

        // Act & Assert
        workflowCycle.Should().BeAssignableTo<BaseEntity>();
        workflowCycle.Should().BeAssignableTo<IEntity>();
        workflowCycle.Should().BeAssignableTo<ITimeModification>();
    }
}
