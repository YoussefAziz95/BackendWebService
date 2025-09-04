using Application.Profiles;
using Domain.Enums;

namespace Application.Features;
public record ActionActorResponse(
string Name,
string? Description,
StatusEnum StatusId,
ActionEnum ActionType,
DateTime CreatedAt,
DateTime? UpdatedAt,
int? UserId,
UserResponse? User,
int? TargetEntityId,
TableNameEnum? TableName): IConvertibleFromEntity<ActionActor, ActionActorResponse>
{
public static ActionActorResponse FromEntity(ActionActor ActionActor) =>
new ActionActorResponse(
ActionActor.Name,
ActionActor.Description,
ActionActor.StatusId,
ActionActor.ActionType,
ActionActor.CreatedAt,
ActionActor.UpdatedAt,
ActionActor.UserId,
ActionActor.User.ToEntity(),
ActionActor.TargetEntityId,
ActionActor.TableName);

}
