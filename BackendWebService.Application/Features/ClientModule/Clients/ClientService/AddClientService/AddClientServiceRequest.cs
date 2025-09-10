using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record AddClientServiceRequest(
int CustomerId,
AddClientRequest Customer,
int? ServiceId,
AddServiceRequest? Service,
int? PropertyId,
AddPropertyRequest? Property,
string? Notes,
int? VoiceNoteId,
AddFileLogRequest? VoiceNote,
int? FilesId,
AddFileLogRequest? Files,
StatusEnum Status,
string Description,
DateTime RequestedDate,
DateTime? ScheduledDate,
DateTime? CompletedDate) :IConvertibleToEntity<ClientService>
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
VoiceNote= VoiceNote.ToEntity(),
FilesId = FilesId,
Files= Files.ToEntity(),
Status = Status,
Description = Description,
RequestedDate = RequestedDate,
ScheduledDate = ScheduledDate,
CompletedDate = CompletedDate

};
}