namespace Application.Features;
public record OrderItemAllResponse(
int OrderId,
int ItemId,
int Quantity,
decimal Total,
DateTime ExpectedTime
);
