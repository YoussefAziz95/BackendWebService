using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class DealDocumentTests
{
    [Fact]
    public void DealDocument_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var dealDocument = new DealDocument();

        // Assert
        dealDocument.Should().NotBeNull();
    }

    [Fact]
    public void DealDocument_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var dealDocument = new DealDocument();

        // Act
        var result = dealDocument.ToString();

        // Assert
        result.Should().Contain("DealDocument");
    }

    [Fact]
    public void DealDocument_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var dealDocument = new DealDocument();

        // Act & Assert
        dealDocument.Should().BeAssignableTo<BaseEntity>();
        dealDocument.Should().BeAssignableTo<IEntity>();
        dealDocument.Should().BeAssignableTo<ITimeModification>();
    }
}
