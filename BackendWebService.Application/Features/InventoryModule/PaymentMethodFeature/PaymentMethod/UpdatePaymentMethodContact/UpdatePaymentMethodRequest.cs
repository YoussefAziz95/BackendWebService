using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record UpdatePaymentMethodRequest(
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
DateTime? UpdatedAt) : IConvertibleToEntity<PaymentMethod>, IRequest<int>
{
    public PaymentMethod ToEntity() => new PaymentMethod
    {
        UserId = UserId,
        MethodType = MethodType,
        Provider = Provider,
        AccountNumber = AccountNumber,
        Name = Name,
        Type = Type,
        IsDefault = IsDefault,
        IsVerified = IsVerified,
        ExpiryDate = ExpiryDate,
        CreatedAt = CreatedAt,
        UpdatedAt = UpdatedAt
    };
}