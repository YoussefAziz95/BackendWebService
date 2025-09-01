using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record BranchServiceAllResponse(
int BranchId,
int ServiceId,
string? Notes,
bool IsActive ): IConvertibleFromEntity<BranchService, BranchServiceAllResponse>        
{
public static BranchServiceAllResponse FromEntity(BranchService BranchService) =>
new BranchServiceAllResponse(
BranchService.BranchId,
BranchService.ServiceId,
BranchService.Notes,
BranchService.IsActive);
}
