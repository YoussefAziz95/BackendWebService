using Application.Profiles;
using Domain;

namespace Application.Features;
public record UserRoleResponse(
UserResponse User,
RoleResponse Role,
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy): IConvertibleFromEntity<UserRole, UserRoleResponse>        
{
public static UserRoleResponse FromEntity(UserRole UserRole) =>
new UserRoleResponse(
UserResponse.FromEntity(UserRole.User),
RoleResponse.FromEntity(UserRole.Role),
UserRole.OrganizationId,
UserRole.IsActive,
UserRole.IsDeleted,
UserRole.IsSystem,
UserRole.CreatedDate,
UserRole.CreatedBy,
UserRole.UpdatedDate,
UserRole.UpdatedBy
);
}