

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteEmployeeAccountRequest(int Id, string Password = null) : IRequest<string>;
