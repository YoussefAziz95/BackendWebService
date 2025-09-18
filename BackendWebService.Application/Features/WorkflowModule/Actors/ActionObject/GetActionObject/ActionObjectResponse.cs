using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record ActionObjectResponse(
int ActionId,
string ActionType,
int ObjectId,
string ObjectType) : IConvertibleFromEntity<ActionObject, ActionObjectResponse>
{
    public static ActionObjectResponse FromEntity(ActionObject ActionObject) =>
    new ActionObjectResponse(
    ActionObject.ActionId,
    ActionObject.ActionType,
    ActionObject.ObjectId,
    ActionObject.ObjectType);
}
