namespace Application.Features;
public record GetPaginatedCase(
 CaseAllResponse CaseAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");