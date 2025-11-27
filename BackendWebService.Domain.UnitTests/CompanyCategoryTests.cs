using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class CompanyCategoryTests
{
    [Fact]
    public void CompanyCategory_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var companyCategory = new CompanyCategory();

        // Assert
        companyCategory.Should().NotBeNull();
    }

    [Fact]
    public void CompanyCategory_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var companyCategory = new CompanyCategory();

        // Act
        var result = companyCategory.ToString();

        // Assert
        result.Should().Contain("CompanyCategory");
    }

    [Fact]
    public void CompanyCategory_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var companyCategory = new CompanyCategory();

        // Act & Assert
        companyCategory.Should().BeAssignableTo<BaseEntity>();
        companyCategory.Should().BeAssignableTo<IEntity>();
        companyCategory.Should().BeAssignableTo<ITimeModification>();
    }
}
