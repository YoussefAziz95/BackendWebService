using Application.Profiles;
using Domain;

namespace Application.Features;
public record RoleClaimResponse(
int? Id,
int? RoleId,
string? ClaimType,
string? ClaimValue,
DateTime? CreatedDate,
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy) : IConvertibleFromEntity<RoleClaim, RoleClaimResponse>
{
    public static RoleClaimResponse FromEntity(RoleClaim RoleClaim) =>
    new RoleClaimResponse(
    RoleClaim.Id,
    RoleClaim.RoleId,
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