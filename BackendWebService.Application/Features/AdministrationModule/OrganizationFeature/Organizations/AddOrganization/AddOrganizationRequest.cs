using Application.Contracts.Features;
using Application.Profiles;
using Domain.Enums;

namespace Application.Features;

public record AddOrganizationRequest(
string Country,
string City,
string StreetAddress,
OrganizationEnum Type,
string FaxNo,
string Phone,
string Email,
string TaxNo,
int FileId,
List<AddAddressRequest>? Addresses,
List<AddContactRequest>? Contacts) : IConvertibleToEntity<Organization>, IRequest<int>
{
    public Organization ToEntity() => new Organization
    {
        Country = Country,
        City = City,
        StreetAddress = StreetAddress,
        Type = Type,
        FaxNo = FaxNo,
        Phone = Phone,
        Email = Email,
        TaxNo = TaxNo,
        FileId = FileId,
        Addresses = Addresses.Select(x => x.ToEntity()).ToList(),
        Contacts = Contacts.Select(x => x.ToEntity()).ToList()
    };
}
