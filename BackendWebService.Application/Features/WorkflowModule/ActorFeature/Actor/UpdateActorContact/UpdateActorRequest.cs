using Application.Contracts.Features;
using Application.Profiles;
namespace Application.Features;
public record UpdateActorRequest(
int ActorId,
string ActorType,
int OwnerId,
string OwnerType) : IConvertibleToEntity<Actor>, IRequest<int>
{
    public Actor ToEntity() => new Actor
    {
        ActorId = ActorId,
        ActorType = ActorType,
        OwnerId = OwnerId,
        OwnerType = OwnerType
    };
}