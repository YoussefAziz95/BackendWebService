using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class JobTests
{
    [Fact]
    public void Job_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var job = new Job();

        // Assert
        job.Should().NotBeNull();
    }

    [Fact]
    public void Job_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var job = new Job();

        // Act
        var result = job.ToString();

        // Assert
        result.Should().Contain("Job");
    }

    [Fact]
    public void Job_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var job = new Job();

        // Act & Assert
        job.Should().BeAssignableTo<BaseEntity>();
        job.Should().BeAssignableTo<IEntity>();
        job.Should().BeAssignableTo<ITimeModification>();
    }
}
