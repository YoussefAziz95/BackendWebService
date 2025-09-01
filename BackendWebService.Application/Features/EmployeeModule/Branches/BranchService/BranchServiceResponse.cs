using Application.Profiles;
using Domain;

namespace Application.Features;
public record BranchServiceResponse(
int BranchId,
int ServiceId,
string? Notes,
bool IsActive):IConvertibleFromEntity<BranchService, BranchServiceResponse>
{
public static BranchServiceResponse FromEntity(BranchService BranchService) =>
new BranchServiceResponse(
BranchService.BranchId,
BranchService.ServiceId,
BranchService.Notes,
BranchService.IsActive);
}
