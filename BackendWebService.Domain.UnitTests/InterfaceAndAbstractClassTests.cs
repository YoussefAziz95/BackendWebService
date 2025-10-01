using Domain;
using FluentAssertions;
using Xunit;
using System.ComponentModel.DataAnnotations;

namespace BackendWebService.Domain.UnitTests;

public class InterfaceAndAbstractClassTests
{
    #region IEntity<TKey> Interface Tests

    [Fact]
    public void IEntityTKey_ShouldHaveIdProperty()
    {
        // Arrange
        var entityType = typeof(IEntity<int>);
        var idProperty = entityType.GetProperty(nameof(IEntity<int>.Id));

        // Act & Assert
        idProperty.Should().NotBeNull("IEntity<TKey> should have Id property");
        idProperty!.PropertyType.Should().Be(typeof(int), "Id should be of type int for IEntity<int>");
        idProperty.CanRead.Should().BeTrue("Id should be readable");
        idProperty.CanWrite.Should().BeTrue("Id should be writable");
    }

    [Fact]
    public void IEntityTKey_WithDifferentKeyTypes_ShouldWork()
    {
        // Arrange
        var intEntity = new TestEntityWithIntKey { Id = 123 };
        var stringEntity = new TestEntityWithStringKey { Id = "test" };
        var guidEntity = new TestEntityWithGuidKey { Id = Guid.NewGuid() };

        // Act & Assert
        intEntity.Id.Should().Be(123);
        stringEntity.Id.Should().Be("test");
        guidEntity.Id.Should().NotBeEmpty();
    }

    #endregion

    #region IEntity Interface Tests

    [Fact]
    public void IEntity_ShouldHaveRequiredProperties()
    {
        // Arrange
        var entityType = typeof(IEntity);
        var organizationIdProperty = entityType.GetProperty(nameof(IEntity.OrganizationId));
        var isActiveProperty = entityType.GetProperty(nameof(IEntity.IsActive));
        var isDeletedProperty = entityType.GetProperty(nameof(IEntity.IsDeleted));
        var isSystemProperty = entityType.GetProperty(nameof(IEntity.IsSystem));

        // Act & Assert
        organizationIdProperty.Should().NotBeNull("IEntity should have OrganizationId property");
        organizationIdProperty!.PropertyType.Should().Be(typeof(int?), "OrganizationId should be nullable int");

        isActiveProperty.Should().NotBeNull("IEntity should have IsActive property");
        isActiveProperty!.PropertyType.Should().Be(typeof(bool?), "IsActive should be nullable bool");

        isDeletedProperty.Should().NotBeNull("IEntity should have IsDeleted property");
        isDeletedProperty!.PropertyType.Should().Be(typeof(bool?), "IsDeleted should be nullable bool");

        isSystemProperty.Should().NotBeNull("IEntity should have IsSystem property");
        isSystemProperty!.PropertyType.Should().Be(typeof(bool?), "IsSystem should be nullable bool");
    }

    [Fact]
    public void IEntity_Properties_ShouldBeSettable()
    {
        // Arrange
        var entity = new TestEntity();

        // Act
        entity.OrganizationId = 123;
        entity.IsActive = true;
        entity.IsDeleted = false;
        entity.IsSystem = true;

        // Assert
        entity.OrganizationId.Should().Be(123);
        entity.IsActive.Should().BeTrue();
        entity.IsDeleted.Should().BeFalse();
        entity.IsSystem.Should().BeTrue();
    }

    #endregion

    #region ITimeModification Interface Tests

    [Fact]
    public void ITimeModification_ShouldHaveRequiredProperties()
    {
        // Arrange
        var interfaceType = typeof(ITimeModification);
        var createdDateProperty = interfaceType.GetProperty(nameof(ITimeModification.CreatedDate));
        var createdByProperty = interfaceType.GetProperty(nameof(ITimeModification.CreatedBy));
        var updatedDateProperty = interfaceType.GetProperty(nameof(ITimeModification.UpdatedDate));
        var updatedByProperty = interfaceType.GetProperty(nameof(ITimeModification.UpdatedBy));

        // Act & Assert
        createdDateProperty.Should().NotBeNull("ITimeModification should have CreatedDate property");
        createdDateProperty!.PropertyType.Should().Be(typeof(DateTime?), "CreatedDate should be nullable DateTime");

        createdByProperty.Should().NotBeNull("ITimeModification should have CreatedBy property");
        createdByProperty!.PropertyType.Should().Be(typeof(string), "CreatedBy should be string");

        updatedDateProperty.Should().NotBeNull("ITimeModification should have UpdatedDate property");
        updatedDateProperty!.PropertyType.Should().Be(typeof(DateTime?), "UpdatedDate should be nullable DateTime");

        updatedByProperty.Should().NotBeNull("ITimeModification should have UpdatedBy property");
        updatedByProperty!.PropertyType.Should().Be(typeof(string), "UpdatedBy should be string");
    }

    [Fact]
    public void ITimeModification_Properties_ShouldBeSettable()
    {
        // Arrange
        var entity = new TestEntity();
        var testDate = DateTime.UtcNow;
        var testUser = "testuser";

        // Act
        entity.CreatedDate = testDate;
        entity.CreatedBy = testUser;
        entity.UpdatedDate = testDate.AddDays(1);
        entity.UpdatedBy = testUser;

        // Assert
        entity.CreatedDate.Should().Be(testDate);
        entity.CreatedBy.Should().Be(testUser);
        entity.UpdatedDate.Should().Be(testDate.AddDays(1));
        entity.UpdatedBy.Should().Be(testUser);
    }

    #endregion

    #region BaseEntity<TKey> Abstract Class Tests

    [Fact]
    public void BaseEntityTKey_ShouldImplementIEntityTKey()
    {
        // Arrange
        var baseEntityType = typeof(BaseEntity<int>);
        var iEntityType = typeof(IEntity<int>);

        // Act & Assert
        baseEntityType.Should().Implement(iEntityType, "BaseEntity<TKey> should implement IEntity<TKey>");
    }

    [Fact]
    public void BaseEntityTKey_ShouldHaveIdProperty()
    {
        // Arrange
        var entity = new TestEntityWithIntKey();

        // Act
        entity.Id = 456;

        // Assert
        entity.Id.Should().Be(456);
    }

    [Fact]
    public void BaseEntityTKey_Equals_ShouldWorkWithDifferentKeyTypes()
    {
        // Arrange
        var intEntity1 = new TestEntityWithIntKey { Id = 123 };
        var intEntity2 = new TestEntityWithIntKey { Id = 123 };
        var intEntity3 = new TestEntityWithIntKey { Id = 456 };
        var stringEntity = new TestEntityWithStringKey { Id = "123" };

        // Act & Assert
        intEntity1.Equals(intEntity2).Should().BeTrue("Entities with same Id should be equal");
        intEntity1.Equals(intEntity3).Should().BeFalse("Entities with different Id should not be equal");
        intEntity1.Equals(stringEntity).Should().BeFalse("Entities with different types should not be equal");
        intEntity1.Equals(null!).Should().BeFalse("Entity should not equal null");
    }

    [Fact]
    public void BaseEntityTKey_GetHashCode_ShouldWorkWithDifferentKeyTypes()
    {
        // Arrange
        var intEntity1 = new TestEntityWithIntKey { Id = 123 };
        var intEntity2 = new TestEntityWithIntKey { Id = 123 };
        var intEntity3 = new TestEntityWithIntKey { Id = 456 };
        var stringEntity = new TestEntityWithStringKey { Id = "123" };

        // Act
        var hash1 = intEntity1.GetHashCode();
        var hash2 = intEntity2.GetHashCode();
        var hash3 = intEntity3.GetHashCode();
        var hash4 = stringEntity.GetHashCode();

        // Assert
        hash1.Should().Be(hash2, "Entities with same Id should have same hash code");
        hash1.Should().NotBe(hash3, "Entities with different Id should have different hash codes");
        hash1.Should().NotBe(hash4, "Entities with different types should have different hash codes");
    }

    [Fact]
    public void BaseEntityTKey_EqualityOperators_ShouldWorkWithDifferentKeyTypes()
    {
        // Arrange
        var intEntity1 = new TestEntityWithIntKey { Id = 123 };
        var intEntity2 = new TestEntityWithIntKey { Id = 123 };
        var intEntity3 = new TestEntityWithIntKey { Id = 456 };

        // Act & Assert
        (intEntity1 == intEntity2).Should().BeTrue("Entities with same Id should be equal with == operator");
        (intEntity1 != intEntity2).Should().BeFalse("Entities with same Id should not be different with != operator");
        (intEntity1 == intEntity3).Should().BeFalse("Entities with different Id should not be equal with == operator");
        (intEntity1 != intEntity3).Should().BeTrue("Entities with different Id should be different with != operator");
    }

    #endregion

    #region BaseEntity Abstract Class Tests

    [Fact]
    public void BaseEntity_ShouldImplementAllInterfaces()
    {
        // Arrange
        var baseEntityType = typeof(BaseEntity);
        var iEntityType = typeof(IEntity);
        var iTimeModificationType = typeof(ITimeModification);
        var iEntityIntType = typeof(IEntity<int>);

        // Act & Assert
        baseEntityType.Should().Implement(iEntityType, "BaseEntity should implement IEntity");
        baseEntityType.Should().Implement(iTimeModificationType, "BaseEntity should implement ITimeModification");
        baseEntityType.Should().Implement(iEntityIntType, "BaseEntity should implement IEntity<int>");
    }

    [Fact]
    public void BaseEntity_ShouldHaveDefaultValues()
    {
        // Arrange & Act
        var entity = new TestEntity();

        // Assert
        entity.Id.Should().Be(0, "Id should default to 0");
        entity.OrganizationId.Should().BeNull("OrganizationId should default to null");
        entity.IsActive.Should().BeTrue("IsActive should default to true");
        entity.IsDeleted.Should().BeFalse("IsDeleted should default to false");
        entity.IsSystem.Should().BeFalse("IsSystem should default to false");
        entity.CreatedDate.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1), "CreatedDate should be set to current time");
        entity.CreatedBy.Should().BeNull("CreatedBy should default to null");
        entity.UpdatedDate.Should().BeNull("UpdatedDate should default to null");
        entity.UpdatedBy.Should().BeNull("UpdatedBy should default to null");
    }

    [Fact]
    public void BaseEntity_ShouldInheritFromBaseEntityTKey()
    {
        // Arrange
        var baseEntityType = typeof(BaseEntity);
        var baseEntityTKeyType = typeof(BaseEntity<int>);

        // Act & Assert
        baseEntityType.Should().BeDerivedFrom(baseEntityTKeyType, "BaseEntity should inherit from BaseEntity<int>");
    }

    [Fact]
    public void BaseEntity_ShouldHaveNullableOrganizationId()
    {
        // Arrange
        var baseEntityType = typeof(BaseEntity);
        var organizationIdProperty = baseEntityType.GetProperty(nameof(BaseEntity.OrganizationId));

        // Act & Assert
        organizationIdProperty.Should().NotBeNull("OrganizationId property should exist");
        organizationIdProperty!.PropertyType.Should().Be(typeof(int?), "OrganizationId should be nullable int");
    }

    #endregion

    #region Entity Implementation Tests

    [Fact]
    public void User_ShouldImplementAllInterfaces()
    {
        // Arrange
        var userType = typeof(User);
        var iEntityType = typeof(IEntity);
        var iTimeModificationType = typeof(ITimeModification);

        // Act & Assert
        userType.Should().Implement(iEntityType, "User should implement IEntity");
        userType.Should().Implement(iTimeModificationType, "User should implement ITimeModification");
    }

    [Fact]
    public void Client_ShouldImplementAllInterfaces()
    {
        // Arrange
        var clientType = typeof(Client);
        var iEntityType = typeof(IEntity);
        var iTimeModificationType = typeof(ITimeModification);

        // Act & Assert
        clientType.Should().Implement(iEntityType, "Client should implement IEntity");
        clientType.Should().Implement(iTimeModificationType, "Client should implement ITimeModification");
    }

    [Fact]
    public void Department_ShouldImplementAllInterfaces()
    {
        // Arrange
        var departmentType = typeof(Department);
        var iEntityType = typeof(IEntity);
        var iTimeModificationType = typeof(ITimeModification);

        // Act & Assert
        departmentType.Should().Implement(iEntityType, "Department should implement IEntity");
        departmentType.Should().Implement(iTimeModificationType, "Department should implement ITimeModification");
    }

    [Fact]
    public void Customer_ShouldImplementAllInterfaces()
    {
        // Arrange
        var customerType = typeof(Customer);
        var iEntityType = typeof(IEntity);
        var iTimeModificationType = typeof(ITimeModification);

        // Act & Assert
        customerType.Should().Implement(iEntityType, "Customer should implement IEntity");
        customerType.Should().Implement(iTimeModificationType, "Customer should implement ITimeModification");
    }

    #endregion

    #region Interface Property Access Tests

    [Fact]
    public void IEntity_Properties_ShouldBeAccessibleThroughInterface()
    {
        // Arrange
        IEntity entity = new TestEntity();

        // Act
        entity.OrganizationId = 999;
        entity.IsActive = false;
        entity.IsDeleted = true;
        entity.IsSystem = true;

        // Assert
        entity.OrganizationId.Should().Be(999);
        entity.IsActive.Should().BeFalse();
        entity.IsDeleted.Should().BeTrue();
        entity.IsSystem.Should().BeTrue();
    }

    [Fact]
    public void ITimeModification_Properties_ShouldBeAccessibleThroughInterface()
    {
        // Arrange
        ITimeModification entity = new TestEntity();
        var testDate = DateTime.UtcNow.AddDays(-1);
        var testUser = "interfaceuser";

        // Act
        entity.CreatedDate = testDate;
        entity.CreatedBy = testUser;
        entity.UpdatedDate = testDate.AddDays(1);
        entity.UpdatedBy = testUser;

        // Assert
        entity.CreatedDate.Should().Be(testDate);
        entity.CreatedBy.Should().Be(testUser);
        entity.UpdatedDate.Should().Be(testDate.AddDays(1));
        entity.UpdatedBy.Should().Be(testUser);
    }

    [Fact]
    public void IEntityTKey_Properties_ShouldBeAccessibleThroughInterface()
    {
        // Arrange
        IEntity<int> entity = new TestEntityWithIntKey();

        // Act
        entity.Id = 777;

        // Assert
        entity.Id.Should().Be(777);
    }

    #endregion

    #region Interface Casting Tests

    [Fact]
    public void Entity_ShouldBeCastableToInterfaces()
    {
        // Arrange
        var entity = new TestEntity();

        // Act
        var iEntity = entity as IEntity;
        var iTimeModification = entity as ITimeModification;
        var iEntityInt = entity as IEntity<int>;

        // Assert
        iEntity.Should().NotBeNull("Entity should be castable to IEntity");
        iTimeModification.Should().NotBeNull("Entity should be castable to ITimeModification");
        iEntityInt.Should().NotBeNull("Entity should be castable to IEntity<int>");
    }

    [Fact]
    public void Entity_ShouldBeCastableFromInterfaces()
    {
        // Arrange
        IEntity iEntity = new TestEntity();
        ITimeModification iTimeModification = new TestEntity();
        IEntity<int> iEntityInt = new TestEntityWithIntKey();

        // Act
        var entity1 = iEntity as TestEntity;
        var entity2 = iTimeModification as TestEntity;
        var entity3 = iEntityInt as TestEntityWithIntKey;

        // Assert
        entity1.Should().NotBeNull("IEntity should be castable to TestEntity");
        entity2.Should().NotBeNull("ITimeModification should be castable to TestEntity");
        entity3.Should().NotBeNull("IEntity<int> should be castable to TestEntityWithIntKey");
    }

    #endregion

    #region Test Helper Classes

    private class TestEntity : BaseEntity
    {
    }

    private class TestEntityWithIntKey : BaseEntity<int>
    {
    }

    private class TestEntityWithStringKey : BaseEntity<string>
    {
    }

    private class TestEntityWithGuidKey : BaseEntity<Guid>
    {
    }

    #endregion
}
