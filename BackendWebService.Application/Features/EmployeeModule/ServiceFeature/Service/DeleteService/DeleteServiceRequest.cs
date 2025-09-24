

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteServiceRequest(int Id, string Password = null) : IRequest<string>;
