using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class ServiceTests
{
    [Fact]
    public void Service_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var service = new Service();

        // Assert
        service.Should().NotBeNull();
        service.Name.Should().BeNull();
        service.Description.Should().BeNull();
        service.Code.Should().BeNull();
        service.CategoryId.Should().Be(0);
        service.Category.Should().BeNull();
    }

    [Fact]
    public void Service_AllProperties_ShouldBeSettable()
    {
        // Arrange
        var service = new Service();
        var category = new Category();

        // Act
        service.Name = "Web Development";
        service.Description = "Custom web application development";
        service.Code = "WEB001";
        service.CategoryId = 123;
        service.Category = category;

        // Assert
        service.Name.Should().Be("Web Development");
        service.Description.Should().Be("Custom web application development");
        service.Code.Should().Be("WEB001");
        service.CategoryId.Should().Be(123);
        service.Category.Should().BeSameAs(category);
    }

    [Fact]
    public void Service_WithNullValues_ShouldBeCreatable()
    {
        // Arrange & Act
        var service = new Service
        {
            Name = null!,
            Description = null!,
            Code = null!,
            Category = null!
        };

        // Assert
        service.Name.Should().BeNull();
        service.Description.Should().BeNull();
        service.Code.Should().BeNull();
        service.Category.Should().BeNull();
    }

    [Fact]
    public void Service_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var service = new Service
        {
            Name = "Consulting",
            Code = "CONS001",
            CategoryId = 1
        };

        // Assert
        service.Name.Should().Be("Consulting");
        service.Code.Should().Be("CONS001");
        service.CategoryId.Should().Be(1);
    }

    [Fact]
    public void Service_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange
        var category = new Category { Id = 456 };

        // Act
        var service = new Service
        {
            Name = "Mobile App Development",
            Description = "Native and cross-platform mobile application development",
            Code = "MOB001",
            CategoryId = 456,
            Category = category
        };

        // Assert
        service.Name.Should().Be("Mobile App Development");
        service.Description.Should().Be("Native and cross-platform mobile application development");
        service.Code.Should().Be("MOB001");
        service.CategoryId.Should().Be(456);
        service.Category.Should().BeSameAs(category);
    }

    [Fact]
    public void Service_WithEmptyStrings_ShouldBeCreatable()
    {
        // Arrange & Act
        var service = new Service
        {
            Name = "",
            Description = "",
            Code = ""
        };

        // Assert
        service.Name.Should().Be("");
        service.Description.Should().Be("");
        service.Code.Should().Be("");
    }

    [Fact]
    public void Service_WithLongStrings_ShouldBeCreatable()
    {
        // Arrange
        var longName = new string('A', 1000);
        var longDescription = new string('B', 2000);
        var longCode = new string('C', 500);

        // Act
        var service = new Service
        {
            Name = longName,
            Description = longDescription,
            Code = longCode
        };

        // Assert
        service.Name.Should().Be(longName);
        service.Description.Should().Be(longDescription);
        service.Code.Should().Be(longCode);
    }

    [Fact]
    public void Service_WithNegativeCategoryId_ShouldBeCreatable()
    {
        // Arrange & Act
        var service = new Service
        {
            CategoryId = -1
        };

        // Assert
        service.CategoryId.Should().Be(-1);
    }

    [Fact]
    public void Service_WithZeroCategoryId_ShouldBeCreatable()
    {
        // Arrange & Act
        var service = new Service
        {
            CategoryId = 0
        };

        // Assert
        service.CategoryId.Should().Be(0);
    }

    [Fact]
    public void Service_WithLargeCategoryId_ShouldBeCreatable()
    {
        // Arrange & Act
        var service = new Service
        {
            CategoryId = int.MaxValue
        };

        // Assert
        service.CategoryId.Should().Be(int.MaxValue);
    }

    [Fact]
    public void Service_WithSpecialCharacters_ShouldBeCreatable()
    {
        // Arrange & Act
        var service = new Service
        {
            Name = "AI & Machine Learning",
            Description = "Artificial Intelligence & ML Solutions 🚀",
            Code = "AI-ML-001"
        };

        // Assert
        service.Name.Should().Be("AI & Machine Learning");
        service.Description.Should().Be("Artificial Intelligence & ML Solutions 🚀");
        service.Code.Should().Be("AI-ML-001");
    }

    [Fact]
    public void Service_WithNumericCode_ShouldBeCreatable()
    {
        // Arrange & Act
        var service = new Service
        {
            Code = "12345"
        };

        // Assert
        service.Code.Should().Be("12345");
    }

    [Fact]
    public void Service_WithAlphanumericCode_ShouldBeCreatable()
    {
        // Arrange & Act
        var service = new Service
        {
            Code = "ABC123XYZ"
        };

        // Assert
        service.Code.Should().Be("ABC123XYZ");
    }

    [Fact]
    public void Service_ShouldInheritFromBaseEntity()
    {
        // Arrange
        var service = new Service();

        // Assert
        service.Should().BeAssignableTo<BaseEntity>();
        service.Should().BeAssignableTo<IEntity>();
        service.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void Service_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var service = new Service { Id = 666 };

        // Act
        var result = service.ToString();

        // Assert
        result.Should().Contain("Service");
    }

    [Theory]
    [InlineData("Data Analysis", "Statistical analysis and data visualization", "DATA001", 100)]
    [InlineData("Cloud Computing", "AWS, Azure, and GCP solutions", "CLOUD001", 200)]
    [InlineData("", "", "", 0)]
    public void Service_WithVariousValues_ShouldBeCreatable(string name, string description, string code, int categoryId)
    {
        // Arrange & Act
        var service = new Service
        {
            Name = name,
            Description = description,
            Code = code,
            CategoryId = categoryId
        };

        // Assert
        service.Name.Should().Be(name);
        service.Description.Should().Be(description);
        service.Code.Should().Be(code);
        service.CategoryId.Should().Be(categoryId);
    }
}
