using Domain.Enums;

namespace Application.Features;
public record UpdateEmployeeRequest(
int UserId,
DateTime RegistrationDate,
StatusEnum AccountStatus,
bool IsAvailable,
RoleEnum Role,
List<UpdateEmployeeAssignmentRequest> Assignments,
List<UpdateEmployeeJobRequest> Jobs);