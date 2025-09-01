using Application.Profiles;
using Domain;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Application.Features;
public record UpdateOrganizationRequest(
string Country,
string City,
string StreetAddress,
OrganizationEnum Type,
string FaxNo,
string Phone,
string Email,
string TaxNo,
int FileId,
List<UpdateAddressRequest>? Addresses,
List<UpdateContactRequest>? Contacts):IConvertibleToEntity<Organization>
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