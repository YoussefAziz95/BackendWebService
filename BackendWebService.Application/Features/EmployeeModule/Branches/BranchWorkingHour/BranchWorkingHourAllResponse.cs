using Domain;
using Domain.Enums;

namespace Application.Features;
public record BranchWorkingHourAllResponse(
    int BranchId,
   DayOfWeek DayOfWeek,
   TimeSpan OpenTime,
  TimeSpan CloseTime,
    bool IsClosed
 );
