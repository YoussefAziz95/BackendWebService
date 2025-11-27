

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteGoogleConfigRequest(int Id, string Password = null) : IRequest<string>;
