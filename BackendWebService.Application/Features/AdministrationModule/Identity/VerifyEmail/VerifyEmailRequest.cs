using Application.Contracts.Features;

namespace Application.Features;
public record VerifyEmailRequest(string PhoneNumber, string Token) : IRequest<int>;