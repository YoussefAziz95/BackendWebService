using Domain;
using Domain.Enums;

namespace Application.Features;
public record UserRoleAllResponse(
User User,
Role Role,
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy);

