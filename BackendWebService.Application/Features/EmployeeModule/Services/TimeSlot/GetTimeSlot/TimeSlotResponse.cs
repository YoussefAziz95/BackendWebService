using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record TimeSlotResponse(
int Id,
DateTime StartTime,
DateTime EndTime,
int UserId) : IConvertibleFromEntity<TimeSlot, TimeSlotResponse>
{
    public static TimeSlotResponse FromEntity(TimeSlot TimeSlot) =>
    new TimeSlotResponse(
    TimeSlot.Id,
    TimeSlot.StartTime,
    TimeSlot.EndTime,
    TimeSlot.UserId);
}