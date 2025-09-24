using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features; 
public record PaymentMethodAllResponse(
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
DateTime? UpdatedAt) : IConvertibleFromEntity<PaymentMethod, PaymentMethodAllResponse>
{
    public static PaymentMethodAllResponse FromEntity(PaymentMethod PaymentMethod) =>
    new PaymentMethodAllResponse(
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

