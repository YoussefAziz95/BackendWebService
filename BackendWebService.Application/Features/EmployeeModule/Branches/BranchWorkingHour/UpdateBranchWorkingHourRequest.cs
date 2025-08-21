using Domain;

namespace Application.Features;
public record UpdateBranchWorkingHourRequest(
   int BranchId,
   DayOfWeek DayOfWeek,
   TimeSpan OpenTime,
  TimeSpan CloseTime,
    bool IsClosed
    );
    