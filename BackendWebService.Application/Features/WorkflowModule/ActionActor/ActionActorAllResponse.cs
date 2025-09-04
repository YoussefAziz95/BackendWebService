using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record ActionActorAllResponse(
string Name,
string? Description,
StatusEnum StatusId,
ActionEnum ActionType,
DateTime CreatedAt,
DateTime? UpdatedAt,
int? UserId,
int? TargetEntityId,
TableNameEnum? TableName) : IConvertibleFromEntity<ActionActor, ActionActorAllResponse>
{
public static ActionActorAllResponse FromEntity(ActionActor ActionActor) =>
new ActionActorAllResponse(
ActionActor.Name,
ActionActor.Description,
ActionActor.StatusId,
ActionActor.ActionType,
ActionActor.CreatedAt,
ActionActor.UpdatedAt,
ActionActor.UserId,
ActionActor.TargetEntityId,
ActionActor.TableName);

}

