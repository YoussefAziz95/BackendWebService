namespace Application.Features;
public record AddNotificationDetailRequest(
int NotificationId,
string Channel,
int UserId,
bool IsRead,
DateTime ExpiryDate,
Notification Notification);