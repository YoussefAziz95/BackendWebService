namespace Application.Features;
public record GetPaginatedEmailLog(
 EmailLogAllResponse EmailLogAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");