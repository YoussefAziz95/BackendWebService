

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteEmployeeJobRequest(int Id, string Password = null) : IRequest<string>;
