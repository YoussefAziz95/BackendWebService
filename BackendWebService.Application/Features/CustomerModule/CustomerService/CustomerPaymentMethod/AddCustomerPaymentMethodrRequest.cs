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
int? UpdatedByUserId
    );
