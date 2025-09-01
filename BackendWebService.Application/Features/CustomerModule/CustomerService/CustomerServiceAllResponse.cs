using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record CustomerServiceAllResponse(
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
int? HandledByUserId):IConvertibleFromEntity<CustomerService, CustomerServiceAllResponse>        
{
public static CustomerServiceAllResponse FromEntity(CustomerService CustomerService) =>
new CustomerServiceAllResponse(
CustomerService.CustomerId,
CustomerService.ServiceId,
CustomerService.PropertyId,
CustomerService.Notes,
CustomerService.VoiceNoteId,
CustomerService.FilesId,
CustomerService.Status,
CustomerService.Description,
CustomerService.RequestedDate,
CustomerService.ScheduledDate,
CustomerService.CompletedDate,
CustomerService.HandledByUserId);
}
