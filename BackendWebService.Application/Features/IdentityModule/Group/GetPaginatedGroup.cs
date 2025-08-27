namespace Application.Features;
public record GetPaginatedGroup(
GroupAllResponse GroupAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");