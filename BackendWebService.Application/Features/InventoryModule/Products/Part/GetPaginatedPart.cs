using Application.Features;

namespace Application.Features;
public record GetPaginatedPart(
 PartAllResponse PartAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");