using Application.Contracts.Features;

namespace Application.Features;
public record DeleteUserRequest(int Id, string Password = null) : IRequest<string>;
