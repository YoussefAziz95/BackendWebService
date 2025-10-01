using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class BaseEntityTests
{
    [Fact]
    public void BaseEntity_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var entity = new TestEntity();

        // Assert
        entity.Should().NotBeNull();
        entity.Id.Should().Be(0);
        entity.OrganizationId.Should().BeNull();
        entity.IsActive.Should().BeTrue();
        entity.IsDeleted.Should().BeFalse();
        entity.IsSystem.Should().BeFalse();
        entity.CreatedDate.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
        entity.CreatedBy.Should().BeNull();
        entity.UpdatedDate.Should().BeNull();
        entity.UpdatedBy.Should().BeNull();
    }

    [Fact]
    public void BaseEntity_Equals_WithSameId_ShouldReturnTrue()
    {
        // Arrange
        var entity1 = new TestEntity { Id = 1 };
        var entity2 = new TestEntity { Id = 1 };

        // Act & Assert
        entity1.Equals(entity2).Should().BeTrue();
        (entity1 == entity2).Should().BeTrue();
        (entity1 != entity2).Should().BeFalse();
    }

    [Fact]
    public void BaseEntity_Equals_WithDifferentId_ShouldReturnFalse()
    {
        // Arrange
        var entity1 = new TestEntity { Id = 1 };
        var entity2 = new TestEntity { Id = 2 };

        // Act & Assert
        entity1.Equals(entity2).Should().BeFalse();
        (entity1 == entity2).Should().BeFalse();
        (entity1 != entity2).Should().BeTrue();
    }

    [Fact]
    public void BaseEntity_Equals_WithNull_ShouldReturnFalse()
    {
        // Arrange
        var entity = new TestEntity { Id = 1 };

        // Act & Assert
        entity.Equals(null).Should().BeFalse();
        (entity == null).Should().BeFalse();
        (entity != null).Should().BeTrue();
    }

    [Fact]
    public void BaseEntity_Equals_WithDifferentType_ShouldReturnFalse()
    {
        // Arrange
        var entity1 = new TestEntity { Id = 1 };
        var entity2 = new AnotherTestEntity { Id = 1 };

        // Act & Assert
        entity1.Equals(entity2).Should().BeFalse();
    }

    [Fact]
    public void BaseEntity_Equals_WithSameReference_ShouldReturnTrue()
    {
        // Arrange
        var entity = new TestEntity { Id = 1 };

        // Act & Assert
        entity.Equals(entity).Should().BeTrue();
        (entity == entity).Should().BeTrue();
    }

    [Fact]
    public void BaseEntity_GetHashCode_ShouldReturnConsistentValue()
    {
        // Arrange
        var entity = new TestEntity { Id = 1 };

        // Act
        var hash1 = entity.GetHashCode();
        var hash2 = entity.GetHashCode();

        // Assert
        hash1.Should().Be(hash2);
    }

    [Fact]
    public void BaseEntity_GetHashCode_WithDifferentIds_ShouldReturnDifferentValues()
    {
        // Arrange
        var entity1 = new TestEntity { Id = 1 };
        var entity2 = new TestEntity { Id = 2 };

        // Act
        var hash1 = entity1.GetHashCode();
        var hash2 = entity2.GetHashCode();

        // Assert
        hash1.Should().NotBe(hash2);
    }

    [Fact]
    public void BaseEntity_Properties_ShouldBeSettable()
    {
        // Arrange
        var entity = new TestEntity();
        var testDate = DateTime.UtcNow;

        // Act
        entity.Id = 123;
        entity.OrganizationId = 456;
        entity.IsActive = false;
        entity.IsDeleted = true;
        entity.IsSystem = true;
        entity.CreatedDate = testDate;
        entity.CreatedBy = "TestUser";
        entity.UpdatedDate = testDate.AddMinutes(1);
        entity.UpdatedBy = "UpdatedUser";

        // Assert
        entity.Id.Should().Be(123);
        entity.OrganizationId.Should().Be(456);
        entity.IsActive.Should().BeFalse();
        entity.IsDeleted.Should().BeTrue();
        entity.IsSystem.Should().BeTrue();
        entity.CreatedDate.Should().Be(testDate);
        entity.CreatedBy.Should().Be("TestUser");
        entity.UpdatedDate.Should().Be(testDate.AddMinutes(1));
        entity.UpdatedBy.Should().Be("UpdatedUser");
    }

    [Fact]
    public void BaseEntity_WithNullValues_ShouldBeCreatable()
    {
        // Arrange & Act
        var entity = new TestEntity
        {
            OrganizationId = null,
            CreatedBy = null,
            UpdatedDate = null,
            UpdatedBy = null
        };

        // Assert
        entity.OrganizationId.Should().BeNull();
        entity.CreatedBy.Should().BeNull();
        entity.UpdatedDate.Should().BeNull();
        entity.UpdatedBy.Should().BeNull();
    }

    [Fact]
    public void BaseEntity_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var entity = new TestEntity { Id = 123 };

        // Act
        var result = entity.ToString();

        // Assert
        result.Should().Contain("TestEntity");
    }

    // Test entity classes for testing BaseEntity
    private class TestEntity : BaseEntity
    {
    }

    private class AnotherTestEntity : BaseEntity
    {
    }
}
