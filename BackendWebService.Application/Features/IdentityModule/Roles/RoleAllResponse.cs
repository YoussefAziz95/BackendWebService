using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record RoleAllResponse(
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy,
int? ParentId,
string DisplayName):IConvertibleFromEntity<Role, RoleAllResponse>
{
public static RoleAllResponse FromEntity(Role Role) =>
new RoleAllResponse(
Role.OrganizationId,
Role.IsActive,
Role.IsDeleted,
Role.IsSystem,
Role.CreatedDate,
Role.CreatedBy,
Role.UpdatedDate,
Role.UpdatedBy,
Role.ParentId,
Role.DisplayName);
}

