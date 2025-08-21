using Domain.Enums;

namespace Application.Features;
public record EmployeeAllResponse(
int UserId,
DateTime RegistrationDate,
StatusEnum AccountStatus,
bool IsAvailable,
RoleEnum Role
);