using Application.Contracts.Features;

namespace Application.Features; 
public record DeleteProductRequest(int Id, string Password = null) : IRequest<string>;
