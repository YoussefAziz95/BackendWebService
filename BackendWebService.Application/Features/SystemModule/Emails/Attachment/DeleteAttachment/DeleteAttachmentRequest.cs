using Application.Contracts.Features;

namespace Application.Features; 
public record DeleteAttachmentRequest(int Id, string Password = null) : IRequest<string>;
