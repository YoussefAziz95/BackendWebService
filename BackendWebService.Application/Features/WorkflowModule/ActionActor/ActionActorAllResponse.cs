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
TableNameEnum? TableName);

