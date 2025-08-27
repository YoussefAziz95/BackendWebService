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
List<AddUserRoleRequest> Users );