using Application.Profiles;
using Domain;

namespace Application.Features;

public record AddressAllResponse(
int OrganizationId,
bool IsAdministration,
string FullAddress,
string Street,
string Zone,
string State,
string City) : IConvertibleFromEntity<Address, AddressAllResponse>
{
    public static AddressAllResponse FromEntity(Address Address) =>
    new AddressAllResponse(
    Address.OrganizationId,
    Address.IsAdministration,
    Address.FullAddress,
    Address.Street,
    Address.Zone,
    Address.State,
    Address.City
    );
}
