using Application.Contracts.Features;

namespace Application.Features; 
public record DeleteWorkflowRequest(int Id, string Password = null) : IRequest<string>;
