namespace Application.Features;
public record GetPaginatedUserRefreshToken(
 UserRefreshTokenAllResponse UserRefreshTokenAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");