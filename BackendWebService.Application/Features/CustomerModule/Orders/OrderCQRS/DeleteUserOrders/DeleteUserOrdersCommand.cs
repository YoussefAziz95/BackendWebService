using Application.Contracts.Features;

namespace BackendWebService.Application.Features.CustomerModule.Orders.OrderCQRS.DeleteUserOrders;
public record DeleteUserOrdersCommand(int UserId) : IRequest<bool>;