

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteSupplierAccountRequest(int Id, string Password = null) : IRequest<string>;
