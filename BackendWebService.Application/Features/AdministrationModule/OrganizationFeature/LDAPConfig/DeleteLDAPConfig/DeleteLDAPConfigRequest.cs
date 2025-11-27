

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteLDAPConfigRequest(int Id, string Password = null) : IRequest<string>;
