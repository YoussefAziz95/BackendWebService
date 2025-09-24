using Application.Contracts.Features;
using Application.Profiles;
using Domain;
namespace Application.Features;
public record UpdateNotificationDetailRequest(
int NotificationId,
string Channel,
int UserId,
bool IsRead,
DateTime ExpiryDate,
UpdateNotificationRequest Notification) : IConvertibleToEntity<NotificationDetail>, IRequest<int>
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