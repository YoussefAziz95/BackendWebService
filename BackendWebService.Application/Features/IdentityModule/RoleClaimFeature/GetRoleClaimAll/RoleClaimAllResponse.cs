using Application.Profiles;
using Domain;

namespace Application.Features;
public record RoleClaimAllResponse(
string? ClaimType,
string? ClaimValue,
DateTime? CreatedDate,
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy) : IConvertibleFromEntity<RoleClaim, RoleClaimAllResponse>
{
    public static RoleClaimAllResponse FromEntity(RoleClaim RoleClaim) =>
    new RoleClaimAllResponse(
    RoleClaim.ClaimType,
    RoleClaim.ClaimValue,
    RoleClaim.CreatedDate,
    RoleClaim.OrganizationId,
    RoleClaim.IsActive,
    RoleClaim.IsDeleted,
    RoleClaim.IsSystem,
    RoleClaim.CreatedBy,
    RoleClaim.UpdatedDate,
    RoleClaim.UpdatedBy);
}

