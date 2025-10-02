using Application.Contracts.Features;

namespace Application.Features;
public record PhoneNumberRequest(string PhoneNumber) : IRequest<LoginResponse>;