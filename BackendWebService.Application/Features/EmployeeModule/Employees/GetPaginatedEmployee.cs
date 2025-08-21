using Domain.Enums;

namespace Application.Features;
public record GetPaginatedEmployee(
int UserId,
 DateTime RegistrationDate,
StatusEnum AccountStatus,
bool IsAvailable,
RoleEnum Role,
List<AddEmployeeAssignmentRequest> Assignments,
List<AddEmployeeJobRequest> Jobs);