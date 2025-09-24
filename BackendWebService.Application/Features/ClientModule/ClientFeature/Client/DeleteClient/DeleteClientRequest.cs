

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteClientRequest(int Id, string Password = null) : IRequest<string>;
