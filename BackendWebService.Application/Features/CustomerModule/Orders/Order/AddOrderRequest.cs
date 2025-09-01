using Application.Features;
using Application.Profiles;
using Domain;

namespace Application.Features;
public record AddOrderRequest(
int TableId,
decimal Total,
decimal Price,
decimal Tax,
decimal Service,
DateTime CreatedAt,
int UserId,
string OrderName,
List<AddOrderItemRequest> OrderItem):IConvertibleToEntity<Order>
{
public Order ToEntity() => new Order
{
TableId = TableId,
Total = Total,
Price = Price,
Tax = Tax,
Service = Service,
CreatedAt = CreatedAt,
UserId= UserId,
OrderName = OrderName,
OrderItems= OrderItem.Select(x => x.ToEntity()).ToList()};
}
