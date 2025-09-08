using Application.Profiles;
using Domain;

namespace Application.Features;
public record ZoneResponse(
string Name,
string? Description,
int? ParentZoneId,
ZoneResponse? ParentZone,
List<ZoneResponse> SubZones) : IConvertibleFromEntity<Zone, ZoneResponse>
{
    public static ZoneResponse FromEntity(Zone Zone) =>
    new ZoneResponse(
    Zone.Name,
    Zone.Description,
    Zone.ParentZoneId,
    ZoneResponse.FromEntity(Zone.ParentZone),
    Zone.SubZones.Select(ZoneResponse.FromEntity).ToList()
    );
}
