using Domain;

namespace Application.Features;
public record ZoneResponse(
string Name,
string? Description,
int? ParentZoneId,
Zone? ParentZone,
List<ZoneResponse> SubZones);