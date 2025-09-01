using Application.Profiles;
using Domain;

namespace Application.Features;
public record AddBranchServiceRequest(
int BranchId,
int ServiceId,
string? Notes,
bool IsActive): IConvertibleToEntity<BranchService>
{
public BranchService ToEntity() => new BranchService
{
BranchId = BranchId,
ServiceId = ServiceId,
Notes = Notes,
IsActive = IsActive};
}