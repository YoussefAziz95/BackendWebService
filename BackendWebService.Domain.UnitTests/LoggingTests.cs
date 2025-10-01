using Domain;
using Domain.Enums;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class LoggingTests
{
    [Fact]
    public void Logging_DefaultConstructor_ShouldCreateInstance()
    {
        // Arrange & Act
        var logging = new Logging();

        // Assert
        logging.Should().NotBeNull();
        logging.UserId.Should().BeNull();
        logging.Message.Should().BeNull();
        logging.ExceptionCode.Should().BeNull();
        logging.KeyExceptionMessage.Should().BeNull();
        logging.LogType.Should().BeNull();
        logging.Suggestion.Should().BeNull();
        logging.Timestamp.Should().BeNull();
        logging.SourceLayer.Should().BeNull();
        logging.SourceClass.Should().BeNull();
        logging.SourceLineNumber.Should().BeNull();
        logging.CorrelationId.Should().BeNull();
        logging.IsActive.Should().BeTrue();
        logging.IsDeleted.Should().BeFalse();
        logging.IsSystem.Should().BeFalse();
        logging.CreatedDate.Should().NotBeNull();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MaxValue)]
    public void Logging_UserId_ShouldBeSettable(int? userId)
    {
        // Arrange
        var logging = new Logging();

        // Act
        logging.UserId = userId;

        // Assert
        logging.UserId.Should().Be(userId);
    }

    [Theory]
    [InlineData("Test message")]
    [InlineData("")]
    [InlineData("Very long message that might exceed normal length expectations")]
    public void Logging_Message_ShouldBeSettable(string message)
    {
        // Arrange
        var logging = new Logging();

        // Act
        logging.Message = message;

        // Assert
        logging.Message.Should().Be(message);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MaxValue)]
    public void Logging_ExceptionCode_ShouldBeSettable(int? exceptionCode)
    {
        // Arrange
        var logging = new Logging();

        // Act
        logging.ExceptionCode = exceptionCode;

        // Assert
        logging.ExceptionCode.Should().Be(exceptionCode);
    }

    [Theory]
    [InlineData("Key exception message")]
    [InlineData("")]
    [InlineData("Very long key exception message that might exceed normal length expectations")]
    public void Logging_KeyExceptionMessage_ShouldBeSettable(string keyExceptionMessage)
    {
        // Arrange
        var logging = new Logging();

        // Act
        logging.KeyExceptionMessage = keyExceptionMessage;

        // Assert
        logging.KeyExceptionMessage.Should().Be(keyExceptionMessage);
    }

    [Theory]
    [InlineData(LogTypeEnum.Info)]
    [InlineData(LogTypeEnum.Warning)]
    [InlineData(LogTypeEnum.Error)]
    [InlineData(LogTypeEnum.Debug)]
    [InlineData(LogTypeEnum.Critical)]
    public void Logging_LogType_ShouldBeSettable(LogTypeEnum logType)
    {
        // Arrange
        var logging = new Logging();

        // Act
        logging.LogType = logType;

        // Assert
        logging.LogType.Should().Be(logType);
    }

    [Theory]
    [InlineData("Suggestion message")]
    [InlineData("")]
    [InlineData("Very long suggestion message that might exceed normal length expectations")]
    public void Logging_Suggestion_ShouldBeSettable(string suggestion)
    {
        // Arrange
        var logging = new Logging();

        // Act
        logging.Suggestion = suggestion;

        // Assert
        logging.Suggestion.Should().Be(suggestion);
    }

    [Fact]
    public void Logging_Timestamp_ShouldBeSettable()
    {
        // Arrange
        var logging = new Logging();
        var timestamp = DateTime.UtcNow;

        // Act
        logging.Timestamp = timestamp;

        // Assert
        logging.Timestamp.Should().Be(timestamp);
    }

    [Theory]
    [InlineData("Presentation Layer")]
    [InlineData("Business Layer")]
    [InlineData("Data Layer")]
    [InlineData("")]
    public void Logging_SourceLayer_ShouldBeSettable(string sourceLayer)
    {
        // Arrange
        var logging = new Logging();

        // Act
        logging.SourceLayer = sourceLayer;

        // Assert
        logging.SourceLayer.Should().Be(sourceLayer);
    }

    [Theory]
    [InlineData("UserService")]
    [InlineData("OrderController")]
    [InlineData("PaymentProcessor")]
    [InlineData("")]
    public void Logging_SourceClass_ShouldBeSettable(string sourceClass)
    {
        // Arrange
        var logging = new Logging();

        // Act
        logging.SourceClass = sourceClass;

        // Assert
        logging.SourceClass.Should().Be(sourceClass);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MaxValue)]
    public void Logging_SourceLineNumber_ShouldBeSettable(int? sourceLineNumber)
    {
        // Arrange
        var logging = new Logging();

        // Act
        logging.SourceLineNumber = sourceLineNumber;

        // Assert
        logging.SourceLineNumber.Should().Be(sourceLineNumber);
    }

    [Theory]
    [InlineData("correlation-123")]
    [InlineData("")]
    [InlineData("very-long-correlation-id-that-might-exceed-normal-length-expectations")]
    public void Logging_CorrelationId_ShouldBeSettable(string correlationId)
    {
        // Arrange
        var logging = new Logging();

        // Act
        logging.CorrelationId = correlationId;

        // Assert
        logging.CorrelationId.Should().Be(correlationId);
    }

    [Fact]
    public void Logging_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var logging = new Logging
        {
            Message = "Test message",
            LogType = LogTypeEnum.Info
        };

        // Assert
        logging.Message.Should().Be("Test message");
        logging.LogType.Should().Be(LogTypeEnum.Info);
        logging.IsActive.Should().BeTrue();
    }

    [Fact]
    public void Logging_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange & Act
        var timestamp = DateTime.UtcNow;
        var logging = new Logging
        {
            UserId = 1,
            Message = "Test message",
            ExceptionCode = 500,
            KeyExceptionMessage = "Key exception",
            LogType = LogTypeEnum.Error,
            Suggestion = "Fix the issue",
            Timestamp = timestamp,
            SourceLayer = "Business Layer",
            SourceClass = "UserService",
            SourceLineNumber = 42,
            CorrelationId = "correlation-123"
        };

        // Assert
        logging.UserId.Should().Be(1);
        logging.Message.Should().Be("Test message");
        logging.ExceptionCode.Should().Be(500);
        logging.KeyExceptionMessage.Should().Be("Key exception");
        logging.LogType.Should().Be(LogTypeEnum.Error);
        logging.Suggestion.Should().Be("Fix the issue");
        logging.Timestamp.Should().Be(timestamp);
        logging.SourceLayer.Should().Be("Business Layer");
        logging.SourceClass.Should().Be("UserService");
        logging.SourceLineNumber.Should().Be(42);
        logging.CorrelationId.Should().Be("correlation-123");
    }

    [Fact]
    public void Logging_WithNullValues_ShouldBeCreatable()
    {
        // Arrange & Act
        var logging = new Logging
        {
            UserId = null!,
            Message = null!,
            ExceptionCode = null!,
            KeyExceptionMessage = null!,
            LogType = null!,
            Suggestion = null!,
            Timestamp = null!,
            SourceLayer = null!,
            SourceClass = null!,
            SourceLineNumber = null!,
            CorrelationId = null
        };

        // Assert
        logging.UserId.Should().BeNull();
        logging.Message.Should().BeNull();
        logging.ExceptionCode.Should().BeNull();
        logging.KeyExceptionMessage.Should().BeNull();
        logging.LogType.Should().BeNull();
        logging.Suggestion.Should().BeNull();
        logging.Timestamp.Should().BeNull();
        logging.SourceLayer.Should().BeNull();
        logging.SourceClass.Should().BeNull();
        logging.SourceLineNumber.Should().BeNull();
        logging.CorrelationId.Should().BeNull();
    }

    [Fact]
    public void Logging_WithEmptyStrings_ShouldBeCreatable()
    {
        // Arrange & Act
        var logging = new Logging
        {
            Message = "",
            KeyExceptionMessage = "",
            Suggestion = "",
            SourceLayer = "",
            SourceClass = "",
            CorrelationId = ""
        };

        // Assert
        logging.Message.Should().Be("");
        logging.KeyExceptionMessage.Should().Be("");
        logging.Suggestion.Should().Be("");
        logging.SourceLayer.Should().Be("");
        logging.SourceClass.Should().Be("");
        logging.CorrelationId.Should().Be("");
    }

    [Fact]
    public void Logging_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var logging = new Logging { Message = "Test message" };

        // Act
        var result = logging.ToString();

        // Assert
        result.Should().Contain("Logging");
    }

    [Fact]
    public void Logging_ShouldInheritFromBaseEntity()
    {
        // Arrange & Act
        var logging = new Logging();

        // Assert
        logging.Should().BeAssignableTo<BaseEntity>();
        logging.Should().BeAssignableTo<IEntity>();
        logging.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void Logging_AllProperties_ShouldBeSettable()
    {
        // Arrange
        var logging = new Logging();
        var timestamp = DateTime.UtcNow;

        // Act
        logging.UserId = 1;
        logging.Message = "Test message";
        logging.ExceptionCode = 500;
        logging.KeyExceptionMessage = "Key exception";
        logging.LogType = LogTypeEnum.Error;
        logging.Suggestion = "Fix the issue";
        logging.Timestamp = timestamp;
        logging.SourceLayer = "Business Layer";
        logging.SourceClass = "UserService";
        logging.SourceLineNumber = 42;
        logging.CorrelationId = "correlation-123";

        // Assert
        logging.UserId.Should().Be(1);
        logging.Message.Should().Be("Test message");
        logging.ExceptionCode.Should().Be(500);
        logging.KeyExceptionMessage.Should().Be("Key exception");
        logging.LogType.Should().Be(LogTypeEnum.Error);
        logging.Suggestion.Should().Be("Fix the issue");
        logging.Timestamp.Should().Be(timestamp);
        logging.SourceLayer.Should().Be("Business Layer");
        logging.SourceClass.Should().Be("UserService");
        logging.SourceLineNumber.Should().Be(42);
        logging.CorrelationId.Should().Be("correlation-123");
    }
}
