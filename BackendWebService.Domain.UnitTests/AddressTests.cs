using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class AddressTests
{
    [Fact]
    public void Address_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var address = new Address();

        // Assert
        address.Should().NotBeNull();
    }

    [Fact]
    public void Address_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var address = new Address();

        // Act
        var result = address.ToString();

        // Assert
        result.Should().Contain("Address");
    }

    [Fact]
    public void Address_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var address = new Address();

        // Act & Assert
        address.Should().BeAssignableTo<BaseEntity>();
        address.Should().BeAssignableTo<IEntity>();
        address.Should().BeAssignableTo<ITimeModification>();
    }
}
