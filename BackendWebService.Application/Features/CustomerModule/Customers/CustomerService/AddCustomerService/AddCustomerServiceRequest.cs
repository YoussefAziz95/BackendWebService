using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record AddCustomerServiceRequest(
int CustomerId,
int ServiceId,
int? PropertyId,
string? Notes,
int? VoiceNoteId,
int? FilesId,
StatusEnum Status,
string Description,
DateTime RequestedDate,
DateTime? ScheduledDate,
DateTime? CompletedDate,
int? HandledByUserId) : IConvertibleToEntity<CustomerService>, IRequest<int>
{
    public CustomerService ToEntity() => new CustomerService
    {
        CustomerId = CustomerId,
        ServiceId = ServiceId,
        PropertyId = PropertyId,
        Notes = Notes,
        VoiceNoteId = VoiceNoteId,
        FilesId = FilesId,
        Status = Status,
        Description = Description,
        RequestedDate = RequestedDate,
        ScheduledDate = ScheduledDate,
        CompletedDate = CompletedDate,
        HandledByUserId = HandledByUserId
    };
}