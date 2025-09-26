

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteOrganizationRequest(int Id, string Password = null) : IRequest<string>;
