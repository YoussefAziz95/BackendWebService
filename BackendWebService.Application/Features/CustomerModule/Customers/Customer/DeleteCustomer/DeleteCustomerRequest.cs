

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteCustomerRequest(int Id, string Password = null) : IRequest<string>;
