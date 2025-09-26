using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record UserResponse(
string FirstName,
string LastName,
string UserName,
string Email,
string PhoneNumber,
string? Department,
string? Title,
RoleEnum MainRole,
int? OrganizationId,
string? CreatedBy,
DateTime? CreatedDate,
DateTime? UpdatedDate,
string? UpdatedBy,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
List<UserRoleResponse> UserRoles,
List<UserGroupResponse> UserGroups,
List<UserLoginResponse> Logins,
List<UserClaimResponse> Claims,
List<UserTokenResponse> Tokens,
List<UserRefreshTokenResponse> UserRefreshTokens) : IConvertibleFromEntity<User, UserResponse>
{
    public static UserResponse FromEntity(User User) =>
    new UserResponse(
    User.FirstName,
    User.LastName,
    User.UserName,
    User.Email,
    User.PhoneNumber,
    User.Department,
    User.Title,
    User.MainRole,
    User.OrganizationId,
    User.CreatedBy,
    User.CreatedDate,
    User.UpdatedDate,
    User.UpdatedBy,
    User.IsActive,
    User.IsDeleted,
    User.IsSystem,
    User.UserRoles.Select(UserRoleResponse.FromEntity).ToList(),
    User.UserGroups.Select(UserGroupResponse.FromEntity).ToList(),
    User.Logins.Select(UserLoginResponse.FromEntity).ToList(),
    User.Claims.Select(UserClaimResponse.FromEntity).ToList(),
    User.Tokens.Select(UserTokenResponse.FromEntity).ToList(),
    User.UserRefreshTokens.Select(UserRefreshTokenResponse.FromEntity).ToList()



    );
}
