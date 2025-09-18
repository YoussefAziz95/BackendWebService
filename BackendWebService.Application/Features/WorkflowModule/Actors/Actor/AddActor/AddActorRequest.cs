using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddActorRequest(
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