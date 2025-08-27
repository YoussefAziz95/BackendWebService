namespace Application.Features;
public record AddRoleClaimRequest(
string? ClaimType,
string? ClaimValue,
DateTime? CreatedDate,
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy);