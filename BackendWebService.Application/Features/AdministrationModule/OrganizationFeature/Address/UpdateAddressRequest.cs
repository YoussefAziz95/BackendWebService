using Application.Profiles;
using Domain;
using System.IO;

namespace Application.Features;
public record UpdateAddressRequest(
int OrganizationId,
bool IsAdministration,
string FullAddress,
string Street,
string Zone,
string State,
string City):IConvertibleToEntity<Address>
{
public Address ToEntity() => new Address
{

OrganizationId = OrganizationId,
IsAdministration = IsAdministration,
Street = Street,
FullAddress = FullAddress,
Zone = Zone,
State = State,
City = City
};
}
