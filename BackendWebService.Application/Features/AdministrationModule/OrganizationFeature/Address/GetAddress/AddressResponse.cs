using Application.Profiles;
using Domain;

namespace Application.Features;
public record AddressResponse(
 int OrganizationId,
bool? IsAdministration,
string? FullAddress,
string Street,
string Zone,
string State,
string City) : IConvertibleFromEntity<Address, AddressResponse>
{
    public static AddressResponse FromEntity(Address Address) =>
        new AddressResponse(
        Address.OrganizationId,
        Address.IsAdministration,
        Address.FullAddress,
        Address.Street,
        Address.Zone,
        Address.State,
        Address.City
        );
}
