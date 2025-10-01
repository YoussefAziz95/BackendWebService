using Domain;
using Domain.Enums;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class OfferTests
{
    [Fact]
    public void Offer_DefaultConstructor_ShouldCreateInstance()
    {
        // Arrange & Act
        var offer = new Offer();

        // Assert
        offer.Should().NotBeNull();
        offer.OrganizationId.Should().Be(0);
        offer.Name.Should().BeNull();
        offer.Description.Should().BeNull();
        offer.StartDate.Should().Be(default(DateTime));
        offer.EndDate.Should().Be(default(DateTime));
        offer.Extention.Should().Be(".txt");
        offer.Code.Should().BeNull();
        offer.IsMultiple.Should().BeFalse();
        offer.IsLocal.Should().BeFalse();
        offer.AccessType.Should().Be((AccessEnum)0);
        offer.Currency.Should().Be((CurrencyEnum)0);
        offer.StatusId.Should().Be(0);
        offer.CompanyId.Should().Be(0);
        offer.CustomerId.Should().Be(0);
        offer.SpecificationsFileId.Should().Be(0);
        offer.RichText.Should().BeNull();
        offer.Criterias.Should().BeNull();
        offer.OfferItems.Should().BeNull();
        offer.OfferObjects.Should().BeNull();
        offer.IsActive.Should().BeTrue();
        offer.IsDeleted.Should().BeFalse();
        offer.IsSystem.Should().BeFalse();
        offer.CreatedDate.Should().NotBeNull();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MaxValue)]
    public void Offer_OrganizationId_ShouldBeSettable(int organizationId)
    {
        // Arrange
        var offer = new Offer();

        // Act
        offer.OrganizationId = organizationId;

        // Assert
        offer.OrganizationId.Should().Be(organizationId);
    }

    [Theory]
    [InlineData("Test Offer")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("Very long offer name that might exceed normal length expectations")]
    public void Offer_Name_ShouldBeSettable(string name)
    {
        // Arrange
        var offer = new Offer();

        // Act
        offer.Name = name;

        // Assert
        offer.Name.Should().Be(name);
    }

    [Theory]
    [InlineData("Test Description")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("Very long description that might exceed normal length expectations")]
    public void Offer_Description_ShouldBeSettable(string description)
    {
        // Arrange
        var offer = new Offer();

        // Act
        offer.Description = description;

        // Assert
        offer.Description.Should().Be(description);
    }

    [Fact]
    public void Offer_StartDate_ShouldBeSettable()
    {
        // Arrange
        var offer = new Offer();
        var startDate = DateTime.UtcNow;

        // Act
        offer.StartDate = startDate;

        // Assert
        offer.StartDate.Should().Be(startDate);
    }

    [Fact]
    public void Offer_EndDate_ShouldBeSettable()
    {
        // Arrange
        var offer = new Offer();
        var endDate = DateTime.UtcNow.AddDays(30);

        // Act
        offer.EndDate = endDate;

        // Assert
        offer.EndDate.Should().Be(endDate);
    }

    [Theory]
    [InlineData(".pdf")]
    [InlineData(".doc")]
    [InlineData(".txt")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(".verylongextension")]
    public void Offer_Extention_ShouldBeSettable(string extention)
    {
        // Arrange
        var offer = new Offer();

        // Act
        offer.Extention = extention;

        // Assert
        offer.Extention.Should().Be(extention);
    }

    [Theory]
    [InlineData("OFFER001")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("Very long code that might exceed normal length expectations")]
    public void Offer_Code_ShouldBeSettable(string code)
    {
        // Arrange
        var offer = new Offer();

        // Act
        offer.Code = code;

        // Assert
        offer.Code.Should().Be(code);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Offer_IsMultiple_ShouldBeSettable(bool isMultiple)
    {
        // Arrange
        var offer = new Offer();

        // Act
        offer.IsMultiple = isMultiple;

        // Assert
        offer.IsMultiple.Should().Be(isMultiple);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Offer_IsLocal_ShouldBeSettable(bool isLocal)
    {
        // Arrange
        var offer = new Offer();

        // Act
        offer.IsLocal = isLocal;

        // Assert
        offer.IsLocal.Should().Be(isLocal);
    }

    [Theory]
    [InlineData(AccessEnum.Public)]
    [InlineData(AccessEnum.Private)]
    public void Offer_AccessType_ShouldBeSettable(AccessEnum accessType)
    {
        // Arrange
        var offer = new Offer();

        // Act
        offer.AccessType = accessType;

        // Assert
        offer.AccessType.Should().Be(accessType);
    }

    [Theory]
    [InlineData(CurrencyEnum.USD)]
    [InlineData(CurrencyEnum.EUR)]
    [InlineData(CurrencyEnum.GBP)]
    [InlineData(CurrencyEnum.JPY)]
    public void Offer_Currency_ShouldBeSettable(CurrencyEnum currency)
    {
        // Arrange
        var offer = new Offer();

        // Act
        offer.Currency = currency;

        // Assert
        offer.Currency.Should().Be(currency);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MaxValue)]
    public void Offer_StatusId_ShouldBeSettable(int statusId)
    {
        // Arrange
        var offer = new Offer();

        // Act
        offer.StatusId = statusId;

        // Assert
        offer.StatusId.Should().Be(statusId);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MaxValue)]
    public void Offer_CompanyId_ShouldBeSettable(int companyId)
    {
        // Arrange
        var offer = new Offer();

        // Act
        offer.CompanyId = companyId;

        // Assert
        offer.CompanyId.Should().Be(companyId);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MaxValue)]
    public void Offer_CustomerId_ShouldBeSettable(int customerId)
    {
        // Arrange
        var offer = new Offer();

        // Act
        offer.CustomerId = customerId;

        // Assert
        offer.CustomerId.Should().Be(customerId);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MaxValue)]
    public void Offer_SpecificationsFileId_ShouldBeSettable(int specificationsFileId)
    {
        // Arrange
        var offer = new Offer();

        // Act
        offer.SpecificationsFileId = specificationsFileId;

        // Assert
        offer.SpecificationsFileId.Should().Be(specificationsFileId);
    }

    [Theory]
    [InlineData("Rich text content")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("Very long rich text content that might exceed normal length expectations")]
    public void Offer_RichText_ShouldBeSettable(string richText)
    {
        // Arrange
        var offer = new Offer();

        // Act
        offer.RichText = richText;

        // Assert
        offer.RichText.Should().Be(richText);
    }

    [Fact]
    public void Offer_Criterias_ShouldBeSettable()
    {
        // Arrange
        var offer = new Offer();
        var criteria = new Criteria();

        // Act
        offer.Criterias = new List<Criteria> { criteria };

        // Assert
        offer.Criterias.Should().NotBeNull();
        offer.Criterias.Should().Contain(criteria);
    }

    [Fact]
    public void Offer_OfferItems_ShouldBeSettable()
    {
        // Arrange
        var offer = new Offer();
        var offerItem = new OfferItem();

        // Act
        offer.OfferItems = new List<OfferItem> { offerItem };

        // Assert
        offer.OfferItems.Should().NotBeNull();
        offer.OfferItems.Should().Contain(offerItem);
    }

    [Fact]
    public void Offer_OfferObjects_ShouldBeSettable()
    {
        // Arrange
        var offer = new Offer();
        var offerObject = new OfferObject();

        // Act
        offer.OfferObjects = new List<OfferObject> { offerObject };

        // Assert
        offer.OfferObjects.Should().NotBeNull();
        offer.OfferObjects.Should().Contain(offerObject);
    }

    [Fact]
    public void Offer_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var offer = new Offer
        {
            OrganizationId = 1,
            Name = "Test Offer",
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(30),
            Code = "OFFER001",
            AccessType = AccessEnum.Public,
            Currency = CurrencyEnum.USD,
            StatusId = 1,
            CompanyId = 1,
            CustomerId = 1,
            SpecificationsFileId = 1
        };

        // Assert
        offer.OrganizationId.Should().Be(1);
        offer.Name.Should().Be("Test Offer");
        offer.Code.Should().Be("OFFER001");
        offer.AccessType.Should().Be(AccessEnum.Public);
        offer.Currency.Should().Be(CurrencyEnum.USD);
        offer.IsActive.Should().BeTrue();
    }

    [Fact]
    public void Offer_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange & Act
        var startDate = DateTime.UtcNow;
        var endDate = DateTime.UtcNow.AddDays(30);
        var criteria = new Criteria();
        var offerItem = new OfferItem();
        var offerObject = new OfferObject();
        var offer = new Offer
        {
            OrganizationId = 1,
            Name = "Test Offer",
            Description = "Test Description",
            StartDate = startDate,
            EndDate = endDate,
            Extention = ".pdf",
            Code = "OFFER001",
            IsMultiple = true,
            IsLocal = false,
            AccessType = AccessEnum.Public,
            Currency = CurrencyEnum.USD,
            StatusId = 1,
            CompanyId = 1,
            CustomerId = 1,
            SpecificationsFileId = 1,
            RichText = "Rich text content",
            Criterias = new List<Criteria> { criteria },
            OfferItems = new List<OfferItem> { offerItem },
            OfferObjects = new List<OfferObject> { offerObject }
        };

        // Assert
        offer.OrganizationId.Should().Be(1);
        offer.Name.Should().Be("Test Offer");
        offer.Description.Should().Be("Test Description");
        offer.StartDate.Should().Be(startDate);
        offer.EndDate.Should().Be(endDate);
        offer.Extention.Should().Be(".pdf");
        offer.Code.Should().Be("OFFER001");
        offer.IsMultiple.Should().BeTrue();
        offer.IsLocal.Should().BeFalse();
        offer.AccessType.Should().Be(AccessEnum.Public);
        offer.Currency.Should().Be(CurrencyEnum.USD);
        offer.StatusId.Should().Be(1);
        offer.CompanyId.Should().Be(1);
        offer.CustomerId.Should().Be(1);
        offer.SpecificationsFileId.Should().Be(1);
        offer.RichText.Should().Be("Rich text content");
        offer.Criterias.Should().Contain(criteria);
        offer.OfferItems.Should().Contain(offerItem);
        offer.OfferObjects.Should().Contain(offerObject);
    }

    [Fact]
    public void Offer_WithNullValues_ShouldBeCreatable()
    {
        // Arrange & Act
        var offer = new Offer
        {
            OrganizationId = 1,
            Name = null,
            Description = null,
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(30),
            Extention = null,
            Code = null,
            RichText = null,
            Criterias = null,
            OfferItems = null,
            OfferObjects = null
        };

        // Assert
        offer.OrganizationId.Should().Be(1);
        offer.Name.Should().BeNull();
        offer.Description.Should().BeNull();
        offer.Extention.Should().BeNull();
        offer.Code.Should().BeNull();
        offer.RichText.Should().BeNull();
        offer.Criterias.Should().BeNull();
        offer.OfferItems.Should().BeNull();
        offer.OfferObjects.Should().BeNull();
    }

    [Fact]
    public void Offer_WithEmptyStrings_ShouldBeCreatable()
    {
        // Arrange & Act
        var offer = new Offer
        {
            OrganizationId = 1,
            Name = "",
            Description = "",
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(30),
            Extention = "",
            Code = "",
            RichText = ""
        };

        // Assert
        offer.Name.Should().Be("");
        offer.Description.Should().Be("");
        offer.Extention.Should().Be("");
        offer.Code.Should().Be("");
        offer.RichText.Should().Be("");
    }

    [Fact]
    public void Offer_WithDefaultEnumValues_ShouldBeCreatable()
    {
        // Arrange & Act
        var offer = new Offer
        {
            OrganizationId = 1,
            Name = "Test Offer",
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(30),
            Code = "OFFER001",
            AccessType = (AccessEnum)0,
            Currency = (CurrencyEnum)0,
            StatusId = 1,
            CompanyId = 1,
            CustomerId = 1,
            SpecificationsFileId = 1
        };

        // Assert
        offer.AccessType.Should().Be((AccessEnum)0);
        offer.Currency.Should().Be((CurrencyEnum)0);
    }

    [Fact]
    public void Offer_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var offer = new Offer { Name = "Test Offer" };

        // Act
        var result = offer.ToString();

        // Assert
        result.Should().Contain("Offer");
    }

    [Fact]
    public void Offer_ShouldInheritFromBaseEntity()
    {
        // Arrange & Act
        var offer = new Offer();

        // Assert
        offer.Should().BeAssignableTo<BaseEntity>();
        offer.Should().BeAssignableTo<IEntity>();
        offer.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void Offer_AllProperties_ShouldBeSettable()
    {
        // Arrange
        var offer = new Offer();
        var startDate = DateTime.UtcNow;
        var endDate = DateTime.UtcNow.AddDays(30);
        var criteria = new Criteria();
        var offerItem = new OfferItem();
        var offerObject = new OfferObject();

        // Act
        offer.OrganizationId = 1;
        offer.Name = "Test Offer";
        offer.Description = "Test Description";
        offer.StartDate = startDate;
        offer.EndDate = endDate;
        offer.Extention = ".pdf";
        offer.Code = "OFFER001";
        offer.IsMultiple = true;
        offer.IsLocal = false;
        offer.AccessType = AccessEnum.Public;
        offer.Currency = CurrencyEnum.USD;
        offer.StatusId = 1;
        offer.CompanyId = 1;
        offer.CustomerId = 1;
        offer.SpecificationsFileId = 1;
        offer.RichText = "Rich text content";
        offer.Criterias = new List<Criteria> { criteria };
        offer.OfferItems = new List<OfferItem> { offerItem };
        offer.OfferObjects = new List<OfferObject> { offerObject };

        // Assert
        offer.OrganizationId.Should().Be(1);
        offer.Name.Should().Be("Test Offer");
        offer.Description.Should().Be("Test Description");
        offer.StartDate.Should().Be(startDate);
        offer.EndDate.Should().Be(endDate);
        offer.Extention.Should().Be(".pdf");
        offer.Code.Should().Be("OFFER001");
        offer.IsMultiple.Should().BeTrue();
        offer.IsLocal.Should().BeFalse();
        offer.AccessType.Should().Be(AccessEnum.Public);
        offer.Currency.Should().Be(CurrencyEnum.USD);
        offer.StatusId.Should().Be(1);
        offer.CompanyId.Should().Be(1);
        offer.CustomerId.Should().Be(1);
        offer.SpecificationsFileId.Should().Be(1);
        offer.RichText.Should().Be("Rich text content");
        offer.Criterias.Should().Contain(criteria);
        offer.OfferItems.Should().Contain(offerItem);
        offer.OfferObjects.Should().Contain(offerObject);
    }
}
