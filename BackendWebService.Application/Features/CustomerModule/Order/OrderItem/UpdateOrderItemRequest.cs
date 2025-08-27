using Domain.Enums;

namespace Application.Features;
public record UpdateOrderItemRequest(
int OrderId,
int ItemId,
int Quantity,
decimal Total,
DateTime ExpectedTime);