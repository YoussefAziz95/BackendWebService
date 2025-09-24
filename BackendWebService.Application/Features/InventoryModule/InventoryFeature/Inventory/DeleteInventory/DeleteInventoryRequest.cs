using Application.Contracts.Features;

namespace Application.Features; 
public record DeleteInventoryRequest(int Id, string Password = null) : IRequest<string>;
