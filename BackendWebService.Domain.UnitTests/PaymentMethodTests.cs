using Domain;
using Domain.Enums;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class PaymentMethodTests
{
    [Fact]
    public void PaymentMethod_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var paymentMethod = new PaymentMethod();

        // Assert
        paymentMethod.Should().NotBeNull();
        paymentMethod.IsDefault.Should().BeFalse();
        paymentMethod.IsVerified.Should().BeFalse();
        paymentMethod.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
    }

    [Fact]
    public void PaymentMethod_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange
        var userId = 123;
        var methodType = "Credit Card";
        var provider = "Visa";
        var accountNumber = "1234567890";
        var name = "John Doe";
        var type = PaymentEnum.CreditCard;

        // Act
        var paymentMethod = new PaymentMethod
        {
            UserId = userId,
            MethodType = methodType,
            Provider = provider,
            AccountNumber = accountNumber,
            Name = name,
            Type = type
        };

        // Assert
        paymentMethod.UserId.Should().Be(userId);
        paymentMethod.MethodType.Should().Be(methodType);
        paymentMethod.Provider.Should().Be(provider);
        paymentMethod.AccountNumber.Should().Be(accountNumber);
        paymentMethod.Name.Should().Be(name);
        paymentMethod.Type.Should().Be(type);
    }

    [Fact]
    public void PaymentMethod_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange
        var userId = 123;
        var methodType = "Credit Card";
        var provider = "Visa";
        var accountNumber = "1234567890";
        var name = "John Doe";
        var type = PaymentEnum.CreditCard;
        var isDefault = true;
        var isVerified = true;
        var expiryDate = DateTime.UtcNow.AddYears(2);
        var createdAt = DateTime.UtcNow.AddDays(-1);
        var updatedAt = DateTime.UtcNow;

        // Act
        var paymentMethod = new PaymentMethod
        {
            UserId = userId,
            MethodType = methodType,
            Provider = provider,
            AccountNumber = accountNumber,
            Name = name,
            Type = type,
            IsDefault = isDefault,
            IsVerified = isVerified,
            ExpiryDate = expiryDate,
            CreatedAt = createdAt,
            UpdatedAt = updatedAt
        };

        // Assert
        paymentMethod.UserId.Should().Be(userId);
        paymentMethod.MethodType.Should().Be(methodType);
        paymentMethod.Provider.Should().Be(provider);
        paymentMethod.AccountNumber.Should().Be(accountNumber);
        paymentMethod.Name.Should().Be(name);
        paymentMethod.Type.Should().Be(type);
        paymentMethod.IsDefault.Should().Be(isDefault);
        paymentMethod.IsVerified.Should().Be(isVerified);
        paymentMethod.ExpiryDate.Should().Be(expiryDate);
        paymentMethod.CreatedAt.Should().Be(createdAt);
        paymentMethod.UpdatedAt.Should().Be(updatedAt);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void PaymentMethod_IsDefault_ShouldBeSettable(bool isDefault)
    {
        // Arrange
        var paymentMethod = new PaymentMethod();

        // Act
        paymentMethod.IsDefault = isDefault;

        // Assert
        paymentMethod.IsDefault.Should().Be(isDefault);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void PaymentMethod_IsVerified_ShouldBeSettable(bool isVerified)
    {
        // Arrange
        var paymentMethod = new PaymentMethod();

        // Act
        paymentMethod.IsVerified = isVerified;

        // Assert
        paymentMethod.IsVerified.Should().Be(isVerified);
    }

    [Theory]
    [InlineData(PaymentEnum.Cash)]
    [InlineData(PaymentEnum.CreditCard)]
    [InlineData(PaymentEnum.DebitCard)]
    [InlineData(PaymentEnum.MobilePayment)]
    [InlineData(PaymentEnum.OnlinePayment)]
    [InlineData(PaymentEnum.Crypto)]
    public void PaymentMethod_Type_ShouldBeSettable(PaymentEnum type)
    {
        // Arrange
        var paymentMethod = new PaymentMethod();

        // Act
        paymentMethod.Type = type;

        // Assert
        paymentMethod.Type.Should().Be(type);
    }

    [Theory]
    [InlineData("Credit Card")]
    [InlineData("Debit Card")]
    [InlineData("Bank Transfer")]
    [InlineData("PayPal")]
    public void PaymentMethod_MethodType_ShouldBeSettable(string methodType)
    {
        // Arrange
        var paymentMethod = new PaymentMethod();

        // Act
        paymentMethod.MethodType = methodType;

        // Assert
        paymentMethod.MethodType.Should().Be(methodType);
    }

    [Theory]
    [InlineData("Visa")]
    [InlineData("Mastercard")]
    [InlineData("American Express")]
    [InlineData("PayPal")]
    public void PaymentMethod_Provider_ShouldBeSettable(string provider)
    {
        // Arrange
        var paymentMethod = new PaymentMethod();

        // Act
        paymentMethod.Provider = provider;

        // Assert
        paymentMethod.Provider.Should().Be(provider);
    }

    [Fact]
    public void PaymentMethod_OptionalProperties_ShouldBeNullable()
    {
        // Arrange
        var paymentMethod = new PaymentMethod();

        // Act & Assert
        paymentMethod.ExpiryDate.Should().BeNull();
        paymentMethod.UpdatedAt.Should().BeNull();
    }

    [Fact]
    public void PaymentMethod_CreatedAt_ShouldDefaultToCurrentTime()
    {
        // Act
        var paymentMethod = new PaymentMethod();

        // Assert
        paymentMethod.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
    }

    [Fact]
    public void PaymentMethod_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var paymentMethod = new PaymentMethod();

        // Act
        var result = paymentMethod.ToString();

        // Assert
        result.Should().Contain("PaymentMethod");
    }

    [Fact]
    public void PaymentMethod_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var paymentMethod = new PaymentMethod();

        // Act & Assert
        paymentMethod.Should().BeAssignableTo<BaseEntity>();
        paymentMethod.Should().BeAssignableTo<IEntity>();
        paymentMethod.Should().BeAssignableTo<ITimeModification>();
    }
}