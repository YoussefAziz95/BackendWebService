using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record UserGroupResponse(
int GroupId,
int UserId) : IConvertibleFromEntity<UserGroup, UserGroupResponse>
{
    public static UserGroupResponse FromEntity(UserGroup UserGroup) =>
    new UserGroupResponse(
    UserGroup.GroupId,
    UserGroup.UserId);
}



