namespace Application.Features;
public record AddTimeSlotRequest(
int Id,
DateTime StartTime,
DateTime EndTime,
int UserId);