namespace Application.Features;
public record AddRecieptRequest(
int PaymentMethodId,
DateTime IssuedAt,
decimal TotalPaid,
List <AddOrderRequest>OrderRequests
 );
