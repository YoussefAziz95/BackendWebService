using Application.Contracts.Features;
using Application.Profiles;
using Domain.Enums;

namespace Application.Features;

public record AddActionActorRequest(
string Name,
string? Description,
StatusEnum StatusId,
ActionEnum ActionType,
DateTime CreatedAt,
DateTime? UpdatedAt,
int? UserId,
AddUserRequest? User,
int? TargetEntityId,
TableNameEnum? TableName) : IConvertibleToEntity<ActionActor>, IRequest<int>
{
    public ActionActor ToEntity() => new ActionActor
    {
        Name = Name,
        Description = Description,
        StatusId = StatusId,
        ActionType = ActionType,
        CreatedAt = CreatedAt,
        UpdatedAt = UpdatedAt,
        UserId = UserId,
        User = User.ToEntity(),
        TableName = TableName
    };
}