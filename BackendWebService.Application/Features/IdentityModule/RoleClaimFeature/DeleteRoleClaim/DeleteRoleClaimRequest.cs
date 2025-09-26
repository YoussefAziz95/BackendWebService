using Application.Contracts.Features;

namespace Application.Features;
public record DeleteRoleClaimRequest(int Id, string Password = null) : IRequest<string>;
