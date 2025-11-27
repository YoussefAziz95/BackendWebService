using Application.Contracts.Features;

namespace Application.Features;
public record DeleteUserGroupRequest(int Id, string Password = null) : IRequest<string>;
