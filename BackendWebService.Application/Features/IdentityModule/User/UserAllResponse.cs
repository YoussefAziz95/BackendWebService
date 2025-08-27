using Domain.Enums;

namespace Application.Features;
public record UserAllResponse(
string FirstName,
string LastName,
string UserName,
string Email,
string PhoneNumber,
string? Department,
string? Title,
string MainRole,
int? OrganizationId,
string? CreatedBy,
DateTime? CreatedDate,
DateTime? UpdatedDate,
string? UpdatedBy,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem);

