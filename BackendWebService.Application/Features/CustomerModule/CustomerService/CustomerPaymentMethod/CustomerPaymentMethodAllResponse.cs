using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record CustomerPaymentMethodAllResponse(
int CustomerId,
int PaymentMethodId,
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
int? UpdatedByUserId): IConvertibleFromEntity<CustomerPaymentMethod, CustomerPaymentMethodAllResponse>        
{
public static CustomerPaymentMethodAllResponse FromEntity(CustomerPaymentMethod CustomerPaymentMethod) =>
new CustomerPaymentMethodAllResponse(
CustomerPaymentMethod.CustomerId,
CustomerPaymentMethod.PaymentMethodId,
CustomerPaymentMethod.ServiceId,
CustomerPaymentMethod.PropertyId,
CustomerPaymentMethod.Notes,
CustomerPaymentMethod.VoiceNoteId,
CustomerPaymentMethod.FilesId,
CustomerPaymentMethod.Status,
CustomerPaymentMethod.Description,
CustomerPaymentMethod.RequestedDate,
CustomerPaymentMethod.ScheduledDate,
CustomerPaymentMethod.CompletedDate,
CustomerPaymentMethod.UpdatedByUserId);
}
