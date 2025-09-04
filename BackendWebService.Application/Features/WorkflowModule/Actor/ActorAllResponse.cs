using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record ActorAllResponse(
int ActorId,
string ActorType,
int OwnerId,
string OwnerType):IConvertibleFromEntity<Actor, ActorAllResponse>
{
public static ActorAllResponse FromEntity(Actor Actor) =>
new ActorAllResponse(
Actor.ActorId,
Actor.ActorType,
Actor.OwnerId,
Actor.OwnerType);
}

