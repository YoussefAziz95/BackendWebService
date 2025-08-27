using Domain;
using Domain.Enums;

namespace Application.Features;
public record UserRefreshTokenAllResponse(
int UserId,
User User,
DateTime CreatedAt,
bool IsValid,
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy);

