using Domain.Enums;

namespace Application.Features;
public record ActorAllResponse(
int ActorId,
string ActorType,
int OwnerId,
string OwnerType);

