using Application.Profiles;
using Domain;

namespace Application.Features;
public record UserGroupResponse(
int GroupId,
int UserId):IConvertibleFromEntity<UserGroup, UserGroupResponse>
{
    public static UserGroupResponse FromEntity(UserGroup UserGroup) =>
    new UserGroupResponse(
    UserGroup.GroupId,
    UserGroup.UserId);
}



