using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class AttachmentTests
{
    [Fact]
    public void Attachment_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var attachment = new Attachment();

        // Assert
        attachment.Should().NotBeNull();
    }

    [Fact]
    public void Attachment_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var attachment = new Attachment();

        // Act
        var result = attachment.ToString();

        // Assert
        result.Should().Contain("Attachment");
    }

    [Fact]
    public void Attachment_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var attachment = new Attachment();

        // Act & Assert
        attachment.Should().BeAssignableTo<BaseEntity>();
        attachment.Should().BeAssignableTo<IEntity>();
        attachment.Should().BeAssignableTo<ITimeModification>();
    }
}
