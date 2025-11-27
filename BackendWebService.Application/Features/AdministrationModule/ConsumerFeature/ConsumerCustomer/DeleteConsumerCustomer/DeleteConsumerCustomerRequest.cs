using Application.Contracts.Features;

namespace Application.Features;
public record DeleteConsumerCustomerRequest(int Id, string Password = null) : IRequest<string>;
