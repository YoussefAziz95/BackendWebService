using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using BackendWebService.IntegrationTests.Base;
using BackendWebService.IntegrationTests.Infrastructure;
using FluentAssertions;
using Application.Contracts.HubServices;
using Application.Contracts.Proxy;
using Application.Features;
using CrossCuttingConcerns.ConfigHubs;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BackendWebService.IntegrationTests.ExternalServices;

/// <summary>
/// Integration tests for SignalR hub interactions
/// </summary>
public class SignalRIntegrationTests : BaseIntegrationTest
{
    private readonly INotificationService _notificationService;
    private readonly IHubContext<NotificationHub> _hubContext;

    public SignalRIntegrationTests(IntegrationTestWebApplicationFactory factory) 
        : base(factory)
    {
        _notificationService = ServiceProvider.GetRequiredService<INotificationService>();
        _hubContext = ServiceProvider.GetRequiredService<IHubContext<NotificationHub>>();
    }

    [Fact]
    public async Task SignalR_ShouldConnectToHub()
    {
        // Arrange
        var connection = new HubConnectionBuilder()
            .WithUrl("http://localhost/NotificationHub")
            .Build();

        // Act & Assert
        var action = async () => await connection.StartAsync();
        await action.Should().NotThrowAsync("SignalR connection should be established");
        
        // Cleanup
        await connection.DisposeAsync();
    }

    [Fact]
    public async Task SignalR_ShouldSendNotificationMessage()
    {
        // Arrange
        var notificationRequest = new AddNotificationRequest(
            KeyMessageTitle: "Test Notification",
            KeyMessageBody: "This is a test notification message",
            Priority: Domain.Enums.NotificationPriorityEnum.Medium,
            ExpiryDate: DateTime.UtcNow.AddDays(7),
            NotifierId: 1,
            NotifiedId: 1,
            NotifiedType: "User",
            NotificationTypeId: 1,
            NotificationType: "Info",
            NotificationObjectId: null,
            NotificationObjectType: null,
            Details: new List<AddNotificationDetailRequest>()
        );

        // Act
        var result = await _notificationService.SendMessageAsync(notificationRequest);

        // Assert
        result.Should().BeTrue("Notification should be sent successfully");
    }

    [Fact]
    public async Task SignalR_ShouldHandleMultipleNotifications()
    {
        // Arrange
        var notifications = new List<AddNotificationRequest>
        {
            new AddNotificationRequest(
                KeyMessageTitle: "Notification 1",
                KeyMessageBody: "First notification message",
                Priority: Domain.Enums.NotificationPriorityEnum.Medium,
                ExpiryDate: DateTime.UtcNow.AddDays(7),
                NotifierId: 1,
                NotifiedId: 1,
                NotifiedType: "User",
                NotificationTypeId: 1,
                NotificationType: "Info",
                NotificationObjectId: null,
                NotificationObjectType: null,
                Details: new List<AddNotificationDetailRequest>()
            ),
            new AddNotificationRequest(
                KeyMessageTitle: "Notification 2",
                KeyMessageBody: "Second notification message",
                Priority: Domain.Enums.NotificationPriorityEnum.High,
                ExpiryDate: DateTime.UtcNow.AddDays(7),
                NotifierId: 2,
                NotifiedId: 2,
                NotifiedType: "User",
                NotificationTypeId: 2,
                NotificationType: "Warning",
                NotificationObjectId: null,
                NotificationObjectType: null,
                Details: new List<AddNotificationDetailRequest>()
            ),
            new AddNotificationRequest(
                KeyMessageTitle: "Notification 3",
                KeyMessageBody: "Third notification message",
                Priority: Domain.Enums.NotificationPriorityEnum.Critical,
                ExpiryDate: DateTime.UtcNow.AddDays(7),
                NotifierId: 3,
                NotifiedId: 3,
                NotifiedType: "User",
                NotificationTypeId: 3,
                NotificationType: "Error",
                NotificationObjectId: null,
                NotificationObjectType: null,
                Details: new List<AddNotificationDetailRequest>()
            )
        };

        // Act
        var results = new List<bool>();
        foreach (var notification in notifications)
        {
            var result = await _notificationService.SendMessageAsync(notification);
            results.Add(result);
        }

        // Assert
        results.Should().AllSatisfy(r => r.Should().BeTrue("All notifications should be sent successfully"));
    }

    [Fact]
    public async Task SignalR_ShouldHandleConcurrentNotifications()
    {
        // Arrange
        var notificationTasks = new List<Task<bool>>();
        var notificationCount = 10;

        for (int i = 0; i < notificationCount; i++)
        {
            var notification = new AddNotificationRequest(
                KeyMessageTitle: $"Concurrent Notification {i}",
                KeyMessageBody: $"This is concurrent notification {i}",
                Priority: Domain.Enums.NotificationPriorityEnum.Medium,
                ExpiryDate: DateTime.UtcNow.AddDays(7),
                NotifierId: i + 1,
                NotifiedId: i + 1,
                NotifiedType: "User",
                NotificationTypeId: 1,
                NotificationType: "Info",
                NotificationObjectId: null,
                NotificationObjectType: null,
                Details: new List<AddNotificationDetailRequest>()
            );

            notificationTasks.Add(_notificationService.SendMessageAsync(notification));
        }

        // Act
        var results = await Task.WhenAll(notificationTasks);

        // Assert
        results.Should().HaveCount(notificationCount, "All concurrent notifications should complete");
        results.Should().AllSatisfy(r => r.Should().BeTrue("All concurrent notifications should succeed"));
    }

    [Fact]
    public async Task SignalR_ShouldHandleEmptyNotificationMessage()
    {
        // Arrange
        var notificationRequest = new AddNotificationRequest(
            KeyMessageTitle: "",
            KeyMessageBody: "",
            Priority: Domain.Enums.NotificationPriorityEnum.Low,
            ExpiryDate: DateTime.UtcNow.AddDays(1),
            NotifierId: 1,
            NotifiedId: 1,
            NotifiedType: "User",
            NotificationTypeId: 1,
            NotificationType: "Info",
            NotificationObjectId: null,
            NotificationObjectType: null,
            Details: new List<AddNotificationDetailRequest>()
        );

        // Act
        var result = await _notificationService.SendMessageAsync(notificationRequest);

        // Assert
        result.Should().BeTrue("Empty notification should be handled gracefully");
    }

    [Fact]
    public async Task SignalR_ShouldHandleLongNotificationMessage()
    {
        // Arrange
        var longMessage = new string('A', 1000); // 1KB message
        var notificationRequest = new AddNotificationRequest(
            KeyMessageTitle: "Long Message Notification",
            KeyMessageBody: longMessage,
            Priority: Domain.Enums.NotificationPriorityEnum.Medium,
            ExpiryDate: DateTime.UtcNow.AddDays(7),
            NotifierId: 1,
            NotifiedId: 1,
            NotifiedType: "User",
            NotificationTypeId: 1,
            NotificationType: "Info",
            NotificationObjectId: null,
            NotificationObjectType: null,
            Details: new List<AddNotificationDetailRequest>()
        );

        // Act
        var result = await _notificationService.SendMessageAsync(notificationRequest);

        // Assert
        result.Should().BeTrue("Long notification message should be handled");
    }

    [Fact]
    public async Task SignalR_ShouldHandleSpecialCharactersInNotification()
    {
        // Arrange
        var notificationRequest = new AddNotificationRequest(
            KeyMessageTitle: "Special Characters: !@#$%^&*()",
            KeyMessageBody: "This notification contains special characters: àáâãäåæçèéêë",
            Priority: Domain.Enums.NotificationPriorityEnum.Medium,
            ExpiryDate: DateTime.UtcNow.AddDays(7),
            NotifierId: 1,
            NotifiedId: 1,
            NotifiedType: "User",
            NotificationTypeId: 1,
            NotificationType: "Info",
            NotificationObjectId: null,
            NotificationObjectType: null,
            Details: new List<AddNotificationDetailRequest>()
        );

        // Act
        var result = await _notificationService.SendMessageAsync(notificationRequest);

        // Assert
        result.Should().BeTrue("Special characters should be handled in notifications");
    }

    [Fact]
    public async Task SignalR_ShouldHandleDifferentNotificationTypes()
    {
        // Arrange
        var notificationTypes = new[] { "Info", "Warning", "Error", "Success" };
        var results = new List<bool>();

        // Act
        foreach (var type in notificationTypes)
        {
            var notification = new AddNotificationRequest(
                KeyMessageTitle: $"{type} Notification",
                KeyMessageBody: $"This is a {type.ToLower()} notification",
                Priority: Domain.Enums.NotificationPriorityEnum.Medium,
                ExpiryDate: DateTime.UtcNow.AddDays(7),
                NotifierId: 1,
                NotifiedId: 1,
                NotifiedType: "User",
                NotificationTypeId: 1,
                NotificationType: type,
                NotificationObjectId: null,
                NotificationObjectType: null,
                Details: new List<AddNotificationDetailRequest>()
            );

            var result = await _notificationService.SendMessageAsync(notification);
            results.Add(result);
        }

        // Assert
        results.Should().AllSatisfy(r => r.Should().BeTrue("All notification types should be handled"));
    }

    [Fact]
    public async Task SignalR_ShouldHandleHubContextInjection()
    {
        // Arrange & Act
        var hubContext = ServiceProvider.GetRequiredService<IHubContext<NotificationHub>>();

        // Assert
        hubContext.Should().NotBeNull("Hub context should be properly injected");
    }

    [Fact]
    public async Task SignalR_ShouldHandleNotificationProxy()
    {
        // Arrange
        var notificationProxy = ServiceProvider.GetRequiredService<INotificationProxy<NotificationHubResponse>>();

        // Act & Assert
        notificationProxy.Should().NotBeNull("Notification proxy should be available");
    }

    [Fact]
    public async Task SignalR_ShouldHandleJsonSerialization()
    {
        // Arrange
        var notificationRequest = new AddNotificationRequest(
            KeyMessageTitle: "JSON Test Notification",
            KeyMessageBody: "This notification tests JSON serialization",
            Priority: Domain.Enums.NotificationPriorityEnum.Medium,
            ExpiryDate: DateTime.UtcNow.AddDays(7),
            NotifierId: 1,
            NotifiedId: 1,
            NotifiedType: "User",
            NotificationTypeId: 1,
            NotificationType: "Info",
            NotificationObjectId: null,
            NotificationObjectType: null,
            Details: new List<AddNotificationDetailRequest>()
        );

        // Act
        var json = JsonSerializer.Serialize(notificationRequest);
        var deserializedRequest = JsonSerializer.Deserialize<AddNotificationRequest>(json);

        // Assert
        json.Should().NotBeNullOrEmpty("JSON serialization should work");
        deserializedRequest.Should().NotBeNull("JSON deserialization should work");
        deserializedRequest!.KeyMessageTitle.Should().Be(notificationRequest.KeyMessageTitle);
        deserializedRequest.KeyMessageBody.Should().Be(notificationRequest.KeyMessageBody);
    }
}
