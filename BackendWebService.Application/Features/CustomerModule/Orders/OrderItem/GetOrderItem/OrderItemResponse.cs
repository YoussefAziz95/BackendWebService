using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record OrderItemResponse(
int OrderId,
int ItemId,
int Quantity,
decimal Total,
DateTime ExpectedTime) : IConvertibleFromEntity<OrderItem, OrderItemResponse>
{
    public static OrderItemResponse FromEntity(OrderItem OrderItem) =>
    new OrderItemResponse(
    OrderItem.OrderId,
    OrderItem.ItemId,
    OrderItem.Quantity,
    OrderItem.Total,
    OrderItem.ExpectedTime);
}
