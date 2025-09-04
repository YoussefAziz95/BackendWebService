using Application.Profiles;
using Domain.Enums;

namespace Application.Features;
public record UpdateActionObjectRequest(
int ActionId,
string ActionType,
int ObjectId,
string ObjectType):IConvertibleToEntity<ActionObject>
{
public ActionObject ToEntity() => new ActionObject
{
ActionId = ActionId,
ActionType = ActionType,
ObjectId = ObjectId,
ObjectType = ObjectType
};
}