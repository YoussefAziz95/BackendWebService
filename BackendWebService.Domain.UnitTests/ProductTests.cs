using Xunit;
using FluentAssertions;
using Domain;
using System.ComponentModel.DataAnnotations;

namespace BackendWebService.Domain.UnitTests;

public class ProductTests
{
    #region Constructor Tests

    [Fact]
    public void Product_Constructor_ShouldSetDefaultValues()
    {
        // Arrange & Act
        var product = new Product();

        // Assert
        product.Number.Should().BeNull();
        product.Name.Should().BeNull();
        product.Description.Should().BeNull();
        product.Code.Should().BeNull();
        product.PartNumber.Should().BeNull();
        product.Manufacturer.Should().BeNull();
        product.CategoryId.Should().Be(0);
        product.FileId.Should().BeNull();
    }

    #endregion

    #region Property Setting Tests

    [Theory]
    [InlineData("PROD001")]
    [InlineData("PRODUCT-123")]
    [InlineData("")]
    [InlineData(null)]
    public void Product_Number_ShouldBeSettable(string number)
    {
        // Arrange
        var product = new Product();

        // Act
        product.Number = number;

        // Assert
        product.Number.Should().Be(number);
    }

    [Theory]
    [InlineData("Test Product")]
    [InlineData("Product Name")]
    [InlineData("")]
    [InlineData(null)]
    public void Product_Name_ShouldBeSettable(string name)
    {
        // Arrange
        var product = new Product();

        // Act
        product.Name = name;

        // Assert
        product.Name.Should().Be(name);
    }

    [Theory]
    [InlineData("Test Description")]
    [InlineData("Product Description")]
    [InlineData("")]
    [InlineData(null)]
    public void Product_Description_ShouldBeSettable(string description)
    {
        // Arrange
        var product = new Product();

        // Act
        product.Description = description;

        // Assert
        product.Description.Should().Be(description);
    }

    [Theory]
    [InlineData("CODE001")]
    [InlineData("PRODUCT-CODE")]
    [InlineData("")]
    [InlineData(null)]
    public void Product_Code_ShouldBeSettable(string code)
    {
        // Arrange
        var product = new Product();

        // Act
        product.Code = code;

        // Assert
        product.Code.Should().Be(code);
    }

    [Theory]
    [InlineData("PART001")]
    [InlineData("PART-123")]
    [InlineData("")]
    [InlineData(null)]
    public void Product_PartNumber_ShouldBeSettable(string partNumber)
    {
        // Arrange
        var product = new Product();

        // Act
        product.PartNumber = partNumber;

        // Assert
        product.PartNumber.Should().Be(partNumber);
    }

    [Theory]
    [InlineData("Test Manufacturer")]
    [InlineData("Manufacturer Name")]
    [InlineData("")]
    [InlineData(null)]
    public void Product_Manufacturer_ShouldBeSettable(string manufacturer)
    {
        // Arrange
        var product = new Product();

        // Act
        product.Manufacturer = manufacturer;

        // Assert
        product.Manufacturer.Should().Be(manufacturer);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    public void Product_CategoryId_ShouldBeSettable(int categoryId)
    {
        // Arrange
        var product = new Product();

        // Act
        product.CategoryId = categoryId;

        // Assert
        product.CategoryId.Should().Be(categoryId);
    }

    #endregion

    #region Business Logic Tests

    [Fact]
    public void Product_FileId_ShouldBeSettable()
    {
        // Arrange
        var product = new Product();
        var fileId = 123;

        // Act
        product.FileId = fileId;

        // Assert
        product.FileId.Should().Be(fileId);
    }

    [Fact]
    public void Product_FileId_ShouldBeNullable()
    {
        // Arrange
        var product = new Product();
        product.FileId = 123;

        // Act
        product.FileId = null;

        // Assert
        product.FileId.Should().BeNull();
    }

    [Fact]
    public void Product_AllProperties_ShouldBeSettable()
    {
        // Arrange
        var product = new Product();
        var number = "PROD001";
        var name = "Test Product";
        var description = "Test Description";
        var code = "CODE001";
        var partNumber = "PART001";
        var manufacturer = "Test Manufacturer";
        var categoryId = 1;
        var fileId = 123;

        // Act
        product.Number = number;
        product.Name = name;
        product.Description = description;
        product.Code = code;
        product.PartNumber = partNumber;
        product.Manufacturer = manufacturer;
        product.CategoryId = categoryId;
        product.FileId = fileId;

        // Assert
        product.Number.Should().Be(number);
        product.Name.Should().Be(name);
        product.Description.Should().Be(description);
        product.Code.Should().Be(code);
        product.PartNumber.Should().Be(partNumber);
        product.Manufacturer.Should().Be(manufacturer);
        product.CategoryId.Should().Be(categoryId);
        product.FileId.Should().Be(fileId);
    }

    #endregion

    #region Edge Cases Tests

    [Fact]
    public void Product_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var product = new Product
        {
            Number = "PROD001",
            Name = "Test Product",
            Description = "Test Description",
            Code = "CODE001",
            PartNumber = "PART001",
            Manufacturer = "Test Manufacturer",
            CategoryId = 1
        };

        // Assert
        product.Number.Should().Be("PROD001");
        product.Name.Should().Be("Test Product");
        product.Description.Should().Be("Test Description");
        product.Code.Should().Be("CODE001");
        product.PartNumber.Should().Be("PART001");
        product.Manufacturer.Should().Be("Test Manufacturer");
        product.CategoryId.Should().Be(1);
    }

    [Fact]
    public void Product_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange & Act
        var product = new Product
        {
            Number = "PROD001",
            Name = "Test Product",
            Description = "Test Description",
            Code = "CODE001",
            PartNumber = "PART001",
            Manufacturer = "Test Manufacturer",
            CategoryId = 1,
            FileId = 123
        };

        // Assert
        product.Number.Should().Be("PROD001");
        product.Name.Should().Be("Test Product");
        product.Description.Should().Be("Test Description");
        product.Code.Should().Be("CODE001");
        product.PartNumber.Should().Be("PART001");
        product.Manufacturer.Should().Be("Test Manufacturer");
        product.CategoryId.Should().Be(1);
        product.FileId.Should().Be(123);
    }

    [Fact]
    public void Product_WithNullFileId_ShouldBeCreatable()
    {
        // Arrange & Act
        var product = new Product
        {
            Number = "PROD001",
            Name = "Test Product",
            Description = "Test Description",
            Code = "CODE001",
            PartNumber = "PART001",
            Manufacturer = "Test Manufacturer",
            CategoryId = 1,
            FileId = null
        };

        // Assert
        product.Number.Should().Be("PROD001");
        product.Name.Should().Be("Test Product");
        product.Description.Should().Be("Test Description");
        product.Code.Should().Be("CODE001");
        product.PartNumber.Should().Be("PART001");
        product.Manufacturer.Should().Be("Test Manufacturer");
        product.CategoryId.Should().Be(1);
        product.FileId.Should().BeNull();
    }

    #endregion

    #region Boundary Values Tests

    [Theory]
    [InlineData("A")] // Minimum length
    [InlineData("PROD001")] // Normal length
    [InlineData("VERY_LONG_PRODUCT_NUMBER_THAT_EXCEEDS_NORMAL_LENGTH")] // Long string
    public void Product_Number_ShouldHandleVariousLengths(string number)
    {
        // Arrange
        var product = new Product();

        // Act
        product.Number = number;

        // Assert
        product.Number.Should().Be(number);
    }

    [Theory]
    [InlineData("A")] // Minimum length
    [InlineData("Test Product")] // Normal length
    [InlineData("Very Long Product Name That Exceeds Normal Length And Should Still Be Valid")] // Long string
    public void Product_Name_ShouldHandleVariousLengths(string name)
    {
        // Arrange
        var product = new Product();

        // Act
        product.Name = name;

        // Assert
        product.Name.Should().Be(name);
    }

    [Theory]
    [InlineData(1)] // Minimum valid ID
    [InlineData(100)] // Normal ID
    [InlineData(int.MaxValue)] // Maximum ID
    public void Product_CategoryId_ShouldHandleVariousValues(int categoryId)
    {
        // Arrange
        var product = new Product();

        // Act
        product.CategoryId = categoryId;

        // Assert
        product.CategoryId.Should().Be(categoryId);
    }

    [Theory]
    [InlineData(1)] // Minimum valid ID
    [InlineData(100)] // Normal ID
    [InlineData(int.MaxValue)] // Maximum ID
    public void Product_FileId_ShouldHandleVariousValues(int fileId)
    {
        // Arrange
        var product = new Product();

        // Act
        product.FileId = fileId;

        // Assert
        product.FileId.Should().Be(fileId);
    }

    #endregion

    #region String Properties Tests

    [Theory]
    [InlineData("PROD001", "Test Product", "Test Description", "CODE001", "PART001", "Test Manufacturer")]
    [InlineData("PROD-002", "Another Product", "Another Description", "CODE-002", "PART-002", "Another Manufacturer")]
    [InlineData("123", "Product 123", "Description 123", "123", "123", "Manufacturer 123")]
    public void Product_StringProperties_ShouldBeSettable(string number, string name, string description, string code, string partNumber, string manufacturer)
    {
        // Arrange
        var product = new Product();

        // Act
        product.Number = number;
        product.Name = name;
        product.Description = description;
        product.Code = code;
        product.PartNumber = partNumber;
        product.Manufacturer = manufacturer;
        product.CategoryId = 1;

        // Assert
        product.Number.Should().Be(number);
        product.Name.Should().Be(name);
        product.Description.Should().Be(description);
        product.Code.Should().Be(code);
        product.PartNumber.Should().Be(partNumber);
        product.Manufacturer.Should().Be(manufacturer);
    }

    #endregion
}
