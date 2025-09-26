using Application.Profiles;
using Domain;

namespace Application.Features;
public record GroupAllResponse(
string Name,
int? ActorId) : IConvertibleFromEntity<Group, GroupAllResponse>
{
    public static GroupAllResponse FromEntity(Group Group) =>
    new GroupAllResponse(
    Group.Name,
    Group.ActorId);
}
