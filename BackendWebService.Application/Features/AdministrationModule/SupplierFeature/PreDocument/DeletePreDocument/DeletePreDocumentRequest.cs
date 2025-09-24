

using Application.Contracts.Features;

namespace Application.Features;

public record DeletePreDocumentRequest(int Id, string Password = null) : IRequest<string>;
