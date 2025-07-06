using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record NotificationResponse(int NotificationId, [property: Required] string MessageTitle, [property: Required] string MessageBody, int UserId, string Status, DateTime ResponseTimestamp, string ResponseChannel, string Notifier, string NotificationType, string NotificationObjectType);