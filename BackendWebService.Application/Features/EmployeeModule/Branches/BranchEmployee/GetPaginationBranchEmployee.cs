using Domain;

namespace Application.Features;
public record GetPaginatedBranchEmployee(
  int BranchId,
    int UserId,
   string? JobTitle,
   string PhoneNumber,
    string? WebsiteUrl,
    bool IsActive,
    DateTime AssignedAt
    );