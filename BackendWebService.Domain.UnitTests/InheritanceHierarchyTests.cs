using FluentAssertions;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class InheritanceHierarchyTests
{
    #region BaseEntity Inheritance Tests

    [Fact]
    public void BaseEntity_ShouldInheritFromCorrectBaseClass()
    {
        // Arrange
        var entity = new TestEntity();

        // Act & Assert
        entity.Should().BeAssignableTo<BaseEntity>();
        entity.Should().BeAssignableTo<IEntity>();
        entity.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void BaseEntity_ShouldHaveCorrectInheritanceChain()
    {
        // Arrange
        var entityType = typeof(TestEntity);

        // Act & Assert
        entityType.BaseType.Should().Be(typeof(BaseEntity));
        entityType.BaseType!.BaseType.Should().Be(typeof(BaseEntity<int>));
        entityType.BaseType!.BaseType!.BaseType.Should().Be(typeof(object));
    }

    [Fact]
    public void BaseEntity_ShouldImplementRequiredInterfaces()
    {
        // Arrange
        var entityType = typeof(TestEntity);

        // Act & Assert
        entityType.GetInterfaces().Should().Contain(typeof(IEntity));
        entityType.GetInterfaces().Should().Contain(typeof(ITimeModification));
    }

    #endregion

    #region Identity Entity Inheritance Tests

    [Fact]
    public void User_ShouldInheritFromIdentityUser()
    {
        // Arrange
        var user = new User();

        // Act & Assert
        user.Should().BeAssignableTo<IdentityUser<int>>();
        user.Should().BeAssignableTo<IEntity>();
        user.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void Role_ShouldInheritFromIdentityRole()
    {
        // Arrange
        var role = new Role();

        // Act & Assert
        role.Should().BeAssignableTo<IdentityRole<int>>();
        role.Should().BeAssignableTo<IEntity>();
        role.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void UserRole_ShouldInheritFromIdentityUserRole()
    {
        // Arrange
        var userRole = new UserRole();

        // Act & Assert
        userRole.Should().BeAssignableTo<IdentityUserRole<int>>();
        userRole.Should().BeAssignableTo<IEntity>();
        userRole.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void UserClaim_ShouldInheritFromIdentityUserClaim()
    {
        // Arrange
        var userClaim = new UserClaim();

        // Act & Assert
        userClaim.Should().BeAssignableTo<IdentityUserClaim<int>>();
        userClaim.Should().BeAssignableTo<IEntity>();
        userClaim.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void RoleClaim_ShouldInheritFromIdentityRoleClaim()
    {
        // Arrange
        var roleClaim = new RoleClaim();

        // Act & Assert
        roleClaim.Should().BeAssignableTo<IdentityRoleClaim<int>>();
        roleClaim.Should().BeAssignableTo<IEntity>();
        roleClaim.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void UserLogin_ShouldInheritFromIdentityUserLogin()
    {
        // Arrange
        var userLogin = new UserLogin();

        // Act & Assert
        userLogin.Should().BeAssignableTo<IdentityUserLogin<int>>();
        userLogin.Should().BeAssignableTo<IEntity>();
        userLogin.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void UserToken_ShouldInheritFromIdentityUserToken()
    {
        // Arrange
        var userToken = new UserToken();

        // Act & Assert
        userToken.Should().BeAssignableTo<IdentityUserToken<int>>();
        userToken.Should().BeAssignableTo<IEntity>();
        userToken.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void UserRefreshToken_ShouldInheritFromBaseEntityGuid()
    {
        // Arrange
        var userRefreshToken = new UserRefreshToken();

        // Act & Assert
        userRefreshToken.Should().BeAssignableTo<BaseEntity<Guid>>();
        userRefreshToken.Should().BeAssignableTo<IEntity<Guid>>();
        userRefreshToken.Should().BeAssignableTo<ITimeModification>();
    }

    #endregion

    #region Polymorphism Tests

    [Fact]
    public void BaseEntity_PolymorphicBehavior_ShouldWorkCorrectly()
    {
        // Arrange
        var entities = new List<BaseEntity>
        {
            new TestEntity { Id = 1 },
            new TestEntity2 { Id = 2 }
        };

        // Act & Assert
        entities.Should().AllSatisfy(entity =>
        {
            entity.Should().BeAssignableTo<BaseEntity>();
            entity.Should().BeAssignableTo<IEntity>();
            entity.Should().BeAssignableTo<ITimeModification>();
        });
    }

    [Fact]
    public void BaseEntity_PolymorphicEquals_ShouldWorkCorrectly()
    {
        // Arrange
        var entity1 = new TestEntity { Id = 1 };
        var entity2 = new TestEntity { Id = 1 };
        var entity3 = new TestEntity { Id = 2 };

        // Act & Assert
        entity1.Equals(entity2).Should().BeTrue();
        entity1.Equals(entity3).Should().BeFalse();
        entity1.Equals(null!).Should().BeFalse();
    }

    [Fact]
    public void BaseEntity_PolymorphicGetHashCode_ShouldWorkCorrectly()
    {
        // Arrange
        var entity1 = new TestEntity { Id = 1 };
        var entity2 = new TestEntity { Id = 1 };
        var entity3 = new TestEntity { Id = 2 };

        // Act
        var hashCode1 = entity1.GetHashCode();
        var hashCode2 = entity2.GetHashCode();
        var hashCode3 = entity3.GetHashCode();

        // Assert
        hashCode1.Should().Be(hashCode2);
        hashCode1.Should().NotBe(hashCode3);
    }

    [Fact]
    public void BaseEntity_PolymorphicToString_ShouldWorkCorrectly()
    {
        // Arrange
        var entity1 = new TestEntity { Id = 1 };
        var entity2 = new TestEntity2 { Id = 2 };
        var entity3 = new TestEntity { Id = 3 };

        // Act
        var toString1 = entity1.ToString();
        var toString2 = entity2.ToString();
        var toString3 = entity3.ToString();

        // Assert
        toString1.Should().NotBeNullOrEmpty();
        toString2.Should().NotBeNullOrEmpty();
        toString3.Should().NotBeNullOrEmpty();
        toString1.Should().NotBe(toString2);
        toString2.Should().NotBe(toString3);
    }

    #endregion

    #region Interface Implementation Tests

    [Fact]
    public void IEntity_ShouldBeImplementedByAllEntities()
    {
        // Arrange
        var entityTypes = new[]
        {
            typeof(TestEntity),
            typeof(User),
            typeof(Role),
            typeof(Organization),
            typeof(Department),
            typeof(Property),
            typeof(Product),
            typeof(Category),
            typeof(Service)
        };

        // Act & Assert
        entityTypes.Should().AllSatisfy(type =>
        {
            type.Should().BeAssignableTo<IEntity>();
        });
    }

    [Fact]
    public void ITimeModification_ShouldBeImplementedByAllEntities()
    {
        // Arrange
        var entityTypes = new[]
        {
            typeof(TestEntity),
            typeof(User),
            typeof(Role),
            typeof(Organization),
            typeof(Department),
            typeof(Property),
            typeof(Product),
            typeof(Category),
            typeof(Service)
        };

        // Act & Assert
        entityTypes.Should().AllSatisfy(type =>
        {
            type.Should().BeAssignableTo<ITimeModification>();
        });
    }

    [Fact]
    public void IEntity_ShouldHaveCorrectProperties()
    {
        // Arrange
        var entityType = typeof(IEntity);
        var properties = entityType.GetProperties();

        // Act & Assert
        properties.Should().HaveCount(4);
        properties.Should().Contain(p => p.Name == "OrganizationId");
        properties.Should().Contain(p => p.Name == "IsActive");
        properties.Should().Contain(p => p.Name == "IsDeleted");
        properties.Should().Contain(p => p.Name == "IsSystem");
    }

    [Fact]
    public void ITimeModification_ShouldHaveCorrectProperties()
    {
        // Arrange
        var entityType = typeof(ITimeModification);
        var properties = entityType.GetProperties();

        // Act & Assert
        properties.Should().HaveCount(4);
        properties.Should().Contain(p => p.Name == "CreatedDate");
        properties.Should().Contain(p => p.Name == "CreatedBy");
        properties.Should().Contain(p => p.Name == "UpdatedDate");
        properties.Should().Contain(p => p.Name == "UpdatedBy");
    }

    #endregion

    #region Generic Type Tests

    [Fact]
    public void BaseEntity_GenericType_ShouldWorkCorrectly()
    {
        // Arrange
        var entity = new TestEntity { Id = 1 };

        // Act & Assert
        entity.Should().BeAssignableTo<BaseEntity>();
        entity.Should().BeAssignableTo<IEntity>();
        entity.Should().BeAssignableTo<ITimeModification>();
        entity.Id.Should().Be(1);
    }

    [Fact]
    public void BaseEntity_GenericType_WithDifferentTypes_ShouldWorkCorrectly()
    {
        // Arrange
        var intEntity = new TestEntity { Id = 1 };
        var longEntity = new TestEntity2 { Id = 2 };

        // Act & Assert
        intEntity.Id.Should().BeOfType(typeof(int));
        longEntity.Id.Should().BeOfType(typeof(int));
    }

    [Fact]
    public void BaseEntity_GenericType_Equals_ShouldWorkCorrectly()
    {
        // Arrange
        var entity1 = new TestEntity { Id = 1 };
        var entity2 = new TestEntity { Id = 1 };
        var entity3 = new TestEntity { Id = 2 };

        // Act & Assert
        entity1.Equals(entity2).Should().BeTrue();
        entity1.Equals(entity3).Should().BeFalse();
    }

    #endregion

    #region Helper Classes

    private class TestEntity : BaseEntity
    {
    }

    private class TestEntity2 : BaseEntity
    {
    }

    #endregion
}
