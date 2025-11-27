

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteBranchLocationRequest(int Id, string Password = null) : IRequest<string>;
