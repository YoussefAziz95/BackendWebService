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
List<UpdateOrderItemRequest> OrderItem);