using Application.Profiles;
using Domain;

namespace Application.Features;
public record OrderResponse(
int TableId,
decimal Total,
decimal Price,
decimal Tax,
decimal Service,
DateTime CreatedAt,
int UserId,
string OrderName,
List<OrderItemResponse> OrderItemsResponse) : IConvertibleFromEntity<Order, OrderResponse>
{
    public static OrderResponse FromEntity(Order Order) =>
    new OrderResponse(
    Order.TableId,
    Order.Total,
    Order.Price,
    Order.Tax,
    Order.Service,
    Order.CreatedAt,
    Order.UserId,
    Order.OrderName,
    Order.OrderItems.Select(OrderItemResponse.FromEntity).ToList());
}
