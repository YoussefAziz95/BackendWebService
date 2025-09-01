using Application.Profiles;
using Domain;

namespace Application.Features;
public record ReceiptAllResponse(
int PaymentMethodId,
PaymentMethod PaymentMethod,
DateTime IssuedAt,
decimal TotalPaid): IConvertibleFromEntity<Receipt, ReceiptAllResponse>        
{
public static ReceiptAllResponse FromEntity(Receipt Receipt) =>
new ReceiptAllResponse(
Receipt.PaymentMethodId,
Receipt.PaymentMethod,
Receipt.IssuedAt,
Receipt.TotalPaid);
}
