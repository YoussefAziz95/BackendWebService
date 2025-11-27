using Application.Profiles;
using Domain;

namespace Application.Features;
public record GroupResponse(
string Name,
int? ActorId,
List<UserGroupResponse> UserGroups) : IConvertibleFromEntity<Group, GroupResponse>
{
    public static GroupResponse FromEntity(Group Group) =>
    new GroupResponse(
    Group.Name,
    Group.ActorId,
    Group.UserGroups.Select(UserGroupResponse.FromEntity).ToList()
    );
}
