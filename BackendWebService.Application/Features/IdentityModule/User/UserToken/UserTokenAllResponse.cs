using Domain;
using Domain.Enums;

namespace Application.Features;
public record UserTokenAllResponse(
User User,
DateTime GeneratedTime,
int Id,
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy);

