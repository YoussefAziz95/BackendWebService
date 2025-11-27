using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class TimeSlotTests
{
    [Fact]
    public void TimeSlot_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var timeSlot = new TimeSlot();

        // Assert
        timeSlot.Should().NotBeNull();
    }

    [Fact]
    public void TimeSlot_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var timeSlot = new TimeSlot();

        // Act
        var result = timeSlot.ToString();

        // Assert
        result.Should().Contain("TimeSlot");
    }

    [Fact]
    public void TimeSlot_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var timeSlot = new TimeSlot();

        // Act & Assert
        timeSlot.Should().BeAssignableTo<BaseEntity>();
        timeSlot.Should().BeAssignableTo<IEntity>();
        timeSlot.Should().BeAssignableTo<ITimeModification>();
    }
}
