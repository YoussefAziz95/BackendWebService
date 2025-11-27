using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class FileFieldValidatorTests
{
    [Fact]
    public void FileFieldValidator_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var fileFieldValidator = new FileFieldValidator();

        // Assert
        fileFieldValidator.Should().NotBeNull();
    }

    [Fact]
    public void FileFieldValidator_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var fileFieldValidator = new FileFieldValidator();

        // Act
        var result = fileFieldValidator.ToString();

        // Assert
        result.Should().Contain("FileFieldValidator");
    }

    [Fact]
    public void FileFieldValidator_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var fileFieldValidator = new FileFieldValidator();

        // Act & Assert
        fileFieldValidator.Should().BeAssignableTo<BaseEntity>();
        fileFieldValidator.Should().BeAssignableTo<IEntity>();
        fileFieldValidator.Should().BeAssignableTo<ITimeModification>();
    }
}
