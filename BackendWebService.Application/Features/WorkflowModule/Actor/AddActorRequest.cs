using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record AddActorRequest(
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
OwnerType = OwnerType};
}