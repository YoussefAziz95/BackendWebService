using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddTimeSlotRequest(
int Id,
DateTime StartTime,
DateTime EndTime,
int UserId) : IConvertibleToEntity<TimeSlot>, IRequest<int>
{
    public TimeSlot ToEntity() => new TimeSlot
    {
        Id = Id,
        StartTime = StartTime,
        EndTime = EndTime,
        UserId = UserId
    };
}