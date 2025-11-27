using Application.Profiles;
using Domain;

namespace Application.Features;

public record OrderAllResponse(
int TableId,
decimal Total,
decimal Price,
decimal Tax,
decimal Service,
DateTime CreatedAt,
int UserId,
string OrderName) : IConvertibleFromEntity<Order, OrderAllResponse>
{
    public static OrderAllResponse FromEntity(Order Order) =>
    new OrderAllResponse(
    Order.TableId,
    Order.Total,
    Order.Price,
    Order.Tax,
    Order.Service,
    Order.CreatedAt,
    Order.UserId,
    Order.OrderName);
}
