using Domain.Enums;

namespace Application.Features;
public record AddActorRequest(
int ActorId,
string ActorType,
int OwnerId,
string OwnerType);