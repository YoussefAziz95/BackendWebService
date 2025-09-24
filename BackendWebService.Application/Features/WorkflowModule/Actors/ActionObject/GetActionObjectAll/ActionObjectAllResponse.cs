using Application.Profiles;

namespace Application.Features;
public record ActionObjectAllResponse(
int ActionId,
string ActionType,
int ObjectId,
string ObjectType) : IConvertibleFromEntity<ActionObject, ActionObjectAllResponse>
{
    public static ActionObjectAllResponse FromEntity(ActionObject ActionObject) =>
    new ActionObjectAllResponse(
    ActionObject.ActionId,
    ActionObject.ActionType,
    ActionObject.ObjectId,
    ActionObject.ObjectType);
}

