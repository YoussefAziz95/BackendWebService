namespace Application.Features;
public record GetPaginatedContactRequest(
ContactAllResponse ContactAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");

