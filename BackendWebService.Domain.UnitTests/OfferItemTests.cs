using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class OfferItemTests
{
    [Fact]
    public void OfferItem_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var offerItem = new OfferItem();

        // Assert
        offerItem.Should().NotBeNull();
    }

    [Fact]
    public void OfferItem_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var offerItem = new OfferItem();

        // Act
        var result = offerItem.ToString();

        // Assert
        result.Should().Contain("OfferItem");
    }

    [Fact]
    public void OfferItem_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var offerItem = new OfferItem();

        // Act & Assert
        offerItem.Should().BeAssignableTo<BaseEntity>();
        offerItem.Should().BeAssignableTo<IEntity>();
        offerItem.Should().BeAssignableTo<ITimeModification>();
    }
}
