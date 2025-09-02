namespace Application.Features;
public record GetPaginatedUserGroup(
UserGroupAllResponse UserGroupAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");