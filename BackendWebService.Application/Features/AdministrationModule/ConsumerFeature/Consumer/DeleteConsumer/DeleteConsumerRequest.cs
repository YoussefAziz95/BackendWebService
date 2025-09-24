using Application.Contracts.Features;

namespace Application.Features;
public record DeleteConsumerRequest(int Id, string Password = null) : IRequest<string>;
