using Domain.Enums;

namespace Application.Features;
public record UpdateEmployeeAccountRequest(
int EmployeeId,
bool IsActive,
DateTime CreatedAt,
DateTime? UpdatedAt);