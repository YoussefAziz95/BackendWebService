

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteSupplierRequest(int Id, string Password = null) : IRequest<string>;
