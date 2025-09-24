using Application.Contracts.Features;

namespace Application.Features; 
public record DeleteRecipientRequest(int Id, string Password = null) : IRequest<string>;
