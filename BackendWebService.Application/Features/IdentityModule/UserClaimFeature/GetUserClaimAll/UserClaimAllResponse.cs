using Application.Profiles;
using Domain;

namespace Application.Features;
public record UserClaimAllResponse(
int Id,
string? ClaimType,
string? ClaimValue,
int UserId,
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy) : IConvertibleFromEntity<UserClaim, UserClaimAllResponse>
{
    public static UserClaimAllResponse FromEntity(UserClaim UserClaim) =>
    new UserClaimAllResponse(
    UserClaim.Id,
    UserClaim.ClaimType,
    UserClaim.ClaimValue,
    UserClaim.UserId,
    UserClaim.OrganizationId,
    UserClaim.IsActive,
    UserClaim.IsDeleted,
    UserClaim.IsSystem,
    UserClaim.CreatedDate,
    UserClaim.CreatedBy,
    UserClaim.UpdatedDate,
    UserClaim.UpdatedBy);
}

