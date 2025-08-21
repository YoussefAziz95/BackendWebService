using Domain;
using Domain.Enums;

namespace Application.Features;
public record BranchServiceAllResponse(
 int BranchId,
    int ServiceId,
    string? Notes,
  bool IsActive
 );
