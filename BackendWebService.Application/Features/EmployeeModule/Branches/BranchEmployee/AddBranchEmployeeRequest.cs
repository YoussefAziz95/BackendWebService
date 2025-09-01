using Application.Profiles;
using Domain;

namespace Application.Features;
public record AddBranchEmployeeRequest(
int BranchId,
int UserId,
string? JobTitle,
bool IsActive,
DateTime AssignedAt):IConvertibleToEntity<BranchEmployee>
{
public BranchEmployee ToEntity() => new BranchEmployee
{
BranchId = BranchId,
UserId = UserId,
JobTitle = JobTitle,
IsActive = IsActive,
AssignedAt = AssignedAt};
}