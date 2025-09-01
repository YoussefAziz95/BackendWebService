using Application.Profiles;
using Domain;

namespace Application.Features;

public record AddPropertyRequest(
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
bool IsDeleted):IConvertibleToEntity<Property>
{
public Property ToEntity() => new Property
{
UserId = UserId,
Name = Name,
ContactName = ContactName,
ContactNumber = ContactNumber,
ZoneId = ZoneId,
Zone = Zone,
Latitude= Latitude,
Longitude= Longitude,
CreatedAt = CreatedAt,
DeletedAt = DeletedAt,
};
}