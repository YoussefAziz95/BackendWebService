namespace Application.Features;
public record GetPaginatedBaseEntity(
 BaseEntityAllResponse BaseEntityAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");