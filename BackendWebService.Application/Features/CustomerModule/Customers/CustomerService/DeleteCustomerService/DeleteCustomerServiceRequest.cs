using Application.Contracts.Features;

namespace Application.Features;

public record DeleteCustomerServiceRequest(int Id, string Password = null) : IRequest<string>;
