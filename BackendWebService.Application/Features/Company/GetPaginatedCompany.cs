using System.ComponentModel.DataAnnotations;

namespace Application.Features;

public record GetPaginatedCompany(int Id, [property: Required] string Name, string RoleType, string Country, string City, string StreetAddress, string? Email, string TaxNo);