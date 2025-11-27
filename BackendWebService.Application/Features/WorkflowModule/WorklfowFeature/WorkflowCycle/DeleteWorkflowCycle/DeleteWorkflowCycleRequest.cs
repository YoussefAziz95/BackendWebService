using Application.Contracts.Features;

namespace Application.Features;
public record DeleteWorkflowCycleRequest(int Id, string Password = null) : IRequest<string>;
