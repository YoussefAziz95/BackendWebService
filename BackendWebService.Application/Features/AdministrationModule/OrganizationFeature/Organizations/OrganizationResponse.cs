using Application.Profiles;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record OrganizationResponse(
   string Country,
    string City,
    string StreetAddress,
    OrganizationEnum Type,
    string FaxNo,
    string Phone,
    string Email,
    string TaxNo,
    int FileId,
    List<AddressResponse>? Addresses,
    List<ContactResponse>? Contacts):IConvertibleFromEntity<Organization, OrganizationResponse>
{
public static OrganizationResponse FromEntity(Organization Organization) =>
    new OrganizationResponse(
    Organization.Country,
    Organization.City,
    Organization.StreetAddress,
    Organization.Type,
    Organization.FaxNo,
    Organization.Phone,
    Organization.Email,
    Organization.TaxNo,
    Organization.FileId,
    Organization.Addresses.Select(AddressResponse.FromEntity).ToList(),
    Organization.Contacts.Select(ContactResponse.FromEntity).ToList()
    );
}
