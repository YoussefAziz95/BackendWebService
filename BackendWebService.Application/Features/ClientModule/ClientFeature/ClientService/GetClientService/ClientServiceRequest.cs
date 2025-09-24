using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ClientServiceRequest(
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
DateTime? CompletedDate) : IRequest<ClientServiceResponse>
{
    public IValidator<ClientServiceRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ClientServiceRequest> validator)
    {
        throw new NotImplementedException();
    }
}

