using Domain;

namespace Application.Features;

public record GetPaginatedProperty(
 PropertyAllResponse PropertyAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");