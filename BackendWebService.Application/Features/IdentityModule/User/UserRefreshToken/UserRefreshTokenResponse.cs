using Domain;

namespace Application.Features;
public record UserRefreshTokenResponse(
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