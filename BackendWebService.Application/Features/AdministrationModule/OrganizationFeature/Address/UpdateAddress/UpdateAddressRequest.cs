using Application.Contracts.Features;
using Application.Profiles;
using Domain;
namespace Application.Features;
public record UpdateAddressRequest(
int Id,
int OrganizationId,
bool IsAdministration,
string FullAddress,
string Street,
string Zone,
string State,
string City) : IConvertibleToEntity<Address>, IRequest<int>
{
    public Address ToEntity() => new Address
    {
        Id = Id,
        OrganizationId = OrganizationId,
        IsAdministration = IsAdministration,
        Street = Street,
        FullAddress = FullAddress,
        Zone = Zone,
        State = State,
        City = City
    };
}