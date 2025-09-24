using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record NotificationAllResponse(
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
string? NotificationObjectType) : IConvertibleFromEntity<Notification, NotificationAllResponse>
{
    public static NotificationAllResponse FromEntity(Notification Notification) =>
    new NotificationAllResponse(
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
    Notification.NotificationObjectType);
}

