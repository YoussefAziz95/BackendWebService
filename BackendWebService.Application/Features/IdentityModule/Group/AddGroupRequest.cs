namespace Application.Features;
public record AddGroupRequest(
string Name,
int? ActorId,
List<AddUserGroupsRequest> UserGroups);