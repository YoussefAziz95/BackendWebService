using Application.Contracts.Features;

namespace Application.Features;
public record MfaRequest(string PhoneNumber) : IRequest<int>;