using Application.Contracts.Features;

namespace Application.Features;
public record LoginPhoneRequest(string PhoneNumber, string Password) : IRequest<LoginResponse>;