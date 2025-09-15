using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ClientServiceAllRequest(
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
DateTime? CompletedDate,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<ClientServiceAllResponse>>
{
    public IValidator<ClientServiceAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ClientServiceAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

