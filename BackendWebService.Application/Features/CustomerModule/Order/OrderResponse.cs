using Domain.Enums;

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
List<OrderItemResponse> OrderItem
    );