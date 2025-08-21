namespace Application.Features;
public record AddOrderItemRequest(
int OrderId,
int ItemId,
int Quantity,
decimal Total,
DateTime ExpectedTime
 );
