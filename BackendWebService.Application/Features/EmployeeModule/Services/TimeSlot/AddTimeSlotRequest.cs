using Application.Profiles;
using Domain;

namespace Application.Features;
public record AddTimeSlotRequest(
int Id,
DateTime StartTime,
DateTime EndTime,
int UserId):IConvertibleToEntity<TimeSlot>
{
public TimeSlot ToEntity() => new TimeSlot
{
Id = Id,
StartTime = StartTime,
EndTime = EndTime,
UserId = UserId};
}