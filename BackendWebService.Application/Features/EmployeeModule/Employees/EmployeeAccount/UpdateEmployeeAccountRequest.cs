using Application.Profiles;
using Domain.Enums;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Application.Features;
public record UpdateEmployeeAccountRequest(
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