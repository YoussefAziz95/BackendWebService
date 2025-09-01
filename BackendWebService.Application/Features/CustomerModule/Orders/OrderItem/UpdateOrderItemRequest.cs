using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record UpdateOrderItemRequest(
int OrderId,
int ItemId,
int Quantity,
decimal Total,
DateTime ExpectedTime):IConvertibleToEntity<OrderItem>
{
public OrderItem ToEntity() => new OrderItem
{
OrderId = OrderId,
ItemId = ItemId,
Quantity = Quantity,
Total = Total,
ExpectedTime = ExpectedTime
};
}
