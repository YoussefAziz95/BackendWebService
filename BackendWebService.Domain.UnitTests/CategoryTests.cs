using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class CategoryTests
{
    [Fact]
    public void Category_Constructor_ShouldInitializeWithDefaultValues()
    {
        // Arrange & Act
        var category = new Category
        {
            Name = "Test Category"
        };

        // Assert
        category.Should().NotBeNull();
        category.Name.Should().Be("Test Category");
        category.IsActive.Should().BeTrue();
        category.IsDeleted.Should().BeFalse();
        category.IsSystem.Should().BeFalse();
        category.CreatedDate.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
    }

    [Fact]
    public void Category_Equals_WithSameId_ShouldReturnTrue()
    {
        // Arrange
        var category1 = new Category { Id = 1, Name = "Category 1" };
        var category2 = new Category { Id = 1, Name = "Category 2" };

        // Act & Assert
        category1.Should().Be(category2);
        (category1 == category2).Should().BeTrue();
        (category1 != category2).Should().BeFalse();
    }

    [Fact]
    public void Category_Equals_WithDifferentId_ShouldReturnFalse()
    {
        // Arrange
        var category1 = new Category { Id = 1, Name = "Category 1" };
        var category2 = new Category { Id = 2, Name = "Category 1" };

        // Act & Assert
        category1.Should().NotBe(category2);
        (category1 == category2).Should().BeFalse();
        (category1 != category2).Should().BeTrue();
    }

    [Fact]
    public void Category_GetHashCode_WithSameId_ShouldReturnSameValue()
    {
        // Arrange
        var category1 = new Category { Id = 1, Name = "Category 1" };
        var category2 = new Category { Id = 1, Name = "Category 2" };

        // Act
        var hashCode1 = category1.GetHashCode();
        var hashCode2 = category2.GetHashCode();

        // Assert
        hashCode1.Should().Be(hashCode2);
    }

    [Fact]
    public void Category_GetHashCode_WithDifferentId_ShouldReturnDifferentValue()
    {
        // Arrange
        var category1 = new Category { Id = 1, Name = "Category 1" };
        var category2 = new Category { Id = 2, Name = "Category 1" };

        // Act
        var hashCode1 = category1.GetHashCode();
        var hashCode2 = category2.GetHashCode();

        // Assert
        hashCode1.Should().NotBe(hashCode2);
    }

    [Fact]
    public void Category_WithParentId_ShouldSetParentId()
    {
        // Arrange & Act
        var category = new Category
        {
            Name = "Sub Category",
            ParentId = 5
        };

        // Assert
        category.ParentId.Should().Be(5);
    }

    [Fact]
    public void Category_WithFileId_ShouldSetFileId()
    {
        // Arrange & Act
        var category = new Category
        {
            Name = "Category with File",
            FileId = 10
        };

        // Assert
        category.FileId.Should().Be(10);
    }
}
