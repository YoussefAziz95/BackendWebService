using Application.Profiles;
using Domain.Enums;

namespace Application.Features;
public record NotificationResponse(
string KeyMessageTitle,
string KeyMessageBody,
NotificationPriorityEnum Priority,
DateTime ExpiryDate,
int NotifierId,
int NotifiedId,
string NotifiedType,
int? NotificationTypeId,
string? NotificationType,
int? NotificationObjectId,
string? NotificationObjectType,
List<NotificationDetailResponse> Details) : IConvertibleFromEntity<Notification, NotificationResponse>
{
    public static NotificationResponse FromEntity(Notification Notification) =>
    new NotificationResponse(
    Notification.KeyMessageTitle,
    Notification.KeyMessageBody,
    Notification.Priority,
    Notification.ExpiryDate,
    Notification.NotifierId,
    Notification.NotifiedId,
    Notification.NotifiedType,
    Notification.NotificationTypeId,
    Notification.NotificationType,
    Notification.NotificationObjectId,
    Notification.NotificationObjectType,
    Notification.Details.Select(NotificationDetailResponse.FromEntity).ToList());
}