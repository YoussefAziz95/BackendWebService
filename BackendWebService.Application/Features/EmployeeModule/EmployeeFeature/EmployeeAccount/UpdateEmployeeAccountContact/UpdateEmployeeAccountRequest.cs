using Application.Contracts.Features;
using Application.Profiles;
namespace Application.Features;
public record UpdateEmployeeAccountRequest(
int EmployeeId,
bool IsActive,
DateTime CreatedAt,
DateTime? UpdatedAt) : IConvertibleToEntity<EmployeeAccount>, IRequest<int>
{
    public EmployeeAccount ToEntity() => new EmployeeAccount
    {
        EmployeeId = EmployeeId,
        IsActive = IsActive,
        CreatedAt = CreatedAt,
        UpdatedAt = UpdatedAt,

    };
}