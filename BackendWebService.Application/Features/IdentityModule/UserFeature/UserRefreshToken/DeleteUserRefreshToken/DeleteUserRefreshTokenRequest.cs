using Application.Contracts.Features;

namespace Application.Features;
public record DeleteUserRefreshTokenRequest(int Id, string Password = null) : IRequest<string>;
