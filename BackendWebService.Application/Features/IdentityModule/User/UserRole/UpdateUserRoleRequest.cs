using Application.Profiles;
using Domain;

namespace Application.Features;
public record UpdateUserRoleRequest(
UpdateUserRequest User,
UpdateRoleRequest Role,
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy):IConvertibleToEntity<UserRole>
{
public UserRole ToEntity() => new UserRole
{
User = User.ToEntity(),
Role = Role.ToEntity(),
OrganizationId = OrganizationId,
IsActive = IsActive,
IsDeleted = IsDeleted,
IsSystem = IsSystem,
CreatedDate = CreatedDate,
CreatedBy = CreatedBy,
UpdatedDate = UpdatedDate,
UpdatedBy = UpdatedBy,
};
}