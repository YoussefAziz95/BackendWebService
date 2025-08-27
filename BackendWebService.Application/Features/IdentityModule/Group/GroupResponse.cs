using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record GroupResponse(
string Name,
int? ActorId,
List<UserGroupResponse> UserGroups);
