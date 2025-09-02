using Domain;
using Domain.Enums;

namespace Application.Features;
public record GetPaginatedJobVerificationRequest(
JobVerificationAllResponse JobVerificationAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");