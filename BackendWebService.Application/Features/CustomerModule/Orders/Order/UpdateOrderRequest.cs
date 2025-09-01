using Application.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Org.BouncyCastle.Asn1.X509;

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
List<UpdateOrderItemRequest> OrderItem):IConvertibleToEntity<Order>
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