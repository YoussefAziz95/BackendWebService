using Application.Contracts.Features;

namespace Application.Features;
public record DeleteConsumerDocumentRequest(int Id, string Password = null) : IRequest<string>;
