using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record UserLoginResponse(
UserResponse User,
int? OrganizationId,
DateTime LoggedOn,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy) : IConvertibleFromEntity<UserLogin, UserLoginResponse>
{
    public static UserLoginResponse FromEntity(UserLogin UserLogin) =>
    new UserLoginResponse(
    UserResponse.FromEntity(UserLogin.User),
    UserLogin.OrganizationId,
    UserLogin.LoggedOn,
    UserLogin.IsActive,
    UserLogin.IsDeleted,
    UserLogin.IsSystem,
    UserLogin.CreatedDate,
    UserLogin.CreatedBy,
    UserLogin.UpdatedDate,
    UserLogin.UpdatedBy);

}