using Domain.Enums;

namespace Application.Features;
public record UpdateRecieptRequest(
int PaymentMethodId,
DateTime IssuedAt,
decimal TotalPaid,
List<AddOrderRequest> OrderRequests
    );