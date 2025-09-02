using Application.Profiles;
using Domain;

namespace Application.Features;
public record AddEmployeeAccountRequest(
int EmployeeId,
bool IsActive,
DateTime CreatedAt,
DateTime? UpdatedAt):IConvertibleToEntity<EmployeeAccount>
{
public EmployeeAccount ToEntity() => new EmployeeAccount
{
EmployeeId = EmployeeId,
IsActive = IsActive,
CreatedAt = CreatedAt,
UpdatedAt = UpdatedAt,
     
};
}