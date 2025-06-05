using System.ComponentModel.DataAnnotations;

namespace Application.Features;

public record GetPaginatedSupplier(int Id, int? SupplierAccountId, [property: Required] string Name, string Country, string City, string StreetAddress, string? Email, string TaxNo);