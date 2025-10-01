using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class BranchTests
{
    [Fact]
    public void Branch_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var branch = new Branch();

        // Assert
        branch.Should().NotBeNull();
        branch.FranchiseName.Should().BeNull();
        branch.FranchiseSlogan.Should().BeNull();
        branch.LogoUrl.Should().BeNull();
        branch.PhoneNumber.Should().BeNull();
        branch.WebsiteUrl.Should().BeNull();
    }

    [Fact]
    public void Branch_AllProperties_ShouldBeSettable()
    {
        // Arrange
        var branch = new Branch();

        // Act
        branch.FranchiseName = "McDonald's";
        branch.FranchiseSlogan = "I'm Lovin' It";
        branch.LogoUrl = "https://example.com/logo.png";
        branch.PhoneNumber = "+1234567890";
        branch.WebsiteUrl = "https://mcdonalds.com";

        // Assert
        branch.FranchiseName.Should().Be("McDonald's");
        branch.FranchiseSlogan.Should().Be("I'm Lovin' It");
        branch.LogoUrl.Should().Be("https://example.com/logo.png");
        branch.PhoneNumber.Should().Be("+1234567890");
        branch.WebsiteUrl.Should().Be("https://mcdonalds.com");
    }

    [Fact]
    public void Branch_WithNullValues_ShouldBeCreatable()
    {
        // Arrange & Act
        var branch = new Branch
        {
            FranchiseName = null,
            FranchiseSlogan = null,
            LogoUrl = null,
            PhoneNumber = null,
            WebsiteUrl = null
        };

        // Assert
        branch.FranchiseName.Should().BeNull();
        branch.FranchiseSlogan.Should().BeNull();
        branch.LogoUrl.Should().BeNull();
        branch.PhoneNumber.Should().BeNull();
        branch.WebsiteUrl.Should().BeNull();
    }

    [Fact]
    public void Branch_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var branch = new Branch
        {
            FranchiseName = "KFC",
            LogoUrl = "https://example.com/kfc-logo.png",
            PhoneNumber = "+1987654321"
        };

        // Assert
        branch.FranchiseName.Should().Be("KFC");
        branch.LogoUrl.Should().Be("https://example.com/kfc-logo.png");
        branch.PhoneNumber.Should().Be("+1987654321");
    }

    [Fact]
    public void Branch_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange & Act
        var branch = new Branch
        {
            FranchiseName = "Subway",
            FranchiseSlogan = "Eat Fresh",
            LogoUrl = "https://example.com/subway-logo.png",
            PhoneNumber = "+1555123456",
            WebsiteUrl = "https://subway.com"
        };

        // Assert
        branch.FranchiseName.Should().Be("Subway");
        branch.FranchiseSlogan.Should().Be("Eat Fresh");
        branch.LogoUrl.Should().Be("https://example.com/subway-logo.png");
        branch.PhoneNumber.Should().Be("+1555123456");
        branch.WebsiteUrl.Should().Be("https://subway.com");
    }

    [Fact]
    public void Branch_WithEmptyStrings_ShouldBeCreatable()
    {
        // Arrange & Act
        var branch = new Branch
        {
            FranchiseName = "",
            FranchiseSlogan = "",
            LogoUrl = "",
            PhoneNumber = "",
            WebsiteUrl = ""
        };

        // Assert
        branch.FranchiseName.Should().Be("");
        branch.FranchiseSlogan.Should().Be("");
        branch.LogoUrl.Should().Be("");
        branch.PhoneNumber.Should().Be("");
        branch.WebsiteUrl.Should().Be("");
    }

    [Fact]
    public void Branch_WithLongStrings_ShouldBeCreatable()
    {
        // Arrange
        var longFranchiseName = new string('A', 1000);
        var longFranchiseSlogan = new string('B', 1000);
        var longLogoUrl = new string('C', 1000);
        var longPhoneNumber = new string('D', 20);
        var longWebsiteUrl = new string('E', 1000);

        // Act
        var branch = new Branch
        {
            FranchiseName = longFranchiseName,
            FranchiseSlogan = longFranchiseSlogan,
            LogoUrl = longLogoUrl,
            PhoneNumber = longPhoneNumber,
            WebsiteUrl = longWebsiteUrl
        };

        // Assert
        branch.FranchiseName.Should().Be(longFranchiseName);
        branch.FranchiseSlogan.Should().Be(longFranchiseSlogan);
        branch.LogoUrl.Should().Be(longLogoUrl);
        branch.PhoneNumber.Should().Be(longPhoneNumber);
        branch.WebsiteUrl.Should().Be(longWebsiteUrl);
    }

    [Fact]
    public void Branch_WithValidUrls_ShouldBeCreatable()
    {
        // Arrange & Act
        var branch = new Branch
        {
            LogoUrl = "https://example.com/logo.png",
            WebsiteUrl = "https://www.example.com"
        };

        // Assert
        branch.LogoUrl.Should().Be("https://example.com/logo.png");
        branch.WebsiteUrl.Should().Be("https://www.example.com");
    }

    [Fact]
    public void Branch_WithValidPhoneNumbers_ShouldBeCreatable()
    {
        // Arrange & Act
        var branch = new Branch
        {
            PhoneNumber = "+1-555-123-4567"
        };

        // Assert
        branch.PhoneNumber.Should().Be("+1-555-123-4567");
    }

    [Fact]
    public void Branch_WithSpecialCharacters_ShouldBeCreatable()
    {
        // Arrange & Act
        var branch = new Branch
        {
            FranchiseName = "Café & Bistro",
            FranchiseSlogan = "Bon Appétit! 🍽️",
            PhoneNumber = "+1 (555) 123-4567"
        };

        // Assert
        branch.FranchiseName.Should().Be("Café & Bistro");
        branch.FranchiseSlogan.Should().Be("Bon Appétit! 🍽️");
        branch.PhoneNumber.Should().Be("+1 (555) 123-4567");
    }

    [Fact]
    public void Branch_ShouldInheritFromBaseEntity()
    {
        // Arrange
        var branch = new Branch();

        // Assert
        branch.Should().BeAssignableTo<BaseEntity>();
        branch.Should().BeAssignableTo<IEntity>();
        branch.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void Branch_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var branch = new Branch { Id = 777 };

        // Act
        var result = branch.ToString();

        // Assert
        result.Should().Contain("Branch");
    }

    [Theory]
    [InlineData("Pizza Hut", "Make It Great", "https://example.com/pizza-hut.png", "+1555123456", "https://pizzahut.com")]
    [InlineData("Domino's", "You Got 30 Minutes", "https://example.com/dominos.png", "+1555987654", "https://dominos.com")]
    [InlineData("", "", "", "", "")]
    public void Branch_WithVariousValues_ShouldBeCreatable(string franchiseName, string franchiseSlogan, string logoUrl, string phoneNumber, string websiteUrl)
    {
        // Arrange & Act
        var branch = new Branch
        {
            FranchiseName = franchiseName,
            FranchiseSlogan = franchiseSlogan,
            LogoUrl = logoUrl,
            PhoneNumber = phoneNumber,
            WebsiteUrl = websiteUrl
        };

        // Assert
        branch.FranchiseName.Should().Be(franchiseName);
        branch.FranchiseSlogan.Should().Be(franchiseSlogan);
        branch.LogoUrl.Should().Be(logoUrl);
        branch.PhoneNumber.Should().Be(phoneNumber);
        branch.WebsiteUrl.Should().Be(websiteUrl);
    }
}
