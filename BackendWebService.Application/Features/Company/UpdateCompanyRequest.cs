using Domain;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
namespace Application.Features;

public record UpdateCompanyRequest([property: Required] int Id,[property: Required] string Name, string Country, string City, string StreetAddress, string RegistrationNumber, string TaxNo, string Email, string? ImageUrl, string? Fax, string? Phone, int? RoleId);