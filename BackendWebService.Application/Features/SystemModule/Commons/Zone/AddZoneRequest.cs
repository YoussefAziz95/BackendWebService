using Domain;

namespace Application.Features;
public record AddZoneRequest(
string Name,
string? Description,
int? ParentZoneId,
Zone? ParentZone,
List<AddZoneRequest> SubZones);