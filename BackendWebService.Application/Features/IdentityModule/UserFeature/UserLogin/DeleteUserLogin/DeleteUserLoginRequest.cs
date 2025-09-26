using Application.Contracts.Features;

namespace Application.Features;
public record DeleteUserLoginRequest(int Id, string Password = null) : IRequest<string>;
