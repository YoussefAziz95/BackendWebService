using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record AddNotificationRequest([property: Required] string MessageTitle, [property: Required] string MessageBody, string Priority, DateTime TimeStamp, DateTime ExpiryDate, int NotifierId, int NotifiedId, string NotifiedType, int? NotificationTypeId, string NotificationType, int? NotificationObjectId, string NotificationObjectType, int? NotificationObjectTypeId);