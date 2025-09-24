using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record CustomerPaymentMethodRequest(
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
int? UpdatedByUserId) : IRequest<CustomerPaymentMethodResponse>
{
    public IValidator<CustomerPaymentMethodRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<CustomerPaymentMethodRequest> validator)
    {
        throw new NotImplementedException();
    }
}

