using Domain.Enums;

namespace Application.Features;
public record EmployeeResponse(
int UserId,
DateTime RegistrationDate,
StatusEnum AccountStatus,
bool IsAvailable,
RoleEnum Role,
List<EmployeeAssignmentResponse> Assignments,
List<EmployeeJobResponse> Jobs);