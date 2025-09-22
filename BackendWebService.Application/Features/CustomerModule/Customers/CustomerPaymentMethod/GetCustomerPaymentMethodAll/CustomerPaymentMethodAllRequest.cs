using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record CustomerPaymentMethodAllRequest(
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
int? UpdatedByUserId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<CustomerPaymentMethodAllResponse>>
{
    public IValidator<CustomerPaymentMethodAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<CustomerPaymentMethodAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

