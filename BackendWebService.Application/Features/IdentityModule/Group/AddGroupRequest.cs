using Application.Profiles;
using Domain;

namespace Application.Features;
public record AddGroupRequest(
string Name,
int? ActorId,
List<AddUserGroupRequest> UserGroups):IConvertibleToEntity<Group>
{
public Group ToEntity() => new Group
{
Name = Name,
ActorId = ActorId,
UserGroups = UserGroups.Select(x => x.ToEntity()).ToList()};
}