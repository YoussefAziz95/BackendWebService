using Domain.Enums;
using System.ComponentModel.DataAnnotations;

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
List<UpdateContactRequest>? Contacts);