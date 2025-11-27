using Application.Contracts.Features;
using Application.Profiles;

namespace Application.Features;
public record ClientPropertyResponse(
int CustomerId,
ClientResponse Customer,
int PropertyId,
PropertyResponse Property,
int AddressId,
AddressResponse Address,
string? Description,
string? City,
string? State,
string? PostalCode,
string? Country,
bool IsActive,
DateTime CreatedAt,
DateTime? UpdatedAt,
DateTime? DeletedAt) : IConvertibleFromEntity<ClientProperty, ClientPropertyResponse>
{
    public static ClientPropertyResponse FromEntity(ClientProperty ClientProperty) =>
    new ClientPropertyResponse(
    ClientProperty.CustomerId,
    ClientResponse.FromEntity(ClientProperty.Customer),
    ClientProperty.PropertyId,
   PropertyResponse.FromEntity(ClientProperty.Property),
    ClientProperty.AddressId,
    AddressResponse.FromEntity(ClientProperty.Address),
    ClientProperty.Description,
    ClientProperty.City,
    ClientProperty.State,
    ClientProperty.PostalCode,
    ClientProperty.Country,
    ClientProperty.IsActive,
    ClientProperty.CreatedAt,
    ClientProperty.UpdatedAt,
    ClientProperty.DeletedAt);
}
