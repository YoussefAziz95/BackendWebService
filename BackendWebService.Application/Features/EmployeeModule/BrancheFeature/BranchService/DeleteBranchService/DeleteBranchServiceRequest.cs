

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteBranchServiceRequest(int Id, string Password = null) : IRequest<string>;
