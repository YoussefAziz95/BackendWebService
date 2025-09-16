using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ConsumerCustomerRequest(
int ConsumerId,
int CategoryId) : IRequest<ConsumerCustomerResponse>
{
    public IValidator<ConsumerCustomerRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ConsumerCustomerRequest> validator)
    {
        throw new NotImplementedException();
    }
}

