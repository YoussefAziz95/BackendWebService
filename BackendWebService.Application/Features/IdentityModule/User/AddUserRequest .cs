using Application.Profiles;
using Domain;
using Org.BouncyCastle.Asn1.Cms;

namespace Application.Features;
public record AddUserRequest
(string FirstName, 
string LastName,
string UserName,
string Email,
string PhoneNumber, 
string? Department,
string? Title,
string MainRole,
int? OrganizationId,
string? CreatedBy,
DateTime? CreatedDate,
DateTime? UpdatedDate,
string? UpdatedBy,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
List<AddUserRoleRequest> UserRoles,
List<AddUserGroupsRequest> UserGroups,
List<AddUserLoginRequest> Logins,
List<AddUserClaimRequest> Claims,
List<AddUserTokenRequest> Tokens,
List<AddUserRefreshTokenRequest> UserRefreshTokens) : IConvertibleToEntity<User>
{
    public User ToEntity() => throw new NotImplementedException();
}