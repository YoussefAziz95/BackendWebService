using Application.Profiles;
using Domain;

namespace Application.Features;
public record TimeSlotAllResponse(
int Id,
DateTime StartTime,
DateTime EndTime,
int UserId) : IConvertibleFromEntity<TimeSlot, TimeSlotAllResponse>
{
    public static TimeSlotAllResponse FromEntity(TimeSlot TimeSlot) =>
    new TimeSlotAllResponse(
    TimeSlot.Id,
    TimeSlot.StartTime,
    TimeSlot.EndTime,
    TimeSlot.UserId);
}

