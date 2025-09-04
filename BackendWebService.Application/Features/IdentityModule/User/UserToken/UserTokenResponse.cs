using Application.Profiles;
using Domain;

namespace Application.Features;
public record UserTokenResponse(
UserResponse User,
DateTime GeneratedTime,
int Id,
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy): IConvertibleFromEntity<UserToken, UserTokenResponse>        
{
public static UserTokenResponse FromEntity(UserToken UserToken) =>
new UserTokenResponse(
UserToken.User.ToEntity(),
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