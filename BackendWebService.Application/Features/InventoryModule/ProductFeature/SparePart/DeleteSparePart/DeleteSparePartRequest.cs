using Application.Contracts.Features;

namespace Application.Features; 
public record DeleteSparePartRequest(int Id, string Password = null) : IRequest<string>;
