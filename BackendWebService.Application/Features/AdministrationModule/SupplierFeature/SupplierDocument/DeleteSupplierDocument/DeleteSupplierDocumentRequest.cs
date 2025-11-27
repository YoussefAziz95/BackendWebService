

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteSupplierDocumentRequest(int Id, string Password = null) : IRequest<string>;
