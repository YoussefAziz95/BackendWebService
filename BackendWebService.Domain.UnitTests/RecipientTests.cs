using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class RecipientTests
{
    [Fact]
    public void Recipient_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var recipient = new Recipient();

        // Assert
        recipient.Should().NotBeNull();
    }

    [Fact]
    public void Recipient_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var recipient = new Recipient();

        // Act
        var result = recipient.ToString();

        // Assert
        result.Should().Contain("Recipient");
    }

    [Fact]
    public void Recipient_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var recipient = new Recipient();

        // Act & Assert
        recipient.Should().BeAssignableTo<BaseEntity>();
        recipient.Should().BeAssignableTo<IEntity>();
        recipient.Should().BeAssignableTo<ITimeModification>();
    }
}
