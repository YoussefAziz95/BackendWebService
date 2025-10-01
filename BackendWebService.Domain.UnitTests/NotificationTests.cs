using Domain;
using Domain.Enums;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class NotificationTests
{
    [Fact]
    public void Notification_DefaultConstructor_ShouldCreateInstance()
    {
        // Arrange & Act
        var notification = new Notification();

        // Assert
        notification.Should().NotBeNull();
        notification.KeyMessageTitle.Should().BeNull();
        notification.KeyMessageBody.Should().BeNull();
        notification.Priority.Should().Be((NotificationPriorityEnum)0);
        notification.TimeStamp.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
        notification.ExpiryDate.Should().Be(default(DateTime));
        notification.NotifierId.Should().Be(0);
        notification.NotifiedId.Should().Be(0);
        notification.NotifiedType.Should().BeNull();
        notification.NotificationTypeId.Should().BeNull();
        notification.NotificationType.Should().BeNull();
        notification.NotificationObjectId.Should().BeNull();
        notification.NotificationObjectType.Should().BeNull();
        notification.Details.Should().BeNull();
        notification.IsActive.Should().BeTrue();
        notification.IsDeleted.Should().BeFalse();
        notification.IsSystem.Should().BeFalse();
        notification.CreatedDate.Should().NotBeNull();
    }

    [Theory]
    [InlineData("Test Title")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("Very long title that might exceed normal length expectations")]
    public void Notification_KeyMessageTitle_ShouldBeSettable(string keyMessageTitle)
    {
        // Arrange
        var notification = new Notification();

        // Act
        notification.KeyMessageTitle = keyMessageTitle;

        // Assert
        notification.KeyMessageTitle.Should().Be(keyMessageTitle);
    }

    [Theory]
    [InlineData("Test Body")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("Very long body that might exceed normal length expectations")]
    public void Notification_KeyMessageBody_ShouldBeSettable(string keyMessageBody)
    {
        // Arrange
        var notification = new Notification();

        // Act
        notification.KeyMessageBody = keyMessageBody;

        // Assert
        notification.KeyMessageBody.Should().Be(keyMessageBody);
    }

    [Theory]
    [InlineData(NotificationPriorityEnum.Low)]
    [InlineData(NotificationPriorityEnum.Medium)]
    [InlineData(NotificationPriorityEnum.High)]
    [InlineData(NotificationPriorityEnum.Critical)]
    public void Notification_Priority_ShouldBeSettable(NotificationPriorityEnum priority)
    {
        // Arrange
        var notification = new Notification();

        // Act
        notification.Priority = priority;

        // Assert
        notification.Priority.Should().Be(priority);
    }

    [Fact]
    public void Notification_TimeStamp_ShouldBeSettable()
    {
        // Arrange
        var notification = new Notification();
        var timeStamp = DateTime.UtcNow.AddHours(-1);

        // Act
        notification.TimeStamp = timeStamp;

        // Assert
        notification.TimeStamp.Should().Be(timeStamp);
    }

    [Fact]
    public void Notification_ExpiryDate_ShouldBeSettable()
    {
        // Arrange
        var notification = new Notification();
        var expiryDate = DateTime.UtcNow.AddDays(7);

        // Act
        notification.ExpiryDate = expiryDate;

        // Assert
        notification.ExpiryDate.Should().Be(expiryDate);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MaxValue)]
    public void Notification_NotifierId_ShouldBeSettable(int notifierId)
    {
        // Arrange
        var notification = new Notification();

        // Act
        notification.NotifierId = notifierId;

        // Assert
        notification.NotifierId.Should().Be(notifierId);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MaxValue)]
    public void Notification_NotifiedId_ShouldBeSettable(int notifiedId)
    {
        // Arrange
        var notification = new Notification();

        // Act
        notification.NotifiedId = notifiedId;

        // Assert
        notification.NotifiedId.Should().Be(notifiedId);
    }

    [Theory]
    [InlineData("User")]
    [InlineData("Admin")]
    [InlineData("System")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("VeryLongNotifiedTypeThatMightExceedNormalLengthExpectations")]
    public void Notification_NotifiedType_ShouldBeSettable(string notifiedType)
    {
        // Arrange
        var notification = new Notification();

        // Act
        notification.NotifiedType = notifiedType;

        // Assert
        notification.NotifiedType.Should().Be(notifiedType);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MaxValue)]
    public void Notification_NotificationTypeId_ShouldBeSettable(int? notificationTypeId)
    {
        // Arrange
        var notification = new Notification();

        // Act
        notification.NotificationTypeId = notificationTypeId;

        // Assert
        notification.NotificationTypeId.Should().Be(notificationTypeId);
    }

    [Theory]
    [InlineData("Email")]
    [InlineData("SMS")]
    [InlineData("Push")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("VeryLongNotificationTypeThatMightExceedNormalLengthExpectations")]
    public void Notification_NotificationType_ShouldBeSettable(string notificationType)
    {
        // Arrange
        var notification = new Notification();

        // Act
        notification.NotificationType = notificationType;

        // Assert
        notification.NotificationType.Should().Be(notificationType);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MaxValue)]
    public void Notification_NotificationObjectId_ShouldBeSettable(int? notificationObjectId)
    {
        // Arrange
        var notification = new Notification();

        // Act
        notification.NotificationObjectId = notificationObjectId;

        // Assert
        notification.NotificationObjectId.Should().Be(notificationObjectId);
    }

    [Theory]
    [InlineData("Order")]
    [InlineData("Product")]
    [InlineData("User")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("VeryLongNotificationObjectTypeThatMightExceedNormalLengthExpectations")]
    public void Notification_NotificationObjectType_ShouldBeSettable(string notificationObjectType)
    {
        // Arrange
        var notification = new Notification();

        // Act
        notification.NotificationObjectType = notificationObjectType;

        // Assert
        notification.NotificationObjectType.Should().Be(notificationObjectType);
    }

    [Fact]
    public void Notification_Details_ShouldBeSettable()
    {
        // Arrange
        var notification = new Notification();
        var detail = new NotificationDetail();

        // Act
        notification.Details = new List<NotificationDetail> { detail };

        // Assert
        notification.Details.Should().NotBeNull();
        notification.Details.Should().Contain(detail);
    }

    [Fact]
    public void Notification_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var notification = new Notification
        {
            KeyMessageTitle = "Test Title",
            Priority = NotificationPriorityEnum.Medium,
            NotifiedType = "User"
        };

        // Assert
        notification.KeyMessageTitle.Should().Be("Test Title");
        notification.Priority.Should().Be(NotificationPriorityEnum.Medium);
        notification.NotifiedType.Should().Be("User");
        notification.IsActive.Should().BeTrue();
    }

    [Fact]
    public void Notification_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange & Act
        var timeStamp = DateTime.UtcNow.AddHours(-1);
        var expiryDate = DateTime.UtcNow.AddDays(7);
        var detail = new NotificationDetail();
        var notification = new Notification
        {
            KeyMessageTitle = "Test Title",
            KeyMessageBody = "Test Body",
            Priority = NotificationPriorityEnum.High,
            TimeStamp = timeStamp,
            ExpiryDate = expiryDate,
            NotifierId = 1,
            NotifiedId = 2,
            NotifiedType = "User",
            NotificationTypeId = 1,
            NotificationType = "Email",
            NotificationObjectId = 1,
            NotificationObjectType = "Order",
            Details = new List<NotificationDetail> { detail }
        };

        // Assert
        notification.KeyMessageTitle.Should().Be("Test Title");
        notification.KeyMessageBody.Should().Be("Test Body");
        notification.Priority.Should().Be(NotificationPriorityEnum.High);
        notification.TimeStamp.Should().Be(timeStamp);
        notification.ExpiryDate.Should().Be(expiryDate);
        notification.NotifierId.Should().Be(1);
        notification.NotifiedId.Should().Be(2);
        notification.NotifiedType.Should().Be("User");
        notification.NotificationTypeId.Should().Be(1);
        notification.NotificationType.Should().Be("Email");
        notification.NotificationObjectId.Should().Be(1);
        notification.NotificationObjectType.Should().Be("Order");
        notification.Details.Should().Contain(detail);
    }

    [Fact]
    public void Notification_WithNullValues_ShouldBeCreatable()
    {
        // Arrange & Act
        var notification = new Notification
        {
            KeyMessageTitle = null,
            KeyMessageBody = null,
            NotifiedType = null,
            NotificationTypeId = null,
            NotificationType = null,
            NotificationObjectId = null,
            NotificationObjectType = null,
            Details = null
        };

        // Assert
        notification.KeyMessageTitle.Should().BeNull();
        notification.KeyMessageBody.Should().BeNull();
        notification.NotifiedType.Should().BeNull();
        notification.NotificationTypeId.Should().BeNull();
        notification.NotificationType.Should().BeNull();
        notification.NotificationObjectId.Should().BeNull();
        notification.NotificationObjectType.Should().BeNull();
        notification.Details.Should().BeNull();
    }

    [Fact]
    public void Notification_WithEmptyStrings_ShouldBeCreatable()
    {
        // Arrange & Act
        var notification = new Notification
        {
            KeyMessageTitle = "",
            KeyMessageBody = "",
            NotifiedType = "",
            NotificationType = "",
            NotificationObjectType = ""
        };

        // Assert
        notification.KeyMessageTitle.Should().Be("");
        notification.KeyMessageBody.Should().Be("");
        notification.NotifiedType.Should().Be("");
        notification.NotificationType.Should().Be("");
        notification.NotificationObjectType.Should().Be("");
    }

    [Fact]
    public void Notification_WithDefaultEnumValue_ShouldBeCreatable()
    {
        // Arrange & Act
        var notification = new Notification
        {
            KeyMessageTitle = "Test Title",
            Priority = (NotificationPriorityEnum)0,
            NotifiedType = "User"
        };

        // Assert
        notification.KeyMessageTitle.Should().Be("Test Title");
        notification.Priority.Should().Be((NotificationPriorityEnum)0);
        notification.NotifiedType.Should().Be("User");
    }

    [Fact]
    public void Notification_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var notification = new Notification { KeyMessageTitle = "Test Title" };

        // Act
        var result = notification.ToString();

        // Assert
        result.Should().Contain("Notification");
    }

    [Fact]
    public void Notification_ShouldInheritFromBaseEntity()
    {
        // Arrange & Act
        var notification = new Notification();

        // Assert
        notification.Should().BeAssignableTo<BaseEntity>();
        notification.Should().BeAssignableTo<IEntity>();
        notification.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void Notification_AllProperties_ShouldBeSettable()
    {
        // Arrange
        var notification = new Notification();
        var timeStamp = DateTime.UtcNow.AddHours(-1);
        var expiryDate = DateTime.UtcNow.AddDays(7);
        var detail = new NotificationDetail();

        // Act
        notification.KeyMessageTitle = "Test Title";
        notification.KeyMessageBody = "Test Body";
        notification.Priority = NotificationPriorityEnum.High;
        notification.TimeStamp = timeStamp;
        notification.ExpiryDate = expiryDate;
        notification.NotifierId = 1;
        notification.NotifiedId = 2;
        notification.NotifiedType = "User";
        notification.NotificationTypeId = 1;
        notification.NotificationType = "Email";
        notification.NotificationObjectId = 1;
        notification.NotificationObjectType = "Order";
        notification.Details = new List<NotificationDetail> { detail };

        // Assert
        notification.KeyMessageTitle.Should().Be("Test Title");
        notification.KeyMessageBody.Should().Be("Test Body");
        notification.Priority.Should().Be(NotificationPriorityEnum.High);
        notification.TimeStamp.Should().Be(timeStamp);
        notification.ExpiryDate.Should().Be(expiryDate);
        notification.NotifierId.Should().Be(1);
        notification.NotifiedId.Should().Be(2);
        notification.NotifiedType.Should().Be("User");
        notification.NotificationTypeId.Should().Be(1);
        notification.NotificationType.Should().Be("Email");
        notification.NotificationObjectId.Should().Be(1);
        notification.NotificationObjectType.Should().Be("Order");
        notification.Details.Should().Contain(detail);
    }
}
