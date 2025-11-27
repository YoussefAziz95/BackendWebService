

using Application.Contracts.Features;

namespace Application.Features;

public record DeletePropertyRequest(int Id, string Password = null) : IRequest<string>;
