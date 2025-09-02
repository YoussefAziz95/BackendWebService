using Domain.Enums;

namespace Application.Features;
public record GetPaginatedEmployee(
EmployeeAllResponse EmployeeAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");