using Application.Profiles;
using Domain;

namespace Application.Features;
public record AddUserRefreshTokenRequest(
int UserId,
AddUserRequest User,
DateTime CreatedAt,
bool IsValid,
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy):IConvertibleToEntity<UserRefreshToken>
{
public UserRefreshToken ToEntity() => new UserRefreshToken
{
UserId = UserId,
User= User,
CreatedAt = CreatedAt,
IsValid=IsValid,
OrganizationId = OrganizationId,
IsActive = IsActive,
IsDeleted = IsDeleted,
IsSystem = IsSystem,
CreatedDate = CreatedDate,
CreatedBy = CreatedBy,
UpdatedDate = UpdatedDate,
UpdatedBy= UpdatedBy

};
}