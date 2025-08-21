using Domain;

namespace Application.Features;
public record BranchServiceResponse(
 int BranchId,
    int ServiceId,
    string? Notes,
  bool IsActive
    );