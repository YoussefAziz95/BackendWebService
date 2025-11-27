using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class ConsumerCustomerTests
{
    [Fact]
    public void ConsumerCustomer_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var consumerCustomer = new ConsumerCustomer();

        // Assert
        consumerCustomer.Should().NotBeNull();
    }

    [Fact]
    public void ConsumerCustomer_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var consumerCustomer = new ConsumerCustomer();

        // Act
        var result = consumerCustomer.ToString();

        // Assert
        result.Should().Contain("ConsumerCustomer");
    }

    [Fact]
    public void ConsumerCustomer_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var consumerCustomer = new ConsumerCustomer();

        // Act & Assert
        consumerCustomer.Should().BeAssignableTo<BaseEntity>();
        consumerCustomer.Should().BeAssignableTo<IEntity>();
        consumerCustomer.Should().BeAssignableTo<ITimeModification>();
    }
}
