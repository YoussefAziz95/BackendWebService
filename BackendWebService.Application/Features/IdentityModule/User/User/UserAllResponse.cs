using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record UserAllResponse(
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
bool? IsSystem) : IConvertibleFromEntity<User, UserAllResponse>
{
public static UserAllResponse FromEntity(User User) =>
new UserAllResponse(
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
User.IsSystem
);
}

