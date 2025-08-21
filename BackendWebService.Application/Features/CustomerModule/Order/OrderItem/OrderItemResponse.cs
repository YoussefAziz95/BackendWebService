using Domain.Enums;

namespace Application.Features;
public record OrderItemResponse(
int OrderId,
int ItemId,
int Quantity,
decimal Total,
DateTime ExpectedTime
    );