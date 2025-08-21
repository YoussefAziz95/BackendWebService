namespace Application.Features;
public record EmployeeAccountAllResponse(
int EmployeeId,
bool IsActive,
DateTime CreatedAt,
DateTime? UpdatedAt);