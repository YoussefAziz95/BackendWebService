using Application.Contracts.Features;
using Application.Profiles;
using Domain;
namespace Application.Features;
public record UpdateReceiptRequest(
int PaymentMethodId,
DateTime IssuedAt,
PaymentMethod PaymentMethod,
decimal TotalPaid,
List<UpdateOrderRequest> Order) : IConvertibleToEntity<Receipt>, IRequest<int>
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
