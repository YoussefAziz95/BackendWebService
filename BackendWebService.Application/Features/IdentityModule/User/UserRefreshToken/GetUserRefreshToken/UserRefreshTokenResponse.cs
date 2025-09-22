using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record UserRefreshTokenResponse(
int UserId,
UserResponse User,
DateTime CreatedAt,
bool IsValid,
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy) : IConvertibleFromEntity<UserRefreshToken, UserRefreshTokenResponse>
{
    public static UserRefreshTokenResponse FromEntity(UserRefreshToken UserRefreshToken) =>
    new UserRefreshTokenResponse(
    UserRefreshToken.UserId,
    UserResponse.FromEntity(UserRefreshToken.User),
    UserRefreshToken.CreatedAt,
    UserRefreshToken.IsValid,
    UserRefreshToken.OrganizationId,
    UserRefreshToken.IsActive,
    UserRefreshToken.IsDeleted,
    UserRefreshToken.IsSystem,
    UserRefreshToken.CreatedDate,
    UserRefreshToken.CreatedBy,
    UserRefreshToken.UpdatedDate,
    UserRefreshToken.UpdatedBy
    );
}

