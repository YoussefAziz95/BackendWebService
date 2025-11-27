using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class OfferObjectTests
{
    [Fact]
    public void OfferObject_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var offerObject = new OfferObject();

        // Assert
        offerObject.Should().NotBeNull();
    }

    [Fact]
    public void OfferObject_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var offerObject = new OfferObject();

        // Act
        var result = offerObject.ToString();

        // Assert
        result.Should().Contain("OfferObject");
    }

    [Fact]
    public void OfferObject_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var offerObject = new OfferObject();

        // Act & Assert
        offerObject.Should().BeAssignableTo<BaseEntity>();
        offerObject.Should().BeAssignableTo<IEntity>();
        offerObject.Should().BeAssignableTo<ITimeModification>();
    }
}
