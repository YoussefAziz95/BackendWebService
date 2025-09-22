using Application.Contracts.Features;

namespace BackendWebService.Application.Features.CustomerModule.Orders.OrderCQRS.GetUserOrders;
public record GetUserOrdersQuery(int UserId) : IRequest<List<GetUserOrdersQueryResult>>;