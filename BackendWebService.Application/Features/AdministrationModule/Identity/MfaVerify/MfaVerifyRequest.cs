using Application.Contracts.Features;

namespace Application.Features;
public record MfaVerifyRequest(string PhoneNumber, string Code): IRequest<int>;