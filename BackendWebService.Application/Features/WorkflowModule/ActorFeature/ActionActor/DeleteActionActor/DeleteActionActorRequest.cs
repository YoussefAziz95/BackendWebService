using Application.Contracts.Features;

namespace Application.Features;
public record DeleteActionActorRequest(int Id, string Password = null) : IRequest<string>;
