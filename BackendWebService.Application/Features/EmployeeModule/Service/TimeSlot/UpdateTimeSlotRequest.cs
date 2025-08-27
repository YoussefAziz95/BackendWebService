namespace Application.Features;
public record UpdateTimeSlotRequest(
int Id,
DateTime StartTime,
DateTime EndTime,
int UserId);