using Application.Profiles;
using Application.Features;
using Domain.Enums;

namespace Application.Features;
public record UpdateEmployeeRequest(
int UserId,
DateTime RegistrationDate,
StatusEnum AccountStatus,
bool IsAvailable,
RoleEnum Role,
List<UpdateEmployeeAssignmentRequest> Assignments,
List<UpdateEmployeeJobRequest> Jobs): IConvertibleToEntity<Employee>
{
public Employee ToEntity() => new Employee
{
UserId = UserId,
RegistrationDate = RegistrationDate,
AccountStatus = AccountStatus,
IsAvailable = IsAvailable,
Role = Role.ToEntity(),
EmployeeAssignments = Assignments.Select(x => x.ToEntity()).ToList(),
EmployeeJobs = Jobs.Select(x => x.ToEntity()).ToList()
};
}