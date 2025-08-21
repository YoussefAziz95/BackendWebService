using Domain;

namespace Application.Features;
public record BranchWorkingHourResponse(
   int BranchId,
   DayOfWeek DayOfWeek,
   TimeSpan OpenTime,
  TimeSpan CloseTime,
    bool IsClosed
    );