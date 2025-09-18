using Application.Contracts.Features;
using Application.Profiles;
using Domain;
namespace Application.Features;
public record UpdateActionObjectRequest(
int ActionId,
string ActionType,
int ObjectId,
string ObjectType) : IConvertibleToEntity<ActionObject>,IRequest<int>
{
    public ActionObject ToEntity() => new ActionObject
    {
        ActionId = ActionId,
        ActionType = ActionType,
        ObjectId = ObjectId,
        ObjectType = ObjectType
    };
}