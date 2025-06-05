using System.ComponentModel.DataAnnotations;

namespace Application.Features;

public record UpdateCompanyRequest(int Id, [property: Required] string Name, string Country, string City, string StreetAddress, string TaxNo, string Email, string? ImageUrl, string? Fax, string? Phone, string? Department, string? Title, List<UpdateSupplierCategoryRequest>? Categories);