using Application.Contracts.Features;

namespace Application.Features; 
public record DeletePortionTypeRequest(int Id, string Password = null) : IRequest<string>;
