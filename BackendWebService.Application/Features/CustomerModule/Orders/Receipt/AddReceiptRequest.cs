using Application.Profiles;
using Application.Features;
using Domain;

namespace Application.Features;
public record AddReceiptRequest(
int PaymentMethodId,
DateTime IssuedAt,
PaymentMethod PaymentMethod,
decimal TotalPaid,
List <AddOrderRequest>Order):IConvertibleToEntity<Receipt>
{
public Receipt ToEntity() => new Receipt
{
PaymentMethodId = PaymentMethodId,
IssuedAt = IssuedAt,
PaymentMethod=PaymentMethod,
TotalPaid = TotalPaid,
Orders= Order.Select(x => x.ToEntity()).ToList()};
}
