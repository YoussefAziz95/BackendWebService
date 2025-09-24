

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteDealDocumentRequest(int Id, string Password = null) : IRequest<string>;
