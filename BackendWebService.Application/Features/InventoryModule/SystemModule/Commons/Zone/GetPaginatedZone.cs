namespace Application.Features;
public record GetPaginatedZone(
 ZoneAllResponse ZoneAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");