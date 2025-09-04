using Application.Profiles;
using Domain;

namespace Application.Features;
public record RoleResponse(
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy,
int? ParentId,
string DisplayName,
List<RoleClaimResponse> Claims,
List<UserRoleResponse> Users) : IConvertibleFromEntity<Role, RoleResponse>
{
    public static RoleResponse FromEntity(Role entity) =>  throw new NotImplementedException();
    

};