using Application.Contracts.Features;
using Application.Profiles;
using Domain;

namespace Application.Features;

public record AddZoneRequest(
string Name,
string? Description,
int? ParentZoneId,
AddZoneRequest? ParentZone,
List<AddZoneRequest> SubZones) : IConvertibleToEntity<Zone>, IRequest<int>
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