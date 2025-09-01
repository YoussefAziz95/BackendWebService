using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record AddCustomerPaymentMethodRequest(
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
int? UpdatedByUserId):IConvertibleToEntity<CustomerPaymentMethod>
{
public CustomerPaymentMethod ToEntity() => new CustomerPaymentMethod
{
CustomerId = CustomerId,
PaymentMethodId = PaymentMethodId,
ServiceId = ServiceId,
PropertyId = PropertyId,
Notes = Notes,
VoiceNoteId = VoiceNoteId,
FilesId = FilesId,
Status= Status,
Description = Description,
RequestedDate = RequestedDate,
ScheduledDate = ScheduledDate,
CompletedDate = CompletedDate,
UpdatedByUserId = UpdatedByUserId
};
}
