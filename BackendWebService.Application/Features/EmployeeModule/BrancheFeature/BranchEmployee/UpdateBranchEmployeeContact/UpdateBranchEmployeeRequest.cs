using Application.Contracts.Features;
using Application.Profiles;
using Domain;
namespace Application.Features;
public record UpdateBranchEmployeeRequest(
int BranchId,
int UserId,
string? JobTitle,
bool IsActive,
DateTime AssignedAt) : IConvertibleToEntity<BranchEmployee>, IRequest<int>
{
    public BranchEmployee ToEntity() => new BranchEmployee
    {
        BranchId = BranchId,
        UserId = UserId,
        JobTitle = JobTitle,
        IsActive = IsActive,
        AssignedAt = AssignedAt
    };
}
