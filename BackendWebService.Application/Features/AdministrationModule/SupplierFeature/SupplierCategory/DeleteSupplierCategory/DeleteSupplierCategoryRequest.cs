

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteSupplierCategoryRequest(int Id, string Password = null) : IRequest<string>;
