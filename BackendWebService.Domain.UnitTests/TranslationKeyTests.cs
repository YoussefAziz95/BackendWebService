using Domain;
using Domain.Enums;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class TranslationKeyTests
{
    [Fact]
    public void TranslationKey_DefaultConstructor_ShouldCreateInstance()
    {
        // Arrange & Act
        var translationKey = new TranslationKey();

        // Assert
        translationKey.Should().NotBeNull();
        translationKey.Key.Should().BeNull();
        translationKey.Language.Should().Be((LanguageEnum)0);
        translationKey.TableName.Should().Be((TableNameEnum)0);
        translationKey.Field.Should().BeNull();
        translationKey.Value.Should().BeNull();
        translationKey.IsActive.Should().BeTrue();
        translationKey.IsDeleted.Should().BeFalse();
        translationKey.IsSystem.Should().BeFalse();
        translationKey.CreatedDate.Should().NotBeNull();
    }

    [Theory]
    [InlineData("user.name")]
    [InlineData("product.title")]
    [InlineData("order.status")]
    [InlineData("")]
    [InlineData("very.long.translation.key.that.might.exceed.normal.length.expectations")]
    public void TranslationKey_Key_ShouldBeSettable(string key)
    {
        // Arrange
        var translationKey = new TranslationKey();

        // Act
        translationKey.Key = key;

        // Assert
        translationKey.Key.Should().Be(key);
    }

    [Theory]
    [InlineData(LanguageEnum.EN)]
    [InlineData(LanguageEnum.AR)]
    [InlineData(LanguageEnum.FK)]
    public void TranslationKey_Language_ShouldBeSettable(LanguageEnum language)
    {
        // Arrange
        var translationKey = new TranslationKey();

        // Act
        translationKey.Language = language;

        // Assert
        translationKey.Language.Should().Be(language);
    }

    [Theory]
    [InlineData(TableNameEnum.User)]
    [InlineData(TableNameEnum.Customer)]
    [InlineData(TableNameEnum.Product)]
    [InlineData(TableNameEnum.Category)]
    [InlineData(TableNameEnum.Service)]
    public void TranslationKey_TableName_ShouldBeSettable(TableNameEnum tableName)
    {
        // Arrange
        var translationKey = new TranslationKey();

        // Act
        translationKey.TableName = tableName;

        // Assert
        translationKey.TableName.Should().Be(tableName);
    }

    [Theory]
    [InlineData("Name")]
    [InlineData("Title")]
    [InlineData("Description")]
    [InlineData("")]
    [InlineData("VeryLongFieldNameThatMightExceedNormalLengthExpectations")]
    public void TranslationKey_Field_ShouldBeSettable(string field)
    {
        // Arrange
        var translationKey = new TranslationKey();

        // Act
        translationKey.Field = field;

        // Assert
        translationKey.Field.Should().Be(field);
    }

    [Theory]
    [InlineData("User Name")]
    [InlineData("Product Title")]
    [InlineData("Order Status")]
    [InlineData("")]
    [InlineData("Very long translation value that might exceed normal length expectations")]
    public void TranslationKey_Value_ShouldBeSettable(string value)
    {
        // Arrange
        var translationKey = new TranslationKey();

        // Act
        translationKey.Value = value;

        // Assert
        translationKey.Value.Should().Be(value);
    }

    [Fact]
    public void TranslationKey_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var translationKey = new TranslationKey
        {
            Key = "user.name",
            Language = LanguageEnum.EN,
            TableName = TableNameEnum.User,
            Field = "Name",
            Value = "User Name"
        };

        // Assert
        translationKey.Key.Should().Be("user.name");
        translationKey.Language.Should().Be(LanguageEnum.EN);
        translationKey.TableName.Should().Be(TableNameEnum.User);
        translationKey.Field.Should().Be("Name");
        translationKey.Value.Should().Be("User Name");
        translationKey.IsActive.Should().BeTrue();
    }

    [Fact]
    public void TranslationKey_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange & Act
        var translationKey = new TranslationKey
        {
            Key = "product.title",
            Language = LanguageEnum.AR,
            TableName = TableNameEnum.Product,
            Field = "Title",
            Value = "عنوان المنتج"
        };

        // Assert
        translationKey.Key.Should().Be("product.title");
        translationKey.Language.Should().Be(LanguageEnum.AR);
        translationKey.TableName.Should().Be(TableNameEnum.Product);
        translationKey.Field.Should().Be("Title");
        translationKey.Value.Should().Be("عنوان المنتج");
    }

    [Fact]
    public void TranslationKey_WithNullValues_ShouldBeCreatable()
    {
        // Arrange & Act
        var translationKey = new TranslationKey
        {
            Key = null!,
            Field = null!,
            Value = null!
        };

        // Assert
        translationKey.Key.Should().BeNull();
        translationKey.Field.Should().BeNull();
        translationKey.Value.Should().BeNull();
        translationKey.Language.Should().Be((LanguageEnum)0);
        translationKey.TableName.Should().Be((TableNameEnum)0);
    }

    [Fact]
    public void TranslationKey_WithEmptyStrings_ShouldBeCreatable()
    {
        // Arrange & Act
        var translationKey = new TranslationKey
        {
            Key = "",
            Field = "",
            Value = ""
        };

        // Assert
        translationKey.Key.Should().Be("");
        translationKey.Field.Should().Be("");
        translationKey.Value.Should().Be("");
    }

    [Theory]
    [InlineData("user.name", LanguageEnum.EN, TableNameEnum.User, "Name", "User Name")]
    [InlineData("product.title", LanguageEnum.AR, TableNameEnum.Product, "Title", "عنوان المنتج")]
    [InlineData("service.name", LanguageEnum.FK, TableNameEnum.Service, "Name", "Service Name")]
    public void TranslationKey_StringProperties_ShouldBeSettable(string key, LanguageEnum language, TableNameEnum tableName, string field, string value)
    {
        // Arrange
        var translationKey = new TranslationKey();

        // Act
        translationKey.Key = key;
        translationKey.Language = language;
        translationKey.TableName = tableName;
        translationKey.Field = field;
        translationKey.Value = value;

        // Assert
        translationKey.Key.Should().Be(key);
        translationKey.Language.Should().Be(language);
        translationKey.TableName.Should().Be(tableName);
        translationKey.Field.Should().Be(field);
        translationKey.Value.Should().Be(value);
    }

    [Fact]
    public void TranslationKey_WithDefaultEnumValues_ShouldBeCreatable()
    {
        // Arrange & Act
        var translationKey = new TranslationKey
        {
            Key = "test.key",
            Language = (LanguageEnum)0,
            TableName = (TableNameEnum)0,
            Field = "TestField",
            Value = "Test Value"
        };

        // Assert
        translationKey.Key.Should().Be("test.key");
        translationKey.Language.Should().Be((LanguageEnum)0);
        translationKey.TableName.Should().Be((TableNameEnum)0);
        translationKey.Field.Should().Be("TestField");
        translationKey.Value.Should().Be("Test Value");
    }

    [Fact]
    public void TranslationKey_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var translationKey = new TranslationKey { Key = "test.key" };

        // Act
        var result = translationKey.ToString();

        // Assert
        result.Should().Contain("TranslationKey");
    }

    [Fact]
    public void TranslationKey_ShouldInheritFromBaseEntity()
    {
        // Arrange & Act
        var translationKey = new TranslationKey();

        // Assert
        translationKey.Should().BeAssignableTo<BaseEntity>();
        translationKey.Should().BeAssignableTo<IEntity>();
        translationKey.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void TranslationKey_AllProperties_ShouldBeSettable()
    {
        // Arrange
        var translationKey = new TranslationKey();

        // Act
        translationKey.Key = "user.name";
        translationKey.Language = LanguageEnum.EN;
        translationKey.TableName = TableNameEnum.User;
        translationKey.Field = "Name";
        translationKey.Value = "User Name";

        // Assert
        translationKey.Key.Should().Be("user.name");
        translationKey.Language.Should().Be(LanguageEnum.EN);
        translationKey.TableName.Should().Be(TableNameEnum.User);
        translationKey.Field.Should().Be("Name");
        translationKey.Value.Should().Be("User Name");
    }
}
