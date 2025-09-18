using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record UserRefreshTokenAllResponse(
int UserId,
DateTime CreatedAt,
bool IsValid,
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy) : IConvertibleFromEntity<UserRefreshToken, UserRefreshTokenAllResponse>
{
    public static UserRefreshTokenAllResponse FromEntity(UserRefreshToken UserRefreshToken) =>
    new UserRefreshTokenAllResponse(
    UserRefreshToken.UserId,
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

