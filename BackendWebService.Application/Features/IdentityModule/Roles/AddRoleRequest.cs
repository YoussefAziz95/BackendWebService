using Application.Profiles;
using Domain;

namespace Application.Features;
public record AddRoleRequest(
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
List<AddRoleClaimRequest> Claims,
List<AddUserRoleRequest> Users ):IConvertibleToEntity<Role>
{
public Role ToEntity() => new Role
{
OrganizationId=OrganizationId,
IsActive=IsActive,
IsDeleted=IsDeleted,
IsSystem=IsSystem,
CreatedDate=CreatedDate,
CreatedBy=CreatedBy,
UpdatedDate=UpdatedDate,
UpdatedBy=UpdatedBy,
ParentId=ParentId,
DisplayName=DisplayName,
Claims= Claims.Select(x => x.ToEntity()).ToList(),
Users= Users.Select(x => x.ToEntity()).ToList()
};
}