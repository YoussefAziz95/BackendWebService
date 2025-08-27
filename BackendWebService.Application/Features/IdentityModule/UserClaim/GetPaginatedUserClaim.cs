namespace Application.Features;
public record GetPaginatedUserClaim(
 UserClaimAllResponse UserClaimAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");