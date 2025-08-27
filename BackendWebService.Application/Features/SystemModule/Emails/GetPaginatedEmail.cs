namespace Application.Features;
public record GetPaginatedEmail(
 EmailAllResponse EmailAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");