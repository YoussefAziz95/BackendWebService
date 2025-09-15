using Application.Profiles;
using Application.Features;
using Domain;

namespace Application.Features;
public record AddNotificationDetailRequest(
int NotificationId,
string Channel,
int UserId,
bool IsRead,
DateTime ExpiryDate,
AddNotificationRequest Notification):IConvertibleToEntity<NotificationDetail>
{
public NotificationDetail ToEntity() => new NotificationDetail
{
NotificationId = NotificationId,
Channel = Channel,
UserId = UserId,
IsRead = IsRead,
ExpiryDate = ExpiryDate,
Notification= Notification.ToEntity() };
}