using Application.Contracts.Features;

namespace Application.Features; 
public record DeleteCaseRequest(int Id, string Password = null) : IRequest<string>;
