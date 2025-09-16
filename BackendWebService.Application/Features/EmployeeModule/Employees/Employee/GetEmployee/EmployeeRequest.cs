using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record EmployeeRequest(
int UserId,
DateTime RegistrationDate,
StatusEnum AccountStatus,
bool IsAvailable,
RoleEnum Role) : IRequest<EmployeeResponse>
{
public IValidator<EmployeeRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<EmployeeRequest> validator)
{
throw new NotImplementedException();
}
}

