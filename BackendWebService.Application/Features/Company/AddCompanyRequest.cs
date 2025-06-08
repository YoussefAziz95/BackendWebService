using System.ComponentModel.DataAnnotations;

namespace Application.Features;

public record AddCompanyRequest([property: Required] string Name, string Country, string City, string StreetAddress, string RegistrationNumber, string TaxNo, string Email, string? ImageUrl, string? Fax, string? Phone, int? RoleId);