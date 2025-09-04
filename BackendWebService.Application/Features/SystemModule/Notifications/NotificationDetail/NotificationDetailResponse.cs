namespace Application.Features;
public record NotificationDetailResponse(
int NotificationId,
string Channel,
int UserId,
bool IsRead,
DateTime ExpiryDate,
Notification Notification);