using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record CustomerServiceResponse(
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
int? HandledByUserId):IConvertibleFromEntity<CustomerService, CustomerServiceResponse>        
{
public static CustomerServiceResponse FromEntity(CustomerService CustomerService) =>
new CustomerServiceResponse(
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

