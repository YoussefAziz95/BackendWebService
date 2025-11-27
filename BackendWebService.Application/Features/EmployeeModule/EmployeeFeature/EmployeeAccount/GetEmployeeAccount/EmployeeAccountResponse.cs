using Application.Contracts.Features;
using Application.Profiles;

namespace Application.Features;
public record EmployeeAccountResponse(
int EmployeeId,
bool IsActive,
DateTime CreatedAt,
DateTime? UpdatedAt) : IConvertibleFromEntity<EmployeeAccount, EmployeeAccountResponse>, IRequest<int>
{
    public static EmployeeAccountResponse FromEntity(EmployeeAccount EmployeeAccount) =>
    new EmployeeAccountResponse(
    EmployeeAccount.EmployeeId,
    EmployeeAccount.IsActive,
    EmployeeAccount.CreatedAt,
    EmployeeAccount.UpdatedAt);
}