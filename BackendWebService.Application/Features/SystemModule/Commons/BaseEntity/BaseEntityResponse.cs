using Domain.Enums;

namespace Application.Features;
public record BaseEntityResponse(
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
DateTime? UpdatedDate,
string? CreatedBy,
string? UpdatedBy);