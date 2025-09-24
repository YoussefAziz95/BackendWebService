using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record EmployeeAccountRequest(
int EmployeeId,
bool IsActive,
DateTime CreatedAt,
DateTime? UpdatedAt) : IRequest<EmployeeAccountResponse>
{
    public IValidator<EmployeeAccountRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<EmployeeAccountRequest> validator)
    {
        throw new NotImplementedException();
    }
}

