using Application.Contracts.Features;
using Application.Profiles;
using Domain.Enums;

namespace Application.Features;

public record AddEmployeeRequest(
int UserId,
DateTime RegistrationDate,
StatusEnum AccountStatus,
bool IsAvailable,
RoleEnum Role,
List<AddEmployeeAssignmentRequest> Assignments,
List<AddEmployeeJobRequest> Jobs) : IConvertibleToEntity<Employee>, IRequest<int>
{
    public Employee ToEntity() => new Employee
    {
        UserId = UserId,
        RegistrationDate = RegistrationDate,
        AccountStatus = AccountStatus,
        IsAvailable = IsAvailable,
        Role = Role,
        Assignments = Assignments.Select(x => x.ToEntity()).ToList(),
        Jobs = Jobs.Select(x => x.ToEntity()).ToList()
    };
}