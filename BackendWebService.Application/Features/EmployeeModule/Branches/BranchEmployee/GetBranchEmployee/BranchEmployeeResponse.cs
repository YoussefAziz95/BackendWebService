using Application.Contracts.Features;
using Application.Profiles;
using Domain;

namespace Application.Features;
public record BranchEmployeeResponse(
int BranchId,
int UserId,
string? JobTitle,
bool IsActive,
DateTime AssignedAt) : IConvertibleFromEntity<BranchEmployee, BranchEmployeeResponse>, IRequest<int>
{
    public static BranchEmployeeResponse FromEntity(BranchEmployee BranchEmployee) =>
    new BranchEmployeeResponse(
    BranchEmployee.BranchId,
    BranchEmployee.UserId,
    BranchEmployee.JobTitle,
    BranchEmployee.IsActive,
    BranchEmployee.AssignedAt);
}
