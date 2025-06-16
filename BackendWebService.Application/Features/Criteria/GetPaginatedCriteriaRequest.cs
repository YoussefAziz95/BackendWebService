namespace Application.Features;

public record GetPaginatedCriteriaRequest(
CriteriaAllResponse CriteriaAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");

