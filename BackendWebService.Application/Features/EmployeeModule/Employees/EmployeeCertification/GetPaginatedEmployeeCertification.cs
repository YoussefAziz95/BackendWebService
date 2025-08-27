using Domain.Enums;

namespace Application.Features;
public record GetPaginatedEmployeeCertification(
EmployeeCertificationAllResponse EmployeeCertificationAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");