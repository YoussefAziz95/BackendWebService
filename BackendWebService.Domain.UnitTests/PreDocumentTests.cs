using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class PreDocumentTests
{
    [Fact]
    public void PreDocument_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var preDocument = new PreDocument();

        // Assert
        preDocument.Should().NotBeNull();
    }

    [Fact]
    public void PreDocument_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var preDocument = new PreDocument();

        // Act
        var result = preDocument.ToString();

        // Assert
        result.Should().Contain("PreDocument");
    }

    [Fact]
    public void PreDocument_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var preDocument = new PreDocument();

        // Act & Assert
        preDocument.Should().BeAssignableTo<BaseEntity>();
        preDocument.Should().BeAssignableTo<IEntity>();
        preDocument.Should().BeAssignableTo<ITimeModification>();
    }
}
