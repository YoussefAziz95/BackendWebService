using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class MicrosoftConfigTests
{
    [Fact]
    public void MicrosoftConfig_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var microsoftConfig = new MicrosoftConfig();

        // Assert
        microsoftConfig.Should().NotBeNull();
    }

    [Fact]
    public void MicrosoftConfig_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var microsoftConfig = new MicrosoftConfig();

        // Act
        var result = microsoftConfig.ToString();

        // Assert
        result.Should().Contain("MicrosoftConfig");
    }

    [Fact]
    public void MicrosoftConfig_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var microsoftConfig = new MicrosoftConfig();

        // Act & Assert
        microsoftConfig.Should().BeAssignableTo<BaseEntity>();
        microsoftConfig.Should().BeAssignableTo<IEntity>();
        microsoftConfig.Should().BeAssignableTo<ITimeModification>();
    }
}
