using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record OfferItemRequest(
int Quantity,
int? RequiredAmount,
int ServiceId,
int OfferId) : IRequest<OfferItemResponse>
{
    public IValidator<OfferItemRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<OfferItemRequest> validator)
    {
        throw new NotImplementedException();
    }
}

