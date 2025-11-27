using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class ReceiptTests
{
    [Fact]
    public void Receipt_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var receipt = new Receipt();

        // Assert
        receipt.Should().NotBeNull();
    }

    [Fact]
    public void Receipt_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var receipt = new Receipt();

        // Act
        var result = receipt.ToString();

        // Assert
        result.Should().Contain("Receipt");
    }

    [Fact]
    public void Receipt_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var receipt = new Receipt();

        // Act & Assert
        receipt.Should().BeAssignableTo<BaseEntity>();
        receipt.Should().BeAssignableTo<IEntity>();
        receipt.Should().BeAssignableTo<ITimeModification>();
    }
}
