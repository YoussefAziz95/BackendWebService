

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteBranchRequest(int Id, string Password = null) : IRequest<string>;
