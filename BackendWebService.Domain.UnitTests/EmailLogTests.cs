using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class EmailLogTests
{
    [Fact]
    public void EmailLog_DefaultConstructor_ShouldCreateInstance()
    {
        // Arrange & Act
        var emailLog = new EmailLog();

        // Assert
        emailLog.Should().NotBeNull();
        emailLog.Subject.Should().BeNull();
        emailLog.Body.Should().BeNull();
        emailLog.SentAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
        emailLog.SenderId.Should().Be(0);
        emailLog.Sender.Should().BeNull();
        emailLog.IsActive.Should().BeTrue();
        emailLog.IsDeleted.Should().BeFalse();
        emailLog.IsSystem.Should().BeFalse();
        emailLog.CreatedDate.Should().NotBeNull();
    }

    [Theory]
    [InlineData("Test Subject")]
    [InlineData("")]
    [InlineData("Very long subject that might exceed normal length expectations")]
    public void EmailLog_Subject_ShouldBeSettable(string subject)
    {
        // Arrange
        var emailLog = new EmailLog();

        // Act
        emailLog.Subject = subject;

        // Assert
        emailLog.Subject.Should().Be(subject);
    }

    [Theory]
    [InlineData("Test Body")]
    [InlineData("")]
    [InlineData("Very long body that might exceed normal length expectations")]
    public void EmailLog_Body_ShouldBeSettable(string body)
    {
        // Arrange
        var emailLog = new EmailLog();

        // Act
        emailLog.Body = body;

        // Assert
        emailLog.Body.Should().Be(body);
    }

    [Fact]
    public void EmailLog_SentAt_ShouldBeSettable()
    {
        // Arrange
        var emailLog = new EmailLog();
        var sentAt = DateTime.UtcNow.AddHours(-1);

        // Act
        emailLog.SentAt = sentAt;

        // Assert
        emailLog.SentAt.Should().Be(sentAt);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MaxValue)]
    public void EmailLog_SenderId_ShouldBeSettable(int senderId)
    {
        // Arrange
        var emailLog = new EmailLog();

        // Act
        emailLog.SenderId = senderId;

        // Assert
        emailLog.SenderId.Should().Be(senderId);
    }

    [Fact]
    public void EmailLog_Sender_ShouldBeSettable()
    {
        // Arrange
        var emailLog = new EmailLog();
        var sender = new User();

        // Act
        emailLog.Sender = sender;

        // Assert
        emailLog.Sender.Should().Be(sender);
    }

    [Fact]
    public void EmailLog_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var emailLog = new EmailLog
        {
            Subject = "Test Subject",
            SenderId = 1
        };

        // Assert
        emailLog.Subject.Should().Be("Test Subject");
        emailLog.SenderId.Should().Be(1);
        emailLog.Body.Should().BeNull();
        emailLog.IsActive.Should().BeTrue();
    }

    [Fact]
    public void EmailLog_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange & Act
        var sender = new User();
        var sentAt = DateTime.UtcNow.AddHours(-2);
        var emailLog = new EmailLog
        {
            Subject = "Test Subject",
            Body = "Test Body",
            SentAt = sentAt,
            SenderId = 1,
            Sender = sender
        };

        // Assert
        emailLog.Subject.Should().Be("Test Subject");
        emailLog.Body.Should().Be("Test Body");
        emailLog.SentAt.Should().Be(sentAt);
        emailLog.SenderId.Should().Be(1);
        emailLog.Sender.Should().Be(sender);
    }

    [Fact]
    public void EmailLog_WithNullSubject_ShouldBeCreatable()
    {
        // Arrange & Act
        var emailLog = new EmailLog
        {
            Subject = null!,
            SenderId = 1
        };

        // Assert
        emailLog.Subject.Should().BeNull();
        emailLog.SenderId.Should().Be(1);
    }

    [Fact]
    public void EmailLog_WithEmptySubject_ShouldBeCreatable()
    {
        // Arrange & Act
        var emailLog = new EmailLog
        {
            Subject = "",
            SenderId = 1
        };

        // Assert
        emailLog.Subject.Should().Be("");
        emailLog.SenderId.Should().Be(1);
    }

    [Fact]
    public void EmailLog_WithZeroSenderId_ShouldBeCreatable()
    {
        // Arrange & Act
        var emailLog = new EmailLog
        {
            Subject = "Test Subject",
            SenderId = 0
        };

        // Assert
        emailLog.Subject.Should().Be("Test Subject");
        emailLog.SenderId.Should().Be(0);
    }

    [Fact]
    public void EmailLog_WithNegativeSenderId_ShouldBeCreatable()
    {
        // Arrange & Act
        var emailLog = new EmailLog
        {
            Subject = "Test Subject",
            SenderId = -1
        };

        // Assert
        emailLog.Subject.Should().Be("Test Subject");
        emailLog.SenderId.Should().Be(-1);
    }

    [Fact]
    public void EmailLog_WithNullSender_ShouldBeCreatable()
    {
        // Arrange & Act
        var emailLog = new EmailLog
        {
            Subject = "Test Subject",
            SenderId = 1,
            Sender = null!
        };

        // Assert
        emailLog.Subject.Should().Be("Test Subject");
        emailLog.SenderId.Should().Be(1);
        emailLog.Sender.Should().BeNull();
    }

    [Fact]
    public void EmailLog_WithNullBody_ShouldBeCreatable()
    {
        // Arrange & Act
        var emailLog = new EmailLog
        {
            Subject = "Test Subject",
            Body = null!,
            SenderId = 1
        };

        // Assert
        emailLog.Subject.Should().Be("Test Subject");
        emailLog.Body.Should().BeNull();
        emailLog.SenderId.Should().Be(1);
    }

    [Fact]
    public void EmailLog_WithEmptyBody_ShouldBeCreatable()
    {
        // Arrange & Act
        var emailLog = new EmailLog
        {
            Subject = "Test Subject",
            Body = "",
            SenderId = 1
        };

        // Assert
        emailLog.Subject.Should().Be("Test Subject");
        emailLog.Body.Should().Be("");
        emailLog.SenderId.Should().Be(1);
    }

    [Fact]
    public void EmailLog_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var emailLog = new EmailLog { Subject = "Test Subject" };

        // Act
        var result = emailLog.ToString();

        // Assert
        result.Should().Contain("EmailLog");
    }

    [Fact]
    public void EmailLog_ShouldInheritFromBaseEntity()
    {
        // Arrange & Act
        var emailLog = new EmailLog();

        // Assert
        emailLog.Should().BeAssignableTo<BaseEntity>();
        emailLog.Should().BeAssignableTo<IEntity>();
        emailLog.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void EmailLog_AllProperties_ShouldBeSettable()
    {
        // Arrange
        var emailLog = new EmailLog();
        var sender = new User();
        var sentAt = DateTime.UtcNow.AddHours(-1);

        // Act
        emailLog.Subject = "Test Subject";
        emailLog.Body = "Test Body";
        emailLog.SentAt = sentAt;
        emailLog.SenderId = 1;
        emailLog.Sender = sender;

        // Assert
        emailLog.Subject.Should().Be("Test Subject");
        emailLog.Body.Should().Be("Test Body");
        emailLog.SentAt.Should().Be(sentAt);
        emailLog.SenderId.Should().Be(1);
        emailLog.Sender.Should().Be(sender);
    }
}
