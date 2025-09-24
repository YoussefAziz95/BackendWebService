using Application.Contracts.Features;

namespace Application.Features;
public record ResetPasswordRequest(string PhoneNumber) : IRequest<LoginResponse>;