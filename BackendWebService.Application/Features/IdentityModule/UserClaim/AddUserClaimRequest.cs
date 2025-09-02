using Application.Profiles;
using Domain;

namespace Application.Features;
public record AddUserClaimRequest(
int? OrganizationId,
AddUserRequest User,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy):IConvertibleToEntity<UserClaim>
{
public UserClaim ToEntity() => new UserClaim
{
OrganizationId = OrganizationId,
User =User,
IsActive = IsActive,
IsDeleted = IsDeleted,
IsSystem = IsSystem,
CreatedDate = CreatedDate,
CreatedBy = CreatedBy,
UpdatedDate = UpdatedDate,
UpdatedBy = UpdatedBy};
}