using Application.Profiles;

namespace Application.Features;
public record NotificationDetailResponse(
int NotificationId,
string Channel,
int UserId,
bool IsRead,
DateTime ExpiryDate) : IConvertibleFromEntity<NotificationDetail, NotificationDetailResponse>
{
    public static NotificationDetailResponse FromEntity(NotificationDetail NotificationDetail) =>
    new NotificationDetailResponse(
    NotificationDetail.NotificationId,
    NotificationDetail.Channel,
    NotificationDetail.UserId,
    NotificationDetail.IsRead,
    NotificationDetail.ExpiryDate);
}