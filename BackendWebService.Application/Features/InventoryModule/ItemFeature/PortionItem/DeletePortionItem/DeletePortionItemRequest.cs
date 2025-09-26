using Application.Contracts.Features;

namespace Application.Features;
public record DeletePortionItemRequest(int Id, string Password = null) : IRequest<string>;
