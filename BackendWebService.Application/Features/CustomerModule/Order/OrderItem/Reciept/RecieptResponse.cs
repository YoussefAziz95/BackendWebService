using Domain.Enums;

namespace Application.Features;
public record RecieptResponse(
int PaymentMethodId,
DateTime IssuedAt,
decimal TotalPaid,
List<AddOrderRequest> OrderRequests
    );