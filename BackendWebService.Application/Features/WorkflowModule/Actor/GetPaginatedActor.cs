namespace Application.Features;
public record GetPaginatedActor(
 ActorAllResponse ActorAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");