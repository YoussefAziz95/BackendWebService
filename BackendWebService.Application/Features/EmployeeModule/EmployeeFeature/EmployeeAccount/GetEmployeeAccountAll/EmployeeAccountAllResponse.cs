using Application.Profiles;

namespace Application.Features;
public record EmployeeAccountAllResponse(
int EmployeeId,
bool IsActive,
DateTime CreatedAt,
DateTime? UpdatedAt) : IConvertibleFromEntity<EmployeeAccount, EmployeeAccountAllResponse>
{
    public static EmployeeAccountAllResponse FromEntity(EmployeeAccount EmployeeAccount) =>
    new EmployeeAccountAllResponse(
    EmployeeAccount.EmployeeId,
    EmployeeAccount.IsActive,
    EmployeeAccount.CreatedAt,
    EmployeeAccount.UpdatedAt);
}