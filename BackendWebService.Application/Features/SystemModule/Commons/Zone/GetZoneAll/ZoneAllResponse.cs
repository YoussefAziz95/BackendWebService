using Application.Profiles;
using Domain;

namespace Application.Features;
public record ZoneAllResponse(
string Name,
string? Description,
int? ParentZoneId) : IConvertibleFromEntity<Zone, ZoneAllResponse>
{
    public static ZoneAllResponse FromEntity(Zone Zone) =>
    new ZoneAllResponse(
    Zone.Name,
    Zone.Description,
    Zone.ParentZoneId);
}

