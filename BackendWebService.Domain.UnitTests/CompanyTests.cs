using FluentAssertions;
using Domain;
using Domain.Enums;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class CompanyTests
{
    #region Constructor Tests

    [Fact]
    public void Company_DefaultConstructor_ShouldCreateInstance()
    {
        // Arrange & Act
        var company = new Company();

        // Assert
        company.Should().NotBeNull();
        company.Id.Should().Be(0);
        company.OrganizationId.Should().Be(0);
        company.Organization.Should().BeNull();
        company.CompanyName.Should().BeNull();
        company.RegistrationNumber.Should().BeNull();
        company.ContactEmail.Should().BeNull();
        company.ContactPhone.Should().BeNull();
        company.Status.Should().Be(StatusEnum.Active);
        company.Chairman.Should().BeNull();
        company.QualityCertificates.Should().BeNull();
        company.ViceChairman.Should().BeNull();
        company.ProductType.Should().BeNull();
        company.CompanyCategories.Should().BeNull();
        company.Managers.Should().BeNull();
        company.CreatedDate.Should().NotBeNull();
        company.UpdatedDate.Should().BeNull();
        company.CreatedBy.Should().BeNull();
        company.UpdatedBy.Should().BeNull();
        company.IsActive.Should().BeTrue();
        company.IsDeleted.Should().BeFalse();
    }

    #endregion

    #region Property Setting Tests

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    public void Company_OrganizationId_ShouldBeSettable(int organizationId)
    {
        // Arrange
        var company = new Company();

        // Act
        company.OrganizationId = organizationId;

        // Assert
        company.OrganizationId.Should().Be(organizationId);
    }

    [Fact]
    public void Company_Organization_ShouldBeSettable()
    {
        // Arrange
        var company = new Company();
        var organization = new Organization();

        // Act
        company.Organization = organization;

        // Assert
        company.Organization.Should().BeSameAs(organization);
    }

    [Theory]
    [InlineData("Acme Corporation")]
    [InlineData("Tech Solutions Inc")]
    [InlineData("Global Enterprises")]
    [InlineData("")]
    public void Company_CompanyName_ShouldBeSettable(string companyName)
    {
        // Arrange
        var company = new Company();

        // Act
        company.CompanyName = companyName;

        // Assert
        company.CompanyName.Should().Be(companyName);
    }

    [Theory]
    [InlineData("REG123456")]
    [InlineData("REG789012")]
    [InlineData("")]
    public void Company_RegistrationNumber_ShouldBeSettable(string registrationNumber)
    {
        // Arrange
        var company = new Company();

        // Act
        company.RegistrationNumber = registrationNumber;

        // Assert
        company.RegistrationNumber.Should().Be(registrationNumber);
    }

    [Theory]
    [InlineData("contact@acme.com")]
    [InlineData("info@techsolutions.com")]
    [InlineData("")]
    public void Company_ContactEmail_ShouldBeSettable(string contactEmail)
    {
        // Arrange
        var company = new Company();

        // Act
        company.ContactEmail = contactEmail;

        // Assert
        company.ContactEmail.Should().Be(contactEmail);
    }

    [Theory]
    [InlineData("+1-555-123-4567")]
    [InlineData("+44-20-7946-0958")]
    [InlineData("")]
    public void Company_ContactPhone_ShouldBeSettable(string contactPhone)
    {
        // Arrange
        var company = new Company();

        // Act
        company.ContactPhone = contactPhone;

        // Assert
        company.ContactPhone.Should().Be(contactPhone);
    }

    [Theory]
    [InlineData(StatusEnum.Active)]
    [InlineData(StatusEnum.Disabled)]
    [InlineData(StatusEnum.Pending)]
    [InlineData(StatusEnum.Deleted)]
    public void Company_Status_ShouldBeSettable(StatusEnum status)
    {
        // Arrange
        var company = new Company();

        // Act
        company.Status = status;

        // Assert
        company.Status.Should().Be(status);
    }

    [Theory]
    [InlineData("John Doe")]
    [InlineData("Jane Smith")]
    [InlineData("")]
    public void Company_Chairman_ShouldBeSettable(string chairman)
    {
        // Arrange
        var company = new Company();

        // Act
        company.Chairman = chairman;

        // Assert
        company.Chairman.Should().Be(chairman);
    }

    [Theory]
    [InlineData("ISO 9001:2015")]
    [InlineData("ISO 14001:2015")]
    [InlineData("")]
    public void Company_QualityCertificates_ShouldBeSettable(string qualityCertificates)
    {
        // Arrange
        var company = new Company();

        // Act
        company.QualityCertificates = qualityCertificates;

        // Assert
        company.QualityCertificates.Should().Be(qualityCertificates);
    }

    [Theory]
    [InlineData("Bob Johnson")]
    [InlineData("Alice Brown")]
    [InlineData("")]
    public void Company_ViceChairman_ShouldBeSettable(string viceChairman)
    {
        // Arrange
        var company = new Company();

        // Act
        company.ViceChairman = viceChairman;

        // Assert
        company.ViceChairman.Should().Be(viceChairman);
    }

    [Theory]
    [InlineData("Software")]
    [InlineData("Manufacturing")]
    [InlineData("")]
    public void Company_ProductType_ShouldBeSettable(string productType)
    {
        // Arrange
        var company = new Company();

        // Act
        company.ProductType = productType;

        // Assert
        company.ProductType.Should().Be(productType);
    }

    [Fact]
    public void Company_CompanyCategories_ShouldBeSettable()
    {
        // Arrange
        var company = new Company();
        var companyCategories = new List<CompanyCategory>();

        // Act
        company.CompanyCategories = companyCategories;

        // Assert
        company.CompanyCategories.Should().BeSameAs(companyCategories);
    }

    [Fact]
    public void Company_Managers_ShouldBeSettable()
    {
        // Arrange
        var company = new Company();
        var managers = new List<Manager>();

        // Act
        company.Managers = managers;

        // Assert
        company.Managers.Should().BeSameAs(managers);
    }

    #endregion

    #region Business Logic Tests

    [Fact]
    public void Company_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var company = new Company
        {
            OrganizationId = 1,
            CompanyName = "Acme Corporation"
        };

        // Assert
        company.OrganizationId.Should().Be(1);
        company.CompanyName.Should().Be("Acme Corporation");
        company.RegistrationNumber.Should().BeNull();
        company.ContactEmail.Should().BeNull();
        company.ContactPhone.Should().BeNull();
        company.Status.Should().Be(StatusEnum.Active);
        company.Chairman.Should().BeNull();
        company.QualityCertificates.Should().BeNull();
        company.ViceChairman.Should().BeNull();
        company.ProductType.Should().BeNull();
        company.CompanyCategories.Should().BeNull();
        company.Managers.Should().BeNull();
    }

    [Fact]
    public void Company_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange & Act
        var organization = new Organization { Name = "Parent Organization" };
        var companyCategories = new List<CompanyCategory> { new CompanyCategory() };
        var managers = new List<Manager> { new Manager() };

        var company = new Company
        {
            OrganizationId = 1,
            Organization = organization,
            CompanyName = "Acme Corporation",
            RegistrationNumber = "REG123456",
            ContactEmail = "contact@acme.com",
            ContactPhone = "+1-555-123-4567",
            Status = StatusEnum.Active,
            Chairman = "John Doe",
            QualityCertificates = "ISO 9001:2015",
            ViceChairman = "Jane Smith",
            ProductType = "Software",
            CompanyCategories = companyCategories,
            Managers = managers
        };

        // Assert
        company.OrganizationId.Should().Be(1);
        company.Organization.Should().BeSameAs(organization);
        company.CompanyName.Should().Be("Acme Corporation");
        company.RegistrationNumber.Should().Be("REG123456");
        company.ContactEmail.Should().Be("contact@acme.com");
        company.ContactPhone.Should().Be("+1-555-123-4567");
        company.Status.Should().Be(StatusEnum.Active);
        company.Chairman.Should().Be("John Doe");
        company.QualityCertificates.Should().Be("ISO 9001:2015");
        company.ViceChairman.Should().Be("Jane Smith");
        company.ProductType.Should().Be("Software");
        company.CompanyCategories.Should().BeSameAs(companyCategories);
        company.Managers.Should().BeSameAs(managers);
    }

    [Fact]
    public void Company_WithNullOrganization_ShouldBeCreatable()
    {
        // Arrange & Act
        var company = new Company
        {
            OrganizationId = 1,
            Organization = null!
        };

        // Assert
        company.OrganizationId.Should().Be(1);
        company.Organization.Should().BeNull();
    }

    [Fact]
    public void Company_WithNullCompanyCategories_ShouldBeCreatable()
    {
        // Arrange & Act
        var company = new Company
        {
            OrganizationId = 1,
            CompanyName = "Acme Corporation",
            CompanyCategories = null
        };

        // Assert
        company.OrganizationId.Should().Be(1);
        company.CompanyName.Should().Be("Acme Corporation");
        company.CompanyCategories.Should().BeNull();
    }

    [Fact]
    public void Company_WithNullManagers_ShouldBeCreatable()
    {
        // Arrange & Act
        var company = new Company
        {
            OrganizationId = 1,
            CompanyName = "Acme Corporation",
            Managers = null
        };

        // Assert
        company.OrganizationId.Should().Be(1);
        company.CompanyName.Should().Be("Acme Corporation");
        company.Managers.Should().BeNull();
    }

    #endregion

    #region Edge Cases Tests

    [Fact]
    public void Company_WithEmptyCompanyName_ShouldBeCreatable()
    {
        // Arrange & Act
        var company = new Company
        {
            OrganizationId = 1,
            CompanyName = ""
        };

        // Assert
        company.OrganizationId.Should().Be(1);
        company.CompanyName.Should().Be("");
    }

    [Fact]
    public void Company_WithNullCompanyName_ShouldBeCreatable()
    {
        // Arrange & Act
        var company = new Company
        {
            OrganizationId = 1,
            CompanyName = null
        };

        // Assert
        company.OrganizationId.Should().Be(1);
        company.CompanyName.Should().BeNull();
    }

    [Fact]
    public void Company_WithZeroOrganizationId_ShouldBeCreatable()
    {
        // Arrange & Act
        var company = new Company
        {
            OrganizationId = 0,
            CompanyName = "Acme Corporation"
        };

        // Assert
        company.OrganizationId.Should().Be(0);
        company.CompanyName.Should().Be("Acme Corporation");
    }

    [Fact]
    public void Company_WithNegativeOrganizationId_ShouldBeCreatable()
    {
        // Arrange & Act
        var company = new Company
        {
            OrganizationId = -1,
            CompanyName = "Acme Corporation"
        };

        // Assert
        company.OrganizationId.Should().Be(-1);
        company.CompanyName.Should().Be("Acme Corporation");
    }

    #endregion

    #region Boundary Values Tests

    [Theory]
    [InlineData("A")] // Minimum length
    [InlineData("Acme Corporation")] // Normal length
    [InlineData("Very Long Company Name That Exceeds Normal Length And Should Still Be Valid")] // Long string
    public void Company_CompanyName_ShouldHandleVariousLengths(string companyName)
    {
        // Arrange
        var company = new Company();

        // Act
        company.CompanyName = companyName;

        // Assert
        company.CompanyName.Should().Be(companyName);
    }

    [Theory]
    [InlineData(1)] // Minimum valid ID
    [InlineData(100)] // Normal ID
    [InlineData(int.MaxValue)] // Maximum ID
    public void Company_OrganizationId_ShouldHandleVariousValues(int organizationId)
    {
        // Arrange
        var company = new Company();

        // Act
        company.OrganizationId = organizationId;

        // Assert
        company.OrganizationId.Should().Be(organizationId);
    }

    #endregion

    #region String Properties Tests

    [Fact]
    public void Company_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var company = new Company
        {
            Id = 1,
            CompanyName = "Acme Corporation"
        };

        // Act
        var result = company.ToString();

        // Assert
        result.Should().NotBeNull();
        result.Should().Contain("Company");
    }

    #endregion

    #region Collection Properties Tests

    [Fact]
    public void Company_CompanyCategories_ShouldBeInitializedAsEmptyList()
    {
        // Arrange
        var company = new Company();

        // Act
        company.CompanyCategories = new List<CompanyCategory>();

        // Assert
        company.CompanyCategories.Should().NotBeNull();
        company.CompanyCategories.Should().BeEmpty();
    }

    [Fact]
    public void Company_CompanyCategories_ShouldAcceptMultipleItems()
    {
        // Arrange
        var company = new Company();
        var companyCategories = new List<CompanyCategory>
        {
            new CompanyCategory(),
            new CompanyCategory(),
            new CompanyCategory()
        };

        // Act
        company.CompanyCategories = companyCategories;

        // Assert
        company.CompanyCategories.Should().NotBeNull();
        company.CompanyCategories.Should().HaveCount(3);
        company.CompanyCategories.Should().Contain(companyCategories);
    }

    [Fact]
    public void Company_Managers_ShouldBeInitializedAsEmptyList()
    {
        // Arrange
        var company = new Company();

        // Act
        company.Managers = new List<Manager>();

        // Assert
        company.Managers.Should().NotBeNull();
        company.Managers.Should().BeEmpty();
    }

    [Fact]
    public void Company_Managers_ShouldAcceptMultipleItems()
    {
        // Arrange
        var company = new Company();
        var managers = new List<Manager>
        {
            new Manager(),
            new Manager(),
            new Manager()
        };

        // Act
        company.Managers = managers;

        // Assert
        company.Managers.Should().NotBeNull();
        company.Managers.Should().HaveCount(3);
        company.Managers.Should().Contain(managers);
    }

    #endregion

    #region Relationship Tests

    [Fact]
    public void Company_OrganizationRelationship_ShouldBeEstablishable()
    {
        // Arrange
        var company = new Company { CompanyName = "Acme Corporation" };
        var organization = new Organization { Name = "Parent Organization" };

        // Act
        company.Organization = organization;
        company.OrganizationId = organization.Id;

        // Assert
        company.Organization.Should().BeSameAs(organization);
        company.OrganizationId.Should().Be(organization.Id);
    }

    [Fact]
    public void Company_CompanyCategoriesRelationship_ShouldBeEstablishable()
    {
        // Arrange
        var company = new Company { CompanyName = "Acme Corporation" };
        var companyCategory = new CompanyCategory();

        // Act
        company.CompanyCategories = new List<CompanyCategory> { companyCategory };

        // Assert
        company.CompanyCategories.Should().NotBeNull();
        company.CompanyCategories.Should().Contain(companyCategory);
    }

    [Fact]
    public void Company_ManagersRelationship_ShouldBeEstablishable()
    {
        // Arrange
        var company = new Company { CompanyName = "Acme Corporation" };
        var manager = new Manager();

        // Act
        company.Managers = new List<Manager> { manager };

        // Assert
        company.Managers.Should().NotBeNull();
        company.Managers.Should().Contain(manager);
    }

    #endregion
}
