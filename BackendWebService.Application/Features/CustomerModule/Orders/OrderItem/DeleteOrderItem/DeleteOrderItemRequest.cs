

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteOrderItemRequest(int Id, string Password = null) : IRequest<string>;
