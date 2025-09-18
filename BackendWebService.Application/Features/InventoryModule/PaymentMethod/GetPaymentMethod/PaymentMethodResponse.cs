using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record PaymentMethodResponse(
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
DateTime? UpdatedAt) : IConvertibleFromEntity<PaymentMethod, PaymentMethodResponse>
{
    public static PaymentMethodResponse FromEntity(PaymentMethod PaymentMethod) =>
    new PaymentMethodResponse(
    PaymentMethod.UserId,
    PaymentMethod.MethodType,
    PaymentMethod.Provider,
    PaymentMethod.AccountNumber,
    PaymentMethod.Name,
    PaymentMethod.Type,
    PaymentMethod.IsDefault,
    PaymentMethod.IsVerified,
    PaymentMethod.ExpiryDate,
    PaymentMethod.CreatedAt,
    PaymentMethod.UpdatedAt
    );
}