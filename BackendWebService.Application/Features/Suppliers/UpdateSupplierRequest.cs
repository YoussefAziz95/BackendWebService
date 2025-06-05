using System.ComponentModel.DataAnnotations;

namespace Application.Features;

public record UpdateSupplierRequest(int Id, [property: Required] string Name, string Country, string City, string StreetAddress, [property: Required] string TaxNo, [property: Required] string Email, string? ImageUrl, string? Fax, string? Phone, string? Department, string? Title, List<UpdateSupplierCategoryRequest>? Categories);