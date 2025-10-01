using FluentAssertions;
using Domain;
using Domain.Enums;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class ReflectionAndDynamicTests
{
    #region Type Reflection Tests

    [Fact]
    public void BaseEntity_GetType_ShouldReturnCorrectType()
    {
        // Arrange
        var entity = new TestEntity();

        // Act
        var type = entity.GetType();

        // Assert
        type.Should().Be(typeof(TestEntity));
        type.Name.Should().Be("TestEntity");
        type.FullName.Should().Contain("TestEntity");
    }

    [Fact]
    public void BaseEntity_GetType_WithDifferentTypes_ShouldReturnDifferentTypes()
    {
        // Arrange
        var entity1 = new TestEntity();
        var entity2 = new TestEntity2();

        // Act
        var type1 = entity1.GetType();
        var type2 = entity2.GetType();

        // Assert
        type1.Should().NotBe(type2);
        type1.Name.Should().Be("TestEntity");
        type2.Name.Should().Be("TestEntity2");
    }

    [Fact]
    public void BaseEntity_GetType_WithInheritance_ShouldReturnCorrectBaseType()
    {
        // Arrange
        var entity = new TestEntity();

        // Act
        var type = entity.GetType();
        var baseType = type.BaseType;

        // Assert
        baseType.Should().Be(typeof(BaseEntity));
        baseType!.BaseType.Should().Be(typeof(BaseEntity<int>));
        baseType!.BaseType!.BaseType.Should().Be(typeof(object));
    }

    #endregion

    #region Property Reflection Tests

    [Fact]
    public void BaseEntity_GetProperties_ShouldReturnAllProperties()
    {
        // Arrange
        var entityType = typeof(TestEntity);

        // Act
        var properties = entityType.GetProperties();

        // Assert
        properties.Should().NotBeEmpty();
        properties.Should().Contain(p => p.Name == "Id");
        properties.Should().Contain(p => p.Name == "CreatedDate");
        properties.Should().Contain(p => p.Name == "UpdatedDate");
    }

    [Fact]
    public void BaseEntity_GetProperty_ShouldReturnCorrectProperty()
    {
        // Arrange
        var entityType = typeof(TestEntity);

        // Act
        var idProperty = entityType.GetProperty("Id");
        var createdDateProperty = entityType.GetProperty("CreatedDate");

        // Assert
        idProperty.Should().NotBeNull();
        idProperty!.PropertyType.Should().Be(typeof(int));
        createdDateProperty.Should().NotBeNull();
        createdDateProperty!.PropertyType.Should().Be(typeof(DateTime?));
    }

    [Fact]
    public void BaseEntity_GetProperty_WithNonExistentProperty_ShouldReturnNull()
    {
        // Arrange
        var entityType = typeof(TestEntity);

        // Act
        var property = entityType.GetProperty("NonExistentProperty");

        // Assert
        property.Should().BeNull();
    }

    #endregion

    #region Method Reflection Tests

    [Fact]
    public void BaseEntity_GetMethods_ShouldReturnAllMethods()
    {
        // Arrange
        var entityType = typeof(TestEntity);

        // Act
        var methods = entityType.GetMethods();

        // Assert
        methods.Should().NotBeEmpty();
        methods.Should().Contain(m => m.Name == "Equals");
        methods.Should().Contain(m => m.Name == "GetHashCode");
        methods.Should().Contain(m => m.Name == "ToString");
    }

    [Fact]
    public void BaseEntity_GetMethod_ShouldReturnCorrectMethod()
    {
        // Arrange
        var entityType = typeof(TestEntity);

        // Act
        var equalsMethod = entityType.GetMethod("Equals", new[] { typeof(object) });
        var getHashCodeMethod = entityType.GetMethod("GetHashCode");

        // Assert
        equalsMethod.Should().NotBeNull();
        getHashCodeMethod.Should().NotBeNull();
        equalsMethod!.ReturnType.Should().Be(typeof(bool));
        getHashCodeMethod!.ReturnType.Should().Be(typeof(int));
    }

    #endregion

    #region Attribute Reflection Tests

    [Fact]
    public void Property_GetCustomAttributes_ShouldReturnValidationAttributes()
    {
        // Arrange
        var propertyType = typeof(Property);
        var nameProperty = propertyType.GetProperty("Name")!;

        // Act
        var attributes = nameProperty.GetCustomAttributes();

        // Assert
        attributes.Should().NotBeEmpty();
        attributes.Should().Contain(a => a is RequiredAttribute);
        attributes.Should().Contain(a => a is MaxLengthAttribute);
    }

    [Fact]
    public void Property_GetCustomAttribute_ShouldReturnSpecificAttribute()
    {
        // Arrange
        var propertyType = typeof(Property);
        var nameProperty = propertyType.GetProperty("Name")!;

        // Act
        var requiredAttribute = nameProperty.GetCustomAttribute<RequiredAttribute>();
        var maxLengthAttribute = nameProperty.GetCustomAttribute<MaxLengthAttribute>();

        // Assert
        requiredAttribute.Should().NotBeNull();
        maxLengthAttribute.Should().NotBeNull();
        maxLengthAttribute!.Length.Should().Be(100);
    }

    [Fact]
    public void Property_GetCustomAttributes_WithInheritance_ShouldReturnInheritedAttributes()
    {
        // Arrange
        var propertyType = typeof(Property);
        var nameProperty = propertyType.GetProperty("Name")!;

        // Act
        var attributes = nameProperty.GetCustomAttributes(true);

        // Assert
        attributes.Should().NotBeEmpty();
        attributes.Should().Contain(a => a is RequiredAttribute);
    }

    #endregion

    #region Interface Reflection Tests

    [Fact]
    public void BaseEntity_GetInterfaces_ShouldReturnAllInterfaces()
    {
        // Arrange
        var entityType = typeof(TestEntity);

        // Act
        var interfaces = entityType.GetInterfaces();

        // Assert
        interfaces.Should().NotBeEmpty();
        interfaces.Should().Contain(typeof(IEntity));
        interfaces.Should().Contain(typeof(ITimeModification));
    }

    [Fact]
    public void BaseEntity_GetInterface_ShouldReturnSpecificInterface()
    {
        // Arrange
        var entityType = typeof(TestEntity);

        // Act
        var iEntityInterface = entityType.GetInterface("IEntity");
        var iTimeModificationInterface = entityType.GetInterface("ITimeModification");

        // Assert
        iEntityInterface.Should().NotBeNull();
        iTimeModificationInterface.Should().NotBeNull();
    }

    #endregion

    #region Dynamic Property Access Tests

    [Fact]
    public void BaseEntity_DynamicPropertyAccess_ShouldWork()
    {
        // Arrange
        var entity = new TestEntity { Id = 1 };

        // Act
        var idValue = (int)entity.GetType().GetProperty("Id")!.GetValue(entity)!;
        var createdDateValue = (DateTime?)entity.GetType().GetProperty("CreatedDate")!.GetValue(entity);

        // Assert
        idValue.Should().Be(1);
        createdDateValue.Should().NotBeNull();
        createdDateValue.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void BaseEntity_DynamicPropertySetting_ShouldWork()
    {
        // Arrange
        var entity = new TestEntity();
        var idProperty = entity.GetType().GetProperty("Id")!;
        var createdDateProperty = entity.GetType().GetProperty("CreatedDate")!;

        // Act
        idProperty.SetValue(entity, 42);
        createdDateProperty.SetValue(entity, DateTime.UtcNow);

        // Assert
        entity.Id.Should().Be(42);
        entity.CreatedDate.Should().NotBeNull();
    }

    #endregion

    #region Dynamic Method Invocation Tests

    [Fact]
    public void BaseEntity_DynamicMethodInvocation_ShouldWork()
    {
        // Arrange
        var entity = new TestEntity { Id = 1 };
        var equalsMethod = entity.GetType().GetMethod("Equals", new[] { typeof(object) })!;

        // Act
        var result = (bool)equalsMethod.Invoke(entity, new object[] { entity })!;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void BaseEntity_DynamicMethodInvocation_WithParameters_ShouldWork()
    {
        // Arrange
        var entity = new TestEntity { Id = 1 };
        var toStringMethod = entity.GetType().GetMethod("ToString")!;

        // Act
        var result = (string)toStringMethod.Invoke(entity, null)!;

        // Assert
        result.Should().NotBeNullOrEmpty();
        result.Should().Contain("TestEntity");
    }

    #endregion

    #region Enum Reflection Tests

    [Fact]
    public void StatusEnum_GetFields_ShouldReturnAllEnumValues()
    {
        // Arrange
        var enumType = typeof(StatusEnum);

        // Act
        var fields = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);

        // Assert
        fields.Should().NotBeEmpty();
        fields.Should().HaveCount(17); // 17 enum values
        fields.Should().Contain(f => f.Name == "Saved");
        fields.Should().Contain(f => f.Name == "Active");
        fields.Should().Contain(f => f.Name == "Completed");
    }

    [Fact]
    public void StatusEnum_GetField_ShouldReturnSpecificField()
    {
        // Arrange
        var enumType = typeof(StatusEnum);

        // Act
        var activeField = enumType.GetField("Active");

        // Assert
        activeField.Should().NotBeNull();
        activeField!.FieldType.Should().Be(typeof(StatusEnum));
    }

    [Fact]
    public void StatusEnum_GetFieldValue_ShouldReturnCorrectValue()
    {
        // Arrange
        var enumType = typeof(StatusEnum);
        var activeField = enumType.GetField("Active")!;

        // Act
        var value = (StatusEnum)activeField.GetValue(null)!;

        // Assert
        value.Should().Be(StatusEnum.Active);
    }

    #endregion

    #region Assembly Reflection Tests

    [Fact]
    public void Domain_Assembly_ShouldContainExpectedTypes()
    {
        // Arrange
        var assembly = typeof(BaseEntity).Assembly;

        // Act
        var types = assembly.GetTypes();

        // Assert
        types.Should().NotBeEmpty();
        types.Should().Contain(typeof(BaseEntity));
        types.Should().Contain(typeof(User));
        types.Should().Contain(typeof(Role));
        types.Should().Contain(typeof(Organization));
    }

    [Fact]
    public void Domain_Assembly_ShouldHaveCorrectName()
    {
        // Arrange
        var assembly = typeof(BaseEntity).Assembly;

        // Act
        var name = assembly.GetName();

        // Assert
        name.Name.Should().Be("BackendWebService.Domain");
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
