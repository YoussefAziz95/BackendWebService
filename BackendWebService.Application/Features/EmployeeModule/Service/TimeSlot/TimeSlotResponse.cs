namespace Application.Features;
public record TimeSlotResponse(
int Id,
DateTime StartTime,
DateTime EndTime,
int UserId);