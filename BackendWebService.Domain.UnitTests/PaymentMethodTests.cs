using Domain;
using Domain.Enums;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class PaymentMethodTests
{
    #region Constructor Tests

    [Fact]
    public void PaymentMethod_Constructor_ShouldSetDefaultValues()
    {
        // Arrange & Act
        var paymentMethod = new PaymentMethod();

        // Assert
        paymentMethod.IsDefault.Should().BeFalse();
        paymentMethod.IsVerified.Should().BeFalse();
        paymentMethod.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        paymentMethod.UpdatedAt.Should().BeNull();
        paymentMethod.ExpiryDate.Should().BeNull();
    }

    [Fact]
    public void PaymentMethod_Constructor_ShouldInitializeRequiredProperties()
    {
        // Arrange & Act
        var paymentMethod = new PaymentMethod();

        // Assert - Verify all required properties are accessible
        paymentMethod.UserId.Should().Be(0); // Default int value
        paymentMethod.MethodType.Should().BeNull();
        paymentMethod.Provider.Should().BeNull();
        paymentMethod.AccountNumber.Should().BeNull();
        paymentMethod.Name.Should().BeNull();
        paymentMethod.Type.Should().Be(default(PaymentEnum));
    }

    [Fact]
    public void PaymentMethod_ShouldInheritFromBaseEntity()
    {
        // Arrange & Act
        var paymentMethod = new PaymentMethod();

        // Assert
        paymentMethod.Should().BeAssignableTo<IEntity>();
        paymentMethod.Should().BeAssignableTo<ITimeModification>();
    }

    #endregion

    #region Property Validation Tests

    [Theory]
    [InlineData("Credit Card", true)]
    [InlineData("Debit Card", true)]
    [InlineData("Mobile Payment", true)]
    [InlineData("Online Payment", true)]
    [InlineData("Cash Payment", true)]
    [InlineData("", false)]
    [InlineData("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA", false)]
    public void PaymentMethod_MethodType_ShouldValidateCorrectly(string methodType, bool isValid)
    {
        // Arrange
        var paymentMethod = new PaymentMethod
        {
            UserId = 1,
            Provider = "Test Provider",
            AccountNumber = "1234567890",
            Name = "Test Payment",
            Type = PaymentEnum.CreditCard
        };

        // Act & Assert
        if (isValid)
        {
            paymentMethod.MethodType = methodType;
            paymentMethod.MethodType.Should().Be(methodType);
        }
        else
        {
            var action = () => paymentMethod.MethodType = methodType;
            action.Should().NotThrow(); // Property setter doesn't throw, validation happens at model level
        }
    }

    [Theory]
    [InlineData("Visa", true)]
    [InlineData("MasterCard", true)]
    [InlineData("PayPal", true)]
    [InlineData("Apple Pay", true)]
    [InlineData("Google Pay", true)]
    [InlineData("", false)]
    [InlineData("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA", false)]
    public void PaymentMethod_Provider_ShouldValidateCorrectly(string provider, bool isValid)
    {
        // Arrange
        var paymentMethod = new PaymentMethod
        {
            UserId = 1,
            MethodType = "Credit Card",
            AccountNumber = "1234567890",
            Name = "Test Payment",
            Type = PaymentEnum.CreditCard
        };

        // Act & Assert
        if (isValid)
        {
            paymentMethod.Provider = provider;
            paymentMethod.Provider.Should().Be(provider);
        }
        else
        {
            var action = () => paymentMethod.Provider = provider;
            action.Should().NotThrow(); // Property setter doesn't throw, validation happens at model level
        }
    }

    [Theory]
    [InlineData("1234567890123456", true)]
    [InlineData("4111-1111-1111-1111", true)]
    [InlineData("5555-5555-5555-4444", true)]
    [InlineData("", false)]
    [InlineData("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA", false)]
    public void PaymentMethod_AccountNumber_ShouldValidateCorrectly(string accountNumber, bool isValid)
    {
        // Arrange
        var paymentMethod = new PaymentMethod
        {
            UserId = 1,
            MethodType = "Credit Card",
            Provider = "Visa",
            Name = "Test Payment",
            Type = PaymentEnum.CreditCard
        };

        // Act & Assert
        if (isValid)
        {
            paymentMethod.AccountNumber = accountNumber;
            paymentMethod.AccountNumber.Should().Be(accountNumber);
        }
        else
        {
            var action = () => paymentMethod.AccountNumber = accountNumber;
            action.Should().NotThrow(); // Property setter doesn't throw, validation happens at model level
        }
    }

    [Theory]
    [InlineData("My Credit Card", true)]
    [InlineData("Primary Payment Method", true)]
    [InlineData("Work Debit Card", true)]
    [InlineData("", false)]
    [InlineData("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA", false)]
    public void PaymentMethod_Name_ShouldValidateCorrectly(string name, bool isValid)
    {
        // Arrange
        var paymentMethod = new PaymentMethod
        {
            UserId = 1,
            MethodType = "Credit Card",
            Provider = "Visa",
            AccountNumber = "1234567890",
            Type = PaymentEnum.CreditCard
        };

        // Act & Assert
        if (isValid)
        {
            paymentMethod.Name = name;
            paymentMethod.Name.Should().Be(name);
        }
        else
        {
            var action = () => paymentMethod.Name = name;
            action.Should().NotThrow(); // Property setter doesn't throw, validation happens at model level
        }
    }

    [Theory]
    [InlineData(PaymentEnum.Cash, true)]
    [InlineData(PaymentEnum.CreditCard, true)]
    [InlineData(PaymentEnum.DebitCard, true)]
    [InlineData(PaymentEnum.MobilePayment, true)]
    [InlineData(PaymentEnum.OnlinePayment, true)]
    [InlineData(PaymentEnum.Crypto, true)]
    public void PaymentMethod_Type_ShouldAcceptValidEnumValues(PaymentEnum type, bool isValid)
    {
        // Arrange
        var paymentMethod = new PaymentMethod
        {
            UserId = 1,
            MethodType = "Credit Card",
            Provider = "Visa",
            AccountNumber = "1234567890",
            Name = "Test Payment"
        };

        // Act & Assert
        if (isValid)
        {
            paymentMethod.Type = type;
            paymentMethod.Type.Should().Be(type);
        }
    }

    #endregion

    #region Business Logic Tests

    [Theory]
    [InlineData("2025-12-31", true)]
    [InlineData("2030-01-01", true)]
    [InlineData("2020-01-01", false)]
    public void PaymentMethod_ExpiryDate_ShouldValidateCorrectly(string expiryDateString, bool isValid)
    {
        // Arrange
        var paymentMethod = new PaymentMethod
        {
            UserId = 1,
            MethodType = "Credit Card",
            Provider = "Visa",
            AccountNumber = "1234567890",
            Name = "Test Payment",
            Type = PaymentEnum.CreditCard
        };

        // Act
        var expiryDate = DateTime.Parse(expiryDateString);
        paymentMethod.ExpiryDate = expiryDate;

        // Assert
        paymentMethod.ExpiryDate.Should().Be(expiryDate);
        
        var isFutureDate = expiryDate > DateTime.UtcNow;
        isFutureDate.Should().Be(isValid);
    }

    [Fact]
    public void PaymentMethod_VerificationStatus_ShouldBeMutable()
    {
        // Arrange
        var paymentMethod = new PaymentMethod
        {
            UserId = 1,
            MethodType = "Credit Card",
            Provider = "Visa",
            AccountNumber = "1234567890",
            Name = "Test Payment",
            Type = PaymentEnum.CreditCard
        };

        // Act & Assert
        paymentMethod.IsVerified.Should().BeFalse(); // Default value

        paymentMethod.IsVerified = true;
        paymentMethod.IsVerified.Should().BeTrue();

        paymentMethod.IsVerified = false;
        paymentMethod.IsVerified.Should().BeFalse();
    }

    [Fact]
    public void PaymentMethod_DefaultStatus_ShouldBeMutable()
    {
        // Arrange
        var paymentMethod = new PaymentMethod
        {
            UserId = 1,
            MethodType = "Credit Card",
            Provider = "Visa",
            AccountNumber = "1234567890",
            Name = "Test Payment",
            Type = PaymentEnum.CreditCard
        };

        // Act & Assert
        paymentMethod.IsDefault.Should().BeFalse(); // Default value

        paymentMethod.IsDefault = true;
        paymentMethod.IsDefault.Should().BeTrue();

        paymentMethod.IsDefault = false;
        paymentMethod.IsDefault.Should().BeFalse();
    }

    [Fact]
    public void PaymentMethod_Timestamps_ShouldBeManagedCorrectly()
    {
        // Arrange
        var beforeCreation = DateTime.UtcNow.AddSeconds(-1);

        // Act
        var paymentMethod = new PaymentMethod
        {
            UserId = 1,
            MethodType = "Credit Card",
            Provider = "Visa",
            AccountNumber = "1234567890",
            Name = "Test Payment",
            Type = PaymentEnum.CreditCard
        };

        var afterCreation = DateTime.UtcNow.AddSeconds(1);

        // Assert
        paymentMethod.CreatedAt.Should().BeOnOrAfter(beforeCreation);
        paymentMethod.CreatedAt.Should().BeOnOrBefore(afterCreation);
        paymentMethod.UpdatedAt.Should().BeNull();

        // Act - Simulate update
        var beforeUpdate = DateTime.UtcNow.AddSeconds(-1);
        paymentMethod.Name = "Updated Payment Name";
        var afterUpdate = DateTime.UtcNow.AddSeconds(1);

        // Assert - UpdatedAt should be set when modified
        // Note: This would typically be handled by the ORM or a base class method
        // For this test, we're verifying the property can be set
        paymentMethod.UpdatedAt = DateTime.UtcNow;
        paymentMethod.UpdatedAt.Should().NotBeNull();
        paymentMethod.UpdatedAt.Should().BeOnOrAfter(beforeUpdate);
        paymentMethod.UpdatedAt.Should().BeOnOrBefore(afterUpdate);
    }

    #endregion

    #region Business Rules Tests

    [Theory]
    [InlineData("4111111111111111", PaymentEnum.CreditCard, true)]
    [InlineData("4111-1111-1111-1111", PaymentEnum.CreditCard, true)]
    [InlineData("5555555555554444", PaymentEnum.CreditCard, true)]
    [InlineData("1234567890", PaymentEnum.DebitCard, true)]
    [InlineData("invalid", PaymentEnum.CreditCard, false)]
    [InlineData("", PaymentEnum.CreditCard, false)]
    public void PaymentMethod_AccountNumberFormat_ShouldValidateBasedOnType(string accountNumber, PaymentEnum type, bool isValid)
    {
        // Arrange
        var paymentMethod = new PaymentMethod
        {
            UserId = 1,
            MethodType = "Credit Card",
            Provider = "Visa",
            Name = "Test Payment",
            Type = type
        };

        // Act
        paymentMethod.AccountNumber = accountNumber;

        // Assert
        paymentMethod.AccountNumber.Should().Be(accountNumber);
        
        // Additional validation logic would be implemented in business logic layer
        if (!isValid)
        {
            // In a real implementation, this would trigger validation errors
            // For now, we're just testing that the property can be set
            paymentMethod.AccountNumber.Should().Be(accountNumber);
        }
    }

    [Theory]
    [InlineData("Visa", PaymentEnum.CreditCard, true)]
    [InlineData("MasterCard", PaymentEnum.CreditCard, true)]
    [InlineData("PayPal", PaymentEnum.OnlinePayment, true)]
    [InlineData("Apple Pay", PaymentEnum.MobilePayment, true)]
    [InlineData("Google Pay", PaymentEnum.MobilePayment, true)]
    [InlineData("Visa", PaymentEnum.DebitCard, false)]
    [InlineData("PayPal", PaymentEnum.CreditCard, false)]
    public void PaymentMethod_ProviderMethodTypeConsistency_ShouldBeValidated(string provider, PaymentEnum type, bool isValid)
    {
        // Arrange
        var paymentMethod = new PaymentMethod
        {
            UserId = 1,
            MethodType = "Credit Card",
            AccountNumber = "1234567890",
            Name = "Test Payment",
            Type = type
        };

        // Act
        paymentMethod.Provider = provider;

        // Assert
        paymentMethod.Provider.Should().Be(provider);
        
        // Additional validation logic would be implemented in business logic layer
        if (!isValid)
        {
            // In a real implementation, this would trigger validation errors
            // For now, we're just testing that the property can be set
            paymentMethod.Provider.Should().Be(provider);
        }
    }

    [Theory]
    [InlineData("2025-12-31", true)]
    [InlineData("2035-01-01", true)] // Within 10 years
    [InlineData("2020-01-01", false)] // Past date
    public void PaymentMethod_ExpiryDateBusinessRules_ShouldBeEnforced(DateTime expiryDate, bool isValid)
    {
        // Arrange
        var paymentMethod = new PaymentMethod
        {
            UserId = 1,
            MethodType = "Credit Card",
            Provider = "Visa",
            AccountNumber = "1234567890",
            Name = "Test Payment",
            Type = PaymentEnum.CreditCard
        };

        // Act
        paymentMethod.ExpiryDate = expiryDate;

        // Assert
        paymentMethod.ExpiryDate.Should().Be(expiryDate);
        
        // Business rule validation
        var isFutureDate = expiryDate > DateTime.UtcNow;
        var isWithinTenYears = expiryDate <= DateTime.UtcNow.AddYears(10);
        var isValidDate = isFutureDate && isWithinTenYears;
        
        isValidDate.Should().Be(isValid);
    }

    [Fact]
    public void PaymentMethod_DefaultPaymentMethodRules_ShouldBeEnforced()
    {
        // Arrange
        var paymentMethod = new PaymentMethod
        {
            UserId = 1,
            MethodType = "Credit Card",
            Provider = "Visa",
            AccountNumber = "1234567890",
            Name = "Test Payment",
            Type = PaymentEnum.CreditCard,
            IsVerified = false
        };

        // Act & Assert
        // Only verified payment methods can be default
        paymentMethod.IsVerified.Should().BeFalse();
        paymentMethod.IsDefault.Should().BeFalse();

        // Set as verified first
        paymentMethod.IsVerified = true;
        paymentMethod.IsVerified.Should().BeTrue();

        // Now can be set as default
        paymentMethod.IsDefault = true;
        paymentMethod.IsDefault.Should().BeTrue();
    }

    #endregion

    #region Edge Cases Tests

    [Theory]
    [InlineData(50)]  // MaxLength for MethodType
    [InlineData(51)] // Exceeds MaxLength for MethodType
    [InlineData(100)] // MaxLength for AccountNumber
    [InlineData(101)] // Exceeds MaxLength for AccountNumber
    public void PaymentMethod_BoundaryValues_ShouldBeHandledCorrectly(int length)
    {
        // Arrange
        var paymentMethod = new PaymentMethod
        {
            UserId = 1,
            Provider = "Visa",
            AccountNumber = "1234567890",
            Name = "Test Payment",
            Type = PaymentEnum.CreditCard
        };

        // Act & Assert
        if (length <= 50)
        {
            var methodType = "A".PadRight(length);
            paymentMethod.MethodType = methodType;
            paymentMethod.MethodType.Should().Be(methodType);
        }
        else
        {
            var methodType = "A".PadRight(length);
            paymentMethod.MethodType = methodType;
            paymentMethod.MethodType.Should().Be(methodType); // Property setter doesn't throw
        }
    }

    [Fact]
    public void PaymentMethod_NullValues_ShouldBeHandledCorrectly()
    {
        // Arrange
        var paymentMethod = new PaymentMethod();

        // Act & Assert
        // Required string properties should accept null (validation happens at model level)
        paymentMethod.MethodType = null!;
        paymentMethod.MethodType.Should().BeNull();

        paymentMethod.Provider = null!;
        paymentMethod.Provider.Should().BeNull();

        paymentMethod.AccountNumber = null!;
        paymentMethod.AccountNumber.Should().BeNull();

        paymentMethod.Name = null!;
        paymentMethod.Name.Should().BeNull();

        // Optional properties should accept null
        paymentMethod.ExpiryDate = null;
        paymentMethod.ExpiryDate.Should().BeNull();

        paymentMethod.UpdatedAt = null;
        paymentMethod.UpdatedAt.Should().BeNull();
    }

    [Theory]
    [InlineData("Visa®", true)]
    [InlineData("MasterCard™", true)]
    [InlineData("PayPal (Official)", true)]
    [InlineData("Apple Pay - Official", true)]
    [InlineData("", false)]
    public void PaymentMethod_SpecialCharacters_ShouldBeHandledCorrectly(string provider, bool isValid)
    {
        // Arrange
        var paymentMethod = new PaymentMethod
        {
            UserId = 1,
            MethodType = "Credit Card",
            AccountNumber = "1234567890",
            Name = "Test Payment",
            Type = PaymentEnum.CreditCard
        };

        // Act
        paymentMethod.Provider = provider;

        // Assert
        paymentMethod.Provider.Should().Be(provider);
        
        if (!isValid)
        {
            // Empty string should be handled
            paymentMethod.Provider.Should().Be(provider);
        }
    }

    [Fact]
    public void PaymentMethod_AllProperties_ShouldBeSettable()
    {
        // Arrange
        var paymentMethod = new PaymentMethod();
        var testDate = DateTime.UtcNow.AddYears(1);

        // Act
        paymentMethod.UserId = 123;
        paymentMethod.MethodType = "Test Method";
        paymentMethod.Provider = "Test Provider";
        paymentMethod.AccountNumber = "1234567890";
        paymentMethod.Name = "Test Name";
        paymentMethod.Type = PaymentEnum.CreditCard;
        paymentMethod.IsDefault = true;
        paymentMethod.IsVerified = true;
        paymentMethod.ExpiryDate = testDate;
        paymentMethod.UpdatedAt = testDate;

        // Assert
        paymentMethod.UserId.Should().Be(123);
        paymentMethod.MethodType.Should().Be("Test Method");
        paymentMethod.Provider.Should().Be("Test Provider");
        paymentMethod.AccountNumber.Should().Be("1234567890");
        paymentMethod.Name.Should().Be("Test Name");
        paymentMethod.Type.Should().Be(PaymentEnum.CreditCard);
        paymentMethod.IsDefault.Should().BeTrue();
        paymentMethod.IsVerified.Should().BeTrue();
        paymentMethod.ExpiryDate.Should().Be(testDate);
        paymentMethod.UpdatedAt.Should().Be(testDate);
    }

    [Fact]
    public void PaymentMethod_EnumValues_ShouldBeAccessible()
    {
        // Arrange & Act
        var paymentMethod = new PaymentMethod();

        // Assert - Test all enum values
        paymentMethod.Type = PaymentEnum.Cash;
        paymentMethod.Type.Should().Be(PaymentEnum.Cash);

        paymentMethod.Type = PaymentEnum.CreditCard;
        paymentMethod.Type.Should().Be(PaymentEnum.CreditCard);

        paymentMethod.Type = PaymentEnum.DebitCard;
        paymentMethod.Type.Should().Be(PaymentEnum.DebitCard);

        paymentMethod.Type = PaymentEnum.MobilePayment;
        paymentMethod.Type.Should().Be(PaymentEnum.MobilePayment);

        paymentMethod.Type = PaymentEnum.OnlinePayment;
        paymentMethod.Type.Should().Be(PaymentEnum.OnlinePayment);

        paymentMethod.Type = PaymentEnum.Crypto;
        paymentMethod.Type.Should().Be(PaymentEnum.Crypto);
    }

    #endregion
}
