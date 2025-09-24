using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record PaymentMethodRequest(
int UserId,
string MethodType,
string Provider,
string AccountNumber,
string Name,
PaymentEnum Type,
bool IsDefault,
bool IsVerified,
DateTime? ExpiryDate,
DateTime CreatedAt,
DateTime? UpdatedAt) : IRequest<PaymentMethodResponse>
{
    public IValidator<PaymentMethodRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<PaymentMethodRequest> validator)
    {
        throw new NotImplementedException();
    }
}

