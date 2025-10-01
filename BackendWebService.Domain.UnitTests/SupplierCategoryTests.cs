using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class SupplierCategoryTests
{
    [Fact]
    public void SupplierCategory_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var supplierCategory = new SupplierCategory();

        // Assert
        supplierCategory.Should().NotBeNull();
    }

    [Fact]
    public void SupplierCategory_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var supplierCategory = new SupplierCategory();

        // Act
        var result = supplierCategory.ToString();

        // Assert
        result.Should().Contain("SupplierCategory");
    }

    [Fact]
    public void SupplierCategory_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var supplierCategory = new SupplierCategory();

        // Act & Assert
        supplierCategory.Should().BeAssignableTo<BaseEntity>();
        supplierCategory.Should().BeAssignableTo<IEntity>();
        supplierCategory.Should().BeAssignableTo<ITimeModification>();
    }
}
