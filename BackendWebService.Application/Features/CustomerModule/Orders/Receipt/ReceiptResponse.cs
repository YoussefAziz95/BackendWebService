using Application.Profiles;
using Application.Features;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record ReceiptResponse(
int PaymentMethodId,
DateTime IssuedAt,
PaymentMethod PaymentMethod,
decimal TotalPaid,
List<OrderResponse> OrdersResponse):IConvertibleFromEntity<Receipt, ReceiptResponse>        
{
public static ReceiptResponse FromEntity(Receipt Receipt) =>
new ReceiptResponse(
Receipt.PaymentMethodId,
Receipt.IssuedAt,
Receipt.PaymentMethod,
Receipt.TotalPaid,
Receipt.Orders.Select(OrderResponse.FromEntity).ToList());
}
