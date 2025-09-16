using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record EmployeeResponse(
int UserId,
DateTime RegistrationDate,
StatusEnum AccountStatus,
bool IsAvailable,
RoleEnum Role,
List<EmployeeAssignmentResponse> Assignments,
List<EmployeeJobResponse> Jobs) : IConvertibleFromEntity<Employee, EmployeeResponse>
{
    public static EmployeeResponse FromEntity(Employee Employee) =>
    new EmployeeResponse(
    Employee.UserId,
    Employee.RegistrationDate,
    Employee.AccountStatus,
    Employee.IsAvailable,
    Employee.Role,
    Employee.Assignments.Select(EmployeeAssignmentResponse.FromEntity).ToList(),
    Employee.Jobs.Select(EmployeeJobResponse.FromEntity).ToList());
}