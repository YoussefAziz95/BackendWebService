using Application.Profiles;
using Domain;
using System.Threading;
using System.Threading.Channels;

namespace Application.Features;
public record UpdateNotificationDetailRequest(
int NotificationId,
string Channel,
int UserId,
bool IsRead,
DateTime ExpiryDate,
UpdateNotificationRequest Notification):IConvertibleToEntity<NotificationDetail>
{
public NotificationDetail ToEntity() => new NotificationDetail
{
NotificationId = NotificationId,
Channel = Channel,
UserId = UserId,
IsRead = IsRead,
ExpiryDate = ExpiryDate,
Notification = Notification.ToEntity()
};
}