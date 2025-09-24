using Application.Profiles;
using Domain;

namespace Application.Features;
public record UserLoginAllResponse(
int? OrganizationId,
DateTime LoggedOn,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy) : IConvertibleFromEntity<UserLogin, UserLoginAllResponse>
{
    public static UserLoginAllResponse FromEntity(UserLogin UserLogin) =>
    new UserLoginAllResponse(
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