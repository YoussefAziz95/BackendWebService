using Domain;
using Domain.Enums;

namespace Application.Features;
public record BranchEmployeeAllResponse(
 int BranchId,
    int UserId,
   string? JobTitle,
   string PhoneNumber,
    string? WebsiteUrl,
    bool IsActive,
    DateTime AssignedAt
 );
