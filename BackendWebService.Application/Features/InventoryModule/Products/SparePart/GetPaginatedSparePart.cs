namespace Application.Features;
public record GetPaginatedSparePart(
 SparePartAllResponse SparePartAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");