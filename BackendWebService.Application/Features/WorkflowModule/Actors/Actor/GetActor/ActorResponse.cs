using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record ActorResponse(
int ActorId,
string ActorType,
int OwnerId,
string OwnerType) : IConvertibleFromEntity<Actor, ActorResponse>
{
    public static ActorResponse FromEntity(Actor Actor) =>
    new ActorResponse(
    Actor.ActorId,
    Actor.ActorType,
    Actor.OwnerId,
    Actor.OwnerType);
}