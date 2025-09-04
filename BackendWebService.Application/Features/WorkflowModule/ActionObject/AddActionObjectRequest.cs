using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record AddActionObjectRequest(
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
ObjectType = ObjectType};
}