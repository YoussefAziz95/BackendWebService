namespace Application.Features;
public record GetPaginatedSupplierAccountRequest(
SupplierAccountAllResponse SupplierAccountAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");

