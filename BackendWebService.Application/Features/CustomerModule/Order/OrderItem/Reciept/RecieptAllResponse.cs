namespace Application.Features;
public record RecieptAllResponse(
int PaymentMethodId,
DateTime IssuedAt,
decimal TotalPaid
);
