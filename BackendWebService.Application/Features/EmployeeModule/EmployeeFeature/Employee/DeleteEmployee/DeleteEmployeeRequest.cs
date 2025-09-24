

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteEmployeeRequest(int Id, string Password = null) : IRequest<string>;
