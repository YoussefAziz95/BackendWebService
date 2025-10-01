using Domain;
using Domain.Enums;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class SupplierTests
{
    [Fact]
    public void Supplier_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var supplier = new Supplier();

        // Assert
        supplier.Should().NotBeNull();
        supplier.OrganizationId.Should().Be(0);
        supplier.Organization.Should().BeNull();
        supplier.Rating.Should().BeNull();
        supplier.BankAccount.Should().BeNull();
        supplier.Status.Should().Be(StatusEnum.Active);
        supplier.SupplierCategories.Should().BeNull();
    }

    [Fact]
    public void Supplier_AllProperties_ShouldBeSettable()
    {
        // Arrange
        var supplier = new Supplier();
        var organization = new Organization();
        var supplierCategories = new List<SupplierCategory>();

        // Act
        supplier.OrganizationId = 123;
        supplier.Organization = organization;
        supplier.Rating = 4.5m;
        supplier.BankAccount = "1234567890";
        supplier.Status = StatusEnum.Pending;
        supplier.SupplierCategories = supplierCategories;

        // Assert
        supplier.OrganizationId.Should().Be(123);
        supplier.Organization.Should().BeSameAs(organization);
        supplier.Rating.Should().Be(4.5m);
        supplier.BankAccount.Should().Be("1234567890");
        supplier.Status.Should().Be(StatusEnum.Pending);
        supplier.SupplierCategories.Should().BeSameAs(supplierCategories);
    }

    [Fact]
    public void Supplier_WithNullValues_ShouldBeCreatable()
    {
        // Arrange & Act
        var supplier = new Supplier
        {
            Organization = null!,
            Rating = null!,
            BankAccount = null!,
            SupplierCategories = null!
        };

        // Assert
        supplier.Organization.Should().BeNull();
        supplier.Rating.Should().BeNull();
        supplier.BankAccount.Should().BeNull();
        supplier.SupplierCategories.Should().BeNull();
    }

    [Fact]
    public void Supplier_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var supplier = new Supplier
        {
            OrganizationId = 1
        };

        // Assert
        supplier.OrganizationId.Should().Be(1);
        supplier.Status.Should().Be(StatusEnum.Active);
    }

    [Fact]
    public void Supplier_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange
        var organization = new Organization { Id = 456 };
        var supplierCategories = new List<SupplierCategory> { new SupplierCategory() };

        // Act
        var supplier = new Supplier
        {
            OrganizationId = 456,
            Organization = organization,
            Rating = 4.8m,
            BankAccount = "9876543210",
            Status = StatusEnum.Completed,
            SupplierCategories = supplierCategories
        };

        // Assert
        supplier.OrganizationId.Should().Be(456);
        supplier.Organization.Should().BeSameAs(organization);
        supplier.Rating.Should().Be(4.8m);
        supplier.BankAccount.Should().Be("9876543210");
        supplier.Status.Should().Be(StatusEnum.Completed);
        supplier.SupplierCategories.Should().BeSameAs(supplierCategories);
    }

    [Fact]
    public void Supplier_WithEmptyStrings_ShouldBeCreatable()
    {
        // Arrange & Act
        var supplier = new Supplier
        {
            BankAccount = ""
        };

        // Assert
        supplier.BankAccount.Should().Be("");
    }

    [Fact]
    public void Supplier_WithLongStrings_ShouldBeCreatable()
    {
        // Arrange
        var longBankAccount = new string('A', 1000);

        // Act
        var supplier = new Supplier
        {
            BankAccount = longBankAccount
        };

        // Assert
        supplier.BankAccount.Should().Be(longBankAccount);
    }

    [Fact]
    public void Supplier_WithNegativeOrganizationId_ShouldBeCreatable()
    {
        // Arrange & Act
        var supplier = new Supplier
        {
            OrganizationId = -1
        };

        // Assert
        supplier.OrganizationId.Should().Be(-1);
    }

    [Fact]
    public void Supplier_WithZeroOrganizationId_ShouldBeCreatable()
    {
        // Arrange & Act
        var supplier = new Supplier
        {
            OrganizationId = 0
        };

        // Assert
        supplier.OrganizationId.Should().Be(0);
    }

    [Fact]
    public void Supplier_WithNegativeRating_ShouldBeCreatable()
    {
        // Arrange & Act
        var supplier = new Supplier
        {
            Rating = -1.5m
        };

        // Assert
        supplier.Rating.Should().Be(-1.5m);
    }

    [Fact]
    public void Supplier_WithZeroRating_ShouldBeCreatable()
    {
        // Arrange & Act
        var supplier = new Supplier
        {
            Rating = 0m
        };

        // Assert
        supplier.Rating.Should().Be(0m);
    }

    [Fact]
    public void Supplier_WithMaxRating_ShouldBeCreatable()
    {
        // Arrange & Act
        var supplier = new Supplier
        {
            Rating = 5.0m
        };

        // Assert
        supplier.Rating.Should().Be(5.0m);
    }

    [Fact]
    public void Supplier_WithEmptySupplierCategories_ShouldBeCreatable()
    {
        // Arrange & Act
        var supplier = new Supplier
        {
            SupplierCategories = new List<SupplierCategory>()
        };

        // Assert
        supplier.SupplierCategories.Should().NotBeNull();
        supplier.SupplierCategories.Should().BeEmpty();
    }

    [Fact]
    public void Supplier_WithMultipleSupplierCategories_ShouldBeCreatable()
    {
        // Arrange
        var supplierCategories = new List<SupplierCategory>
        {
            new SupplierCategory { Id = 1 },
            new SupplierCategory { Id = 2 },
            new SupplierCategory { Id = 3 }
        };

        // Act
        var supplier = new Supplier
        {
            SupplierCategories = supplierCategories
        };

        // Assert
        supplier.SupplierCategories.Should().HaveCount(3);
        supplier.SupplierCategories.Should().Contain(supplierCategories);
    }

    [Fact]
    public void Supplier_ShouldInheritFromBaseEntity()
    {
        // Arrange
        var supplier = new Supplier();

        // Assert
        supplier.Should().BeAssignableTo<BaseEntity>();
        supplier.Should().BeAssignableTo<IEntity>();
        supplier.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void Supplier_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var supplier = new Supplier { Id = 888 };

        // Act
        var result = supplier.ToString();

        // Assert
        result.Should().Contain("Supplier");
    }

    [Theory]
    [InlineData(100, 4.5, "1234567890", StatusEnum.Active)]
    [InlineData(200, 3.2, "9876543210", StatusEnum.Pending)]
    [InlineData(0, 0.0, "", StatusEnum.Completed)]
    public void Supplier_WithVariousValues_ShouldBeCreatable(int organizationId, decimal rating, string bankAccount, StatusEnum status)
    {
        // Arrange & Act
        var supplier = new Supplier
        {
            OrganizationId = organizationId,
            Rating = rating,
            BankAccount = bankAccount,
            Status = status
        };

        // Assert
        supplier.OrganizationId.Should().Be(organizationId);
        supplier.Rating.Should().Be(rating);
        supplier.BankAccount.Should().Be(bankAccount);
        supplier.Status.Should().Be(status);
    }
}
