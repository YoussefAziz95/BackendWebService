

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteBranchEmployeeRequest(int Id, string Password = null) : IRequest<string>;
