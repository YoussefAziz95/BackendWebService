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

    #region Property Validation Tests

    [Theory]
    [InlineData("PROD001", true)]
    [InlineData("PRODUCT-123", true)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void Product_Number_ShouldValidateCorrectly(string number, bool isValid)
    {
        // Arrange
        var product = new Product
        {
            Number = number,
            Name = "Test Product",
            Description = "Test Description",
            Code = "CODE001",
            PartNumber = "PART001",
            Manufacturer = "Test Manufacturer",
            CategoryId = 1
        };

        // Act
        var validationContext = new ValidationContext(product) { MemberName = nameof(Product.Number) };
        var validationResults = new List<ValidationResult>();
        var actualIsValid = Validator.TryValidateProperty(product.Number, validationContext, validationResults);

        // Assert
        actualIsValid.Should().Be(isValid);
        if (!isValid)
        {
            validationResults.Should().NotBeEmpty();
        }
        else
        {
            validationResults.Should().BeEmpty();
        }
    }

    [Theory]
    [InlineData("Test Product", true)]
    [InlineData("Product Name", true)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void Product_Name_ShouldValidateCorrectly(string name, bool isValid)
    {
        // Arrange
        var product = new Product
        {
            Number = "PROD001",
            Name = name,
            Description = "Test Description",
            Code = "CODE001",
            PartNumber = "PART001",
            Manufacturer = "Test Manufacturer",
            CategoryId = 1
        };

        // Act
        var validationContext = new ValidationContext(product) { MemberName = nameof(Product.Name) };
        var validationResults = new List<ValidationResult>();
        var actualIsValid = Validator.TryValidateProperty(product.Name, validationContext, validationResults);

        // Assert
        actualIsValid.Should().Be(isValid);
        if (!isValid)
        {
            validationResults.Should().NotBeEmpty();
        }
        else
        {
            validationResults.Should().BeEmpty();
        }
    }

    [Theory]
    [InlineData("Test Description", true)]
    [InlineData("Product Description", true)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void Product_Description_ShouldValidateCorrectly(string description, bool isValid)
    {
        // Arrange
        var product = new Product
        {
            Number = "PROD001",
            Name = "Test Product",
            Description = description,
            Code = "CODE001",
            PartNumber = "PART001",
            Manufacturer = "Test Manufacturer",
            CategoryId = 1
        };

        // Act
        var validationContext = new ValidationContext(product) { MemberName = nameof(Product.Description) };
        var validationResults = new List<ValidationResult>();
        var actualIsValid = Validator.TryValidateProperty(product.Description, validationContext, validationResults);

        // Assert
        actualIsValid.Should().Be(isValid);
        if (!isValid)
        {
            validationResults.Should().NotBeEmpty();
        }
        else
        {
            validationResults.Should().BeEmpty();
        }
    }

    [Theory]
    [InlineData("CODE001", true)]
    [InlineData("PRODUCT-CODE", true)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void Product_Code_ShouldValidateCorrectly(string code, bool isValid)
    {
        // Arrange
        var product = new Product
        {
            Number = "PROD001",
            Name = "Test Product",
            Description = "Test Description",
            Code = code,
            PartNumber = "PART001",
            Manufacturer = "Test Manufacturer",
            CategoryId = 1
        };

        // Act
        var validationContext = new ValidationContext(product) { MemberName = nameof(Product.Code) };
        var validationResults = new List<ValidationResult>();
        var actualIsValid = Validator.TryValidateProperty(product.Code, validationContext, validationResults);

        // Assert
        actualIsValid.Should().Be(isValid);
        if (!isValid)
        {
            validationResults.Should().NotBeEmpty();
        }
        else
        {
            validationResults.Should().BeEmpty();
        }
    }

    [Theory]
    [InlineData("PART001", true)]
    [InlineData("PART-123", true)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void Product_PartNumber_ShouldValidateCorrectly(string partNumber, bool isValid)
    {
        // Arrange
        var product = new Product
        {
            Number = "PROD001",
            Name = "Test Product",
            Description = "Test Description",
            Code = "CODE001",
            PartNumber = partNumber,
            Manufacturer = "Test Manufacturer",
            CategoryId = 1
        };

        // Act
        var validationContext = new ValidationContext(product) { MemberName = nameof(Product.PartNumber) };
        var validationResults = new List<ValidationResult>();
        var actualIsValid = Validator.TryValidateProperty(product.PartNumber, validationContext, validationResults);

        // Assert
        actualIsValid.Should().Be(isValid);
        if (!isValid)
        {
            validationResults.Should().NotBeEmpty();
        }
        else
        {
            validationResults.Should().BeEmpty();
        }
    }

    [Theory]
    [InlineData("Test Manufacturer", true)]
    [InlineData("Manufacturer Name", true)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void Product_Manufacturer_ShouldValidateCorrectly(string manufacturer, bool isValid)
    {
        // Arrange
        var product = new Product
        {
            Number = "PROD001",
            Name = "Test Product",
            Description = "Test Description",
            Code = "CODE001",
            PartNumber = "PART001",
            Manufacturer = manufacturer,
            CategoryId = 1
        };

        // Act
        var validationContext = new ValidationContext(product) { MemberName = nameof(Product.Manufacturer) };
        var validationResults = new List<ValidationResult>();
        var actualIsValid = Validator.TryValidateProperty(product.Manufacturer, validationContext, validationResults);

        // Assert
        actualIsValid.Should().Be(isValid);
        if (!isValid)
        {
            validationResults.Should().NotBeEmpty();
        }
        else
        {
            validationResults.Should().BeEmpty();
        }
    }

    [Theory]
    [InlineData(1, true)]
    [InlineData(100, true)]
    [InlineData(0, false)]
    [InlineData(-1, false)]
    public void Product_CategoryId_ShouldValidateCorrectly(int categoryId, bool isValid)
    {
        // Arrange
        var product = new Product
        {
            Number = "PROD001",
            Name = "Test Product",
            Description = "Test Description",
            Code = "CODE001",
            PartNumber = "PART001",
            Manufacturer = "Test Manufacturer",
            CategoryId = categoryId
        };

        // Act
        var validationContext = new ValidationContext(product) { MemberName = nameof(Product.CategoryId) };
        var validationResults = new List<ValidationResult>();
        var actualIsValid = Validator.TryValidateProperty(product.CategoryId, validationContext, validationResults);

        // Assert
        actualIsValid.Should().Be(isValid);
        if (!isValid)
        {
            validationResults.Should().NotBeEmpty();
        }
        else
        {
            validationResults.Should().BeEmpty();
        }
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
    public void Product_WithMinimalData_ShouldBeValid()
    {
        // Arrange
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

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(product, new ValidationContext(product), validationResults, true);

        // Assert
        isValid.Should().BeTrue();
        validationResults.Should().BeEmpty();
    }

    [Fact]
    public void Product_WithCompleteData_ShouldBeValid()
    {
        // Arrange
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

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(product, new ValidationContext(product), validationResults, true);

        // Assert
        isValid.Should().BeTrue();
        validationResults.Should().BeEmpty();
    }

    [Fact]
    public void Product_WithNullFileId_ShouldBeValid()
    {
        // Arrange
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

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(product, new ValidationContext(product), validationResults, true);

        // Assert
        isValid.Should().BeTrue();
        validationResults.Should().BeEmpty();
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
        var product = new Product
        {
            Number = number,
            Name = "Test Product",
            Description = "Test Description",
            Code = "CODE001",
            PartNumber = "PART001",
            Manufacturer = "Test Manufacturer",
            CategoryId = 1
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(product, new ValidationContext(product), validationResults, true);

        // Assert
        isValid.Should().BeTrue();
        product.Number.Should().Be(number);
    }

    [Theory]
    [InlineData("A")] // Minimum length
    [InlineData("Test Product")] // Normal length
    [InlineData("Very Long Product Name That Exceeds Normal Length And Should Still Be Valid")] // Long string
    public void Product_Name_ShouldHandleVariousLengths(string name)
    {
        // Arrange
        var product = new Product
        {
            Number = "PROD001",
            Name = name,
            Description = "Test Description",
            Code = "CODE001",
            PartNumber = "PART001",
            Manufacturer = "Test Manufacturer",
            CategoryId = 1
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(product, new ValidationContext(product), validationResults, true);

        // Assert
        isValid.Should().BeTrue();
        product.Name.Should().Be(name);
    }

    [Theory]
    [InlineData(1)] // Minimum valid ID
    [InlineData(100)] // Normal ID
    [InlineData(int.MaxValue)] // Maximum ID
    public void Product_CategoryId_ShouldHandleVariousValues(int categoryId)
    {
        // Arrange
        var product = new Product
        {
            Number = "PROD001",
            Name = "Test Product",
            Description = "Test Description",
            Code = "CODE001",
            PartNumber = "PART001",
            Manufacturer = "Test Manufacturer",
            CategoryId = categoryId
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(product, new ValidationContext(product), validationResults, true);

        // Assert
        isValid.Should().BeTrue();
        product.CategoryId.Should().Be(categoryId);
    }

    [Theory]
    [InlineData(1)] // Minimum valid ID
    [InlineData(100)] // Normal ID
    [InlineData(int.MaxValue)] // Maximum ID
    public void Product_FileId_ShouldHandleVariousValues(int fileId)
    {
        // Arrange
        var product = new Product
        {
            Number = "PROD001",
            Name = "Test Product",
            Description = "Test Description",
            Code = "CODE001",
            PartNumber = "PART001",
            Manufacturer = "Test Manufacturer",
            CategoryId = 1,
            FileId = fileId
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(product, new ValidationContext(product), validationResults, true);

        // Assert
        isValid.Should().BeTrue();
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
