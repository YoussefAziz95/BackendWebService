using Application.Profiles;

namespace Application.Features;
public record NotificationDetailAllResponse(
int NotificationId,
string Channel,
int UserId,
bool IsRead,
DateTime ExpiryDate) : IConvertibleFromEntity<NotificationDetail, NotificationDetailAllResponse>
{
    public static NotificationDetailAllResponse FromEntity(NotificationDetail NotificationDetail) =>
    new NotificationDetailAllResponse(
    NotificationDetail.NotificationId,
    NotificationDetail.Channel,
    NotificationDetail.UserId,
    NotificationDetail.IsRead,
    NotificationDetail.ExpiryDate);
}



