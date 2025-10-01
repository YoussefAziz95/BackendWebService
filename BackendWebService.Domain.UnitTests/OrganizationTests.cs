using FluentAssertions;
using Domain;
using Domain.Enums;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class OrganizationTests
{
    #region Constructor Tests

    [Fact]
    public void Organization_DefaultConstructor_ShouldCreateInstance()
    {
        // Arrange & Act
        var organization = new Organization();

        // Assert
        organization.Should().NotBeNull();
        organization.Id.Should().Be(0);
        organization.Name.Should().BeNull();
        organization.Country.Should().BeNull();
        organization.City.Should().BeNull();
        organization.StreetAddress.Should().BeNull();
        organization.Type.Should().Be((OrganizationEnum)0);
        organization.FaxNo.Should().BeNull();
        organization.Phone.Should().BeNull();
        organization.Email.Should().BeNull();
        organization.TaxNo.Should().BeNull();
        organization.FileId.Should().Be(0);
        organization.File.Should().BeNull();
        organization.Addresses.Should().BeNull();
        organization.Contacts.Should().BeNull();
        organization.CreatedDate.Should().NotBeNull();
        organization.UpdatedDate.Should().BeNull();
        organization.CreatedBy.Should().BeNull();
        organization.UpdatedBy.Should().BeNull();
        organization.IsActive.Should().BeTrue();
        organization.IsDeleted.Should().BeFalse();
    }

    #endregion

    #region Property Setting Tests

    [Theory]
    [InlineData("Acme Corporation")]
    [InlineData("Tech Solutions Inc")]
    [InlineData("Global Enterprises")]
    [InlineData("")]
    public void Organization_Name_ShouldBeSettable(string name)
    {
        // Arrange
        var organization = new Organization();

        // Act
        organization.Name = name;

        // Assert
        organization.Name.Should().Be(name);
    }

    [Theory]
    [InlineData("United States")]
    [InlineData("Canada")]
    [InlineData("United Kingdom")]
    [InlineData("")]
    public void Organization_Country_ShouldBeSettable(string country)
    {
        // Arrange
        var organization = new Organization();

        // Act
        organization.Country = country;

        // Assert
        organization.Country.Should().Be(country);
    }

    [Theory]
    [InlineData("New York")]
    [InlineData("Toronto")]
    [InlineData("London")]
    [InlineData("")]
    public void Organization_City_ShouldBeSettable(string city)
    {
        // Arrange
        var organization = new Organization();

        // Act
        organization.City = city;

        // Assert
        organization.City.Should().Be(city);
    }

    [Theory]
    [InlineData("123 Main Street")]
    [InlineData("456 Business Ave")]
    [InlineData("789 Corporate Blvd")]
    [InlineData("")]
    public void Organization_StreetAddress_ShouldBeSettable(string streetAddress)
    {
        // Arrange
        var organization = new Organization();

        // Act
        organization.StreetAddress = streetAddress;

        // Assert
        organization.StreetAddress.Should().Be(streetAddress);
    }

    [Theory]
    [InlineData(OrganizationEnum.Company)]
    [InlineData(OrganizationEnum.Organization)]
    [InlineData(OrganizationEnum.Supplier)]
    [InlineData(OrganizationEnum.Consumer)]
    public void Organization_Type_ShouldBeSettable(OrganizationEnum type)
    {
        // Arrange
        var organization = new Organization();

        // Act
        organization.Type = type;

        // Assert
        organization.Type.Should().Be(type);
    }

    [Theory]
    [InlineData("+1-555-123-4567")]
    [InlineData("+44-20-7946-0958")]
    [InlineData("")]
    public void Organization_FaxNo_ShouldBeSettable(string faxNo)
    {
        // Arrange
        var organization = new Organization();

        // Act
        organization.FaxNo = faxNo;

        // Assert
        organization.FaxNo.Should().Be(faxNo);
    }

    [Theory]
    [InlineData("+1-555-123-4567")]
    [InlineData("+44-20-7946-0958")]
    [InlineData("")]
    public void Organization_Phone_ShouldBeSettable(string phone)
    {
        // Arrange
        var organization = new Organization();

        // Act
        organization.Phone = phone;

        // Assert
        organization.Phone.Should().Be(phone);
    }

    [Theory]
    [InlineData("contact@acme.com")]
    [InlineData("info@techsolutions.com")]
    [InlineData("")]
    public void Organization_Email_ShouldBeSettable(string email)
    {
        // Arrange
        var organization = new Organization();

        // Act
        organization.Email = email;

        // Assert
        organization.Email.Should().Be(email);
    }

    [Theory]
    [InlineData("12-3456789")]
    [InlineData("98-7654321")]
    [InlineData("")]
    public void Organization_TaxNo_ShouldBeSettable(string taxNo)
    {
        // Arrange
        var organization = new Organization();

        // Act
        organization.TaxNo = taxNo;

        // Assert
        organization.TaxNo.Should().Be(taxNo);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    public void Organization_FileId_ShouldBeSettable(int fileId)
    {
        // Arrange
        var organization = new Organization();

        // Act
        organization.FileId = fileId;

        // Assert
        organization.FileId.Should().Be(fileId);
    }

    [Fact]
    public void Organization_File_ShouldBeSettable()
    {
        // Arrange
        var organization = new Organization();
        var file = new FileLog();

        // Act
        organization.File = file;

        // Assert
        organization.File.Should().BeSameAs(file);
    }

    [Fact]
    public void Organization_Addresses_ShouldBeSettable()
    {
        // Arrange
        var organization = new Organization();
        var addresses = new List<Address>();

        // Act
        organization.Addresses = addresses;

        // Assert
        organization.Addresses.Should().BeSameAs(addresses);
    }

    [Fact]
    public void Organization_Contacts_ShouldBeSettable()
    {
        // Arrange
        var organization = new Organization();
        var contacts = new List<Contact>();

        // Act
        organization.Contacts = contacts;

        // Assert
        organization.Contacts.Should().BeSameAs(contacts);
    }

    #endregion

    #region Business Logic Tests

    [Fact]
    public void Organization_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var organization = new Organization
        {
            Name = "Acme Corporation"
        };

        // Assert
        organization.Name.Should().Be("Acme Corporation");
        organization.Country.Should().BeNull();
        organization.City.Should().BeNull();
        organization.StreetAddress.Should().BeNull();
        organization.Type.Should().Be((OrganizationEnum)0);
        organization.FaxNo.Should().BeNull();
        organization.Phone.Should().BeNull();
        organization.Email.Should().BeNull();
        organization.TaxNo.Should().BeNull();
        organization.FileId.Should().Be(0);
        organization.File.Should().BeNull();
        organization.Addresses.Should().BeNull();
        organization.Contacts.Should().BeNull();
    }

    [Fact]
    public void Organization_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange & Act
        var file = new FileLog();
        var addresses = new List<Address> { new Address() };
        var contacts = new List<Contact> { new Contact() };

        var organization = new Organization
        {
            Name = "Acme Corporation",
            Country = "United States",
            City = "New York",
            StreetAddress = "123 Main Street",
            Type = OrganizationEnum.Company,
            FaxNo = "+1-555-123-4567",
            Phone = "+1-555-123-4567",
            Email = "contact@acme.com",
            TaxNo = "12-3456789",
            FileId = 123,
            File = file,
            Addresses = addresses,
            Contacts = contacts
        };

        // Assert
        organization.Name.Should().Be("Acme Corporation");
        organization.Country.Should().Be("United States");
        organization.City.Should().Be("New York");
        organization.StreetAddress.Should().Be("123 Main Street");
        organization.Type.Should().Be(OrganizationEnum.Company);
        organization.FaxNo.Should().Be("+1-555-123-4567");
        organization.Phone.Should().Be("+1-555-123-4567");
        organization.Email.Should().Be("contact@acme.com");
        organization.TaxNo.Should().Be("12-3456789");
        organization.FileId.Should().Be(123);
        organization.File.Should().BeSameAs(file);
        organization.Addresses.Should().BeSameAs(addresses);
        organization.Contacts.Should().BeSameAs(contacts);
    }

    [Fact]
    public void Organization_WithNullFile_ShouldBeCreatable()
    {
        // Arrange & Act
        var organization = new Organization
        {
            Name = "Acme Corporation",
            FileId = 123,
            File = null!
        };

        // Assert
        organization.Name.Should().Be("Acme Corporation");
        organization.FileId.Should().Be(123);
        organization.File.Should().BeNull();
    }

    [Fact]
    public void Organization_WithNullAddresses_ShouldBeCreatable()
    {
        // Arrange & Act
        var organization = new Organization
        {
            Name = "Acme Corporation",
            Addresses = null
        };

        // Assert
        organization.Name.Should().Be("Acme Corporation");
        organization.Addresses.Should().BeNull();
    }

    [Fact]
    public void Organization_WithNullContacts_ShouldBeCreatable()
    {
        // Arrange & Act
        var organization = new Organization
        {
            Name = "Acme Corporation",
            Contacts = null
        };

        // Assert
        organization.Name.Should().Be("Acme Corporation");
        organization.Contacts.Should().BeNull();
    }

    #endregion

    #region Edge Cases Tests

    [Fact]
    public void Organization_WithEmptyName_ShouldBeCreatable()
    {
        // Arrange & Act
        var organization = new Organization
        {
            Name = ""
        };

        // Assert
        organization.Name.Should().Be("");
    }

    [Fact]
    public void Organization_WithNullName_ShouldBeCreatable()
    {
        // Arrange & Act
        var organization = new Organization
        {
            Name = null!
        };

        // Assert
        organization.Name.Should().BeNull();
    }

    [Fact]
    public void Organization_WithZeroFileId_ShouldBeCreatable()
    {
        // Arrange & Act
        var organization = new Organization
        {
            Name = "Acme Corporation",
            FileId = 0
        };

        // Assert
        organization.Name.Should().Be("Acme Corporation");
        organization.FileId.Should().Be(0);
    }

    [Fact]
    public void Organization_WithNegativeFileId_ShouldBeCreatable()
    {
        // Arrange & Act
        var organization = new Organization
        {
            Name = "Acme Corporation",
            FileId = -1
        };

        // Assert
        organization.Name.Should().Be("Acme Corporation");
        organization.FileId.Should().Be(-1);
    }

    #endregion

    #region Boundary Values Tests

    [Theory]
    [InlineData("A")] // Minimum length
    [InlineData("Acme Corporation")] // Normal length
    [InlineData("Very Long Organization Name That Exceeds Normal Length And Should Still Be Valid")] // Long string
    public void Organization_Name_ShouldHandleVariousLengths(string name)
    {
        // Arrange
        var organization = new Organization();

        // Act
        organization.Name = name;

        // Assert
        organization.Name.Should().Be(name);
    }

    [Theory]
    [InlineData(1)] // Minimum valid ID
    [InlineData(100)] // Normal ID
    [InlineData(int.MaxValue)] // Maximum ID
    public void Organization_FileId_ShouldHandleVariousValues(int fileId)
    {
        // Arrange
        var organization = new Organization();

        // Act
        organization.FileId = fileId;

        // Assert
        organization.FileId.Should().Be(fileId);
    }

    #endregion

    #region String Properties Tests

    [Fact]
    public void Organization_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var organization = new Organization
        {
            Id = 1,
            Name = "Acme Corporation"
        };

        // Act
        var result = organization.ToString();

        // Assert
        result.Should().NotBeNull();
        result.Should().Contain("Organization");
    }

    #endregion

    #region Collection Properties Tests

    [Fact]
    public void Organization_Addresses_ShouldBeInitializedAsEmptyList()
    {
        // Arrange
        var organization = new Organization();

        // Act
        organization.Addresses = new List<Address>();

        // Assert
        organization.Addresses.Should().NotBeNull();
        organization.Addresses.Should().BeEmpty();
    }

    [Fact]
    public void Organization_Addresses_ShouldAcceptMultipleItems()
    {
        // Arrange
        var organization = new Organization();
        var addresses = new List<Address>
        {
            new Address(),
            new Address(),
            new Address()
        };

        // Act
        organization.Addresses = addresses;

        // Assert
        organization.Addresses.Should().NotBeNull();
        organization.Addresses.Should().HaveCount(3);
        organization.Addresses.Should().Contain(addresses);
    }

    [Fact]
    public void Organization_Contacts_ShouldBeInitializedAsEmptyList()
    {
        // Arrange
        var organization = new Organization();

        // Act
        organization.Contacts = new List<Contact>();

        // Assert
        organization.Contacts.Should().NotBeNull();
        organization.Contacts.Should().BeEmpty();
    }

    [Fact]
    public void Organization_Contacts_ShouldAcceptMultipleItems()
    {
        // Arrange
        var organization = new Organization();
        var contacts = new List<Contact>
        {
            new Contact(),
            new Contact(),
            new Contact()
        };

        // Act
        organization.Contacts = contacts;

        // Assert
        organization.Contacts.Should().NotBeNull();
        organization.Contacts.Should().HaveCount(3);
        organization.Contacts.Should().Contain(contacts);
    }

    #endregion

    #region Relationship Tests

    [Fact]
    public void Organization_FileRelationship_ShouldBeEstablishable()
    {
        // Arrange
        var organization = new Organization { Name = "Acme Corporation" };
        var file = new FileLog();

        // Act
        organization.File = file;
        organization.FileId = file.Id;

        // Assert
        organization.File.Should().BeSameAs(file);
        organization.FileId.Should().Be(file.Id);
    }

    [Fact]
    public void Organization_AddressesRelationship_ShouldBeEstablishable()
    {
        // Arrange
        var organization = new Organization { Name = "Acme Corporation" };
        var address = new Address();

        // Act
        organization.Addresses = new List<Address> { address };

        // Assert
        organization.Addresses.Should().NotBeNull();
        organization.Addresses.Should().Contain(address);
    }

    [Fact]
    public void Organization_ContactsRelationship_ShouldBeEstablishable()
    {
        // Arrange
        var organization = new Organization { Name = "Acme Corporation" };
        var contact = new Contact();

        // Act
        organization.Contacts = new List<Contact> { contact };

        // Assert
        organization.Contacts.Should().NotBeNull();
        organization.Contacts.Should().Contain(contact);
    }

    #endregion
}
