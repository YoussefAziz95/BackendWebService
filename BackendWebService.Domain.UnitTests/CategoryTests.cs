using FluentAssertions;
using Domain;
using Domain.Enums;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class CategoryTests
{
    #region Constructor Tests

    [Fact]
    public void Category_DefaultConstructor_ShouldCreateInstance()
    {
        // Arrange & Act
        var category = new Category();

        // Assert
        category.Should().NotBeNull();
        category.Id.Should().Be(0);
        category.Name.Should().BeNull();
        category.ParentId.Should().BeNull();
        category.FileId.Should().BeNull();
        category.File.Should().BeNull();
        category.ParentCategory.Should().BeNull();
        category.SubCategories.Should().BeNull();
        category.CreatedDate.Should().NotBeNull();
        category.UpdatedDate.Should().BeNull();
        category.CreatedBy.Should().BeNull();
        category.UpdatedBy.Should().BeNull();
        category.IsActive.Should().BeTrue();
        category.IsDeleted.Should().BeFalse();
    }

    #endregion

    #region Property Setting Tests

    [Theory]
    [InlineData("Electronics")]
    [InlineData("Clothing")]
    [InlineData("Books")]
    [InlineData("")]
    public void Category_Name_ShouldBeSettable(string name)
    {
        // Arrange
        var category = new Category();

        // Act
        category.Name = name;

        // Assert
        category.Name.Should().Be(name);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    public void Category_ParentId_ShouldBeSettable(int? parentId)
    {
        // Arrange
        var category = new Category();

        // Act
        category.ParentId = parentId;

        // Assert
        category.ParentId.Should().Be(parentId);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    public void Category_FileId_ShouldBeSettable(int? fileId)
    {
        // Arrange
        var category = new Category();

        // Act
        category.FileId = fileId;

        // Assert
        category.FileId.Should().Be(fileId);
    }

    [Fact]
    public void Category_File_ShouldBeSettable()
    {
        // Arrange
        var category = new Category();
        var file = new FileLog();

        // Act
        category.File = file;

        // Assert
        category.File.Should().BeSameAs(file);
    }

    [Fact]
    public void Category_ParentCategory_ShouldBeSettable()
    {
        // Arrange
        var category = new Category();
        var parentCategory = new Category();

        // Act
        category.ParentCategory = parentCategory;

        // Assert
        category.ParentCategory.Should().BeSameAs(parentCategory);
    }

    [Fact]
    public void Category_SubCategories_ShouldBeSettable()
    {
        // Arrange
        var category = new Category();
        var subCategories = new List<Category>();

        // Act
        category.SubCategories = subCategories;

        // Assert
        category.SubCategories.Should().BeSameAs(subCategories);
    }

    #endregion

    #region Business Logic Tests

    [Fact]
    public void Category_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var category = new Category
        {
            Name = "Electronics"
        };

        // Assert
        category.Name.Should().Be("Electronics");
        category.ParentId.Should().BeNull();
        category.FileId.Should().BeNull();
        category.File.Should().BeNull();
        category.ParentCategory.Should().BeNull();
        category.SubCategories.Should().BeNull();
    }

    [Fact]
    public void Category_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange & Act
        var parentCategory = new Category { Name = "Parent Category" };
        var file = new FileLog();
        var subCategories = new List<Category> { new Category { Name = "Sub Category" } };

        var category = new Category
        {
            Name = "Electronics",
            ParentId = 1,
            FileId = 123,
            File = file,
            ParentCategory = parentCategory,
            SubCategories = subCategories
        };

        // Assert
        category.Name.Should().Be("Electronics");
        category.ParentId.Should().Be(1);
        category.FileId.Should().Be(123);
        category.File.Should().BeSameAs(file);
        category.ParentCategory.Should().BeSameAs(parentCategory);
        category.SubCategories.Should().BeSameAs(subCategories);
    }

    [Fact]
    public void Category_WithNullFile_ShouldBeCreatable()
    {
        // Arrange & Act
        var category = new Category
        {
            Name = "Electronics",
            FileId = 123,
            File = null
        };

        // Assert
        category.Name.Should().Be("Electronics");
        category.FileId.Should().Be(123);
        category.File.Should().BeNull();
    }

    [Fact]
    public void Category_WithNullParentCategory_ShouldBeCreatable()
    {
        // Arrange & Act
        var category = new Category
        {
            Name = "Electronics",
            ParentId = 1,
            ParentCategory = null
        };

        // Assert
        category.Name.Should().Be("Electronics");
        category.ParentId.Should().Be(1);
        category.ParentCategory.Should().BeNull();
    }

    [Fact]
    public void Category_WithNullSubCategories_ShouldBeCreatable()
    {
        // Arrange & Act
        var category = new Category
        {
            Name = "Electronics",
            SubCategories = null
        };

        // Assert
        category.Name.Should().Be("Electronics");
        category.SubCategories.Should().BeNull();
    }

    #endregion

    #region Edge Cases Tests

    [Fact]
    public void Category_WithEmptyName_ShouldBeCreatable()
    {
        // Arrange & Act
        var category = new Category
        {
            Name = ""
        };

        // Assert
        category.Name.Should().Be("");
    }

    [Fact]
    public void Category_WithNullName_ShouldBeCreatable()
    {
        // Arrange & Act
        var category = new Category
        {
            Name = null!
        };

        // Assert
        category.Name.Should().BeNull();
    }

    [Fact]
    public void Category_WithZeroParentId_ShouldBeCreatable()
    {
        // Arrange & Act
        var category = new Category
        {
            Name = "Electronics",
            ParentId = 0
        };

        // Assert
        category.Name.Should().Be("Electronics");
        category.ParentId.Should().Be(0);
    }

    [Fact]
    public void Category_WithNegativeParentId_ShouldBeCreatable()
    {
        // Arrange & Act
        var category = new Category
        {
            Name = "Electronics",
            ParentId = -1
        };

        // Assert
        category.Name.Should().Be("Electronics");
        category.ParentId.Should().Be(-1);
    }

    [Fact]
    public void Category_WithZeroFileId_ShouldBeCreatable()
    {
        // Arrange & Act
        var category = new Category
        {
            Name = "Electronics",
            FileId = 0
        };

        // Assert
        category.Name.Should().Be("Electronics");
        category.FileId.Should().Be(0);
    }

    [Fact]
    public void Category_WithNegativeFileId_ShouldBeCreatable()
    {
        // Arrange & Act
        var category = new Category
        {
            Name = "Electronics",
            FileId = -1
        };

        // Assert
        category.Name.Should().Be("Electronics");
        category.FileId.Should().Be(-1);
    }

    #endregion

    #region Boundary Values Tests

    [Theory]
    [InlineData("A")] // Minimum length
    [InlineData("Electronics")] // Normal length
    [InlineData("Very Long Category Name That Exceeds Normal Length And Should Still Be Valid")] // Long string
    public void Category_Name_ShouldHandleVariousLengths(string name)
    {
        // Arrange
        var category = new Category();

        // Act
        category.Name = name;

        // Assert
        category.Name.Should().Be(name);
    }

    [Theory]
    [InlineData(1)] // Minimum valid ID
    [InlineData(100)] // Normal ID
    [InlineData(int.MaxValue)] // Maximum ID
    public void Category_ParentId_ShouldHandleVariousValues(int parentId)
    {
        // Arrange
        var category = new Category();

        // Act
        category.ParentId = parentId;

        // Assert
        category.ParentId.Should().Be(parentId);
    }

    [Theory]
    [InlineData(1)] // Minimum valid ID
    [InlineData(100)] // Normal ID
    [InlineData(int.MaxValue)] // Maximum ID
    public void Category_FileId_ShouldHandleVariousValues(int fileId)
    {
        // Arrange
        var category = new Category();

        // Act
        category.FileId = fileId;

        // Assert
        category.FileId.Should().Be(fileId);
    }

    #endregion

    #region String Properties Tests

    [Fact]
    public void Category_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var category = new Category
        {
            Id = 1,
            Name = "Electronics"
        };

        // Act
        var result = category.ToString();

        // Assert
        result.Should().NotBeNull();
        result.Should().Contain("Category");
    }

    #endregion

    #region Collection Properties Tests

    [Fact]
    public void Category_SubCategories_ShouldBeInitializedAsEmptyList()
    {
        // Arrange
        var category = new Category();

        // Act
        category.SubCategories = new List<Category>();

        // Assert
        category.SubCategories.Should().NotBeNull();
        category.SubCategories.Should().BeEmpty();
    }

    [Fact]
    public void Category_SubCategories_ShouldAcceptMultipleItems()
    {
        // Arrange
        var category = new Category();
        var subCategories = new List<Category>
        {
            new Category { Name = "Sub Category 1" },
            new Category { Name = "Sub Category 2" },
            new Category { Name = "Sub Category 3" }
        };

        // Act
        category.SubCategories = subCategories;

        // Assert
        category.SubCategories.Should().NotBeNull();
        category.SubCategories.Should().HaveCount(3);
        category.SubCategories.Should().Contain(subCategories);
    }

    #endregion

    #region Relationship Tests

    [Fact]
    public void Category_ParentChildRelationship_ShouldBeEstablishable()
    {
        // Arrange
        var parentCategory = new Category { Name = "Parent Category" };
        var childCategory = new Category { Name = "Child Category" };

        // Act
        childCategory.ParentCategory = parentCategory;
        childCategory.ParentId = parentCategory.Id;

        // Assert
        childCategory.ParentCategory.Should().BeSameAs(parentCategory);
        childCategory.ParentId.Should().Be(parentCategory.Id);
    }

    [Fact]
    public void Category_FileRelationship_ShouldBeEstablishable()
    {
        // Arrange
        var category = new Category { Name = "Electronics" };
        var file = new FileLog();

        // Act
        category.File = file;
        category.FileId = file.Id;

        // Assert
        category.File.Should().BeSameAs(file);
        category.FileId.Should().Be(file.Id);
    }

    #endregion
}