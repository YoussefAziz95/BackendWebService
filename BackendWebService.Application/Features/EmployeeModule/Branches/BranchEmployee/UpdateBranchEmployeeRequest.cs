using Domain;

namespace Application.Features;
public record UpdateBranchEmployeeRequest(
 int BranchId,
    int UserId,
   string? JobTitle,
   string PhoneNumber,
    string? WebsiteUrl,
    bool IsActive,
    DateTime AssignedAt
    );