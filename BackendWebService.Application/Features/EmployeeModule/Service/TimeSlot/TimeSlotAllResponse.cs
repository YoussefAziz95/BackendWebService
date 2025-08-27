using Domain.Enums;

namespace Application.Features;
public record TimeSlotAllResponse(
int Id,
DateTime StartTime,
DateTime EndTime,
int UserId);

