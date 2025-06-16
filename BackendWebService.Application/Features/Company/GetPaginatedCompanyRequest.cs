using System.ComponentModel.DataAnnotations;

namespace Application.Features;

public record GetPaginatedCompanyRequest(
CompanyAllResponse CompanyAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");

