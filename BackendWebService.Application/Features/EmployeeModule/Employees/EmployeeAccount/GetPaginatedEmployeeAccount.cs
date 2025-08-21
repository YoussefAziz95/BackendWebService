namespace Application.Features;
public record GetPaginatedEmployeeAccount(
int EmployeeId,
bool IsActive,
DateTime CreatedAt,
DateTime? UpdatedAt);