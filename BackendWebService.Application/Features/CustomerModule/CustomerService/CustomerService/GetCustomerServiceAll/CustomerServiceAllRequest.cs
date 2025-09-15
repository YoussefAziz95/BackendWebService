using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record CustomerServiceAllRequest(
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
int? HandledByUserId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<CustomerServiceAllResponse>>
{
    public IValidator<CustomerServiceAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<CustomerServiceAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

