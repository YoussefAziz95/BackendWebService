namespace Application.Features;
public record EmployeeAccountResponse(
int EmployeeId,
bool IsActive,
DateTime CreatedAt,
DateTime? UpdatedAt);