using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record UserRoleAllResponse(
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy): IConvertibleFromEntity<UserRole, UserRoleAllResponse>        
{
public static UserRoleAllResponse FromEntity(UserRole UserRole) =>
new UserRoleAllResponse(
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

