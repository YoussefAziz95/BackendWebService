using Application.Profiles;
using Domain;

namespace Application.Features;
public record UpdateUserLoginRequest(
UpdateUserLoginRequest UserLogin,
UpdateUserRequest User,
int? OrganizationId,
DateTime LoggedOn,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy):IConvertibleToEntity<UserLogin>
{
public UserLogin ToEntity() => new UserLogin
{
User = User.ToEntity(),
OrganizationId = OrganizationId,
LoggedOn = LoggedOn,
IsActive = IsActive,
IsDeleted = IsDeleted,
IsSystem = IsSystem,
CreatedDate = CreatedDate,
CreatedBy = CreatedBy,
UpdatedDate = UpdatedDate,
UpdatedBy = UpdatedBy,


};
}