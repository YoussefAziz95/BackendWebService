using Application.Profiles;
using Domain.Enums;

namespace Application.Features;
public record EmployeeAllResponse(
int UserId,
DateTime RegistrationDate,
StatusEnum AccountStatus,
bool IsAvailable,
RoleEnum Role) : IConvertibleFromEntity<Employee, EmployeeAllResponse>
{
    public static EmployeeAllResponse FromEntity(Employee Employee) =>
    new EmployeeAllResponse(
    Employee.UserId,
    Employee.RegistrationDate,
    Employee.AccountStatus,
    Employee.IsAvailable,
    Employee.Role);
}
