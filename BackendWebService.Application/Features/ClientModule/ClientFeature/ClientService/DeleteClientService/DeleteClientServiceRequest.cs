

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteClientServiceRequest(int Id, string Password = null) : IRequest<string>;
