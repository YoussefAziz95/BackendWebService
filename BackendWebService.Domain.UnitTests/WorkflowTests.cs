using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class WorkflowTests
{
    [Fact]
    public void Workflow_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var workflow = new Workflow();

        // Assert
        workflow.Should().NotBeNull();
    }

    [Fact]
    public void Workflow_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var workflow = new Workflow();

        // Act
        var result = workflow.ToString();

        // Assert
        result.Should().Contain("Workflow");
    }

    [Fact]
    public void Workflow_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var workflow = new Workflow();

        // Act & Assert
        workflow.Should().BeAssignableTo<BaseEntity>();
        workflow.Should().BeAssignableTo<IEntity>();
        workflow.Should().BeAssignableTo<ITimeModification>();
    }
}
