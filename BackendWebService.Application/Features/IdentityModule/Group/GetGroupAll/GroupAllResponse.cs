using Application.Profiles;
using Domain;
using Domain.Enums;

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
