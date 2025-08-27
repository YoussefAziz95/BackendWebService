namespace Application.Features;
public record GetPaginatedManagerRequest(
ManagerAllResponse CompanyAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");

