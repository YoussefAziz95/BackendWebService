using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Features;

public record UpdateOrganizationRequest(int Id, [property: Required] string Name, string Country, string City, string StreetAddress, OrganizationEnum Type, string FaxNo, string Phone, string Email, string TaxNo, string? ImageUrl, string? Fax);