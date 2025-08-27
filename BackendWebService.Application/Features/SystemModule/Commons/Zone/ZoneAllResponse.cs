using Domain;
using Domain.Enums;

namespace Application.Features;
public record ZoneAllResponse(
string Name,
string? Description,
int? ParentZoneId,
Zone? ParentZone);

