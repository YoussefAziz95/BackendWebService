using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class SupplierDocumentTests
{
    [Fact]
    public void SupplierDocument_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var supplierDocument = new SupplierDocument();

        // Assert
        supplierDocument.Should().NotBeNull();
    }

    [Fact]
    public void SupplierDocument_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var supplierDocument = new SupplierDocument();

        // Act
        var result = supplierDocument.ToString();

        // Assert
        result.Should().Contain("SupplierDocument");
    }

    [Fact]
    public void SupplierDocument_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var supplierDocument = new SupplierDocument();

        // Act & Assert
        supplierDocument.Should().BeAssignableTo<BaseEntity>();
        supplierDocument.Should().BeAssignableTo<IEntity>();
        supplierDocument.Should().BeAssignableTo<ITimeModification>();
    }
}
