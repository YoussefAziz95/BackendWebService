using Application.Contracts.Features;
using Application.Profiles;

namespace Application.Features;

public record AddActionObjectRequest(
int ActionId,
string ActionType,
int ObjectId,
string ObjectType) : IConvertibleToEntity<ActionObject>, IRequest<int>
{
    public ActionObject ToEntity() => new ActionObject
    {
        ActionId = ActionId,
        ActionType = ActionType,
        ObjectId = ObjectId,
        ObjectType = ObjectType
    };
}