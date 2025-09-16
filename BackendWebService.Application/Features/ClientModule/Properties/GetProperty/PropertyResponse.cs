using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record PropertyResponse(
int UserId,
string Name,
string? ContactName,
string ContactNumber,
int? ZoneId,
ZoneResponse? Zone,
double Latitude,
double Longitude,
DateTimeOffset CreatedAt,
DateTimeOffset? DeletedAt,
bool IsDeleted) : IConvertibleFromEntity<Property, PropertyResponse>
{
    public static PropertyResponse FromEntity(Property Property) =>
    new PropertyResponse(
    Property.UserId,
    Property.Name,
    Property.ContactName,
    Property.ContactNumber,
    Property.ZoneId,
    ZoneResponse.FromEntity(Property.Zone),
    Property.Latitude,
    Property.Longitude,
    Property.CreatedAt,
    Property.DeletedAt,
    Property.IsDeleted);
}