using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record RoleResponse(
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy,
int? ParentId,
string DisplayName,
List<RoleClaimResponse> Claims,
List<UserRoleResponse> Users) : IConvertibleFromEntity<Role, RoleResponse>
{
    public static RoleResponse FromEntity(Role Role) =>
    new RoleResponse(
    Role.OrganizationId,
    Role.IsActive,
    Role.IsDeleted,
    Role.IsSystem,
    Role.CreatedDate,
    Role.CreatedBy,
    Role.UpdatedDate,
    Role.UpdatedBy,
    Role.ParentId,
    Role.DisplayName,
    Role.Claims.Select(RoleClaimResponse.FromEntity).ToList(),
    Role.Users.Select(UserRoleResponse.FromEntity).ToList()

    );
}