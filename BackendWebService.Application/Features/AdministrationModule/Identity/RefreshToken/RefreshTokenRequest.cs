using Application.Contracts.Features;

namespace Application.Features;
public record RefreshTokenRequest(string Token) : IRequest<int>;