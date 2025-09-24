using Application.Contracts.Features;

namespace Application.Features;
public record DeleteConsumerAccountRequest(int Id, string Password = null) : IRequest<string>;
