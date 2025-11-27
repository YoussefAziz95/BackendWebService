using Application.Contracts.Features;

namespace Application.Features;
public record LoginAuthenticatorRequest(
    string ClientId,
    string AccessToken) : IRequest<int>;