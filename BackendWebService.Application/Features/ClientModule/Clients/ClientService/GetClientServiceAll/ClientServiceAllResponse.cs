using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record ClientServiceAllResponse(
int CustomerId,
int? ServiceId,
int? PropertyId,
string? Notes,
int? VoiceNoteId,
int? FilesId,
StatusEnum Status,
string Description,
DateTime RequestedDate,
DateTime? ScheduledDate,
DateTime? CompletedDate) : IConvertibleFromEntity<ClientService, ClientServiceAllResponse>
{
public static ClientServiceAllResponse FromEntity(ClientService ClientService) =>
new ClientServiceAllResponse(
ClientService.CustomerId,
ClientService.ServiceId,
ClientService.PropertyId,
ClientService.Notes,
ClientService.VoiceNoteId,
ClientService.FilesId,
ClientService.Status,
ClientService.Description,
ClientService.RequestedDate,
ClientService.ScheduledDate,
ClientService.CompletedDate);
}
