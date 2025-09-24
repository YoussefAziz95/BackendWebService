using Application.Profiles;
using Domain;

namespace Application.Features;

public record BranchEmployeeAllResponse(
int BranchId,
int UserId,
string? JobTitle,
bool IsActive,
DateTime AssignedAt) : IConvertibleFromEntity<BranchEmployee, BranchEmployeeAllResponse>
{
    public static BranchEmployeeAllResponse FromEntity(BranchEmployee BranchEmployee) =>
    new BranchEmployeeAllResponse(
    BranchEmployee.BranchId,
    BranchEmployee.UserId,
    BranchEmployee.JobTitle,
    BranchEmployee.IsActive,
    BranchEmployee.AssignedAt);
}

