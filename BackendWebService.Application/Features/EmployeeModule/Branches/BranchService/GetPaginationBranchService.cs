using Domain;

namespace Application.Features;
public record GetPaginatedBranchService(
   int BranchId,
    int ServiceId,
    string? Notes,
  bool IsActive
    );