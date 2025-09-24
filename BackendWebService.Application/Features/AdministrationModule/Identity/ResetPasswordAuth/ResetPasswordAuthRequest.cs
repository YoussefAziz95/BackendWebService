using Application.Contracts.Features;

namespace Application.Features;
public record ResetPasswordAuthRequest(string PhoneNumber, string oldPassword, string newPassword, string confirmNewPassword) : IRequest<int>;