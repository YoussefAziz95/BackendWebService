using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record UserClaimResponse(
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