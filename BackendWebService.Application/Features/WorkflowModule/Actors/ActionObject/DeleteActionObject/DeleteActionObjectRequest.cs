using Application.Contracts.Features;

namespace Application.Features; 
public record DeleteActionObjectRequest(int Id, string Password = null) : IRequest<string>;
