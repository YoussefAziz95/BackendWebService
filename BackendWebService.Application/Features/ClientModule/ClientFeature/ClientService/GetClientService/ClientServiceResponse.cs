using Application.Profiles;
using Domain.Enums;

namespace Application.Features;
public record ClientServiceResponse(
int CustomerId,
ClientResponse Customer,
int? ServiceId,
ServiceResponse? Service,
int? PropertyId,
PropertyResponse? Property,
string? Notes,
int? VoiceNoteId,
FileLogResponse? VoiceNote,
int? FilesId,
FileLogResponse? Files,
StatusEnum Status,
string Description,
DateTime RequestedDate,
DateTime? ScheduledDate,
DateTime? CompletedDate) : IConvertibleFromEntity<ClientService, ClientServiceResponse>
{
    public static ClientServiceResponse FromEntity(ClientService ClientService) =>
    new ClientServiceResponse(
    ClientService.CustomerId,
    ClientResponse.FromEntity(ClientService.Customer),
    ClientService.ServiceId,
    ServiceResponse.FromEntity(ClientService.Service),
    ClientService.PropertyId,
    PropertyResponse.FromEntity(ClientService.Property),
    ClientService.Notes,
    ClientService.VoiceNoteId,
    FileLogResponse.FromEntity(ClientService.VoiceNote),
    ClientService.FilesId,
    FileLogResponse.FromEntity(ClientService.Files),
    ClientService.Status,
    ClientService.Description,
    ClientService.RequestedDate,
    ClientService.ScheduledDate,
    ClientService.CompletedDate);
}
