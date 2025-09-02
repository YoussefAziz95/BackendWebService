using Application.Features;
using Application.Profiles;
using Application.Features;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record AddEmployeeRequest(
int UserId,
DateTime RegistrationDate,
StatusEnum AccountStatus,
bool IsAvailable,
RoleEnum Role,
List<AddEmployeeAssignmentRequest> Assignments,
List<AddEmployeeJobRequest> Jobs):IConvertibleToEntity<Employee>
{
public Employee ToEntity() => new Employee
{
UserId = UserId,
RegistrationDate = RegistrationDate,
AccountStatus = AccountStatus,
IsAvailable = IsAvailable,
Role = Role.ToEntity(),
EmployeeAssignments= Assignments.Select(x => x.ToEntity()).ToList(),
EmployeeJob = Jobs.Select(x => x.ToEntity()).ToList()
};
}