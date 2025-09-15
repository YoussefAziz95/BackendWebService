using Application.Profiles;
using Domain;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record AddNotificationRequest(
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
List<AddNotificationDetailRequest> Details):IConvertibleToEntity<Notification>
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
Details= Details.Select(x => x.ToEntity()).ToList()

};
}