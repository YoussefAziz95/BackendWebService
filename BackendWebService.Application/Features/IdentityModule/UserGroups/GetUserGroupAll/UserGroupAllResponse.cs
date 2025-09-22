using Application.Profiles;
using Domain;
using Domain.Enums;

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

