using Application.Contracts.Features;

namespace Application.Features; 
public record DeleteZoneRequest(int Id, string Password = null) : IRequest<string>;
