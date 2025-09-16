using Application.Contracts.Features;

namespace Application.Features;
public record LoginEmailRequest(string Email, string Password) : IRequest<int>;