using Application.Profiles;
using Application.Features;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record UpdateReceiptRequest(
int PaymentMethodId,
DateTime IssuedAt,
PaymentMethod PaymentMethod,
decimal TotalPaid,
List<UpdateOrderRequest> Order):IConvertibleToEntity<Receipt>
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
