using Domain.Enums;

namespace Application.Features;
public record NotificationDetailAllResponse(
int NotificationId,
string Channel,
int UserId,
bool IsRead,
DateTime ExpiryDate,
Notification Notification);

