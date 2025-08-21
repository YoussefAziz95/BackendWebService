namespace Application.Features;
public record OrderAllResponse(
 int TableId,
decimal Total,
decimal Price,
decimal Tax,
decimal Service,
DateTime CreatedAt,
int UserId,
string OrderName
);
