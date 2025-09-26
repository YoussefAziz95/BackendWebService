using Application.Contracts.Features;

namespace Application.Features;
public record DeleteUserTokenRequest(int Id, string Password = null) : IRequest<string>;
