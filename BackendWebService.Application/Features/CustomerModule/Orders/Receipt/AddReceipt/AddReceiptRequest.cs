using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record AddReceiptRequest(
int PaymentMethodId,
DateTime IssuedAt,
PaymentMethod PaymentMethod,
decimal TotalPaid,
List<AddOrderRequest> Order) : IConvertibleToEntity<Receipt>, IRequest<int>
{
    public Receipt ToEntity() => new Receipt
    {
        PaymentMethodId = PaymentMethodId,
        IssuedAt = IssuedAt,
        PaymentMethod = PaymentMethod,
        TotalPaid = TotalPaid,
        Orders = Order.Select(x => x.ToEntity()).ToList()
    };
}
