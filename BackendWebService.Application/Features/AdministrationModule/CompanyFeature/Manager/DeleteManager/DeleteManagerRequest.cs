using Application.Contracts.Features;

namespace Application.Features;
public record DeleteManagerRequest(int Id, string Password = null) : IRequest<string>;
