using Application.Profiles;
using Domain.Enums;

namespace Application.Features;
public record UpdateActorRequest(
int ActorId,
string ActorType,
int OwnerId,
string OwnerType):IConvertibleToEntity<Actor>
{
public Actor ToEntity() => new Actor
{
ActorId = ActorId,
ActorType = ActorType,
OwnerId = OwnerId,
OwnerType = OwnerType
};
}