using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record UpdateUserRequest(
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
List<UpdateUserRoleRequest> UserRoles,
List<UpdateUserGroupRequest> UserGroups,
List<UpdateUserLoginRequest> Logins,
List<UpdateUserClaimRequest> Claims,
List<UpdateUserTokenRequest> Tokens,
List<UpdateUserRefreshTokenRequest> UserRefreshTokens) : IConvertibleToEntity<User>
{
public User ToEntity() => new User
{
FirstName = FirstName,
LastName = LastName,
UserName = UserName,
Email = Email,
PhoneNumber = PhoneNumber,
Department = Department,
Title = Title,
MainRole = MainRole,
OrganizationId = OrganizationId,
CreatedBy = CreatedBy,
CreatedDate = CreatedDate,
UpdatedDate = UpdatedDate,
UpdatedBy = UpdatedBy,
IsActive = IsActive,
IsDeleted = IsDeleted,
IsSystem = IsSystem,
UserRoles = UserRoles.Select(x => x.ToEntity()).ToList(),
UserGroups = UserGroups.Select(x => x.ToEntity()).ToList(),
Logins = Logins.Select(x => x.ToEntity()).ToList(),
Claims = Claims.Select(x => x.ToEntity()).ToList(),
Tokens = Tokens.Select(x => x.ToEntity()).ToList(),
UserRefreshTokens = UserRefreshTokens.Select(x => x.ToEntity()).ToList()
};
}

