using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ReceiptRequest(
int PaymentMethodId,
DateTime IssuedAt,
decimal TotalPaid) : IRequest<ReceiptResponse>
{
    public IValidator<ReceiptRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ReceiptRequest> validator)
    {
        throw new NotImplementedException();
    }
}

