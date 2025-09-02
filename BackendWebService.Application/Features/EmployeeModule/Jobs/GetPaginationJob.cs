using Application.Features;
using Domain;

namespace Application.Features;
public record GetPaginatedJobRequest(
JobAllResponse JobAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");