using Application.Profiles;
using Domain;

namespace Application.Features;
public record UpdateZoneRequest(
string Name,
string? Description,
int? ParentZoneId,
UpdateZoneRequest? ParentZone,
List<UpdateZoneRequest> SubZones):IConvertibleToEntity<Zone>
{
public Zone ToEntity() => new Zone
{
Name = Name,
Description = Description,
ParentZoneId = ParentZoneId,
ParentZone = ParentZone.ToEntity(),
SubZones = SubZones.Select(x => x.ToEntity()).ToList()
};
}