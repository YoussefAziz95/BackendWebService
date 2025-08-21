using Domain;

namespace Application.Features;
public record AddBranchWorkingHourRequest(
   int BranchId,
   DayOfWeek DayOfWeek,
   TimeSpan OpenTime,
  TimeSpan CloseTime,
    bool IsClosed
    );