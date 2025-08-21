using Domain;

namespace Application.Features;
public record UpdateBranchServiceRequest(
 int BranchId,
    int ServiceId,
    string? Notes,
  bool IsActive
    );
    