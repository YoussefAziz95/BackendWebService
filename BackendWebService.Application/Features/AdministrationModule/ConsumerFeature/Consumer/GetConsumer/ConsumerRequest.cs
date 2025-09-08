using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ConsumerRequest(
int OrganizationId,
decimal? Rating,
string? BankAccount) : IRequest<ConsumerResponse>
{
    public IValidator<ConsumerRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ConsumerRequest> validator)
    {
        throw new NotImplementedException();
    }
}

