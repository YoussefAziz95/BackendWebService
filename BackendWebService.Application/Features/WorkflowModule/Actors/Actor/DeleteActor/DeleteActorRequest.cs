using Application.Contracts.Features;

namespace Application.Features; 
public record DeleteActorRequest(int Id, string Password = null) : IRequest<string>;
