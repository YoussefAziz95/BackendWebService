using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record EmployeeServiceRequest(
int? EmployeeId,
int? CustomerServiceId,
string? Notes,
int? VoiceNoteId,
int? FilesId,
string Description,
string? AdditionalPhon) : IRequest<EmployeeServiceResponse>
{
    public IValidator<EmployeeServiceRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<EmployeeServiceRequest> validator)
    {
        throw new NotImplementedException();
    }
}

