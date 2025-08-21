using Domain;
using Domain.Enums;

namespace Application.Features;
public record JobAllResponse(
string Name,
 string? Description,
 DateTime StartDate,
 DateTime EndDate,
 DateTime? ExpirationTime,
 bool IsVerified);
