using Application.Profiles;
using Domain;

namespace Application.Features;
public record UpdateGroupRequest(
string Name,
int? ActorId,
List<UpdateUserGroupRequest> UserGroups):IConvertibleToEntity<Group>
{
public Group ToEntity() => new Group
{
Name = Name,
ActorId = ActorId,
UserGroups = UserGroups.Select(x => x.ToEntity()).ToList()
};
}