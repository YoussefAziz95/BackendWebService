using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record EmployeeServiceAllRequest(
int? EmployeeId,
int? CustomerServiceId,
string? Notes,
int? VoiceNoteId,
int? FilesId,
string Description,
string? AdditionalPhoneNumber,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<EmployeeServiceAllResponse>>
{
    public IValidator<EmployeeServiceAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<EmployeeServiceAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

