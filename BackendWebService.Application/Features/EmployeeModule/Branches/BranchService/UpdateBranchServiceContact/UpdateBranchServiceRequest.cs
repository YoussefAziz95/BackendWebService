using Application.Contracts.Features;
using Application.Profiles;
using Domain;
namespace Application.Features;
public record UpdateBranchServiceRequest(
int BranchId,
int ServiceId,
string? Notes,
bool IsActive) : IConvertibleToEntity<BranchService>,IRequest<int>
{
    public BranchService ToEntity() => new BranchService
    {
        BranchId = BranchId,
        ServiceId = ServiceId,
        Notes = Notes,
        IsActive = IsActive
    };
}
