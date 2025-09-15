using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;
namespace Application.Features;
public record UpdateOrderRequest(
int TableId,
decimal Total,
decimal Price,
decimal Tax,
decimal Service,
DateTime CreatedAt,
int UserId,
string OrderName,
List<UpdateOrderItemRequest> OrderItem) : IConvertibleToEntity<Order>, IRequest<int>
{
    public Order ToEntity() => new Order
    {
        TableId = TableId,
        Total = Total,
        Price = Price,
        Tax = Tax,
        Service = Service,
        CreatedAt = CreatedAt,
        UserId = UserId,
        OrderName = OrderName,
        OrderItems = OrderItem.Select(x => x.ToEntity()).ToList()
    };
}