using Application.Features;

namespace BackendWebService.Application.Features.InventoryModule.Products.Part;
public record GetPaginatedPart(
 PartAllResponse PartAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");