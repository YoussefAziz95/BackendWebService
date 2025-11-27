

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteClientAccountRequest(int Id, string Password = null) : IRequest<string>;
