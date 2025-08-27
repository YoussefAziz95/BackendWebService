using Domain.Enums;

namespace Application.Features;
public record ActorResponse(
int ActorId,
string ActorType,
int OwnerId,
string OwnerType);