using Domain.Enums;

namespace Application.Features;
public record ItemAllResponse(
string Name,
string? Description,
decimal UnitPrice,
int CategoryId,
int PreparationTimeMinutes);

