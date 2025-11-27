using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class DealDetailsTests
{
    [Fact]
    public void DealDetails_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var dealDetails = new DealDetails();

        // Assert
        dealDetails.Should().NotBeNull();
    }

    [Fact]
    public void DealDetails_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var dealDetails = new DealDetails();

        // Act
        var result = dealDetails.ToString();

        // Assert
        result.Should().Contain("DealDetails");
    }

    [Fact]
    public void DealDetails_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var dealDetails = new DealDetails();

        // Act & Assert
        dealDetails.Should().BeAssignableTo<BaseEntity>();
        dealDetails.Should().BeAssignableTo<IEntity>();
        dealDetails.Should().BeAssignableTo<ITimeModification>();
    }
}
