using Domain;

namespace Application.Features;
public record UpdateZoneRequest(
string Name,
string? Description,
int? ParentZoneId,
Zone? ParentZone,
List<UpdateZoneRequest> SubZones);