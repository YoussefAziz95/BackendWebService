namespace Application.Features;
public record GetPaginatedEmployeeService(
EmployeeServiceAllResponse EmployeeServiceAllResponse,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc");