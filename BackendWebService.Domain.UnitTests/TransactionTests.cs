using Xunit;
using FluentAssertions;
using Domain;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BackendWebService.Domain.UnitTests;

public class TransactionTests
{
    #region Constructor Tests

    [Fact]
    public void Transaction_Constructor_ShouldSetDefaultValues()
    {
        // Arrange & Act
        var transaction = new Transaction();

        // Assert
        transaction.TransactionDate.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        transaction.UpdatedAt.Should().BeNull();
    }

    #endregion

    #region Property Validation Tests

    [Theory]
    [InlineData(1, true)]
    [InlineData(100, true)]
    [InlineData(0, false)]
    [InlineData(-1, false)]
    public void Transaction_UserId_ShouldValidateCorrectly(int userId, bool isValid)
    {
        // Arrange
        var transaction = new Transaction
        {
            UserId = userId,
            PaymentMethod = PaymentEnum.CreditCard,
            Type = TransactionEnum.Payment,
            Amount = 100.00m,
            Currency = CurrencyEnum.USD,
            Status = StatusEnum.Pending,
            ReferenceNumber = "REF123456"
        };

        // Act
        var validationContext = new ValidationContext(transaction) { MemberName = nameof(Transaction.UserId) };
        var validationResults = new List<ValidationResult>();
        var actualIsValid = Validator.TryValidateProperty(transaction.UserId, validationContext, validationResults);

        // Assert
        actualIsValid.Should().Be(isValid);
        if (!isValid)
        {
            validationResults.Should().NotBeEmpty();
        }
        else
        {
            validationResults.Should().BeEmpty();
        }
    }

    [Theory]
    [InlineData(PaymentEnum.CreditCard, true)]
    [InlineData(PaymentEnum.DebitCard, true)]
    [InlineData(PaymentEnum.Cash, true)]
    [InlineData(PaymentEnum.MobilePayment, true)]
    public void Transaction_PaymentMethod_ShouldValidateCorrectly(PaymentEnum paymentMethod, bool isValid)
    {
        // Arrange
        var transaction = new Transaction
        {
            UserId = 1,
            PaymentMethod = paymentMethod,
            Type = TransactionEnum.Payment,
            Amount = 100.00m,
            Currency = CurrencyEnum.USD,
            Status = StatusEnum.Pending,
            ReferenceNumber = "REF123456"
        };

        // Act
        var validationContext = new ValidationContext(transaction) { MemberName = nameof(Transaction.PaymentMethod) };
        var validationResults = new List<ValidationResult>();
        var actualIsValid = Validator.TryValidateProperty(transaction.PaymentMethod, validationContext, validationResults);

        // Assert
        actualIsValid.Should().Be(isValid);
        if (!isValid)
        {
            validationResults.Should().NotBeEmpty();
        }
        else
        {
            validationResults.Should().BeEmpty();
        }
    }

    [Theory]
    [InlineData(TransactionEnum.Payment, true)]
    [InlineData(TransactionEnum.Refund, true)]
    [InlineData(TransactionEnum.Transfer, true)]
    [InlineData(TransactionEnum.Withdrawal, true)]
    public void Transaction_Type_ShouldValidateCorrectly(TransactionEnum type, bool isValid)
    {
        // Arrange
        var transaction = new Transaction
        {
            UserId = 1,
            PaymentMethod = PaymentEnum.CreditCard,
            Type = type,
            Amount = 100.00m,
            Currency = CurrencyEnum.USD,
            Status = StatusEnum.Pending,
            ReferenceNumber = "REF123456"
        };

        // Act
        var validationContext = new ValidationContext(transaction) { MemberName = nameof(Transaction.Type) };
        var validationResults = new List<ValidationResult>();
        var actualIsValid = Validator.TryValidateProperty(transaction.Type, validationContext, validationResults);

        // Assert
        actualIsValid.Should().Be(isValid);
        if (!isValid)
        {
            validationResults.Should().NotBeEmpty();
        }
        else
        {
            validationResults.Should().BeEmpty();
        }
    }

    [Theory]
    [InlineData(0.01, true)]
    [InlineData(100.00, true)]
    [InlineData(999999.99, true)]
    [InlineData(0.00, false)]
    [InlineData(-1.00, false)]
    public void Transaction_Amount_ShouldValidateCorrectly(decimal amount, bool isValid)
    {
        // Arrange
        var transaction = new Transaction
        {
            UserId = 1,
            PaymentMethod = PaymentEnum.CreditCard,
            Type = TransactionEnum.Payment,
            Amount = amount,
            Currency = CurrencyEnum.USD,
            Status = StatusEnum.Pending,
            ReferenceNumber = "REF123456"
        };

        // Act
        var validationContext = new ValidationContext(transaction) { MemberName = nameof(Transaction.Amount) };
        var validationResults = new List<ValidationResult>();
        var actualIsValid = Validator.TryValidateProperty(transaction.Amount, validationContext, validationResults);

        // Assert
        actualIsValid.Should().Be(isValid);
        if (!isValid)
        {
            validationResults.Should().NotBeEmpty();
        }
        else
        {
            validationResults.Should().BeEmpty();
        }
    }

    [Theory]
    [InlineData(CurrencyEnum.USD, true)]
    [InlineData(CurrencyEnum.EUR, true)]
    [InlineData(CurrencyEnum.GBP, true)]
    [InlineData(CurrencyEnum.JPY, true)]
    public void Transaction_Currency_ShouldValidateCorrectly(CurrencyEnum currency, bool isValid)
    {
        // Arrange
        var transaction = new Transaction
        {
            UserId = 1,
            PaymentMethod = PaymentEnum.CreditCard,
            Type = TransactionEnum.Payment,
            Amount = 100.00m,
            Currency = currency,
            Status = StatusEnum.Pending,
            ReferenceNumber = "REF123456"
        };

        // Act
        var validationContext = new ValidationContext(transaction) { MemberName = nameof(Transaction.Currency) };
        var validationResults = new List<ValidationResult>();
        var actualIsValid = Validator.TryValidateProperty(transaction.Currency, validationContext, validationResults);

        // Assert
        actualIsValid.Should().Be(isValid);
        if (!isValid)
        {
            validationResults.Should().NotBeEmpty();
        }
        else
        {
            validationResults.Should().BeEmpty();
        }
    }

    [Theory]
    [InlineData(StatusEnum.Pending, true)]
    [InlineData(StatusEnum.Completed, true)]
    [InlineData(StatusEnum.Returned, true)]
    [InlineData(StatusEnum.Deleted, true)]
    public void Transaction_Status_ShouldValidateCorrectly(StatusEnum status, bool isValid)
    {
        // Arrange
        var transaction = new Transaction
        {
            UserId = 1,
            PaymentMethod = PaymentEnum.CreditCard,
            Type = TransactionEnum.Payment,
            Amount = 100.00m,
            Currency = CurrencyEnum.USD,
            Status = status,
            ReferenceNumber = "REF123456"
        };

        // Act
        var validationContext = new ValidationContext(transaction) { MemberName = nameof(Transaction.Status) };
        var validationResults = new List<ValidationResult>();
        var actualIsValid = Validator.TryValidateProperty(transaction.Status, validationContext, validationResults);

        // Assert
        actualIsValid.Should().Be(isValid);
        if (!isValid)
        {
            validationResults.Should().NotBeEmpty();
        }
        else
        {
            validationResults.Should().BeEmpty();
        }
    }

    [Theory]
    [InlineData("REF123456", true)]
    [InlineData("TXN789012", true)]
    [InlineData("A", true)] // Minimum length
    [InlineData("", false)]
    [InlineData(null, false)]
    public void Transaction_ReferenceNumber_ShouldValidateCorrectly(string referenceNumber, bool isValid)
    {
        // Arrange
        var transaction = new Transaction
        {
            UserId = 1,
            PaymentMethod = PaymentEnum.CreditCard,
            Type = TransactionEnum.Payment,
            Amount = 100.00m,
            Currency = CurrencyEnum.USD,
            Status = StatusEnum.Pending,
            ReferenceNumber = referenceNumber
        };

        // Act
        var validationContext = new ValidationContext(transaction) { MemberName = nameof(Transaction.ReferenceNumber) };
        var validationResults = new List<ValidationResult>();
        var actualIsValid = Validator.TryValidateProperty(transaction.ReferenceNumber, validationContext, validationResults);

        // Assert
        actualIsValid.Should().Be(isValid);
        if (!isValid)
        {
            validationResults.Should().NotBeEmpty();
        }
        else
        {
            validationResults.Should().BeEmpty();
        }
    }

    [Theory]
    [InlineData("Payment for services", true)]
    [InlineData("", true)] // Optional field
    [InlineData(null, true)] // Optional field
    [InlineData("Very long notes that exceed the maximum length of 500 characters and should still be valid because we're testing the optional nature of this field and not the length validation which would be handled by MaxLength attribute", true)]
    public void Transaction_Notes_ShouldValidateCorrectly(string notes, bool isValid)
    {
        // Arrange
        var transaction = new Transaction
        {
            UserId = 1,
            PaymentMethod = PaymentEnum.CreditCard,
            Type = TransactionEnum.Payment,
            Amount = 100.00m,
            Currency = CurrencyEnum.USD,
            Status = StatusEnum.Pending,
            ReferenceNumber = "REF123456",
            Notes = notes
        };

        // Act
        var validationContext = new ValidationContext(transaction) { MemberName = nameof(Transaction.Notes) };
        var validationResults = new List<ValidationResult>();
        var actualIsValid = Validator.TryValidateProperty(transaction.Notes, validationContext, validationResults);

        // Assert
        actualIsValid.Should().Be(isValid);
        if (!isValid)
        {
            validationResults.Should().NotBeEmpty();
        }
        else
        {
            validationResults.Should().BeEmpty();
        }
    }

    #endregion

    #region Business Logic Tests

    [Fact]
    public void Transaction_TransactionDate_ShouldBeSetOnConstruction()
    {
        // Arrange & Act
        var transaction = new Transaction();

        // Assert
        transaction.TransactionDate.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void Transaction_TransactionDate_ShouldBeSettable()
    {
        // Arrange
        var transaction = new Transaction();
        var customDate = DateTime.UtcNow.AddDays(-1);

        // Act
        transaction.TransactionDate = customDate;

        // Assert
        transaction.TransactionDate.Should().Be(customDate);
    }

    [Fact]
    public void Transaction_UpdatedAt_ShouldBeSettable()
    {
        // Arrange
        var transaction = new Transaction();
        var updateDate = DateTime.UtcNow;

        // Act
        transaction.UpdatedAt = updateDate;

        // Assert
        transaction.UpdatedAt.Should().Be(updateDate);
    }

    [Fact]
    public void Transaction_UpdatedAt_ShouldBeNullable()
    {
        // Arrange
        var transaction = new Transaction();
        transaction.UpdatedAt = DateTime.UtcNow;

        // Act
        transaction.UpdatedAt = null;

        // Assert
        transaction.UpdatedAt.Should().BeNull();
    }

    #endregion

    #region Edge Cases Tests

    [Fact]
    public void Transaction_WithMinimalData_ShouldBeValid()
    {
        // Arrange
        var transaction = new Transaction
        {
            UserId = 1,
            PaymentMethod = PaymentEnum.CreditCard,
            Type = TransactionEnum.Payment,
            Amount = 0.01m,
            Currency = CurrencyEnum.USD,
            Status = StatusEnum.Pending,
            ReferenceNumber = "REF123"
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(transaction, new ValidationContext(transaction), validationResults, true);

        // Assert
        isValid.Should().BeTrue();
        validationResults.Should().BeEmpty();
    }

    [Fact]
    public void Transaction_WithCompleteData_ShouldBeValid()
    {
        // Arrange
        var transaction = new Transaction
        {
            UserId = 1,
            PaymentMethod = PaymentEnum.CreditCard,
            Type = TransactionEnum.Payment,
            Amount = 100.00m,
            Currency = CurrencyEnum.USD,
            Status = StatusEnum.Completed,
            ReferenceNumber = "REF123456",
            Notes = "Payment for services rendered",
            TransactionDate = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(transaction, new ValidationContext(transaction), validationResults, true);

        // Assert
        isValid.Should().BeTrue();
        validationResults.Should().BeEmpty();
    }

    [Fact]
    public void Transaction_WithMaximumAmount_ShouldBeValid()
    {
        // Arrange
        var transaction = new Transaction
        {
            UserId = 1,
            PaymentMethod = PaymentEnum.CreditCard,
            Type = TransactionEnum.Payment,
            Amount = decimal.MaxValue,
            Currency = CurrencyEnum.USD,
            Status = StatusEnum.Pending,
            ReferenceNumber = "REF123456"
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(transaction, new ValidationContext(transaction), validationResults, true);

        // Assert
        isValid.Should().BeTrue();
        validationResults.Should().BeEmpty();
    }

    [Fact]
    public void Transaction_WithMinimumAmount_ShouldBeValid()
    {
        // Arrange
        var transaction = new Transaction
        {
            UserId = 1,
            PaymentMethod = PaymentEnum.CreditCard,
            Type = TransactionEnum.Payment,
            Amount = 0.01m,
            Currency = CurrencyEnum.USD,
            Status = StatusEnum.Pending,
            ReferenceNumber = "REF123456"
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(transaction, new ValidationContext(transaction), validationResults, true);

        // Assert
        isValid.Should().BeTrue();
        validationResults.Should().BeEmpty();
    }

    #endregion

    #region Boundary Values Tests

    [Theory]
    [InlineData(0.01)] // Minimum valid amount
    [InlineData(100.00)] // Normal amount
    [InlineData(999999.99)] // Large amount
    public void Transaction_Amount_ShouldHandleVariousValues(decimal amount)
    {
        // Arrange
        var transaction = new Transaction
        {
            UserId = 1,
            PaymentMethod = PaymentEnum.CreditCard,
            Type = TransactionEnum.Payment,
            Amount = amount,
            Currency = CurrencyEnum.USD,
            Status = StatusEnum.Pending,
            ReferenceNumber = "REF123456"
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(transaction, new ValidationContext(transaction), validationResults, true);

        // Assert
        isValid.Should().BeTrue();
        transaction.Amount.Should().Be(amount);
    }

    [Theory]
    [InlineData("A")] // Minimum length
    [InlineData("REF123456")] // Normal length
    [InlineData("REF1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890")] // Maximum length (100 chars)
    public void Transaction_ReferenceNumber_ShouldHandleVariousLengths(string referenceNumber)
    {
        // Arrange
        var transaction = new Transaction
        {
            UserId = 1,
            PaymentMethod = PaymentEnum.CreditCard,
            Type = TransactionEnum.Payment,
            Amount = 100.00m,
            Currency = CurrencyEnum.USD,
            Status = StatusEnum.Pending,
            ReferenceNumber = referenceNumber
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(transaction, new ValidationContext(transaction), validationResults, true);

        // Assert
        isValid.Should().BeTrue();
        transaction.ReferenceNumber.Should().Be(referenceNumber);
    }

    #endregion

    #region Enum Validation Tests

    [Theory]
    [InlineData(PaymentEnum.CreditCard)]
    [InlineData(PaymentEnum.DebitCard)]
    [InlineData(PaymentEnum.Cash)]
    [InlineData(PaymentEnum.MobilePayment)]
    public void Transaction_PaymentMethod_ShouldAcceptAllValidEnums(PaymentEnum paymentMethod)
    {
        // Arrange
        var transaction = new Transaction
        {
            UserId = 1,
            PaymentMethod = paymentMethod,
            Type = TransactionEnum.Payment,
            Amount = 100.00m,
            Currency = CurrencyEnum.USD,
            Status = StatusEnum.Pending,
            ReferenceNumber = "REF123456"
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(transaction, new ValidationContext(transaction), validationResults, true);

        // Assert
        isValid.Should().BeTrue();
        transaction.PaymentMethod.Should().Be(paymentMethod);
    }

    [Theory]
    [InlineData(TransactionEnum.Payment)]
    [InlineData(TransactionEnum.Refund)]
    [InlineData(TransactionEnum.Transfer)]
    [InlineData(TransactionEnum.Withdrawal)]
    public void Transaction_Type_ShouldAcceptAllValidEnums(TransactionEnum type)
    {
        // Arrange
        var transaction = new Transaction
        {
            UserId = 1,
            PaymentMethod = PaymentEnum.CreditCard,
            Type = type,
            Amount = 100.00m,
            Currency = CurrencyEnum.USD,
            Status = StatusEnum.Pending,
            ReferenceNumber = "REF123456"
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(transaction, new ValidationContext(transaction), validationResults, true);

        // Assert
        isValid.Should().BeTrue();
        transaction.Type.Should().Be(type);
    }

    [Theory]
    [InlineData(CurrencyEnum.USD)]
    [InlineData(CurrencyEnum.EUR)]
    [InlineData(CurrencyEnum.GBP)]
    [InlineData(CurrencyEnum.JPY)]
    public void Transaction_Currency_ShouldAcceptAllValidEnums(CurrencyEnum currency)
    {
        // Arrange
        var transaction = new Transaction
        {
            UserId = 1,
            PaymentMethod = PaymentEnum.CreditCard,
            Type = TransactionEnum.Payment,
            Amount = 100.00m,
            Currency = currency,
            Status = StatusEnum.Pending,
            ReferenceNumber = "REF123456"
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(transaction, new ValidationContext(transaction), validationResults, true);

        // Assert
        isValid.Should().BeTrue();
        transaction.Currency.Should().Be(currency);
    }

    [Theory]
    [InlineData(StatusEnum.Pending)]
    [InlineData(StatusEnum.Completed)]
    [InlineData(StatusEnum.Returned)]
    [InlineData(StatusEnum.Deleted)]
    public void Transaction_Status_ShouldAcceptAllValidEnums(StatusEnum status)
    {
        // Arrange
        var transaction = new Transaction
        {
            UserId = 1,
            PaymentMethod = PaymentEnum.CreditCard,
            Type = TransactionEnum.Payment,
            Amount = 100.00m,
            Currency = CurrencyEnum.USD,
            Status = status,
            ReferenceNumber = "REF123456"
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(transaction, new ValidationContext(transaction), validationResults, true);

        // Assert
        isValid.Should().BeTrue();
        transaction.Status.Should().Be(status);
    }

    #endregion
}
