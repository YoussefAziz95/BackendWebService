using Application.Profiles;
using Domain;

namespace Application.Features;
public record UserGroupAllResponse(
int GroupId,
int UserId) : IConvertibleFromEntity<UserGroup, UserGroupAllResponse>
{
    public static UserGroupAllResponse FromEntity(UserGroup UserGroup) =>
    new UserGroupAllResponse(
    UserGroup.GroupId,
    UserGroup.UserId);
}

