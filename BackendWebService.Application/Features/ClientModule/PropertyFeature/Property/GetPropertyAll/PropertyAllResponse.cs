using Application.Profiles;
using Domain;

namespace Application.Features;

public record PropertyAllResponse(
int UserId,
string Name,
string? ContactName,
string ContactNumber,
int? ZoneId,
Zone? Zone,
double Latitude,
double Longitude,
DateTimeOffset CreatedAt,
DateTimeOffset? DeletedAt,
bool IsDeleted) : IConvertibleFromEntity<Property, PropertyAllResponse>
{
    public static PropertyAllResponse FromEntity(Property Property) =>
    new PropertyAllResponse(
    Property.UserId,
    Property.Name,
    Property.ContactName,
    Property.ContactNumber,
    Property.ZoneId,
    Property.Zone,
    Property.Latitude,
    Property.Longitude,
    Property.CreatedAt,
    Property.DeletedAt,
    Property.IsDeleted);
}