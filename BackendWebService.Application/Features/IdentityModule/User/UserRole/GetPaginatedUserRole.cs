namespace Application.Features;
public record GetPaginatedUserRole(
 UserRoleAllResponse UserRoleAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");