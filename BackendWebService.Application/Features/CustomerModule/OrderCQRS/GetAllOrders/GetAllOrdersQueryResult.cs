namespace Application.Features;
public record GetAllOrdersQueryResult(int OrderId, string OrderName, int OrderOwnerId, string OrderOwnerUserName);