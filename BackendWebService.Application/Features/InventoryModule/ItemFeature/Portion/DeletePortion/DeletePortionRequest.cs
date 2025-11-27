using Application.Contracts.Features;

namespace Application.Features;
public record DeletePortionRequest(int Id, string Password = null) : IRequest<string>;
