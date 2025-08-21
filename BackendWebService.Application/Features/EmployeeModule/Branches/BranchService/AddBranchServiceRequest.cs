using Domain;

namespace Application.Features;
public record AddBranchServiceRequest(
   int BranchId,
    int ServiceId,
    string? Notes,
  bool IsActive  
    );