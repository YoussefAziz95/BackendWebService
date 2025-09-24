using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record CustomerRequest(
int UserId,
RoleEnum Role,
StatusEnum Status,
bool MFAEnabled = false) : IRequest<CustomerResponse>
{
    public IValidator<CustomerRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<CustomerRequest> validator)
    {
        throw new NotImplementedException();
    }
}

