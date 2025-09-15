using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record OrderItemAllResponse(
int OrderId,
int ItemId,
int Quantity,
decimal Total,
DateTime ExpectedTime) : IConvertibleFromEntity<OrderItem, OrderItemAllResponse>
{
    public static OrderItemAllResponse FromEntity(OrderItem OrderItem) =>
    new OrderItemAllResponse(
    OrderItem.OrderId,
    OrderItem.ItemId,
    OrderItem.Quantity,
    OrderItem.Total,
    OrderItem.ExpectedTime);
}
