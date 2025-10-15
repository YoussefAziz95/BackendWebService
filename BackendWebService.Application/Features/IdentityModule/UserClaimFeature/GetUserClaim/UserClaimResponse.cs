using Application.Profiles;
using Domain;

namespace Application.Features;
public record UserClaimResponse(
string? ClaimType,
string? ClaimValue,
int UserId,
int? OrganizationId,
UserResponse User,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy) : IConvertibleFromEntity<UserClaim, UserClaimResponse>
{
    public static UserClaimResponse FromEntity(UserClaim UserClaim) =>
    new UserClaimResponse(
    UserClaim.ClaimType,
    UserClaim.ClaimValue,
    UserClaim.UserId,
    UserClaim.OrganizationId,
    UserResponse.FromEntity(UserClaim.User),
    UserClaim.IsActive,
    UserClaim.IsDeleted,
    UserClaim.IsSystem,
    UserClaim.CreatedDate,
    UserClaim.CreatedBy,
    UserClaim.UpdatedDate,
    UserClaim.UpdatedBy);
}