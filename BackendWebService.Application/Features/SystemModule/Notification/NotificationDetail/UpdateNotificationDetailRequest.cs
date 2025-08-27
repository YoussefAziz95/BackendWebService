namespace Application.Features;
public record UpdateNotificationDetailRequest(
int NotificationId,
string Channel,
int UserId,
bool IsRead,
DateTime ExpiryDate,
Notification Notification);