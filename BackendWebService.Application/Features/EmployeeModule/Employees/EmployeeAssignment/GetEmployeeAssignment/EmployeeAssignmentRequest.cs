using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record EmployeeAssignmentRequest(
int EmployeeId,
int JobId,
DateTime AssignedDate,
StatusEnum Status,
DateTime? EmployeeResponseDate,
string? AdminNotes) : IRequest<EmployeeAssignmentResponse>
{
public IValidator<EmployeeAssignmentRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<EmployeeAssignmentRequest> validator)
{
throw new NotImplementedException();
}
}

