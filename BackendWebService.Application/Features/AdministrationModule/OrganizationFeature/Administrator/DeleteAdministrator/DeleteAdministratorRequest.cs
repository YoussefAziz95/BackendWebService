

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteAdministratorRequest(int Id, string Password = null) : IRequest<string>;
