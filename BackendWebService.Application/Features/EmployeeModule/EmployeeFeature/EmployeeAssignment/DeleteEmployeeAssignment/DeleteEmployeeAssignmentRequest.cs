

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteEmployeeAssignmentRequest(int Id, string Password = null) : IRequest<string>;
