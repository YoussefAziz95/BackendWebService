

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteCustomerPaymentMethodRequest(int Id, string Password = null) : IRequest<string>;
