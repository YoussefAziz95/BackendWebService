using Application.Contracts.Features;
using Application.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;
namespace Application.Features;
public record UpdatePropertyRequest(
int UserId,
string Name,
string? ContactName,
string ContactNumber,
int? ZoneId,
UpdateZoneRequest? Zone,
double Latitude,
double Longitude,
DateTimeOffset CreatedAt,
DateTimeOffset? DeletedAt,
bool IsDeleted) : IConvertibleToEntity<Property>,IRequest<int>
{
    public Property ToEntity() => new Property
    {
        UserId = UserId,
        Name = Name,
        ContactName = ContactName,
        ContactNumber = ContactNumber,
        ZoneId = ZoneId,
        Zone = Zone.ToEntity(),
        Latitude = Latitude,
        Longitude = Longitude,
        CreatedAt = CreatedAt,
        DeletedAt = DeletedAt,
    };
}