using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class GoogleConfigTests
{
    [Fact]
    public void GoogleConfig_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var googleConfig = new GoogleConfig();

        // Assert
        googleConfig.Should().NotBeNull();
    }

    [Fact]
    public void GoogleConfig_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var googleConfig = new GoogleConfig();

        // Act
        var result = googleConfig.ToString();

        // Assert
        result.Should().Contain("GoogleConfig");
    }

    [Fact]
    public void GoogleConfig_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var googleConfig = new GoogleConfig();

        // Act & Assert
        googleConfig.Should().BeAssignableTo<BaseEntity>();
        googleConfig.Should().BeAssignableTo<IEntity>();
        googleConfig.Should().BeAssignableTo<ITimeModification>();
    }
}
