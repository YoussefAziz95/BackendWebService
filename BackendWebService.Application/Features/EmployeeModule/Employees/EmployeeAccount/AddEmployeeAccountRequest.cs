namespace Application.Features;
public record AddEmployeeAccountRequest(
int EmployeeId,
bool IsActive,
DateTime CreatedAt,
DateTime? UpdatedAt);