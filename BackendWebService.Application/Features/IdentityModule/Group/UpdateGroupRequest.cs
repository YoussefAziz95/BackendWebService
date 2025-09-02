namespace Application.Features;
public record UpdateGroupRequest(
string Name,
int? ActorId,
List<UpdateUserGroupRequest> UserGroups);