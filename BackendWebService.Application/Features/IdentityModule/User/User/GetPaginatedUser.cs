namespace Application.Features;
public record GetPaginatedUser(
UserAllResponse UserAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");