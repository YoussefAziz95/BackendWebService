using Application.Contracts.Features;
using Application.Profiles;
using Domain.Enums;
namespace Application.Features;
public record UpdateClientServiceRequest(
int CustomerId,
UpdateClientRequest Customer,
int? ServiceId,
UpdateServiceRequest? Service,
int? PropertyId,
UpdatePropertyRequest? Property,
string? Notes,
int? VoiceNoteId,
UpdateFileLogRequest? VoiceNote,
int? FilesId,
UpdateFileLogRequest? Files,
StatusEnum Status,
string Description,
DateTime RequestedDate,
DateTime? ScheduledDate,
DateTime? CompletedDate) : IConvertibleToEntity<ClientService>, IRequest<int>
{
    public ClientService ToEntity() => new ClientService
    {
        CustomerId = CustomerId,
        Customer = Customer.ToEntity(),
        ServiceId = ServiceId,
        Service = Service.ToEntity(),
        PropertyId = PropertyId,
        Property = Property.ToEntity(),
        Notes = Notes,
        VoiceNoteId = VoiceNoteId,
        VoiceNote = VoiceNote.ToEntity(),
        FilesId = FilesId,
        Files = Files.ToEntity(),
        Status = Status,
        Description = Description,
        RequestedDate = RequestedDate,
        ScheduledDate = ScheduledDate,
        CompletedDate = CompletedDate

    };
}