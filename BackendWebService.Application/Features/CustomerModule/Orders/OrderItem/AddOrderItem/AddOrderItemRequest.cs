using Application.Contracts.Features;
using Application.Profiles;
using Domain;

namespace Application.Features;

public record AddOrderItemRequest(
int OrderId,
int ItemId,
int Quantity,
decimal Total,
DateTime ExpectedTime) : IConvertibleToEntity<OrderItem>, IRequest<int>
{
    public OrderItem ToEntity() => new OrderItem
    {
        OrderId = OrderId,
        ItemId = ItemId,
        Quantity = Quantity,
        Total = Total,
        ExpectedTime = ExpectedTime
    };
}
