using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record RolesResponse(
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
List<UpdateRoleClaimRequest> Claims,
List<UpdateUserRoleRequest> Users);