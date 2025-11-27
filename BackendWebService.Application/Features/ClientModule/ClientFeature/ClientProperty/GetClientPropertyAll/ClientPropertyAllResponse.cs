using Application.Profiles;

namespace Application.Features;

public record ClientPropertyAllResponse(
int CustomerId,
int PropertyId,
int AddressId,
string? Description,
string? City,
string? State,
string? PostalCode,
string? Country,
bool IsActive) : IConvertibleFromEntity<ClientProperty, ClientPropertyAllResponse>
{
    public static ClientPropertyAllResponse FromEntity(ClientProperty ClientProperty) =>
    new ClientPropertyAllResponse(
    ClientProperty.CustomerId,
    ClientProperty.PropertyId,
    ClientProperty.AddressId,
    ClientProperty.Description,
    ClientProperty.City,
    ClientProperty.State,
    ClientProperty.PostalCode,
    ClientProperty.Country,
    ClientProperty.IsActive);
}
