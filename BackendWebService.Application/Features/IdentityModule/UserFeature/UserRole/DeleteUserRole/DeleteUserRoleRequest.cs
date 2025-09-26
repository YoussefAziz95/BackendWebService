using Application.Contracts.Features;

namespace Application.Features;
public record DeleteUserRoleRequest(int Id, string Password = null) : IRequest<string>;
