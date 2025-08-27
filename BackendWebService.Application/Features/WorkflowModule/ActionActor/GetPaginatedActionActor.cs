namespace Application.Features;
public record GetPaginatedActionActor(
 ActionActorAllResponse ActionActorAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");