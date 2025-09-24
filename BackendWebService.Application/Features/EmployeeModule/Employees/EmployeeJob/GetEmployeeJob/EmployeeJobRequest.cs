using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record EmployeeJobRequest(
int EmployeeId,
int JobId,
DateTime AssignedDate,
StatusEnum Status,
DateTime? CompletionDate,
string? Notes) : IRequest<EmployeeJobResponse>
{
    public IValidator<EmployeeJobRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<EmployeeJobRequest> validator)
    {
        throw new NotImplementedException();
    }
}

