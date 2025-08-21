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
List<AddOrderItemRequest> OrderItem
    );
