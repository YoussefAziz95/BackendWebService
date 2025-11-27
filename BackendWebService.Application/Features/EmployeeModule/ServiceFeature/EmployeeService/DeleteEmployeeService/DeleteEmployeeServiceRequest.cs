

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteEmployeeServiceRequest(int Id, string Password = null) : IRequest<string>;
