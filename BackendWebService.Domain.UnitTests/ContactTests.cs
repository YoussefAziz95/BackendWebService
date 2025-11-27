using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class ContactTests
{
    [Fact]
    public void Contact_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var contact = new Contact();

        // Assert
        contact.Should().NotBeNull();
    }

    [Fact]
    public void Contact_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var contact = new Contact();

        // Act
        var result = contact.ToString();

        // Assert
        result.Should().Contain("Contact");
    }

    [Fact]
    public void Contact_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var contact = new Contact();

        // Act & Assert
        contact.Should().BeAssignableTo<BaseEntity>();
        contact.Should().BeAssignableTo<IEntity>();
        contact.Should().BeAssignableTo<ITimeModification>();
    }
}
