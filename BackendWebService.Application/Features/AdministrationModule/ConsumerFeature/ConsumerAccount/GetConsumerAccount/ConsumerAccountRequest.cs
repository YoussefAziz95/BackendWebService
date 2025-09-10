using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ConsumerAccountRequest(
int CompanyId,
int ConsumerId,
bool IsApproved) : IRequest<ConsumerAccountResponse>
{
    public IValidator<ConsumerAccountRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ConsumerAccountRequest> validator)
    {
        throw new NotImplementedException();
    }
}

