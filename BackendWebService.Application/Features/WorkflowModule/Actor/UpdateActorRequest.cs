using Domain.Enums;

namespace Application.Features;
public record UpdateActorRequest(
int ActorId,
string ActorType,
int OwnerId,
string OwnerType);