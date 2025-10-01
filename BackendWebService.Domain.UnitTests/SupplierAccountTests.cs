using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class SupplierAccountTests
{
    [Fact]
    public void SupplierAccount_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var supplierAccount = new SupplierAccount();

        // Assert
        supplierAccount.Should().NotBeNull();
    }

    [Fact]
    public void SupplierAccount_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var supplierAccount = new SupplierAccount();

        // Act
        var result = supplierAccount.ToString();

        // Assert
        result.Should().Contain("SupplierAccount");
    }

    [Fact]
    public void SupplierAccount_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var supplierAccount = new SupplierAccount();

        // Act & Assert
        supplierAccount.Should().BeAssignableTo<BaseEntity>();
        supplierAccount.Should().BeAssignableTo<IEntity>();
        supplierAccount.Should().BeAssignableTo<ITimeModification>();
    }
}
