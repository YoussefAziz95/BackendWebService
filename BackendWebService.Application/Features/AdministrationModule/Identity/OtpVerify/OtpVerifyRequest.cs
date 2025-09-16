using Application.Contracts.Features;

namespace Application.Features;
public record OtpVerifyRequest(string PhoneNumber, string Code): IRequest<int>;