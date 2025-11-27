using Application.Contracts.Features;

namespace Application.Features;
public record DeleteSpareRequest(int Id, string Password = null) : IRequest<string>;
