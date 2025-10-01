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

    #region Property Setting Tests

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    public void Transaction_UserId_ShouldBeSettable(int userId)
    {
        // Arrange
        var transaction = new Transaction();

        // Act
        transaction.UserId = userId;

        // Assert
        transaction.UserId.Should().Be(userId);
    }

    [Theory]
    [InlineData(PaymentEnum.CreditCard)]
    [InlineData(PaymentEnum.DebitCard)]
    [InlineData(PaymentEnum.Cash)]
    [InlineData(PaymentEnum.MobilePayment)]
    public void Transaction_PaymentMethod_ShouldBeSettable(PaymentEnum paymentMethod)
    {
        // Arrange
        var transaction = new Transaction();

        // Act
        transaction.PaymentMethod = paymentMethod;

        // Assert
        transaction.PaymentMethod.Should().Be(paymentMethod);
    }

    [Theory]
    [InlineData(TransactionEnum.Payment)]
    [InlineData(TransactionEnum.Refund)]
    [InlineData(TransactionEnum.Transfer)]
    [InlineData(TransactionEnum.Withdrawal)]
    public void Transaction_Type_ShouldBeSettable(TransactionEnum type)
    {
        // Arrange
        var transaction = new Transaction();

        // Act
        transaction.Type = type;

        // Assert
        transaction.Type.Should().Be(type);
    }

    [Theory]
    [InlineData(0.01)]
    [InlineData(100.00)]
    [InlineData(999999.99)]
    [InlineData(0.00)]
    [InlineData(-1.00)]
    public void Transaction_Amount_ShouldBeSettable(decimal amount)
    {
        // Arrange
        var transaction = new Transaction();

        // Act
        transaction.Amount = amount;

        // Assert
        transaction.Amount.Should().Be(amount);
    }

    [Theory]
    [InlineData(CurrencyEnum.USD)]
    [InlineData(CurrencyEnum.EUR)]
    [InlineData(CurrencyEnum.GBP)]
    [InlineData(CurrencyEnum.JPY)]
    public void Transaction_Currency_ShouldBeSettable(CurrencyEnum currency)
    {
        // Arrange
        var transaction = new Transaction();

        // Act
        transaction.Currency = currency;

        // Assert
        transaction.Currency.Should().Be(currency);
    }

    [Theory]
    [InlineData(StatusEnum.Pending)]
    [InlineData(StatusEnum.Completed)]
    [InlineData(StatusEnum.Returned)]
    [InlineData(StatusEnum.Deleted)]
    public void Transaction_Status_ShouldBeSettable(StatusEnum status)
    {
        // Arrange
        var transaction = new Transaction();

        // Act
        transaction.Status = status;

        // Assert
        transaction.Status.Should().Be(status);
    }

    [Theory]
    [InlineData("REF123456")]
    [InlineData("TXN789012")]
    [InlineData("A")] // Minimum length
    [InlineData("")]
    [InlineData(null)]
    public void Transaction_ReferenceNumber_ShouldBeSettable(string referenceNumber)
    {
        // Arrange
        var transaction = new Transaction();

        // Act
        transaction.ReferenceNumber = referenceNumber;

        // Assert
        transaction.ReferenceNumber.Should().Be(referenceNumber);
    }

    [Theory]
    [InlineData("Payment for services")]
    [InlineData("")] // Optional field
    [InlineData(null)] // Optional field
    [InlineData("Very long notes that exceed the maximum length of 500 characters and should still be valid because we're testing the optional nature of this field and not the length validation which would be handled by MaxLength attribute")]
    public void Transaction_Notes_ShouldBeSettable(string notes)
    {
        // Arrange
        var transaction = new Transaction();

        // Act
        transaction.Notes = notes;

        // Assert
        transaction.Notes.Should().Be(notes);
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
    public void Transaction_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
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

        // Assert
        transaction.UserId.Should().Be(1);
        transaction.PaymentMethod.Should().Be(PaymentEnum.CreditCard);
        transaction.Type.Should().Be(TransactionEnum.Payment);
        transaction.Amount.Should().Be(0.01m);
        transaction.Currency.Should().Be(CurrencyEnum.USD);
        transaction.Status.Should().Be(StatusEnum.Pending);
        transaction.ReferenceNumber.Should().Be("REF123");
    }

    [Fact]
    public void Transaction_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange & Act
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

        // Assert
        transaction.UserId.Should().Be(1);
        transaction.PaymentMethod.Should().Be(PaymentEnum.CreditCard);
        transaction.Type.Should().Be(TransactionEnum.Payment);
        transaction.Amount.Should().Be(100.00m);
        transaction.Currency.Should().Be(CurrencyEnum.USD);
        transaction.Status.Should().Be(StatusEnum.Completed);
        transaction.ReferenceNumber.Should().Be("REF123456");
        transaction.Notes.Should().Be("Payment for services rendered");
        transaction.TransactionDate.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        transaction.UpdatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void Transaction_WithMaximumAmount_ShouldBeCreatable()
    {
        // Arrange & Act
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

        // Assert
        transaction.Amount.Should().Be(decimal.MaxValue);
    }

    [Fact]
    public void Transaction_WithMinimumAmount_ShouldBeCreatable()
    {
        // Arrange & Act
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

        // Assert
        transaction.Amount.Should().Be(0.01m);
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
        var transaction = new Transaction();

        // Act
        transaction.ReferenceNumber = referenceNumber;

        // Assert
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
