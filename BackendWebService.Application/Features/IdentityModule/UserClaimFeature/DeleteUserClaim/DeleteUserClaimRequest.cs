using Application.Contracts.Features;

namespace Application.Features;
public record DeleteUserClaimRequest(int Id, string Password = null) : IRequest<string>;
