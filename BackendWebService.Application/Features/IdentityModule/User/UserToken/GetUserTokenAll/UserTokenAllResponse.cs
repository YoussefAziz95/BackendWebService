using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record UserTokenAllResponse(
DateTime GeneratedTime,
int Id,
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy) : IConvertibleFromEntity<UserToken, UserTokenAllResponse>
{
    public static UserTokenAllResponse FromEntity(UserToken UserToken) =>
    new UserTokenAllResponse(
    UserToken.GeneratedTime,
    UserToken.Id,
    UserToken.OrganizationId,
    UserToken.IsActive,
    UserToken.IsDeleted,
    UserToken.IsSystem,
    UserToken.CreatedDate,
    UserToken.CreatedBy,
    UserToken.UpdatedDate,
    UserToken.UpdatedBy
    );
}

