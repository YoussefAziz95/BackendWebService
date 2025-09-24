using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record DealDetailsRequest(
int DealId,
int OfferItemId,
int Quantity,
decimal DetailPrice,
decimal ItemPrice) : IRequest<DealDetailsResponse>
{
    public IValidator<DealDetailsRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<DealDetailsRequest> validator)
    {
        throw new NotImplementedException();
    }
}

