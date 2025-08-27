namespace Application.Features;
public record GetPaginatedSupplierCategory(
SupplierCategoryAllResponse SupplierCategoryAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");