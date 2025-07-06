using Application.Contracts.Features;

namespace Application.Features;
public record DeleteUserOrdersCommand(int UserId) : IRequest<bool>;