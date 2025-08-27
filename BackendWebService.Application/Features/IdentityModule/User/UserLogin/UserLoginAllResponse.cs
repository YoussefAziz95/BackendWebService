using Domain.Enums;

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
string? UpdatedBy);

