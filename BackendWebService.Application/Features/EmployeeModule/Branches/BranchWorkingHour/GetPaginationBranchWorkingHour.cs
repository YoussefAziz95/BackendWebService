using Domain;

namespace Application.Features;
public record GetPaginatedBranchWorkingHour(
   int BranchId,
   DayOfWeek DayOfWeek,
   TimeSpan OpenTime,
  TimeSpan CloseTime,
    bool IsClosed
    );