using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record SupplierResponse(int Id, [property: Required] string Name, string Country, string City, string StreetAddress, string Email, string TaxNo, string? Phone, int FileId, string? ImageUrl, string? Fax, DateTime? ApprovedDate, bool IsDocumentsApproved, bool IsApproved, List<SupplierCategoryResponse>? Categories, string? Department, string? Title);