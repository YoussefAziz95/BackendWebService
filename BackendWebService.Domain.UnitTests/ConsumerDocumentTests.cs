using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class ConsumerDocumentTests
{
    [Fact]
    public void ConsumerDocument_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var consumerDocument = new ConsumerDocument();

        // Assert
        consumerDocument.Should().NotBeNull();
    }

    [Fact]
    public void ConsumerDocument_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var consumerDocument = new ConsumerDocument();

        // Act
        var result = consumerDocument.ToString();

        // Assert
        result.Should().Contain("ConsumerDocument");
    }

    [Fact]
    public void ConsumerDocument_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var consumerDocument = new ConsumerDocument();

        // Act & Assert
        consumerDocument.Should().BeAssignableTo<BaseEntity>();
        consumerDocument.Should().BeAssignableTo<IEntity>();
        consumerDocument.Should().BeAssignableTo<ITimeModification>();
    }
}
