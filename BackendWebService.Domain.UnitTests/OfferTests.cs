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
        // Act
        var offer = new Offer();

        // Assert
        offer.Should().NotBeNull();
        offer.IsMultiple.Should().BeFalse();
        offer.IsLocal.Should().BeFalse();
        offer.Extention.Should().Be(".txt");
    }

    [Fact]
    public void Offer_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange
        var organizationId = 123;
        var name = "Test Offer";
        var startDate = DateTime.UtcNow;
        var endDate = DateTime.UtcNow.AddDays(30);
        var code = "OFFER001";
        var accessType = AccessEnum.Public;
        var currency = CurrencyEnum.USD;
        var statusId = 1;
        var companyId = 456;
        var customerId = 789;
        var specificationsFileId = 101;

        // Act
        var offer = new Offer
        {
            OrganizationId = organizationId,
            Name = name,
            StartDate = startDate,
            EndDate = endDate,
            Code = code,
            AccessType = accessType,
            Currency = currency,
            StatusId = statusId,
            CompanyId = companyId,
            CustomerId = customerId,
            SpecificationsFileId = specificationsFileId
        };

        // Assert
        offer.OrganizationId.Should().Be(organizationId);
        offer.Name.Should().Be(name);
        offer.StartDate.Should().Be(startDate);
        offer.EndDate.Should().Be(endDate);
        offer.Code.Should().Be(code);
        offer.AccessType.Should().Be(accessType);
        offer.Currency.Should().Be(currency);
        offer.StatusId.Should().Be(statusId);
        offer.CompanyId.Should().Be(companyId);
        offer.CustomerId.Should().Be(customerId);
        offer.SpecificationsFileId.Should().Be(specificationsFileId);
    }

    [Fact]
    public void Offer_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange
        var organizationId = 123;
        var name = "Complete Offer";
        var description = "A complete offer description";
        var startDate = DateTime.UtcNow;
        var endDate = DateTime.UtcNow.AddDays(30);
        var extention = ".pdf";
        var code = "OFFER002";
        var isMultiple = true;
        var isLocal = true;
        var accessType = AccessEnum.Private;
        var currency = CurrencyEnum.EUR;
        var statusId = 2;
        var companyId = 456;
        var customerId = 789;
        var specificationsFileId = 101;
        var richText = "<p>Rich text content</p>";

        // Act
        var offer = new Offer
        {
            OrganizationId = organizationId,
            Name = name,
            Description = description,
            StartDate = startDate,
            EndDate = endDate,
            Extention = extention,
            Code = code,
            IsMultiple = isMultiple,
            IsLocal = isLocal,
            AccessType = accessType,
            Currency = currency,
            StatusId = statusId,
            CompanyId = companyId,
            CustomerId = customerId,
            SpecificationsFileId = specificationsFileId,
            RichText = richText
        };

        // Assert
        offer.OrganizationId.Should().Be(organizationId);
        offer.Name.Should().Be(name);
        offer.Description.Should().Be(description);
        offer.StartDate.Should().Be(startDate);
        offer.EndDate.Should().Be(endDate);
        offer.Extention.Should().Be(extention);
        offer.Code.Should().Be(code);
        offer.IsMultiple.Should().Be(isMultiple);
        offer.IsLocal.Should().Be(isLocal);
        offer.AccessType.Should().Be(accessType);
        offer.Currency.Should().Be(currency);
        offer.StatusId.Should().Be(statusId);
        offer.CompanyId.Should().Be(companyId);
        offer.CustomerId.Should().Be(customerId);
        offer.SpecificationsFileId.Should().Be(specificationsFileId);
        offer.RichText.Should().Be(richText);
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
    [InlineData(".pdf")]
    [InlineData(".doc")]
    [InlineData(".txt")]
    [InlineData(".xlsx")]
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

    [Fact]
    public void Offer_OptionalProperties_ShouldBeNullable()
    {
        // Arrange
        var offer = new Offer();

        // Act & Assert
        offer.Description.Should().BeNull();
        offer.RichText.Should().BeNull();
    }

    [Fact]
    public void Offer_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var offer = new Offer();

        // Act
        var result = offer.ToString();

        // Assert
        result.Should().Contain("Offer");
    }

    [Fact]
    public void Offer_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var offer = new Offer();

        // Act & Assert
        offer.Should().BeAssignableTo<BaseEntity>();
        offer.Should().BeAssignableTo<IEntity>();
        offer.Should().BeAssignableTo<ITimeModification>();
    }
}