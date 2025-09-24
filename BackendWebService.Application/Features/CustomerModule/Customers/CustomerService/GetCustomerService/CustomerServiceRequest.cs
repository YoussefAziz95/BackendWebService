using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record CustomerServiceRequest(
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
int? HandledByUserId) : IRequest<CustomerServiceResponse>
{
    public IValidator<CustomerServiceRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<CustomerServiceRequest> validator)
    {
        throw new NotImplementedException();
    }
}

