using Application.Contracts.Features;

namespace BackendWebService.Application.Features.CustomerModule.Orders.OrderCQRS.GetAllOrders;
public record GetAllOrdersQuery() : IRequest<List<GetAllOrdersQueryResult>>;