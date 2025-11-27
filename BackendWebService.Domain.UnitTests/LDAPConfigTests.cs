using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class LDAPConfigTests
{
    [Fact]
    public void LDAPConfig_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var ldapConfig = new LDAPConfig();

        // Assert
        ldapConfig.Should().NotBeNull();
    }

    [Fact]
    public void LDAPConfig_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var ldapConfig = new LDAPConfig();

        // Act
        var result = ldapConfig.ToString();

        // Assert
        result.Should().Contain("LDAPConfig");
    }

    [Fact]
    public void LDAPConfig_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var ldapConfig = new LDAPConfig();

        // Act & Assert
        ldapConfig.Should().BeAssignableTo<BaseEntity>();
        ldapConfig.Should().BeAssignableTo<IEntity>();
        ldapConfig.Should().BeAssignableTo<ITimeModification>();
    }
}
