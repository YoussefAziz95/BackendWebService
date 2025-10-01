using FluentAssertions;
using Domain;
using Domain.Enums;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class SerializationAndDeserializationTests
{
    #region JSON Serialization Tests

    [Fact]
    public void BaseEntity_JsonSerialization_ShouldWork()
    {
        // Arrange
        var entity = new TestEntity { Id = 1, CreatedDate = DateTime.UtcNow };

        // Act
        var json = JsonSerializer.Serialize(entity);
        var deserializedEntity = JsonSerializer.Deserialize<TestEntity>(json);

        // Assert
        json.Should().NotBeNullOrEmpty();
        deserializedEntity.Should().NotBeNull();
        deserializedEntity!.Id.Should().Be(entity.Id);
    }

    [Fact]
    public void User_JsonSerialization_ShouldWork()
    {
        // Arrange
        var user = new User
        {
            Id = 1,
            UserName = "testuser",
            Email = "test@example.com",
            FirstName = "Test",
            LastName = "User"
        };

        // Act
        var json = JsonSerializer.Serialize(user);
        var deserializedUser = JsonSerializer.Deserialize<User>(json);

        // Assert
        json.Should().NotBeNullOrEmpty();
        deserializedUser.Should().NotBeNull();
        deserializedUser!.Id.Should().Be(user.Id);
        deserializedUser.UserName.Should().Be(user.UserName);
        deserializedUser.Email.Should().Be(user.Email);
    }

    [Fact]
    public void Organization_JsonSerialization_ShouldWork()
    {
        // Arrange
        var organization = new Organization
        {
            Id = 1,
            Name = "Test Organization",
            Type = OrganizationEnum.Company,
            IsActive = true
        };

        // Act
        var json = JsonSerializer.Serialize(organization);
        var deserializedOrganization = JsonSerializer.Deserialize<Organization>(json);

        // Assert
        json.Should().NotBeNullOrEmpty();
        deserializedOrganization.Should().NotBeNull();
        deserializedOrganization!.Id.Should().Be(organization.Id);
        deserializedOrganization.Name.Should().Be(organization.Name);
        deserializedOrganization.Type.Should().Be(organization.Type);
    }

    [Fact]
    public void Property_JsonSerialization_ShouldWork()
    {
        // Arrange
        var property = new Property
        {
            Id = 1,
            Name = "Test Property",
            ContactName = "John Doe",
            ContactNumber = "123-456-7890",
            Latitude = 40.7128,
            Longitude = -74.0060
        };

        // Act
        var json = JsonSerializer.Serialize(property);
        var deserializedProperty = JsonSerializer.Deserialize<Property>(json);

        // Assert
        json.Should().NotBeNullOrEmpty();
        deserializedProperty.Should().NotBeNull();
        deserializedProperty!.Id.Should().Be(property.Id);
        deserializedProperty.Name.Should().Be(property.Name);
        deserializedProperty.Latitude.Should().Be(property.Latitude);
    }

    #endregion

    #region JSON Serialization with Options Tests

    [Fact]
    public void BaseEntity_JsonSerialization_WithOptions_ShouldWork()
    {
        // Arrange
        var entity = new TestEntity { Id = 1, CreatedDate = DateTime.UtcNow };
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        // Act
        var json = JsonSerializer.Serialize(entity, options);
        var deserializedEntity = JsonSerializer.Deserialize<TestEntity>(json, options);

        // Assert
        json.Should().NotBeNullOrEmpty();
        json.Should().Contain("id");
        deserializedEntity.Should().NotBeNull();
        deserializedEntity!.Id.Should().Be(entity.Id);
    }

    [Fact]
    public void User_JsonSerialization_WithOptions_ShouldWork()
    {
        // Arrange
        var user = new User
        {
            Id = 1,
            UserName = "testuser",
            Email = "test@example.com"
        };
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        // Act
        var json = JsonSerializer.Serialize(user, options);
        var deserializedUser = JsonSerializer.Deserialize<User>(json, options);

        // Assert
        json.Should().NotBeNullOrEmpty();
        json.Should().Contain("userName");
        json.Should().Contain("email");
        deserializedUser.Should().NotBeNull();
        deserializedUser!.UserName.Should().Be(user.UserName);
    }

    #endregion

    #region XML Serialization Tests

    [Fact]
    public void BaseEntity_XmlSerialization_ShouldWork()
    {
        // Arrange
        var entity = new TestEntity { Id = 1, CreatedDate = DateTime.UtcNow };
        var serializer = new XmlSerializer(typeof(TestEntity));

        // Act
        using var writer = new StringWriter();
        serializer.Serialize(writer, entity);
        var xml = writer.ToString();

        using var reader = new StringReader(xml);
        var deserializedEntity = (TestEntity)serializer.Deserialize(reader)!;

        // Assert
        xml.Should().NotBeNullOrEmpty();
        xml.Should().Contain("TestEntity");
        deserializedEntity.Should().NotBeNull();
        deserializedEntity.Id.Should().Be(entity.Id);
    }

    [Fact]
    public void TestEntity_XmlSerialization_ShouldWork()
    {
        // Arrange
        var entity = new TestEntity
        {
            Id = 1
        };
        var serializer = new XmlSerializer(typeof(TestEntity));

        // Act
        using var writer = new StringWriter();
        serializer.Serialize(writer, entity);
        var xml = writer.ToString();

        using var reader = new StringReader(xml);
        var deserializedEntity = (TestEntity)serializer.Deserialize(reader)!;

        // Assert
        xml.Should().NotBeNullOrEmpty();
        xml.Should().Contain("TestEntity");
        deserializedEntity.Should().NotBeNull();
        deserializedEntity.Id.Should().Be(entity.Id);
    }

    #endregion

    #region Enum Serialization Tests

    [Fact]
    public void StatusEnum_JsonSerialization_ShouldWork()
    {
        // Arrange
        var status = StatusEnum.Active;

        // Act
        var json = JsonSerializer.Serialize(status);
        var deserializedStatus = JsonSerializer.Deserialize<StatusEnum>(json);

        // Assert
        json.Should().Be("3");
        deserializedStatus.Should().Be(status);
    }

    [Fact]
    public void StatusEnum_JsonSerialization_WithStringNames_ShouldWork()
    {
        // Arrange
        var status = StatusEnum.Active;
        var options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() }
        };

        // Act
        var json = JsonSerializer.Serialize(status, options);
        var deserializedStatus = JsonSerializer.Deserialize<StatusEnum>(json, options);

        // Assert
        json.Should().Be("\"Active\"");
        deserializedStatus.Should().Be(status);
    }

    [Fact]
    public void OrganizationEnum_JsonSerialization_ShouldWork()
    {
        // Arrange
        var organizationType = OrganizationEnum.Company;

        // Act
        var json = JsonSerializer.Serialize(organizationType);
        var deserializedType = JsonSerializer.Deserialize<OrganizationEnum>(json);

        // Assert
        json.Should().Be("2");
        deserializedType.Should().Be(organizationType);
    }

    #endregion

    #region Collection Serialization Tests

    [Fact]
    public void User_UserRoles_JsonSerialization_ShouldWork()
    {
        // Arrange
        var user = new User
        {
            Id = 1,
            UserName = "testuser",
            UserRoles = new List<UserRole>
            {
                new UserRole { UserId = 1, RoleId = 1 },
                new UserRole { UserId = 1, RoleId = 2 }
            }
        };

        // Act
        var json = JsonSerializer.Serialize(user);
        var deserializedUser = JsonSerializer.Deserialize<User>(json);

        // Assert
        json.Should().NotBeNullOrEmpty();
        deserializedUser.Should().NotBeNull();
        deserializedUser!.UserRoles.Should().NotBeNull();
        deserializedUser.UserRoles.Should().HaveCount(2);
    }

    [Fact]
    public void Organization_Addresses_JsonSerialization_ShouldWork()
    {
        // Arrange
        var organization = new Organization
        {
            Id = 1,
            Name = "Test Organization",
            Addresses = new List<Address>
            {
                new Address { Id = 1, Street = "123 Main St", City = "New York" },
                new Address { Id = 2, Street = "456 Oak Ave", City = "Los Angeles" }
            }
        };

        // Act
        var json = JsonSerializer.Serialize(organization);
        var deserializedOrganization = JsonSerializer.Deserialize<Organization>(json);

        // Assert
        json.Should().NotBeNullOrEmpty();
        deserializedOrganization.Should().NotBeNull();
        deserializedOrganization!.Addresses.Should().NotBeNull();
        deserializedOrganization.Addresses.Should().HaveCount(2);
    }

    #endregion

    #region Complex Object Serialization Tests

    [Fact]
    public void ComplexEntity_JsonSerialization_ShouldWork()
    {
        // Arrange
        var user = new User
        {
            Id = 1,
            UserName = "testuser",
            Email = "test@example.com",
            FirstName = "Test",
            LastName = "User",
            IsActive = true,
            IsDeleted = false,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow
        };

        // Act
        var json = JsonSerializer.Serialize(user);
        var deserializedUser = JsonSerializer.Deserialize<User>(json);

        // Assert
        json.Should().NotBeNullOrEmpty();
        deserializedUser.Should().NotBeNull();
        deserializedUser!.Id.Should().Be(user.Id);
        deserializedUser.UserName.Should().Be(user.UserName);
        deserializedUser.Email.Should().Be(user.Email);
        deserializedUser.FirstName.Should().Be(user.FirstName);
        deserializedUser.LastName.Should().Be(user.LastName);
        deserializedUser.IsActive.Should().Be(user.IsActive);
        deserializedUser.IsDeleted.Should().Be(user.IsDeleted);
    }

    [Fact]
    public void NestedEntity_JsonSerialization_ShouldWork()
    {
        // Arrange
        var department = new Department
        {
            Id = 1,
            Name = "IT Department",
            Description = "Information Technology Department",
            Code = "IT",
            IsActive = true,
            Organization = new Organization
            {
                Id = 1,
                Name = "Test Organization",
                Type = OrganizationEnum.Company
            }
        };

        // Act
        var json = JsonSerializer.Serialize(department);
        var deserializedDepartment = JsonSerializer.Deserialize<Department>(json);

        // Assert
        json.Should().NotBeNullOrEmpty();
        deserializedDepartment.Should().NotBeNull();
        deserializedDepartment!.Id.Should().Be(department.Id);
        deserializedDepartment.Name.Should().Be(department.Name);
        deserializedDepartment.Organization.Should().NotBeNull();
        deserializedDepartment.Organization!.Name.Should().Be(department.Organization!.Name);
    }

    #endregion

    #region Error Handling Tests

    [Fact]
    public void JsonSerialization_WithInvalidData_ShouldHandleGracefully()
    {
        // Arrange
        var invalidJson = "{ \"Id\": \"invalid\", \"UserName\": null }";

        // Act & Assert
        var act = () => JsonSerializer.Deserialize<User>(invalidJson);
        act.Should().Throw<JsonException>();
    }

    [Fact]
    public void JsonSerialization_WithMissingProperties_ShouldHandleGracefully()
    {
        // Arrange
        var incompleteJson = "{ \"Id\": 1 }";

        // Act
        var user = JsonSerializer.Deserialize<User>(incompleteJson);

        // Assert
        user.Should().NotBeNull();
        user!.Id.Should().Be(1);
        user.UserName.Should().BeNull();
    }

    #endregion

    #region Performance Tests

    [Fact]
    public void JsonSerialization_Performance_ShouldBeReasonable()
    {
        // Arrange
        var entities = Enumerable.Range(1, 1000)
            .Select(i => new TestEntity { Id = i, CreatedDate = DateTime.UtcNow })
            .ToList();

        // Act
        var startTime = DateTime.UtcNow;
        var json = JsonSerializer.Serialize(entities);
        var deserializedEntities = JsonSerializer.Deserialize<List<TestEntity>>(json);
        var endTime = DateTime.UtcNow;

        // Assert
        json.Should().NotBeNullOrEmpty();
        deserializedEntities.Should().NotBeNull();
        deserializedEntities!.Should().HaveCount(1000);
        (endTime - startTime).TotalMilliseconds.Should().BeLessThan(1000);
    }

    #endregion

    #region Helper Classes

    public class TestEntity : BaseEntity
    {
    }

    #endregion
}
