using Application.Features;
using Application.Profiles;
using Domain.Enums;

namespace Application.Features;
public record UpdateNotificationRequest(
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
List<UpdateNotificationDetailRequest> Details):IConvertibleToEntity<Notification>
{
public Notification ToEntity() => new Notification
{
KeyMessageTitle = KeyMessageTitle,
KeyMessageBody = KeyMessageBody,
Priority = Priority,
ExpiryDate = ExpiryDate,
NotifierId = NotifierId,
NotifiedId = NotifiedId,
NotifiedType = NotifiedType,
NotificationTypeId = NotificationTypeId,
NotificationType = NotificationType,
NotificationObjectId = NotificationObjectId,
NotificationObjectType = NotificationObjectType,
Details = Details.Select(x => x.ToEntity()).ToList()

};
}