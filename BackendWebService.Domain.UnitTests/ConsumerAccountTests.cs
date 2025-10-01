using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class ConsumerAccountTests
{
    [Fact]
    public void ConsumerAccount_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var consumerAccount = new ConsumerAccount();

        // Assert
        consumerAccount.Should().NotBeNull();
    }

    [Fact]
    public void ConsumerAccount_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var consumerAccount = new ConsumerAccount();

        // Act
        var result = consumerAccount.ToString();

        // Assert
        result.Should().Contain("ConsumerAccount");
    }

    [Fact]
    public void ConsumerAccount_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var consumerAccount = new ConsumerAccount();

        // Act & Assert
        consumerAccount.Should().BeAssignableTo<BaseEntity>();
        consumerAccount.Should().BeAssignableTo<IEntity>();
        consumerAccount.Should().BeAssignableTo<ITimeModification>();
    }
}
