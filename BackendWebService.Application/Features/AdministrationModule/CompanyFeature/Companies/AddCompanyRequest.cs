using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record AddCompanyRequest(
    [property: Required] string CompanyName,
    string Country,
    string City,
    string StreetAddress,
    string RegistrationNumber,
    string TaxNo,
    string Email,
    int? FileId,
    string? Fax,
    string? Phone,
    int? RoleId,
    List<AddAddressRequest>? Addresses,
    List<AddContactRequest>? Contacts
);
